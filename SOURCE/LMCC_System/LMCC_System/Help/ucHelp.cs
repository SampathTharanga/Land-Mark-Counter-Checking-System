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
    public partial class ucHelp : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucHelp ucHelp_Instance;
        public static ucHelp _ucHelp
        {
            get
            {
                ucHelp_Instance = null;
                if (ucHelp_Instance == null)
                    ucHelp_Instance = new ucHelp();
                return ucHelp_Instance;
            }
        }
        public ucHelp()
        {
            InitializeComponent();
        }
    }
}
