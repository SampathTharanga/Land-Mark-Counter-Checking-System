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
    public partial class ucLMSettle : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucLMSettle ucLMSettle_Instance;
        public static ucLMSettle _ucLMSettle
        {
            get
            {
                ucLMSettle_Instance = null;
                if (ucLMSettle_Instance == null)
                    ucLMSettle_Instance = new ucLMSettle();
                return ucLMSettle_Instance;
            }
        }
        public ucLMSettle()
        {
            InitializeComponent();
        }
    }
}
