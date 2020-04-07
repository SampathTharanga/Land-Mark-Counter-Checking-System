using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMCC_System.User
{
    public partial class frmUserProfile : Form
    {
        public frmUserProfile()
        {
            InitializeComponent();
        }

        private void pbxUserSetting_Click(object sender, EventArgs e)
        {
            //USER SETTING FORM OPEN
            frmUser frmU = new frmUser();
            frmU.ShowDialog();
        }
    }
}
