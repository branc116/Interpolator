using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;

namespace Interpolator
{
    public partial class tocka : UserControl
    {
        OleDbConnection conn;
        string dbpath;

        public delegate void OnUpdate(int globalid, int localid);
        public event OnUpdate Update1;

        public tocka()
        {
            InitializeComponent();
            dbpath = Application.StartupPath + global::Interpolator.Properties.Resources.NameOfDbString;
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
        }
        public Panel make_new_point(int id_tab,int id_toc,int global_tab,int global_toc,string x,string y,bool saw)
        {

            this.Controls[0].SendToBack();
            this.Controls[0].Name = id_toc.ToString();
            this.Controls[0].TabIndex = global_toc+1;
            this.Controls[0].TabStop = false;
            int tab = id_tab + 256 * global_tab;
            int toc = id_toc + 256 * global_toc;
            this.Controls[0].AccessibleDescription = tab.ToString();
            this.Controls[0].AccessibleName = toc.ToString();
            this.Controls[0].Controls["y_tocke"].Text = y;
            this.Controls[0].Controls["x_tocke"].Text = x;
            this.Controls[0].Controls["id_tocke"].Text = (id_toc+1).ToString();
            for (int i = 0; i < this.Controls[0].Controls.Count; i++)
            {
                this.Controls[0].Controls[i].AccessibleDescription = tab.ToString();
                this.Controls[0].Controls[i].AccessibleName = toc.ToString();
                this.Controls[0].Controls[i].Tag = new int[] { id_tab, id_toc, global_tab, global_toc };
            }
            ((CheckBox)(this.Controls[0].Controls["show_tocke"])).Checked = saw;
            this.Controls[0].Controls["y_tocke"].Name += global_toc;
            this.Controls[0].Controls["x_tocke"].Name += global_toc;
            this.Controls[0].Controls["id_tocke"].Name += global_toc;
            this.Controls[0].Controls["show_tocke"].Name += global_toc;
            this.Controls[0].Controls["dlt_tocke"].Name += global_toc;
            return (Panel)this.Controls[0];
        }
        protected void CallUpdate1(int g,int l)
        {
            OnUpdate handle = Update1;
            if (handle != null)
            {
                handle(g, l);
            }
        }
        protected void OnClickCoordinates(object sender, EventArgs e)
        {
            TextBox temp = new TextBox();
            temp.Name = "temp";
            temp.Location = ((Label)sender).Location;
            temp.Text = ((Label)sender).Text;
            temp.Font = ((Label)sender).Font;
            temp.Size = ((Label)sender).Size;
            temp.Font = SystemFonts.DefaultFont;
            temp.Tag = ((Label)sender).Tag;
            temp.AccessibleName = ((Label)sender).Name;
            temp.TextAlign = HorizontalAlignment.Center;
            temp.Leave += Temp_Leave;
            temp.KeyPress += OnKeyPressTemp;
            temp.TextChanged += Temp_TextChanged;
            ((Label)sender).Visible = false;
            
            ((Label)sender).Parent.Controls.Add(temp);
            temp.SelectAll();
            temp.Focus();
        }

        private void Temp_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).SuspendLayout();
            ((TextBox)sender).Size =(Graphics.FromImage(new Bitmap(1,1))).MeasureString(((TextBox)sender).Text, ((TextBox)sender).Font).ToSize();
            ((TextBox)sender).Size = new Size(((TextBox)sender).Size.Width + 10, ((TextBox)sender).Size.Height);
            ((TextBox)sender).ResumeLayout();
        }

        private void OnKeyPressTemp(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                ((TextBox)sender).Parent.Focus();
                Panel_tocke.Focus();
            }
            
        }

        private void Temp_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Controls[(string)((TextBox)sender).AccessibleName].Visible = true;
            ((TextBox)sender).Parent.Controls[(string)((TextBox)sender).AccessibleName].Text = ((TextBox)sender).Text;
            int[] tg = (int[])((TextBox)sender).Tag;
            string num = (string)((TextBox)sender).AccessibleName.Substring(7);
            string NewX = ((TextBox)sender).Parent.Controls["x_tocke"+num].Text;
            string NewY = ((TextBox)sender).Parent.Controls["y_tocke"+num].Text;
            string comm = "UPDATE tocke" + tg[2].ToString() + " SET point_x=" + NewX + ", point_y=" + NewY + " WHERE id=" + tg[3].ToString() + ';';
            conn.Open();
            new OleDbCommand(comm, conn).ExecuteNonQuery();
            conn.Close();
            CallUpdate1(tg[2], tg[0]);
            ((TextBox)sender).Dispose();
        }
        private void OnClickShow(object sender, EventArgs e)
        {
            CheckBox c = ((CheckBox)sender);
            int[] tg = (int[])c.Tag;
            string s="-1";
            if (!c.Checked) s = "0";
            string comm = "UPDATE tocke" + tg[2].ToString() + " SET sh=" + s + " WHERE id=" + tg[3].ToString() + ';';
            conn.Open();
            new OleDbCommand(comm, conn).ExecuteNonQuery();
            conn.Close();
            CallUpdate1(tg[2], tg[0]);
        }
        Button bb;
        Object send;
        private void OnClickDlt(object sender, EventArgs e)
        {
            bb = ((Button)sender);
            send = sender;
            new Thread(new ThreadStart(ThreadDlt)).Start();
        }
        protected void ThreadDlt()
        {
            CheckForIllegalCrossThreadCalls = false;
            Button b = bb;
            Object sender = send;
            int[] tg = (int[])b.Tag;
            string comm = "DELETE FROM tocke" + tg[2].ToString() + " WHERE id=" + tg[3].ToString() + ';';
            conn.Open();
            new OleDbCommand(comm, conn).ExecuteNonQuery();
            conn.Close();
            CallUpdate1(tg[2], tg[0]);
            TableLayoutPanel t = (TableLayoutPanel)b.Parent;
            t.Visible = false;
            int id = 0;
            for (int i = 1; i < t.RowCount; i++)
            {
                if (t.GetControlFromPosition(4, i) == (Control)sender)
                {
                    id = i;
                    for (int j = 0; j <= 4; j++) t.GetControlFromPosition(j, i).Dispose();
                    break;
                }
            }

            for (int i = id; i < (t.RowCount - 1); i++)
            {
                t.GetControlFromPosition(0, i + 1).Text = (Convert.ToInt32(t.GetControlFromPosition(0, i + 1).Text) - 1).ToString();
                for (int j = 0; j <= 4; j++)
                {
                    t.Controls.Add(t.GetControlFromPosition(j, i + 1), j, i);
                    //t.GetControlFromPosition(j, i + 1).Dispose();
                }
            }
            t.RowCount--;
            t.Visible = true;
        }

    }
}
