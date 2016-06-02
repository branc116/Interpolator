using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Interpolator
{
    public partial class Postavke : Form
    {
        public int BrojDecimala;
        public int RezolucijaCrta;
        public bool KoristiRazlomke;
        protected int PravaVrijednostSlidera;
        protected int[] VrijednostiRezolucija;
        protected Thread ThisThread;
        delegate void s(string t);
        public Postavke()
        {
            InitializeComponent();
            VrijednostiRezolucija = new int[10]
            {
                0,200,700,1200,2000,4000,6000,9000,10000,12000
            };
            PravaVrijednostSlidera = 1;
            BrojDecimala = 2;
            RezolucijaCrta = 200;
            ThisThread = new Thread(pokreni);
        }

        #region metode
        public void ShowPanel()
        {
            try {
                ThisThread.Start();
            }
            catch
            {
                AsincStart("hello");
                
            }
        }
        protected void AsincStart(string s)
        {
            if (this.InvokeRequired)
            {
                string ss = "aa";
                this.Invoke(new s(AsincStart), new object[] { ss });
            }
            else
            {
                this.ShowDialog();
            }
        }
        protected void pokreni()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            try {
                Application.Run(this);
            }
            catch
            {
                InitializeComponent();
                trackBar1.Value = PravaVrijednostSlidera;
                textBox1.Text = BrojDecimala.ToString();
                
                this.ShowDialog();
            }
        }
        #endregion
        #region events
        private void OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                int temp = Convert.ToInt32(((TextBox)sender).Text);
                if (temp > 16) throw new Exception("Broj je preveliki, maksimalni broj je 16");
                BrojDecimala = temp;
                Error.Visible = false;
            }
            catch (Exception ee)
            {
                if (ee.ToString() != "1")
                    Error.Visible = true;

            }
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            PravaVrijednostSlidera = ((TrackBar)sender).Value;
            RezolucijaCrta = VrijednostiRezolucija[((TrackBar)sender).Value];
        }
        #endregion
    }
}
