using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Text.RegularExpressions;
using System.Globalization;

namespace QLVT_DATHANG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            //string n = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", Int32.Parse("12345"));
            //Console.WriteLine(n);
            //Console.WriteLine(n.Replace(",", ""));
        }
    }
}
