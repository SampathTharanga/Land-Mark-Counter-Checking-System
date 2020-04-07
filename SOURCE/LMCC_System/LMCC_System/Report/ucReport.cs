using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMCC_System
{
    public partial class ucReport : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucReport ucReport_Instance;
        public static ucReport _ucReport
        {
            get
            {
                ucReport_Instance = null;
                if (ucReport_Instance == null)
                    ucReport_Instance = new ucReport();
                return ucReport_Instance;
            }
        }
        public ucReport()
        {
            InitializeComponent();
        }
    }
}
