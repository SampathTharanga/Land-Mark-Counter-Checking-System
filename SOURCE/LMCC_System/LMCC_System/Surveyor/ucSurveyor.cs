using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Text.RegularExpressions;

namespace LMCC_System
{
    public partial class ucSurveyor : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucSurveyor Surveyor_Instance;
        public static ucSurveyor _Surveyor
        {
            get
            {
                Surveyor_Instance = null;
                if (Surveyor_Instance == null)
                    Surveyor_Instance = new ucSurveyor();
                return Surveyor_Instance;
            }
        }

        SurveyorClassBLL objClassBLL;

        public ucSurveyor()
        {
            InitializeComponent();
        }

        //SET CURRENT USER USERNAME AND DIVISION
        static string _username = "", _division = "";
        public static void PassValue(string username, string division)
        {
            _division = division;
            _username = username;
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
                MessageBox.Show(ex.Message, "SURVEYOR ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //SAVE SURVEYOR DATA
        private void UserDataSave()
        {
            //try
            //{
                if (//CHECK TEXBOXES NOT NULL OR EMPTY
                    String.IsNullOrWhiteSpace(txtEmpRegNo.Text) ||
                    String.IsNullOrWhiteSpace(txtName.Text) ||
                    String.IsNullOrWhiteSpace(cbxSurveyorType.Text) ||
                    String.IsNullOrWhiteSpace(txtMobile.Text) ||
                    String.IsNullOrWhiteSpace(txtEmail.Text)
                    )
                {
                    MessageBox.Show("You must be filling all field!.", "Surveyor Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (objClassBLL.ExistSurveyor(_division, txtEmpRegNo.Text) == false)
                    {

                        //PROPERTIES FOR DATA ADD
                        objClassBLL = new SurveyorClassBLL()
                        {
                            date = DateTime.Today,
                            emp_reg_no=txtEmpRegNo.Text,
                            initail_name=txtName.Text,
                            surveyor_type=cbxSearchSurType.Text,
                            mobile=txtMobile.Text,
                            email=txtEmail.Text,
                            division=_division,
                            username=_username
                        };
                        //INSERT DATA TO DATABASE
                        objClassBLL.AddNewSurveyor();
                        MessageBox.Show("Surveyor registration successfully!", "Surveyor Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //CLEAR ALL TEXBOX AND COMBOBOX
                        ClearTextBoxces();

                        //LOAD USER DATA
                        LoadDataDgv();

                        //SET TO BUTTON TEXT Add
                        btnAdd.Text = "Add";
                    }

                    else
                    {
                        MessageBox.Show("Already exist this surveyor!", "Surveyor Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "USER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //UPDATE SURVEYOR DATA
        private void SurveyorDataUpadate()
        {
            try
            {
                if (//CHECK TEXBOXES NOT NULL OR EMPTY
                    String.IsNullOrWhiteSpace(txtEmpRegNo.Text) ||
                    String.IsNullOrWhiteSpace(txtName.Text) ||
                    String.IsNullOrWhiteSpace(cbxSearchSurType.Text) ||
                    String.IsNullOrWhiteSpace(txtMobile.Text) ||
                    String.IsNullOrWhiteSpace(txtEmail.Text)
                 )
                {
                    MessageBox.Show("You must be filling all field!.", "Surveyor Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objClassBLL = new SurveyorClassBLL()
                    {
                        date=DateTime.Today,
                        emp_reg_no=txtEmpRegNo.Text,
                        initail_name=txtName.Text,
                        surveyor_type=cbxSurveyorType.Text.ToString(),
                        mobile=txtMobile.Text,
                        email=txtEmail.Text,
                        division=_division,
                        username=_username
                    };

                    //UPDATE USER DATA
                    objClassBLL.UpdateSurveyor();
                    MessageBox.Show("Surveyor Update successfully!", "Surveyor Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //CLEAR ALL TEXBOX AND COMBOBOX
                    ClearTextBoxces();

                    //LOAD USER DATA
                    LoadDataDgv();

                    //SET TO BUTTON TEXT Add
                    btnAdd.Text = "Add";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SURVEYOR ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD SURVEYOR DATA
        private void LoadDataDgv()
        {
            objClassBLL = new SurveyorClassBLL();
            dgvSurveyor.DataSource = objClassBLL.LoadSurveyor();
            dgvSurveyor.DataMember = "Table_Surveyor";
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
        }

        private void ucSurveyor_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            btnAdd.Text = "Add";//TEXTBOX DEFAULT TEXT SET AFTER DATAGRIDVIEW ROW DOUBLE CLICK   

            LoadDataDgv();//LOAD USER DATA
            DataGrdViewDesign();//DATAGRIDVIEW DESIGN

            //LOAD DIVISION DATA TO COMBO BOX
            objClassBLL = new SurveyorClassBLL();
            cbxSurveyorType.DataSource = objClassBLL.LoadSurveyorType();
        }

        //DATAGRIDVIEW DESIGN SECTION
        private void DataGrdViewDesign()
        {
            try
            {
                dgvSurveyor.Columns[0].HeaderText = "Date";
                dgvSurveyor.Columns[1].HeaderText = "Emp./Reg. No";
                dgvSurveyor.Columns[2].HeaderText = "Name";
                dgvSurveyor.Columns[3].HeaderText = "Surveyor Type";
                dgvSurveyor.Columns[4].HeaderText = "Mobile";
                dgvSurveyor.Columns[5].HeaderText = "Email";
                dgvSurveyor.Columns[6].HeaderText = "Division";
                dgvSurveyor.Columns[7].HeaderText = "Username";

                dgvSurveyor.Columns[0].Width = 100;
                dgvSurveyor.Columns[1].Width = 100;
                dgvSurveyor.Columns[2].Width = 100;
                dgvSurveyor.Columns[3].Width = 200;
                dgvSurveyor.Columns[4].Width = 150;
                dgvSurveyor.Columns[5].Width = 100;
                dgvSurveyor.Columns[6].Width = 200;
                dgvSurveyor.Columns[7].Width = 100;

                //dgvUser.BorderStyle = BorderStyle.None;
                dgvSurveyor.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dgvSurveyor.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvSurveyor.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
                dgvSurveyor.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvSurveyor.BackgroundColor = Color.White;

                dgvSurveyor.EnableHeadersVisualStyles = false;
                dgvSurveyor.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgvSurveyor.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 50, 64);
                dgvSurveyor.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                dgvSurveyor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSurveyor.MultiSelect = false;

                dgvSurveyor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvSurveyor.AllowUserToResizeRows = false;

                dgvSurveyor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvSurveyor.AllowUserToResizeColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SURVEYOR ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //MOUSE DOUBLE CLICK AND FILL ALREADY DATA TO TEXTBOXES
        private void dgvSurveyor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                btnAdd.Text = "Update";//ADD BUTTON TEXT CHANGE TO Update

                txtEmpRegNo.Text = dgvSurveyor.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvSurveyor.CurrentRow.Cells[2].Value.ToString();
                cbxSurveyorType.Text = dgvSurveyor.CurrentRow.Cells[3].Value.ToString();
                txtMobile.Text = dgvSurveyor.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = dgvSurveyor.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SURVEYOR ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
                e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")//USER ADD BUTTON USE
                UserDataSave();//USER DATA SAVE

            if (btnAdd.Text == "Update")//USER UPDATE BUTTON USE
                SurveyorDataUpadate();//USER DATA UPDATE
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
