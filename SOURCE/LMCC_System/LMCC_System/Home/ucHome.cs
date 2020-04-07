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
    public partial class ucHome : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucHome ucHome_Instance;
        public static ucHome _ucHome
        {
            get
            {
                ucHome_Instance = null;
                if (ucHome_Instance == null)
                    ucHome_Instance = new ucHome();
                return ucHome_Instance;
            }
        }
        public ucHome()
        {
            InitializeComponent();
        }
    }
}
