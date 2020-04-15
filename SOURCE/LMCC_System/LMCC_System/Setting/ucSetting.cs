using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMCC_System.Setting
{
    public partial class ucSetting : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucSetting Setting_Instance;
        public static ucSetting _Setting
        {
            get
            {
                Setting_Instance = null;
                if (Setting_Instance == null)
                    Setting_Instance = new ucSetting();
                return Setting_Instance;
            }
        }

        public ucSetting()
        {
            InitializeComponent();
        }
    }
}
