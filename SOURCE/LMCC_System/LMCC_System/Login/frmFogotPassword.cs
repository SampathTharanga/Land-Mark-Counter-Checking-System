using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace LMCC_System.Login
{
    public partial class frmFogotPassword : Form
    {
        UserClassBLL objUserLogic;

        public frmFogotPassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear(); //CLEAR ALL TEXTBOX AND COMBO BOX
        }

        //CLEAR ALL TEXTBOX AND COMBO BOX
        private void Clear()
        {
            try
            {
                Action<Control.ControlCollection> func = null;
                func = (controls) =>
                {
                    foreach (Control control in controls)
                    {
                        if (control is TextBox)
                            (control as TextBox).Clear();
                        else if (control is ComboBox)
                            (control as ComboBox).SelectedIndex = -1;
                        else
                            func(control.Controls);
                    }
                };
                func(Controls);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fogot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFroget_Click(object sender, EventArgs e)
        {
            Recovery();//RECOVERY USER PASSWORD
        }

        //RECOVERY USER PASSWORD
        private void Recovery()
        {
            try
            {
                objUserLogic = new UserClassBLL();
                DataSet ds = new DataSet();
                ds = (DataSet)objUserLogic.CurrentUser(txtUsername.Text);

                DataTable dt = ds.Tables["Table_User"];
                DataColumn[] usernameCol = dt.Columns.Cast<DataColumn>().ToArray();
                bool checkUserExist = dt.AsEnumerable().Any(row => usernameCol.Any(col => row[col].ToString() == txtUsername.Text));

                //CHECK USER EXIST OR NOT
                if (checkUserExist)
                {
                    string secQue = ds.Tables["Table_User"].Rows[0].Field<string>("sec_question");
                    string secAns = ds.Tables["Table_User"].Rows[0].Field<string>("sec_answer");

                    if (secQue.Equals(cbxSecQue.Text) && secAns.Equals(txtSecAns.Text))
                    {
                        string password = ds.Tables["Table_User"].Rows[0].Field<string>("password");
                        MessageBox.Show("Your password is \"" + password + "\"", "Fogot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Wrong Answer or Security Question!", "Fogot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Clear(); //CLEAR ALL TEXTBOX AND COMBO BOX
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username!", "Fogot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Clear(); //CLEAR ALL TEXTBOX AND COMBO BOX
                }

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fogot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
