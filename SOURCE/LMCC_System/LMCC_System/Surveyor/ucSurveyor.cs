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
        static string user = string.Empty;
        frmMain objFrmMain = new frmMain(user);

        public ucSurveyor()
        {
            InitializeComponent();
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
            try
            {
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
                    if (objClassBLL.ExistSurveyor(txtEmpRegNo.Text, objFrmMain._CurrentUserDivision) == false)
                    {

                        ////PROPERTIES FOR DATA ADD
                        //objUserLogic = new UserClassBLL()
                        //{
                        //    username = txtUsername.Text,
                        //    userType = cbxType.Text.ToString(),
                        //    password = txtPass.Text,
                        //    secQue = cbxSecQue.Text.ToString(),
                        //    secAns = txtSecAns.Text,
                        //    mobile = txtMobile.Text,
                        //    email = txtEmail.Text,
                        //    division = cbxDivision.Text
                        //};
                        ////INSERT DATA TO DATABASE
                        //objUserLogic.AddNewUser();
                        //MessageBox.Show("User registration successfully!", "User Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ////CLEAR ALL TEXBOX AND COMBOBOX
                        //ClearTextBoxces();

                        ////LOAD USER DATA
                        //LoadDataDgv();

                        ////SET TO BUTTON TEXT Add
                        //btnAdd.Text = "Add";
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

        //UPDATE SURVEYOR DATA

        //LOAD SURVEYOR DATA

        //VALIDATING EMAIL IS CORRECT

        //DATAGRIDVIEW DESIGN SECTION

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
        }

        private void ucSurveyor_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(objFrmMain._CurrentUserDivision) || string.IsNullOrWhiteSpace(objFrmMain._CurrentUsername))
                MessageBox.Show(objFrmMain._CurrentUserDivision + " | " + objFrmMain._CurrentUsername);
            else
                MessageBox.Show("Empty");
        }
    }
}
