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
    public partial class ucLMReceived : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucLMReceived ucLMReceived_Instance;
        public static ucLMReceived _ucLMReceived
        {
            get
            {
                ucLMReceived_Instance = null;
                if (ucLMReceived_Instance == null)
                    ucLMReceived_Instance = new ucLMReceived();
                return ucLMReceived_Instance;
            }
        }
        public ucLMReceived()
        {
            InitializeComponent();
        }
    }
}
