using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace LMCC_System.User
{
    public partial class frmUserProfile : Form
    {
        UserClassBLL objUserLogic;
        string loginUser = string.Empty;

        public frmUserProfile(string loginUsername)//HERE LOGIN USERNAME
        {
            InitializeComponent();
            lblUsername.Text = loginUsername;//CURRENT LOGIN USENAME
            loginUser = loginUsername;
        }

        private void pbxUserSetting_Click(object sender, EventArgs e)
        {
            //USER SETTING FORM OPEN
            frmUser frmU = new frmUser();
            frmU.ShowDialog();
        }
        
        private void frmUserProfile_Load(object sender, EventArgs e)
        {
            UserProfileDetails();//LOGIN USER PROFILE DETAILS
        }

        //LOGIN USER PROFILE DETAILS
        public void UserProfileDetails()
        {
            try
            {
                objUserLogic = new UserClassBLL();
                DataSet ds = new DataSet();
                ds = (DataSet)objUserLogic.CurrentUser(loginUser);

                lblUsernameTop.Text = lblUsername.Text = loginUser;
                lblType.Text = ds.Tables["Table_User"].Rows[0].Field<string>("user_type");
                lblDivision.Text = lblDivisionTop.Text = ds.Tables["Table_User"].Rows[0].Field<string>("division");
                lblMobile.Text = ds.Tables["Table_User"].Rows[0].Field<string>("mobile");
                lblEmail.Text = ds.Tables["Table_User"].Rows[0].Field<string>("email");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "USER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
