using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace LMCC_System
{
    public partial class frmMain : Form
    {
        UserClassBLL objUserLogic;

        private static bool isRun = false;
        private static readonly object syncLock = new object();

        //LEFT MENU BUTTON COLORS
        Color leaveColor = Color.FromArgb(38, 50, 64),
              clickColor = Color.FromArgb(52, 70, 87);

        //LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
        bool _btnHome = false,
             _btnSurveyor = false,
             _btnLmMaking = false,
             _btnReport = false,
             _btnHelp = false,
             _btnLmManage = false,
             _btnSetting = false;

        public frmMain(string loginUser)
        {
            InitializeComponent();
            Load += new EventHandler(frmMain_Load);
            
            lblUserProfile.Text = loginUser;//CURRENT LOGIN USERNAME

            ButtonsBorderRemove(pnlLeftMenu);//LEFT MENU BUTTONS BORDER REMOVE
        }

        //LEFT MENU BUTTONS BORDER REMOVE
        private void ButtonsBorderRemove(Panel panel)
        {
            foreach (var button in panel.Controls.OfType<Button>())
            {
                button.FlatAppearance.BorderSize = 0;
            }
        }

        //LEFT MENU BUTTONS BLUE COLOR LINE DESIGN
        private void ButtonLeftBlueColorLine_Show(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                Color.FromArgb(132, 209, 219), 6, ButtonBorderStyle.Solid,
                Color.Red, 0, ButtonBorderStyle.Solid,
                Color.Red, 0, ButtonBorderStyle.Solid,
                Color.Red, 0, ButtonBorderStyle.Solid);
        }

        //LEFT MENU BUTTONS BLUE COLOR LINE REMOVE AND SET DEFAULT COLOR
        private void ButtonLeftBlueColorLine_Hide(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, this.BackColor, ButtonBorderStyle.None);

        }

        //LEFT MENU ALL BUTTONS BLUE COLOR LINE HIDE
        private void DefaultColorSetAllMenuButtons(Panel panel)
        {
            foreach (var button in panel.Controls.OfType<Button>())
            {
                button.BackColor = leaveColor;
            }
        }

        //LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
        private void MenuButtonDefaultValSet()
        {
            _btnHome = false;
            _btnSurveyor = false;
            _btnLmMaking = false;
            _btnReport = false;
            _btnHelp = false;
            _btnLmManage = false;
            _btnSetting = false;
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
                MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE

                btnHome.BackColor = clickColor;//CLICK COLOR SET
                _btnHome = true;

                //USER CONTROL LM HOME OPEN
                pnlMain.Controls.Clear();
                if (!pnlMain.Controls.Contains(ucHome._ucHome))
                {
                    pnlMain.Controls.Add(ucHome._ucHome);
                    ucHome._ucHome.Dock = DockStyle.Fill;
                    ucHome._ucHome.BringToFront();
                }

                //ENSURE THIS METHOD ONLY RUN ONCE
                lock (syncLock)
                {
                    if (!isRun)
                    {
                        LoginUserAllAvailableCheck();//AT LEAST ONE USER EXIST OR NOT CHECK
                        isRun = true;
                    }
                }

                //PARSE CURRENT USER DATA TO SURVEYOR USERCONTROL
                ucSurveyor.PassValue(lblUserProfile.Text, lblCommenDetails.Text);

                //PARSE CURRENT USER DATA TO LM MAKING USERCONTROL
                ucLMMaking.PassValue(lblUserProfile.Text, lblCommenDetails.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //AT LEAST ONE USER EXIST OR NOT CHECK
        private void LoginUserAllAvailableCheck()
        {
            try
            {
                objUserLogic = new UserClassBLL();
                DataSet ds = new DataSet();
                ds = (DataSet)objUserLogic.CurrentUser(lblUserProfile.Text);
                string secQue = ds.Tables["Table_User"].Rows[0].Field<string>("sec_question");
                string secAns = ds.Tables["Table_User"].Rows[0].Field<string>("sec_answer");
                string mobile = ds.Tables["Table_User"].Rows[0].Field<string>("mobile");
                string division = ds.Tables["Table_User"].Rows[0].Field<string>("division");
                lblCommenDetails.Text = division;//CURRENT USER DIVISION 
                if (string.IsNullOrEmpty(secQue) || string.IsNullOrEmpty(secAns) || string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(division))
                {
                    frmUser frmUs = new frmUser();
                    frmUs.ShowDialog();
                    MessageBox.Show("You must filling all of details.", "User Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //SET CURRENT USERNAME AND DIVISION
                //objUcSurveyor = new ucSurveyor();
                //objUcSurveyor.PassValue(lblUserProfile.Text, division);

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
                btnHome.BackColor = clickColor;//CLICK COLOR SET

                MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
                _btnHome = true;

                //USER CONTROL LM HOME OPEN
                pnlMain.Controls.Clear();
                if (!pnlMain.Controls.Contains(ucHome._ucHome))
                {
                    pnlMain.Controls.Add(ucHome._ucHome);
                    ucHome._ucHome.Dock = DockStyle.Fill;
                    ucHome._ucHome.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLmMaking_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnLmMaking == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }


        private void btnReport_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnReport == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }

        private void btnHelp_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnHelp == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }

        private void btnLmMaking_MouseEnter(object sender, EventArgs e)
        {
            _btnLmMaking = true;
        }

        private void btnReport_MouseEnter(object sender, EventArgs e)
        {
            _btnReport = true;
        }

        private void btnHelp_MouseEnter(object sender, EventArgs e)
        {
            _btnHelp = true;
        }

        private void btnLmMaking_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnLmMaking.BackColor == clickColor)
                _btnLmMaking = true;
            else
                _btnLmMaking = false;
        }

        private void btnReport_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnReport.BackColor == clickColor)
                _btnReport = true;
            else
                _btnReport = false;
        }

        private void btnHelp_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnHelp.BackColor == clickColor)
                _btnHelp = true;
            else
                _btnHelp = false;
        }

        private void btnLmMaking_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
                btnLmMaking.BackColor = clickColor;

                MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
                _btnLmMaking = true;

                //USER CONTROL LM MAKING OPEN
                pnlMain.Controls.Clear();
                if (!pnlMain.Controls.Contains(ucLMMaking._LMMaking))
                {
                    pnlMain.Controls.Add(ucLMMaking._LMMaking);
                    ucLMMaking._LMMaking.Dock = DockStyle.Fill;
                    ucLMMaking._LMMaking.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
                btnReport.BackColor = clickColor;

                MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
                _btnReport = true;

                //USER CONTROL LM SETTLE OPEN
                pnlMain.Controls.Clear();
                if (!pnlMain.Controls.Contains(ucReport._ucReport))
                {
                    pnlMain.Controls.Add(ucReport._ucReport);
                    ucReport._ucReport.Dock = DockStyle.Fill;
                    ucReport._ucReport.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void lblUserProfile_Click(object sender, EventArgs e)
        {
            //USER PROFILE FORM OPEN
            User.frmUserProfile frmUP = new User.frmUserProfile(lblUserProfile.Text);
            frmUP.ShowDialog();
        }

        private void lblUserProfile_MouseEnter(object sender, EventArgs e)
        {
            //MOUSE ENTER COLOR CHANGE USERNAME LABEL
            lblUserProfile.ForeColor = Color.FromArgb(132, 209, 219);
        }

        private void lblUserProfile_MouseLeave(object sender, EventArgs e)
        {
            //MOUSE LEAVE COLOR CHANGE USERNAME LABEL
            lblUserProfile.ForeColor = Color.White;
        }

        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            //MOUSE ENTER COLOR CHANGE LOGOUT LABEL
            lblLogout.ForeColor = Color.Red;
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            //MOUSE ENTER COLOR CHANGE LOGOUT LABEL
            lblLogout.ForeColor = Color.DarkOrange;
        }

        private void lblCommenDetails_MouseEnter(object sender, EventArgs e)
        {
            //DIVISION LABAL MOUSE ENTER COLOR CHANGE
            lblCommenDetails.ForeColor = Color.Green;
        }

        private void lblCommenDetails_MouseLeave(object sender, EventArgs e)
        {
            //DIVISION LABAL MOUSE LEAVE COLOR CHANGE
            lblCommenDetails.ForeColor = Color.White;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
                btnHelp.BackColor = clickColor;

                MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
                _btnHelp = true;

                //USER CONTROL LM SETTLE OPEN
                pnlMain.Controls.Clear();
                if (!pnlMain.Controls.Contains(ucHelp._ucHelp))
                {
                    pnlMain.Controls.Add(ucHelp._ucHelp);
                    ucHelp._ucHelp.Dock = DockStyle.Fill;
                    ucHelp._ucHelp.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void btnSurveyor_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
                btnSurveyor.BackColor = clickColor;

                MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
                _btnSurveyor = true;

                //USER CONTROL SURVEYOR OPEN
                pnlMain.Controls.Clear();
                if (!pnlMain.Controls.Contains(ucSurveyor._Surveyor))
                {
                    pnlMain.Controls.Add(ucSurveyor._Surveyor);
                    ucSurveyor._Surveyor.Dock = DockStyle.Fill;
                    ucSurveyor._Surveyor.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnHome_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnHome == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }

        private void btnLmManage_MouseEnter(object sender, EventArgs e)
        {
            _btnLmManage = true;
        }

        private void btnLmManage_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnLmManage.BackColor == clickColor)
                _btnLmManage = true;
            else
                _btnLmManage = false;
        }

        private void btnLmSetting_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
                btnLmSetting.BackColor = clickColor;

                MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
                _btnSetting = true;

                //USER CONTROL LM MAKING OPEN
                pnlMain.Controls.Clear();
                if (!pnlMain.Controls.Contains(Setting.ucSetting._Setting))
                {
                    pnlMain.Controls.Add(Setting.ucSetting._Setting);
                    Setting.ucSetting._Setting.Dock = DockStyle.Fill;
                    Setting.ucSetting._Setting.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Setting Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLmSetting_MouseEnter(object sender, EventArgs e)
        {
            _btnSetting = true;
        }

        private void btnLmSetting_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnLmSetting.BackColor == clickColor)
                _btnSetting = true;
            else
                _btnSetting = false;
        }

        private void btnLmSetting_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnSetting == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }

        private void btnLmManage_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnLmManage == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }

        private void btnLmManage_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
                btnLmManage.BackColor = clickColor;

                MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
                _btnLmManage = true;

                //USER CONTROL LM MAKING OPEN
                pnlMain.Controls.Clear();
                if (!pnlMain.Controls.Contains(LM_Manage.ucLMManage._LMManage))
                {
                    pnlMain.Controls.Add(LM_Manage.ucLMManage._LMManage);
                    LM_Manage.ucLMManage._LMManage.Dock = DockStyle.Fill;
                    LM_Manage.ucLMManage._LMManage.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "User Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            _btnHome = true;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnHome.BackColor == clickColor)
                _btnHome = true;
            else
                _btnHome = false;
        }

        private void btnSurveyor_MouseEnter(object sender, EventArgs e)
        {
            _btnSurveyor = true;
        }

        private void btnSurveyor_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnSurveyor.BackColor == clickColor)
                _btnSurveyor = true;
            else
                _btnSurveyor = false;
        }

        private void btnSurveyor_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnSurveyor == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }
    }
}
