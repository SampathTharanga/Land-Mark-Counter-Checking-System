using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMCC_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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
        void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                backgroundWorker1.ReportProgress(i);
                if(lblPrecentage.InvokeRequired)
                {
                    lblPrecentage.Invoke(new MethodInvoker(delegate
                    {
                        lblPrecentage.Visible = true;
                        lblPrecentage.Show();
                        lblPrecentage.Text = "Please wait ... "+ progressBar1.Value + "%";
                    }));
                }
                if(progressBar1.Value==100)
                    ClickBtnLoginOpenMainForm();

                System.Threading.Thread.Sleep(50);
            }
            lblPrecentage.Visible = false;
        }

        public void UsernameRemoveText(object sender, EventArgs e)
        {
            //USERNAME PLACEHOLDER
            if (txtUsename.Text == "Username")
                txtUsename.Text = "";
        }
        public void PasswordRemoveText(object sender, EventArgs e)
        {
            //PASSWORD PLACEHOLDER
            if (txtPassword.Text == "Password")
                txtPassword.Text = "";
        }

        public void UsernameAddText(object sender, EventArgs e)
        {
            //USERNAME PLACEHOLDER
            if (string.IsNullOrWhiteSpace(txtUsename.Text))
                txtUsename.Text = "Username";
        }

        public void PasswordAddText(object sender, EventArgs e)
        {
            //PASSWORD PLACEHOLDER
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                txtPassword.Text = "Password";
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
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

        private void btnLogIn_Paint(object sender, PaintEventArgs e)
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

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            //ClickBtnLoginOpenMainForm();
        }

        //LOGIN FORM HIDE AND MAIN FORM OPEN
        public void ClickBtnLoginOpenMainForm()
        {
            this.Invoke(new MethodInvoker(delegate ()//FIX: CREOSS-OPERATION NOT VALID ERROR
            {
                //OPEN MAIN FORM
                this.Hide();
                var formMain = new frmMain(txtUsename.Text);//LOGIN USERNAME RETURN MAIN FORM
                formMain.Closed += (s, args) => this.Close();
                formMain.ShowDialog();
            }
            ));

        }

        private void llblFogotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //OPEN FROGOT PASSWORD FORM
            Login.frmFogotPassword frmFP = new Login.frmFogotPassword();
            frmFP.ShowDialog();
        }
    }
}
