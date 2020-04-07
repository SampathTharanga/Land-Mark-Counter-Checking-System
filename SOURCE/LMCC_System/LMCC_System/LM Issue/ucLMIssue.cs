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
    public partial class ucLMIssue : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucLMIssue ucLMIssue_Instance;
        public static ucLMIssue _ucLMIssue
        {
            get
            {
                ucLMIssue_Instance = null;
                if (ucLMIssue_Instance == null)
                    ucLMIssue_Instance = new ucLMIssue();
                return ucLMIssue_Instance;
            }
        }
        public ucLMIssue()
        {
            InitializeComponent();
        }
    }
}
