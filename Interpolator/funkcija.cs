using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;
using System.Threading;

namespace Interpolator
{
    public partial class funkcija : UserControl
    {
        #region Properties
        bool Debug = global::Interpolator.Properties.Settings.Default.DebugMode;
        bool Inside;
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet medataset;

        public string selekt = "SELECT * FROM postavke";
        string dbpath;

        string[] Mods = new string[2] { "Pol", "Sin" };

        public delegate void OnUpdate(int globalid, int localid);
        public event OnUpdate Update2;

        Point org, eLocation;
        Panel temp;
        Thread TranslateThread;
        Thread ScaleThread;
        #endregion
        #region public
        public funkcija()
        {
            InitializeComponent();
            dbpath = Application.StartupPath + global::Interpolator.Properties.Resources.NameOfDbString;
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
            conn.Open();
            OleDbCommand cmd1 = new OleDbCommand(selekt, conn);
            adapter = new OleDbDataAdapter(cmd1);
            medataset = new DataSet();
            adapter.Fill(medataset);
            conn.Close();
        }
        public Panel make_new_func(int idd,int global_idd)
        {
            Panel temp = (Panel)this.Controls[0];
            int elements = temp.Controls.Count;
            temp.Name = idd.ToString();
            ((ToolStrip)this.Controls[0].Controls["Naslov"]).Items[0].Text = "Funkcije #" + idd.ToString();
            for (int i = 0; i < elements; i++)
            { 
                temp.Controls[i].Tag = new int[]{idd, global_idd };
                temp.Controls[i].AccessibleDescription = idd.ToString();
                temp.Controls[i].AccessibleName = global_idd.ToString();
            }
            ToolStrip temps = (ToolStrip)temp.Controls["Properties"];
            int elementss = temps.Items.Count;
            ToolStripItemCollection tempc = temps.Items;
            for (int i = 0; i < elementss; i++)
            {
                temp.Controls[i].Tag = new int[] { idd, global_idd };
                temps.Items[i].AccessibleDescription = idd.ToString();
                temps.Items[i].AccessibleName = global_idd.ToString();
            }
            temps = (ToolStrip)temp.Controls["Naslov"];
            elementss = temps.Items.Count;
            for (int i = 0; i < elementss; i++)
            {
                temp.Controls[i].Tag = new int[] { idd, global_idd };
                temps.Items[i].AccessibleDescription = idd.ToString();
                temps.Items[i].AccessibleName = global_idd.ToString();
            }
            temps = (ToolStrip)temp.Controls["Izgled"];
            elementss = temps.Items.Count;
            for (int i = 0; i < elementss; i++)
            {
                temp.Controls[i].Tag = new int[] { idd, global_idd };
                temps.Items[i].AccessibleDescription = idd.ToString();
                temps.Items[i].AccessibleName = global_idd.ToString();
            }
            OleDbDataAdapter tempad = new OleDbDataAdapter("SELECT * FROM postavke WHERE id="+ global_idd, conn);
            DataSet temp_ds = new DataSet();
            tempad.Fill(temp_ds);
            if (temp_ds.Tables[0].Rows.Count == 0)
            {
                OleDbCommand insrt = new OleDbCommand("INSERT INTO postavke (boja, mode, pokazi, ime, func) VALUES ('" + System.Drawing.Color.Black.ToArgb() + "', 1, -1, 'Funkcija #', 'F(X)=NULL');", conn);
                OleDbCommand create = new OleDbCommand("CREATE TABLE tocke" + global_idd + " (id COUNTER PRIMARY KEY, point_x FLOAT, point_y FLOAT, sh BIT);", conn);
                colorDialog1.Color = System.Drawing.Color.Black;
                Color.BackColor = colorDialog1.Color;

                conn.Open();
                insrt.ExecuteNonQuery();
                create.ExecuteNonQuery();
                conn.Close();
            }
            else {
                Color.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(temp_ds.Tables[0].Rows[0][3]));
                mode.Text = Mods[Convert.ToInt32(temp_ds.Tables[0].Rows[0][2])];
                Name_of_func.Text = temp_ds.Tables[0].Rows[0][5].ToString();

                tempad = new OleDbDataAdapter("SELECT * FROM tocke" + global_idd, conn);
                temp_ds = new DataSet();                
                tempad.Fill(temp_ds);
                for (int i = 0; i < temp_ds.Tables[0].Rows.Count; i++)
                {
                    DodajTocku(i, idd, Convert.ToInt32(temp_ds.Tables[0].Rows[i][0]) , global_idd, temp_ds.Tables[0].Rows[i][1].ToString(), temp_ds.Tables[0].Rows[i][2].ToString(), !Convert.ToBoolean(temp_ds.Tables[0].Rows[i][3]),false);                    
                }
                CallUpdate2(global_idd, idd);
            }
            temp.Location = new Point(10, 60);
            return temp;
        }
        #endregion
        #region protected
        protected void DodajTocku(int Id,int Tab,int GlobalId,int GlobalTab, string x, string y, bool show, bool unos)
        {
            tocka t = new tocka();
            Panel p = t.make_new_point(Tab, Id, GlobalTab, GlobalId, x, y, !show);            
            this.MyTable.RowCount++;
            this.MyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.MyTable.Controls.Add(p.Controls["id_tocke" + GlobalId],0, this.MyTable.RowCount-1);
            this.MyTable.Controls.Add(p.Controls["x_tocke" + GlobalId], 1, this.MyTable.RowCount-1);
            this.MyTable.Controls.Add(p.Controls["y_tocke" + GlobalId], 2, this.MyTable.RowCount-1);
            this.MyTable.Controls.Add(p.Controls["show_tocke" + GlobalId], 3, this.MyTable.RowCount-1);
            this.MyTable.Controls.Add(p.Controls["dlt_tocke" + GlobalId], 4, this.MyTable.RowCount-1);
            //Input_x.Parent.Controls["points"].Controls.Add(p);
            //p.BringToFront();
            if (unos)
            {
                string comm = "INSERT INTO tocke" + GlobalTab.ToString() + " (point_x, point_y, sh) VALUES (" + x.ToString() + ',' + y.ToString() + ',' + (!show).ToString() + ");";
                conn.Open();
                new OleDbCommand(comm, conn).ExecuteNonQuery();
                conn.Close();
                CallUpdate2(GlobalTab, Tab);
            }
            t.Update1 += OnUpdate1;
        }
        int GId;
        int LId;
        protected void CallUpdate2(int GlobalId, int LocalId)
        {
            GId = GlobalId;
            LId = LocalId;
            new Thread(new ThreadStart(UpIt)).Start();
        }
        protected void UpIt()
        {
            CheckForIllegalCrossThreadCalls = false;
            OnUpdate handle = Update2;
            if (handle != null)
            {
                handle(GId, LId);
            }
        }
        protected void Translate()
        {
            CheckForIllegalCrossThreadCalls = false;
            String presset = OpenTK.Input.Mouse.GetState().LeftButton.ToString();
            while (presset == "Pressed")
            {

                presset = OpenTK.Input.Mouse.GetState().LeftButton.ToString();
                temp.Location = new Point((int)(eLocation.X + 1.4 * (OpenTK.Input.Mouse.GetState().X - org.X)), (int)(eLocation.Y + 1.4 * (OpenTK.Input.Mouse.GetState().Y - org.Y)));
            }

        }
        protected void Scale()
        {
            CheckForIllegalCrossThreadCalls = false;
            temp.Dock = DockStyle.None;
            while (Inside)
            {
                if (temp.Size.Width != eLocation.X && temp.Size.Height != eLocation.Y)
                {
                    MyTable.Visible = false;
                    temp.Size = new Size(eLocation.X, eLocation.Y);
                    MyTable.Visible = true;
                }
            }
        }
        #endregion
        #region private
        private void OnMouseDownMove(object sender, MouseEventArgs e)
        {

            temp = (Panel)((ToolStrip)sender).Parent;
            temp.Dock = DockStyle.None;
            temp.BringToFront();

            eLocation = temp.Location;

            if (TranslateThread == null)
            {
                org = new Point(OpenTK.Input.Mouse.GetState().X, OpenTK.Input.Mouse.GetState().Y);
                TranslateThread = new Thread(new ThreadStart(this.Translate));
                TranslateThread.Name = e.Location.ToString();
                TranslateThread.Start();
            }
        }
        private void OnMouseUpMove(object sender, MouseEventArgs e)
        {
            TranslateThread = null;
        }
        private void OnUpdate1(int globalid, int localid)
        {
            CallUpdate2(globalid, localid);
        }
        private void OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                Double d = Convert.ToDouble(((TextBox)sender).Text.ToString(CultureInfo.CurrentCulture));
                String dd = ((TextBox)sender).Parent.Controls["Input_x"].Text.ToString();
                string selec = "SELECT * FROM tocke" + ((int[])((TextBox)sender).Tag)[1].ToString(CultureInfo.CurrentCulture) + " WHERE point_x= " + dd + ";";                
                OleDbDataAdapter ad = new OleDbDataAdapter(selec,conn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) throw new Exception("Isti X");
                ErrorBox.Visible = false;
                
            }
            catch(Exception ee)
            {

                ErrorBox.Visible = true;
                
            }
        }
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                dodaj_button.PerformClick();
            }
        }
        private void OnClickDodaj(object sender, EventArgs e)
        {
            try {
                if (ErrorBox.Visible) throw new Exception("ErrorBox is Visible");
                double x = Convert.ToDouble(Input_x.Text.ToString(CultureInfo.GetCultureInfo("hr-HR")));
                double y = Convert.ToDouble(Input_y.Text.ToString(CultureInfo.GetCultureInfo("hr-HR")));
                int[] tg = (int[])Input_x.Tag;
                int GlobalIdToc = 1;
                if (Input_x.Parent.Controls["points"].Controls[0].Controls.Count > 5) {
                    GlobalIdToc =((int[])Input_x.Parent.Controls["points"].Controls[0].Controls[Input_x.Parent.Controls["points"].Controls[0].Controls.Count-1].Tag)[3] + 1;
                }
                DodajTocku(this.MyTable.RowCount-1, ((int[])Input_x.Tag)[0], GlobalIdToc, ((int[])Input_x.Tag)[1], x.ToString(CultureInfo.GetCultureInfo("hr-HR")), y.ToString(CultureInfo.GetCultureInfo("hr-HR")), false,true);
                ErrorBox.Visible = false;
            }
            catch(Exception ee)
            {
                ErrorBox.Visible = true;
                try {
                    conn.Close();
                }
                catch { }
               if (Debug) MessageBox.Show(ee.ToString());
            }
        }
        private void OnClickClose(object sender, EventArgs e)
        {
            int[] tg = (int[])((ToolStripButton)sender).GetCurrentParent().Tag;
            
            conn.Open();
            new OleDbCommand("DELETE FROM postavke WHERE id =" + tg[1] + ';', conn).ExecuteNonQuery();
            new OleDbCommand("DROP TABLE tocke" + tg[1] + ';', conn).ExecuteNonQuery();
            conn.Close();
            ((ToolStripButton)sender).GetCurrentParent().Parent.Dispose();
        }
        private void OnClickMaximise(object sender, EventArgs e)
        {
            if (((ToolStripButton)sender).AccessibleName == "max")
            {
                ((ToolStripButton)sender).AccessibleName = "min";
                Panel p = (Panel)((ToolStripButton)sender).GetCurrentParent().Parent;
                p.Dock = DockStyle.Fill;
                p.BringToFront();
            }
            else
            {
                ((ToolStripButton)sender).AccessibleName = "max";
                Panel p = (Panel)((ToolStripButton)sender).GetCurrentParent().Parent;
                p.Dock = DockStyle.None;
            }
        }
        private void OnClickMinimise(object sender, EventArgs e)
        {
            ((ToolStripButton)sender).GetCurrentParent().Parent.Visible = false;
        }
        private void OnClickPaint(object sender, EventArgs e)
        {            
            colorDialog1.ShowDialog();
            string comm = "UPDATE postavke SET boja = " + colorDialog1.Color.ToArgb().ToString() + " WHERE id = " + ((int[])(((ToolStripButton)sender).GetCurrentParent().Tag))[1] + ";";
            ((ToolStripButton)sender).BackColor = colorDialog1.Color;
            if (colorDialog1.Color.IsKnownColor)
                ((ToolStripButton)sender).ToolTipText = colorDialog1.Color.ToKnownColor().ToString();
            else
                ((ToolStripButton)sender).ToolTipText = colorDialog1.Color.ToString();
            OleDbCommand oc = new OleDbCommand(comm, conn);
            CallUpdate2(((int[])(((ToolStripButton)sender).GetCurrentParent().Tag))[1], ((int[])(((ToolStripButton)sender).GetCurrentParent().Tag))[0]);
            conn.Open();
            oc.ExecuteNonQuery();
            conn.Close();
        }
        private void OnClickCngMode(object sender, EventArgs e)
        {
            String cur = ((ToolStripButton)sender).Text;
            int NewMode = 0;
            if (cur != "Sin")
            {
                NewMode = 1;
            }
            ((ToolStripButton)sender).Text = Mods[NewMode];
            string comm = "UPDATE postavke SET mode = " + NewMode + " WHERE id = " + ((int[])(((ToolStripButton)sender).GetCurrentParent().Tag))[1] + ";";
            OleDbCommand oc = new OleDbCommand(comm, conn);
            conn.Open();
            oc.ExecuteNonQuery();
            conn.Close();
            CallUpdate2(((int[])(((ToolStripButton)sender).GetCurrentParent().Tag))[1], ((int[])(((ToolStripButton)sender).GetCurrentParent().Tag))[0]);
        }
        private void OnCopyToClipboard(object sender, EventArgs e)
        {
            ToolStrip t = ((ToolStrip)(((ToolStripButton)sender).GetCurrentParent()));
            Panel p = (Panel)t.Parent;
            Label l = (Label)p.Controls["func_label"];
            Clipboard.SetText(l.Text);
        }
        private void OnMouseMoveScale(object sender, MouseEventArgs e)
        {
            temp = (Panel)sender;
            if (temp.Size.Width-20<e.X && temp.Size.Height - 20 < e.Y || Inside)
            {
                temp.Cursor = Cursors.SizeNWSE;
                if (e.Button.ToString() == "Left")
                {
                    if (ScaleThread == null)
                    {
                        org = e.Location;
                        ScaleThread = new Thread(new ThreadStart(Scale));
                        Inside = true;
                        ScaleThread.Start();
                    }
                    eLocation = e.Location;
                }
                else
                {
                    Inside = false;
                    
                    ScaleThread = null;
                }
            }
            else
            {
                ScaleThread = null;
                Inside = false;
                temp.Cursor = Cursors.Default;
            }


        }
        private void OnClickFuncName(object sender, EventArgs e)
        {
            ToolStripTextBox tstb = new ToolStripTextBox();
            ToolStripButton tsb = ((ToolStripButton)sender);
            ToolStrip ts = ((ToolStripButton)sender).GetCurrentParent();
            tsb.Visible = false;          
            tstb.Text = tsb.Text;
            tstb.AutoSize = true;
            tstb.Name = "tstb";
            tstb.KeyPress += Tstb_KeyPress;
            tstb.LostFocus += Tstb_LostFocus;
            ts.Items.Add(tstb);
            tstb.Focus();
        }
        private void Tstb_LostFocus(object sender, EventArgs e)
        {
            Name_of_func.Text = ((ToolStripTextBox)sender).Text;
            ((ToolStripTextBox)sender).Dispose();
            Name_of_func.Visible = true;

            string str = "UPDATE postavke SET ime = '" + Name_of_func.Text + "' WHERE id =" + ((int[])(Naslov.Tag))[1] + ";";
            OleDbCommand comm = new OleDbCommand(str, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        private void Tstb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                ((ToolStripTextBox)sender).GetCurrentParent().Focus();

        }
        private void OnClickTakeFocus(object sender, EventArgs e)
        {
            ((Control)sender).Focus();
        }
        #endregion
    }
}
