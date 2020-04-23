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
        /// ┌───────────────────────────────────────────────────────────────────────────────────────────────────────┐ \\
        /// │ Powerd by : Sampath Tharanga                                                                          │ \\
        /// ├───────────────────────────────────────────────────────────────────────────────────────────────────────┤ \\
        /// │ Email     : sampaththaranga13@gmail.com                                                               │ \\
        /// │ Website   : http://www.athaebula.com/                                                                 │ \\ 
        /// │ Facebook  : https://www.facebook.com/sampath.tharanga.50                                              │ \\
        /// │ Twitter   : https://twitter.com/sampath13331                                                          │ \\ 
        /// │ Linkdin   : https://www.linkedin.com/in/sampath-tharanga-b842b869/                                    │ \\ 
        /// │ Github    : https://github.com/SampathTharanga                                                        │ \\ 
        /// │                                                                                                       │ \\
        /// │ Project   : LMCC System                                                                               │ \\
        /// │ Version   : 1.0.0.0                                                                                   │ \\
        /// │ Release   : 2020.05.05                                                                                │ \\
        /// ├───────────────────────────────────────────────────────────────────────────────────────────────────────┤ \\
        /// │ SAMPATH THARANGA | SRMST SAMARADIWAKARA                                              Copyright © 2020 │ \\
        /// └───────────────────────────────────────────────────────────────────────────────────────────────────────┘ \\

        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain(""));
        }
    }
}
