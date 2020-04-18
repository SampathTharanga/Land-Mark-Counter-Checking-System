using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace LMCC_System
{
    public partial class frmLogin : Form
    {
        UserClassBLL objUserLogic;
        public frmLogin()
        {
            InitializeComponent();

            btnLogIn.Enabled = true;
            llblFogotPass.Enabled = true; ;

            //BUTTON BORDER REMOVE
            btnLogIn.FlatAppearance.BorderSize = 0;
            lblPrecentage.Visible = false;

            //BACKGROUD WORKER WITH SPLASH SCREEN
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker1_ProgressChanged);
        }

        //BACKGROUD WORKER WITH SPLASH SCREEN
        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        //BACKGROUD WORKER WITH SPLASH SCREEN
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i <= 100; i++)
                {
                    backgroundWorker1.ReportProgress(i);
                    if (lblPrecentage.InvokeRequired)
                    {
                        lblPrecentage.Invoke(new MethodInvoker(delegate
                        {
                            lblPrecentage.Visible = true;
                            lblPrecentage.Show();
                            lblPrecentage.Text = "Please wait ... " + progressBar1.Value + "%";
                        }));
                    }
                    if (progressBar1.Value == 100)
                        ClickBtnLoginOpenMainForm();

                    System.Threading.Thread.Sleep(50);
                }
                lblPrecentage.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UsernameRemoveText(object sender, EventArgs e)
        {
            //USERNAME PLACEHOLDER
            if (txtUsename.Text == "Username")
                txtUsename.Text = "";
        }
        private void PasswordRemoveText(object sender, EventArgs e)
        {
            //PASSWORD PLACEHOLDER
            if (txtPassword.Text == "Password")
                txtPassword.Text = "";
        }

        private void UsernameAddText(object sender, EventArgs e)
        {
            //USERNAME PLACEHOLDER
            if (string.IsNullOrWhiteSpace(txtUsename.Text))
                txtUsename.Text = "Username";
        }

        private void PasswordAddText(object sender, EventArgs e)
        {
            //PASSWORD PLACEHOLDER
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                txtPassword.Text = "Password";
        }

        //PLACEHODER USERNAME AND PASSWORD
        private void PlaceHolderUser()
        {
            try
            {
                //USERNAME PLACEHOLDER
                txtUsename.Text = "Username";
                txtUsename.GotFocus += new EventHandler(UsernameRemoveText);
                txtUsename.LostFocus += new EventHandler(UsernameAddText);


                //PASSWORD PLACEHOLDER
                txtPassword.Text = "Password";
                txtPassword.GotFocus += new EventHandler(PasswordRemoveText);
                txtPassword.LostFocus += new EventHandler(PasswordAddText);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            PlaceHolderUser();//PLACEHOLDER
            UserNotExist();//IF NOT USER OPEN USER REGISTERATION WINDOW


        }

        //IF NOT USER OPEN USER REGISTERATION WINDOW
        private void UserNotExist()
        {
            try
            {
                objUserLogic = new UserClassBLL();
                DataSet ds = new DataSet();
                ds = (DataSet)objUserLogic.LoadUserData();
                DataTable dt = ds.Tables["Table_User"];
                if (dt.Rows.Count == 0)
                {
                    frmUser frmObjUser = new frmUser();
                    frmObjUser.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLogIn_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                //LOGIN ROUNDED BUTTON
                System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
                System.Drawing.Rectangle newRectangle = btnLogIn.ClientRectangle;
                newRectangle.Inflate(18, 18);
                e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle);
                newRectangle.Inflate(-1, -1);
                buttonPath.AddEllipse(newRectangle);
                btnLogIn.Region = new System.Drawing.Region(buttonPath);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                objUserLogic = new UserClassBLL();
                DataSet ds = new DataSet();
                ds = (DataSet)objUserLogic.CurrentUser(txtUsename.Text);

                //CHECK USER EXIST OR NOT (USING LINQ)
                DataTable dt = ds.Tables["Table_User"];
                DataColumn[] usernameCol = dt.Columns.Cast<DataColumn>().ToArray();
                bool checkUserExist = dt.AsEnumerable().Any(row => usernameCol.Any(col => row[col].ToString() == txtUsename.Text));

                //CHECK USER EXIST OR NOT
                if (checkUserExist)
                {
                    //AVAILABLE USERNAME & PASSWORD GET
                    string username = ds.Tables["Table_User"].Rows[0].Field<string>("username");
                    string password = ds.Tables["Table_User"].Rows[0].Field<string>("password");

                    //CHECK USERNAME & PASSWORD ARE EQUAL
                    if (username.Equals(txtUsename.Text) && password.Equals(txtPassword.Text))
                    {
                        //RUNNING BACKGROUNDWORKER AND STARTING PROCESS COUNTING PRECENTAGE
                        backgroundWorker1.RunWorkerAsync();

                        btnLogIn.Enabled = false;
                        llblFogotPass.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Login Fail, Please check again password!", "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PlaceHolderUser();
                    }
                }
                else
                {
                    MessageBox.Show("User not exist, Please check again username!", "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PlaceHolderUser();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        //LOGIN FORM HIDE AND MAIN FORM OPEN
        private void ClickBtnLoginOpenMainForm()
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate ()//FIX: CROSS-OPERATION NOT VALID ERROR
                {
                    //OPEN MAIN FORM
                    this.Hide();
                    var formMain = new frmMain(txtUsename.Text);//LOGIN USERNAME RETURN MAIN FORM
                    formMain.Closed += (s, args) => this.Close();
                    formMain.ShowDialog();
                }
                ));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void llblFogotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //OPEN FROGOT PASSWORD FORM
            Login.frmFogotPassword frmFP = new Login.frmFogotPassword();
            frmFP.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
