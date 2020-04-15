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
    public partial class ucLMMaking : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucLMMaking LMMaking_Instance;
        public static ucLMMaking _LMMaking
        {
            get
            {
                LMMaking_Instance = null;
                if (LMMaking_Instance == null)
                    LMMaking_Instance = new ucLMMaking();
                return LMMaking_Instance;
            }
        }
        public ucLMMaking()
        {
            InitializeComponent();
        }

        private void pbxLMSetting_Click(object sender, EventArgs e)
        {

        }
    }
}
