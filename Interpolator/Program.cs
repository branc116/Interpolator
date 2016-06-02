using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace Interpolator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                File.WriteAllBytes(Application.StartupPath + "\\OpenTK.dll", global::Interpolator.Properties.Resources.OpenTK);
            }
            catch(Exception ee)
            {
                if (global::Interpolator.Properties.Settings.Default.DebugMode) MessageBox.Show(ee.ToString());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            lo:
            try {
                Application.Run(new Form1());
            }
            catch (Exception ee)
            {
                if (global::Interpolator.Properties.Settings.Default.DebugMode) MessageBox.Show(ee.ToString());
                goto lo;
            }
        }
    }
}
