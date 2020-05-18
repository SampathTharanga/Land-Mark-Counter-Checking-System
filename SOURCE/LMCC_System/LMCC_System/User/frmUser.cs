using BusinessLogicLayer;//IMPORT BUSIINESS LOGC LAYER
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "USER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX

            txtUsername.Enabled = true;//ENABLE TEXTBOX AFTER DATAGRIDVIEW ROW DOUBLE CLICK
            cbxDivision.Enabled = true;
            btnAdd.Text = "Add";//TEXTBOX DEFAULT TEXT SET AFTER DATAGRIDVIEW ROW DOUBLE CLICK
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           if(btnAdd.Text=="Add")//USER ADD BUTTON USE
                UserDataSave();//USER DATA SAVE

            if (btnAdd.Text == "Update")//USER UPDATE BUTTON USE
                UserDataUpadate();//USER DATA UPDATE
        }

        //SAVE USER DATA
        private void UserDataSave()
        {
            try
            {
                if (//CHECK TEXBOXES NOT NULL OR EMPTY
                    String.IsNullOrWhiteSpace(txtUsername.Text) ||
                    String.IsNullOrWhiteSpace(cbxType.Text) ||
                    String.IsNullOrWhiteSpace(txtPass.Text) ||
                    String.IsNullOrWhiteSpace(txtConfirmPass.Text) ||
                    String.IsNullOrWhiteSpace(cbxSecQue.Text) ||
                    String.IsNullOrWhiteSpace(txtSecAns.Text) ||
                    String.IsNullOrWhiteSpace(txtEmail.Text) ||
                    String.IsNullOrWhiteSpace(txtMobile.Text) ||
                    String.IsNullOrWhiteSpace(cbxDivision.Text)
                    )
                {
                    MessageBox.Show("You must be filling all field!.", "User Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (objUserLogic.NewUserCheck(txtUsername.Text, cbxDivision.Text) == false)
                    {

                        //PROPERTIES FOR DATA ADD
                        objUserLogic = new UserClassBLL()
                        {
                            username = txtUsername.Text,
                            userType = cbxType.Text.ToString(),
                            password = txtPass.Text,
                            secQue = cbxSecQue.Text.ToString(),
                            secAns = txtSecAns.Text,
                            mobile = txtMobile.Text,
                            email = txtEmail.Text,
                            division = cbxDivision.Text
                        };
                        //INSERT DATA TO DATABASE
                        objUserLogic.AddNewUser();
                        MessageBox.Show("User registration successfully!", "User Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //CLEAR ALL TEXBOX AND COMBOBOX
                        ClearTextBoxces();

                        //LOAD USER DATA
                        LoadDataDgv();

                        //SET TO BUTTON TEXT Add
                        btnAdd.Text = "Add";
                    }

                    else
                    {
                        MessageBox.Show("Already exist this user!", "User Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "USER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //UPDATE USER DATA
        private void UserDataUpadate()
        {
            try
            {
                if (//CHECK TEXBOXES NOT NULL OR EMPTY
                    String.IsNullOrWhiteSpace(txtUsername.Text) ||
                    String.IsNullOrWhiteSpace(cbxType.Text) ||
                    String.IsNullOrWhiteSpace(txtPass.Text) ||
                    String.IsNullOrWhiteSpace(txtConfirmPass.Text) ||
                    String.IsNullOrWhiteSpace(cbxSecQue.Text) ||
                    String.IsNullOrWhiteSpace(txtSecAns.Text) ||
                    String.IsNullOrWhiteSpace(txtEmail.Text) ||
                    String.IsNullOrWhiteSpace(txtMobile.Text) ||
                    String.IsNullOrWhiteSpace(cbxDivision.Text)
                 )
                {
                    MessageBox.Show("You must be filling all field!.", "User Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                        objUserLogic = new UserClassBLL()
                        {
                            username = txtUsername.Text,
                            userType = cbxType.Text,
                            password = txtPass.Text,
                            secQue = cbxSecQue.Text,
                            secAns = txtSecAns.Text,
                            mobile = txtMobile.Text,
                            email = txtEmail.Text,
                            division = cbxDivision.Text
                        };

                        //UPDATE USER DATA
                        objUserLogic.UpdateUser();
                        MessageBox.Show("User Update successfully!", "User Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //CLEAR ALL TEXBOX AND COMBOBOX
                        ClearTextBoxces();

                        //LOAD USER DATA
                        LoadDataDgv();

                        //SET TO BUTTON TEXT Add
                        btnAdd.Text = "Add";

                        //TEXTBOX ENABLE
                        txtUsername.Enabled = true;
                    cbxDivision.Enabled = true;
    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "USER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "USER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtUsername.Enabled = true;//ENABLE TEXTBOX AFTER DATAGRIDVIEW ROW DOUBLE CLICK
            cbxDivision.Enabled = true;
            btnAdd.Text = "Add";//TEXTBOX DEFAULT TEXT SET AFTER DATAGRIDVIEW ROW DOUBLE CLICK   

            LoadDataDgv();//LOAD USER DATA
            DataGrdViewDesign();//DATAGRIDVIEW DESIGN

            //LOAD DIVISION DATA TO COMBO BOX
            objUserLogic = new UserClassBLL();
            cbxDivision.DataSource=objUserLogic.LoadDivisioToCbx();
        }

        //DATAGRIDVIEW DESIGN SECTION
        private void DataGrdViewDesign()
        {
            try
            {
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
                dgvUser.Columns[3].Width = 200;
                dgvUser.Columns[4].Width = 150;
                dgvUser.Columns[5].Width = 100;
                dgvUser.Columns[6].Width = 200;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "USER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        //MOUSE DOUBLE CLICK AND FILL ALREADY DATA TO TEXTBOXES
        private void dgvUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtUsername.Enabled = false;
                cbxDivision.Enabled = false;
                btnAdd.Text = "Update";//ADD BUTTON TEXT CHANGE TO Update

                txtUsername.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();
                cbxType.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
                txtPass.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
                txtConfirmPass.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
                cbxSecQue.Text = dgvUser.CurrentRow.Cells[3].Value.ToString();
                txtSecAns.Text = dgvUser.CurrentRow.Cells[4].Value.ToString();
                txtMobile.Text = dgvUser.CurrentRow.Cells[5].Value.ToString();
                txtEmail.Text = dgvUser.CurrentRow.Cells[6].Value.ToString();
                cbxDivision.Text = dgvUser.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "USER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
                e.Handled = true;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
        }

        private void txtSecAns_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Space);
        }
    }
}
