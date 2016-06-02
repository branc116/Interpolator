using System;
using System.IO;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using ADOX;
namespace Interpolator
{
    
    public struct tocke
    {
        public double x, y;
        public bool sh;

        public void napravi(double valu_x, double valu_y, bool valu_sh)
        {
            x = valu_x;
            y = valu_y;
            sh = valu_sh;
        }
    };
    public partial class Form1 : Form
    {
        #region varijable
        public int cur = 0;
        public string x_temp, y_temp;
        public Label xx, yy, id;
        public Button dlt;
        public CheckBox sh;
        delegate void poli();
        public string expontent = "⁰¹²³⁴⁵⁶⁷⁸⁹⁺⁻⁼⁽⁾";
        public string dbpath;
        public double x, y;
        public string selekt = "SELECT * FROM postavke";
        int br_tablica = 0, rl_br_tablica = 0;
        int funkcija = 0, number_of_controls_without_funcs;
        Point local_poz = new Point();
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet medataset;
        prikaz_tocki graf;
        Thread th;
        string cur_open_file;
        Postavke p;
        bool Debug = global::Interpolator.Properties.Settings.Default.DebugMode;
        #endregion
        #region init
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            p = new Postavke();
            p.Show();
            p.Hide();
            graf = new prikaz_tocki(p);
            th = new Thread(graf.poc);
            //var obj = new WindowsFormsApplication1.SimpleWindow();

            //new Thread(obj.poc).Start();            
            InitializeComponent();
            number_of_controls_without_funcs = this.Controls.Count;
            dbpath = Application.StartupPath + global::Interpolator.Properties.Resources.NameOfDbString;
            if (!File.Exists(dbpath))
            {
                ADOX.Catalog cat = new ADOX.Catalog();
                try
                {
                    cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
                }
                catch (Exception e)
                {
                    if (Debug) MessageBox.Show(e.ToString());
                }

                cat = null;
            }
            else
            {
                ADOX.Catalog cat = new ADOX.Catalog();
                System.IO.File.Delete(dbpath);
                cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
            }
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
            
            //adapter.Fill(medataset);
            try
            {
                using (OleDbCommand cmd = new OleDbCommand(global::Interpolator.Properties.Resources.PropertiesCreateString , conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ee) { if (Debug) MessageBox.Show("Error: " + ee.ToString()); }
            medataset = new DataSet();
            OleDbCommand cmd1 = new OleDbCommand(selekt, conn);
            adapter = new OleDbDataAdapter(cmd1);
            adapter.Fill(medataset);
            
            updatezy();
        }
        #endregion
        #region forma logika

        private void otvori_postavke(object sender, EventArgs e)
        {
            p.ShowPanel();
        }
        private void spremi_datoteku(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Name != "Spremi" || cur_open_file=="")
            {
                Save.ShowDialog();
            }
            cur_open_file = Save.FileName+ ".tocke";
            File.Copy(dbpath, cur_open_file, true);

        }
        private void napravi_novu_datoteku(object sender, EventArgs e)
        {
            Save.ShowDialog();
            cur_open_file = Save.FileName + ".tocke";
            this.Text = cur_open_file;
            try {
                ADOX.Catalog cat = new ADOX.Catalog();
                cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
                cat = null;
                System.IO.File.Copy(dbpath, cur_open_file, true);
            }
            catch(Exception ee)
            {
                if (ee.ToString() != "1")
                {
                    if (Debug) MessageBox.Show("Spremi staru datoteku");
                    spremiKaoToolStripMenuItem.PerformClick();
                    File.Delete(dbpath);

                    ADOX.Catalog cat = new ADOX.Catalog();
                    cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
                    cat = null;
                    System.IO.File.Copy(dbpath, cur_open_file, true);
                }

            }
            Osvjezi.PerformClick();
        }
        private void otvori_dat(object sender, EventArgs e)
        {
            if (sender.ToString() == "Otvori")
            {
                Open.ShowDialog();
                cur_open_file = Open.FileName;
                System.IO.File.Copy(cur_open_file, dbpath, true);
                this.Text = cur_open_file;
            }
            //MessageBox.Show(Open.FileName + "\n\n" + Application.StartupPath);

            if (!File.Exists(dbpath))
            {
                ADOX.Catalog cat = new ADOX.Catalog();

                cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
                cat = null;
            }
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
            
            //adapter.Fill(medataset);
            try
            {
                using (OleDbCommand cmd = new OleDbCommand(global::Interpolator.Properties.Resources.PropertiesCreateString, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ee) { if(Debug) MessageBox.Show("Error: " + ee.ToString()); }
            medataset = new DataSet();
            OleDbCommand cmd1 = new OleDbCommand(selekt, conn);
            adapter = new OleDbDataAdapter(cmd1);
            adapter.Fill(medataset);
            
            for (int i=0;i<this.Controls.Count;i++){
                if (this.Controls[i].GetType().ToString()== "System.Windows.Forms.Panel" && this.Controls[i].Name != "SkupFunkcija")
                {
                    this.Controls[i].Dispose();
                    i--;
                }
            }
            br_tablica = 0;
            updatezy();
        }

        private void OnClickAbout(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void OnClickPomoc(object sender, EventArgs e)
        {
            
            File.WriteAllBytes(Application.StartupPath + "\\help.pdf", global::Interpolator.Properties.Resources.Dokumentacija);

            System.Diagnostics.Process.Start((Application.StartupPath + "\\help.pdf"));
        }



        private void exit(object sender, EventArgs e)
        {
            Dispose(true);
        }
        private void dodajbut(object sender, EventArgs e)
        {
            int next_id = 1;
            if (medataset.Tables[0].Rows.Count > 0)
            {
                next_id = Convert.ToInt32(medataset.Tables[0].Rows[medataset.Tables[0].Rows.Count - 1][0]) + 1;
            }
            
            funkcija f= new funkcija();
            Panel temp_panel = f.make_new_func(rl_br_tablica, next_id);
            f.Update2 += A_Update1;            
            this.Controls.Add(temp_panel);
            this.Controls[rl_br_tablica.ToString()].SendToBack();
            
            adapter.Fill(medataset);
            br_tablica++;
            rl_br_tablica++;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!th.IsAlive)
            {
                graf = new prikaz_tocki(p);
                th = new Thread(graf.poc);
                th.Start();
            }
        }
        private void A_Update1(int globalid, int localid)
        {
            izracunaj_polinom(localid, globalid);
        }

        #endregion
        #region metode
        public void izracunaj_polinom(int izrac_tab_local, int izrac_tab_global)
        {
            
            #region init_matrice
            
            if (th.IsAlive && th.Priority < ThreadPriority.AboveNormal)
            {
                graf.e_treba = true;
                th.Priority = ThreadPriority.AboveNormal;
            }
            OleDbDataAdapter tempad = new OleDbDataAdapter("SELECT * FROM postavke WHERE id = " + izrac_tab_global.ToString(), conn);
            DataSet temp_ds = new DataSet();
            tempad.Fill(temp_ds);
            int modeer = Convert.ToInt32(temp_ds.Tables[0].Rows[0][2]);
            //OleDbDataAdapter tempad = new OleDbDataAdapter("SELECT * FROM tocke" + Convert.ToInt32(medataset.Tables[0].Rows[izrac_tab][1]), conn);
            tempad = new OleDbDataAdapter("SELECT * FROM tocke" + izrac_tab_global.ToString(), conn);
            temp_ds = new DataSet();
            tempad.Fill(temp_ds);

            int n = 0;
            tocke[] temp = new tocke[100];
            for (int i = 0; i < temp_ds.Tables[0].Rows.Count; i++)
            {
                bool b = Convert.ToBoolean(temp_ds.Tables[0].Rows[i][3]);
                if (b == true)
                {
                    temp[n].x = Convert.ToDouble(temp_ds.Tables[0].Rows[i][1], CultureInfo.GetCultureInfo("hr-HR"));
                    temp[n].y = Convert.ToDouble(temp_ds.Tables[0].Rows[i][2], CultureInfo.GetCultureInfo("hr-HR"));
                    n++;
                }
            }
            #endregion
            mematka nekaj = new mematka();
            tocke[] nekakve = nekaj.izrac_func(temp, modeer, n);

            Label temp_lb = (Label)this.Controls[izrac_tab_local.ToString()].Controls[2];
            temp_lb.Text = nekaj.string_func(nekakve, modeer, p);
            OleDbCommand up = new OleDbCommand("UPDATE postavke SET func = '" + temp_lb.Text + "' WHERE id = " + izrac_tab_global + ";",conn);
            try {
                conn.Open();
            }catch(Exception ee){
                if (Debug) MessageBox.Show(ee.ToString());
            }
            try {
                up.ExecuteNonQuery();
            }
            catch(Exception ee)
            {
                if (Debug) MessageBox.Show(ee.ToString());
            }
            try { 
            conn.Close();
            }catch(Exception ee){
                if (Debug) MessageBox.Show(ee.ToString());
            }
}
        void updatezy()
        {

            for (int i = 0; i < medataset.Tables[0].Rows.Count; i++)
            {
                funkcija f = new funkcija();
                Panel temp_panel = (Panel)f.make_new_func(i+1, Convert.ToInt32(medataset.Tables[0].Rows[i][0]));
                f.Update2 += A_Update1;
                this.Controls.Add(temp_panel);
                br_tablica++;
            }
            rl_br_tablica = br_tablica;
        }
        #endregion
    }
    public class prikaz_tocki : GameWindow
    {
        Postavke PostavkeGrafike;
        public void poc()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Thread.Sleep(1000);
            using (prikaz_tocki kordinatni = new prikaz_tocki(PostavkeGrafike))
            {
                // Get the title and category  of this example using reflection.

                kordinatni.Title = "Prikaz Funkcija";
                kordinatni.Icon = global::Interpolator.Properties.Resources.MainIcon;
                kordinatni.Run(1.0, 120.0);
            }
        }

        public prikaz_tocki(Postavke p) : base(400, 300, new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8)) {
            MouseMove += Prikaz_tocki_MouseMove;
            KeyDown += Keyboard_KeyDown;
            PostavkeGrafike = p; }
        #region varijable
        struct trans
        {
            public float x, y, zoom;
            public trans(float a, float b, float c)
            {
                x = a;
                y = b;
                zoom = c;
            }

        };
        struct tockeikrivulje
        {
            public Vector2[] zadanetocke;
            public Double[] kaeficjent_xa_na_itu;
            public Vector2[] tockekrivulje;
            public Color boja_tocke;
            public double MinDif;
            public int br_tocki;
            public int mode;

        };
        bool u_grafu;
        bool up_graf;
        bool Debug = global::Interpolator.Properties.Settings.Default.DebugMode;
        public bool e_treba;
        bool mise;
        bool unutra;

        int rez = 900;
        int br_tab = 0;
        int x_old;
        int y_old;
        int last_scroll_status;

        long lenght_old;

        float aspect;
        float fov;

        Vector3 poz_eye;
        Vector3 poz_look_at;

        string dbpath;

        tockeikrivulje[] pol = new tockeikrivulje[100];    
            
        trans t = new trans(0.5f, 0, 3);
        
        OleDbConnection conn;

        public event EventHandler db_update;
        
        #endregion

        #region GL_logika
        private void Prikaz_tocki_MouseMove(object sender, MouseMoveEventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetState();
            int j = mouse.Wheel;

            int xd, yd;
            if (mouse[MouseButton.Left])
            {
                if (!mise)
                {
                    x_old = mouse.X;
                    y_old = mouse.Y;
                }
                mise = true;
                xd = mouse.X - x_old;
                yd = mouse.Y - y_old;
                poz_eye.X = poz_look_at.X = poz_eye.X - xd * poz_eye.Z * 0.004f;
                poz_eye.Y = poz_look_at.Y = poz_eye.Y + yd * poz_eye.Z * 0.004f;
                x_old = mouse.X;
                y_old = mouse.Y;
                up_graf = true;
            }
            else
            {
                mise = false;
            }
        }
        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == OpenTK.Input.Key.Escape)
                this.Exit();

            if (e.Key == OpenTK.Input.Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;

        }
        private void rowup(object sender, OleDbRowUpdatedEventArgs e)
        {
           if(Debug) MessageBox.Show(sender.ToString());
        }
        private void Ondb_update(object sender, EventArgs e)
        {

        }
        #endregion


        #region metode

        void refreshtoc()
        {
            unutra = true;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            e_treba = false;
            lenght_old = new FileInfo(dbpath).Length;
            br_tab = 0;


            string select = "SELECT * FROM postavke";
            OleDbDataAdapter p = new OleDbDataAdapter(select, conn);
            DataSet mainds = new DataSet();
            p.Fill(mainds);

            for (int i = 0; i < mainds.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToBoolean(mainds.Tables[0].Rows[i][4]) == true)
                {
                    string selctr = "SELECT * FROM tocke" + mainds.Tables[0].Rows[i][0].ToString() + " WHERE sh = true; ";
                    OleDbDataAdapter curt = new OleDbDataAdapter(selctr, conn);
                    DataSet ct = new DataSet();
                    curt.Fill(ct);
                    pol[i].zadanetocke = new Vector2[40];
                    pol[i].br_tocki = 0;
                    curt.RowUpdated += new OleDbRowUpdatedEventHandler(rowup);
                    for (int j = 0; j < ct.Tables[0].Rows.Count; j++)
                    {
                        pol[i].zadanetocke[j] = new Vector2((float)Convert.ToDecimal(ct.Tables[0].Rows[j][1]), (float)Convert.ToDecimal(ct.Tables[0].Rows[j][2]));
                        pol[i].br_tocki++;
                    }
                    pol[i].boja_tocke = Color.FromArgb(Convert.ToInt32(mainds.Tables[0].Rows[i][3]));
                    pol[i].mode = Convert.ToInt32(mainds.Tables[0].Rows[i][2]);
                    izracunaj_polinom(i);
                    br_tab++;
                }
            }

            unutra = false;

        }
        public void db_update_invoke()
        {
            if (db_update != null)
                db_update.Invoke(this, EventArgs.Empty);
        }
        void izracunaj_polinom(int izrac_tab_local)
        {

            #region init_matrice
            conn.Close();
            int n = 0;
            tocke[] temp = new tocke[100];
            for (int i = 0; i < pol[izrac_tab_local].br_tocki; i++)
            {
                temp[n].x = pol[izrac_tab_local].zadanetocke[i].X;
                temp[n].y = pol[izrac_tab_local].zadanetocke[i].Y;
                n++;
            }
            double[][] matrica = new double[n + 1][];
            for (int j = 0; j < n; j++)
            {
                double[] temp_red = new double[n + 1];
                temp_red[n] = temp[j].y;
                for (int i = 0; i < n; i++)
                {
                    temp_red[n - 1 - i] = Math.Pow(temp[j].x, i);
                }
                matrica[j] = temp_red;
            }
            #endregion
            #region make_le_string
            Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
            pol[izrac_tab_local].kaeficjent_xa_na_itu = new Double[n + 2];
            mematka nekaj = new mematka();
            tocke[] nekakve = nekaj.izrac_func(temp, pol[izrac_tab_local].mode, n);
            if (pol[izrac_tab_local].mode == 0)
            {
                for (int i = 0; i < n; i++)
                {


                    pol[izrac_tab_local].kaeficjent_xa_na_itu[(int)nekakve[i].x] = nekakve[i].y;


                }
            }
            else if (pol[izrac_tab_local].mode == 1)
            {
                pol[izrac_tab_local].MinDif = 0;
                if (nekakve != null)
                {
                    if (nekakve.Length > 1)
                        pol[izrac_tab_local].MinDif = nekakve[1].x;
                    for (int i = 0; i < n; i++)
                    {
                        pol[izrac_tab_local].kaeficjent_xa_na_itu[i] = nekakve[i].y;
                    }
                }
            }

            make_graf(izrac_tab_local);
            #endregion

        }
        void make_graf(int izrac_tab_local)
        {
            aspect = Width / (float)Height;
            float x_min = (float)(poz_eye.Z * aspect * Math.Tan(fov / 2));

            //MessageBox.Show(x_min.ToString());
            float odd = (x_min * -1 + poz_eye.X - 3);
            float doo = (x_min + poz_eye.X + 3);



            double y = 0;
            pol[izrac_tab_local].tockekrivulje = new Vector2[rez];
            int brojac = 0;
            double step = (Math.Abs(doo - odd) / (double)rez);
            for (double i = odd; brojac < rez; i += step)
            {
                double broj = i;
                if (pol[izrac_tab_local].mode == 0)
                {
                    
                    y = pol[izrac_tab_local].kaeficjent_xa_na_itu[0];

                    for (int j = 1; j < pol[izrac_tab_local].br_tocki; j++)
                    {
                        y += pol[izrac_tab_local].kaeficjent_xa_na_itu[j] * Math.Pow(broj, j);
                    }

                }
                else if (pol[izrac_tab_local].mode == 1)
                {
                    y += pol[izrac_tab_local].kaeficjent_xa_na_itu[0];
                    double dif = pol[izrac_tab_local].MinDif;
                    for (int j = 1; j < pol[izrac_tab_local].br_tocki; j++)
                    {
                        y += pol[izrac_tab_local].kaeficjent_xa_na_itu[j] * Math.Sin(dif*j* broj);
                    }
                }
                else
                {
                    //shit the bed
                }
                pol[izrac_tab_local].tockekrivulje[brojac] = new Vector2((float)broj, (float)y);
                brojac++;
                y = 0;
            }
        }
        void update_graf()
        {
            for (int i = 0; i < br_tab; i++)
            {
                make_graf(i);
            }
            u_grafu = false;
        }
        #endregion


        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            rez = PostavkeGrafike.RezolucijaCrta;
            fov = MathHelper.PiOver2;
            poz_eye = new Vector3(0f, 0f, 10f);
            poz_look_at = Vector3.Zero;
            dbpath = Application.StartupPath + global::Interpolator.Properties.Resources.NameOfDbString;
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbpath);
            Thread th = new Thread(refreshtoc);
            th.Start();

            GL.ClearColor(Color.LightYellow);
            GL.PointSize(10f);
            GL.LineWidth(5f);
            GL.Enable(EnableCap.PointSmooth);
            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
            GL.EnableClientState(ArrayCap.ColorArray);
            GL.EnableClientState(ArrayCap.VertexArray);

            e_treba = false;

            db_update += Ondb_update;
            while (th.IsAlive)
            {
                continue;
            }

            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            last_scroll_status = OpenTK.Input.Mouse.GetState().Wheel;

        }





        #endregion

        #region OnResize
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 p = Matrix4.CreatePerspectiveFieldOfView(fov, Width / (float)Height, 0.1f, float.MaxValue);
            GL.LoadMatrix(ref p);

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 mv = Matrix4.LookAt(new Vector3(0f, 0f, 5f), new Vector3(0f, 0f, 0f), Vector3.UnitY);
            GL.LoadMatrix(ref mv);
            aspect = Width / (float)Height;
            new Thread(update_graf).Start();
            u_grafu = true;
        }

        #endregion

        #region OnUpdateFrame


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            
            if (Thread.CurrentThread.Priority == ThreadPriority.AboveNormal && !unutra)
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                new Thread(refreshtoc).Start();
                Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            }
            if ((OpenTK.Input.Mouse.GetState().Wheel != last_scroll_status || up_graf || rez != PostavkeGrafike.RezolucijaCrta) && !u_grafu)
            {
                rez = PostavkeGrafike.RezolucijaCrta;
                up_graf = false;
                u_grafu = true;
                last_scroll_status = OpenTK.Input.Mouse.GetState().Wheel;
                new Thread(update_graf).Start();
            }

        }

        #endregion

        #region OnRenderFrame


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            
            GL.PopMatrix();

            int cons = 0; //stavi u global

            poz_eye.Z = 1 / (float)(Math.Pow(10, (OpenTK.Input.Mouse.GetState().Wheel - cons) / (double)5));
            int atemp = OpenTK.Input.Mouse.GetState().Wheel;

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LineWidth(5f);
            GL.MatrixMode(MatrixMode.Modelview);

            Matrix4 mv = Matrix4.LookAt(poz_eye, poz_look_at, Vector3.UnitY);



            GL.Color4(Color.Red);
            //GL.Begin(PrimitiveType.Points);
            //GL.Vertex3(0f, 0f, 0f);
            //GL.End();

            GL.LineWidth(1f);
            int xsize = (int)(MathHelper.PiOver2 * poz_eye.Z * aspect), ysize = (int)(2 * MathHelper.PiOver2 * poz_eye.Z * (1 / aspect));
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color4(Color.Aqua);
            int mod_W = Math.Max(1, Math.Max((int)Math.Pow(10, (int)Math.Log10(Math.Abs(2 * xsize)) - 1), (int)Math.Pow(10, (int)Math.Log10(Math.Abs(2 * ysize)) - 1)));
            
            int xsize_abs = xsize + (int)Math.Abs(poz_eye.X);
            int ysize_abs = ysize + (int)Math.Abs(poz_eye.Y);
            xsize += (int)poz_eye.X;
            ysize += (int)poz_eye.Y;
            xsize -= (xsize % mod_W);
            ysize -= (ysize % mod_W);
            xsize_abs -= (xsize_abs % mod_W);
            ysize_abs -= (ysize_abs % mod_W);
            for (long i = -1 * xsize_abs; i < xsize_abs; i += mod_W)
            {

                long broj_x = i;
                long broj_y = ysize_abs;


                GL.Color4(Color.Aqua);
                if (broj_x % (mod_W * 10) == 0) GL.Color4(Color.PaleVioletRed);
                if (broj_x == 0) GL.Color4(Color.Red);
                GL.Vertex3(broj_x, broj_y, 0);
                GL.Vertex3(broj_x, -1 * broj_y, 0);
                GL.Vertex3(broj_x, broj_y, 0);

            }
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            for (long i = -1 * ysize_abs; i < ysize_abs; i += mod_W)
            {
                long broj_y = i;
                long broj_x = xsize_abs;


                GL.Color4(Color.Aqua);
                if (broj_y % (mod_W * 10) == 0) GL.Color4(Color.PaleVioletRed);
                if (broj_y == 0) GL.Color4(Color.Red);
                GL.Vertex3(broj_x, broj_y, 0);
                GL.Vertex3(-1 * broj_x, broj_y, 0);

                GL.Vertex3(broj_x, broj_y, 0);

            }
            GL.End();
            GL.LineWidth(4f);
            GL.LoadMatrix(ref mv);
            for (int i = 0; i < br_tab; i++)
            {
                GL.Begin(PrimitiveType.Points);
                GL.Color4(pol[i].boja_tocke);

                for (int j = 0; j < pol[i].br_tocki; j++)
                {
                    GL.Vertex2(pol[i].zadanetocke[j]);
                }
                GL.End();
                GL.Begin(PrimitiveType.LineStrip);
                for (int j = 5; j < pol[i].tockekrivulje.Length - 5; j++)
                {
                    if (pol[i].tockekrivulje[j].X != 0 && pol[i].tockekrivulje[j].Y != 0)
                    {
                        GL.Vertex2(pol[i].tockekrivulje[j]);
                    }
                }
                GL.End();
            }

            GL.PopMatrix();
            this.SwapBuffers();

        }
        #endregion

    }
    

}