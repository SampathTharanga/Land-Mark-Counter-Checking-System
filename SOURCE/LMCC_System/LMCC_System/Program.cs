using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMCC_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Developed by : Sampath Tharanga | SRMST Samaradiwakara | Baliya
        /// System : LMCC System
        /// Version : 1.0.0.0
        /// Year : 2020
        /// Email : sampaththaranga13@gmail.com
        /// Facebook : https://www.facebook.com/sampath.tharanga.50
        /// Twitter : https://twitter.com/sampath13331
        /// Linkdin : https://www.linkedin.com/in/sampath-tharanga-b842b869/
        /// Website : http://www.athaebula.com/
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmUser());
        }
    }
}
