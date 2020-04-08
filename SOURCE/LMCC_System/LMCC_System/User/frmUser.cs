using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;//IMPORT BUSIINESS LOGC LAYER
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace LMCC_System
{
    public partial class frmUser : Form
    {
        UserClassBLL objUserLogic;
        public frmUser()
        {
            InitializeComponent();
        }

        //CLOSE USER WINDOW
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //CLEAR ALL TEXBOX AND COMBOBOX
        private void ClearTextBoxces()
        {
            Action<Control.ControlCollection> func = null;
            func = (cotrols) =>
            {
                foreach (Control control in cotrols)
                {
                    if (control is TextBox)
                        (control as TextBox).Clear();//TEXTBOX CLEAR
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedIndex = -1;//COMBOBOX CLEAR
                    else
                        func(control.Controls);
                }
            };
            func(Controls);
        }

        private void btnnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //USER DATA SAVE
            UserDataSave();
        }

        //SAVE USER DATA
        private void UserDataSave()
        {
            
            if (
                String.IsNullOrWhiteSpace(txtUsername.Text) ||
                String.IsNullOrWhiteSpace(cbxType.Text) ||
                String.IsNullOrWhiteSpace(txtPass.Text) ||
                String.IsNullOrWhiteSpace(txtConfirmPass.Text) ||
                String.IsNullOrWhiteSpace(cbxSecQue.Text) ||
                String.IsNullOrWhiteSpace(txtSecAns.Text) ||
                String.IsNullOrWhiteSpace(txtEmail.Text) ||
                String.IsNullOrWhiteSpace(txtMobile.Text) ||
                String.IsNullOrWhiteSpace(txtDivision.Text)
                )
            {
                MessageBox.Show("You must be filling all field!.", "User Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //INSERT NEW USER
                objUserLogic = new UserClassBLL()
                {
                    username = txtUsername.Text,
                    userType = cbxType.Text.ToString(),
                    password = txtPass.Text,
                    secQue = cbxSecQue.Text.ToString(),
                    secAns = txtSecAns.Text,
                    mobile = txtMobile.Text,
                    email = txtEmail.Text,
                    division = txtDivision.Text
            };
                //INSERT DATA TO DATABASE
                objUserLogic.AddNewUser();
                MessageBox.Show("User registration successfully!", "User Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //CLEAR ALL TEXBOX AND COMBOBOX
                ClearTextBoxces();

                //LOAD USER DATA
                LoadDataDgv();

            }
        }

        //LOAD USER DATA
        private void LoadDataDgv()
        {
            objUserLogic = new UserClassBLL();
            dgvUser.DataSource = objUserLogic.LoadUserData();
            dgvUser.DataMember = "Table_User";
        }

        //VALIDATING EMAIL IS CORRECT
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex rEMail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Please enter correct email address!", "Email Address Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                    e.Cancel = true;
                }
            }

        }

        //CHECK PASSWORD AND CONFIRM PASSWORD ARE EQUAL
        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (!(txtPass.Text.Equals(txtConfirmPass.Text)))
            {
                MessageBox.Show("Password and Confirm Password must be equal!", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPass.SelectAll();
                e.Cancel = true;
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            //LOAD USER DATA
            LoadDataDgv();
            //DATAGRIDVIEW DESIGN
            DataGrdViewDesign();
        }

        //DATAGRIDVIEW DESIGN SECTION
        private void DataGrdViewDesign()
        {
            //DATAGRIDVIEW DESIGN SECTION.
            dgvUser.Columns[0].HeaderText = "Username";
            dgvUser.Columns[1].HeaderText = "User Type";
            dgvUser.Columns[2].HeaderText = "Password";
            dgvUser.Columns[3].HeaderText = "Security Question";
            dgvUser.Columns[4].HeaderText = "Security Answer";
            dgvUser.Columns[5].HeaderText = "Mobile";
            dgvUser.Columns[6].HeaderText = "Email";
            dgvUser.Columns[7].HeaderText = "Division";

            dgvUser.Columns[0].Width = 100;
            dgvUser.Columns[1].Width = 100;
            dgvUser.Columns[2].Width = 100;
            dgvUser.Columns[3].Width = 100;
            dgvUser.Columns[4].Width = 100;
            dgvUser.Columns[5].Width = 100;
            dgvUser.Columns[6].Width = 100;
            dgvUser.Columns[7].Width = 100;

            //dgvUser.BorderStyle = BorderStyle.None;
            dgvUser.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvUser.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUser.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dgvUser.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvUser.BackgroundColor = Color.White;

            dgvUser.EnableHeadersVisualStyles = false;
            dgvUser.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUser.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 50, 64);
            dgvUser.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUser.MultiSelect = false;

            dgvUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvUser.AllowUserToResizeRows = false;

            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvUser.AllowUserToResizeColumns = false;
        }

        //MOBILE NUMBER VALIDATE
        private void txtMobile_Validating(object sender, CancelEventArgs e)
        {
            Regex mobilePattern = new Regex(@"^[0-9]{10}$");
            if (!(mobilePattern.IsMatch(txtMobile.Text)))
            {
                MessageBox.Show("Please enter valid mobile number!", "Mobile Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobile.SelectAll();
                e.Cancel = true;
            }
        }
    }
}
