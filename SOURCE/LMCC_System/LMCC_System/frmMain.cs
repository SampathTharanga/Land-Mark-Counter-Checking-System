﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;//BUSINESS LOOGIC LAYER

namespace LMCC_System
{
    public partial class frmMain : Form
    {
        //LEFT MENU BUTTON COLORS
        Color leaveColor = Color.FromArgb(38, 50, 64),
              clickColor = Color.FromArgb(52, 70, 87);

        //LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
        bool _btnHome = false,
             _btnSurveyor = false,
             _btnLmMaking = false,
             _btnLmIssue = false,
             _btnLmSttle = false,
             _btnLmRecived = false,
             _btnReport = false,
             _btnHelp = false;

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
            _btnLmIssue = false;
            _btnLmSttle = false;
            _btnLmRecived = false;
            _btnReport = false;
            _btnHelp = false;
        }
        private void frmMain_Load(object sender, EventArgs e)
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
        }

        private void btnHome_Click(object sender, EventArgs e)
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

        private void btnLmMaking_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnLmMaking == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }

        private void btnLmIssue_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnLmIssue == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }

        private void btnLmSttle_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnLmSttle == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
        }

        private void btnLmRecived_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnLmRecived == true)
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

        private void btnLmIssue_MouseEnter(object sender, EventArgs e)
        {
            _btnLmIssue = true;
        }

        private void btnLmSttle_MouseEnter(object sender, EventArgs e)
        {
            _btnLmSttle = true;
        }

        private void btnLmRecived_MouseEnter(object sender, EventArgs e)
        {
            _btnLmRecived = true;
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

        private void btnLmIssue_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnLmIssue.BackColor == clickColor)
                _btnLmIssue = true;
            else
                _btnLmIssue = false;
        }

        private void btnLmSttle_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnLmSttle.BackColor == clickColor)
                _btnLmSttle = true;
            else
                _btnLmSttle = false;
        }

        private void btnLmRecived_MouseLeave(object sender, EventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (btnLmRecived.BackColor == clickColor)
                _btnLmRecived = true;
            else
                _btnLmRecived = false;
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

        private void btnLmIssue_Click(object sender, EventArgs e)
        {
            DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
            btnLmIssue.BackColor = clickColor;

            MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
            _btnLmIssue = true;

            //USER CONTROL LM ISSUE OPEN
            pnlMain.Controls.Clear();
            if (!pnlMain.Controls.Contains(ucLMIssue._ucLMIssue))
            {
                pnlMain.Controls.Add(ucLMIssue._ucLMIssue);
                ucLMIssue._ucLMIssue.Dock = DockStyle.Fill;
                ucLMIssue._ucLMIssue.BringToFront();
            }
        }

        private void btnLmSttle_Click(object sender, EventArgs e)
        {
            DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
            btnLmSttle.BackColor = clickColor;

            MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
            _btnLmSttle = true;

            //USER CONTROL LM SETTLE OPEN
            pnlMain.Controls.Clear();
            if (!pnlMain.Controls.Contains(ucLMSettle._ucLMSettle))
            {
                pnlMain.Controls.Add(ucLMSettle._ucLMSettle);
                ucLMSettle._ucLMSettle.Dock = DockStyle.Fill;
                ucLMSettle._ucLMSettle.BringToFront();
            }
        }

        private void btnLmRecived_Click(object sender, EventArgs e)
        {
            DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
            btnLmRecived.BackColor = clickColor;

            MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
            _btnLmRecived = true;

            //USER CONTROL LM SETTLE OPEN
            pnlMain.Controls.Clear();
            if (!pnlMain.Controls.Contains(ucLMReceived._ucLMReceived))
            {
                pnlMain.Controls.Add(ucLMReceived._ucLMReceived);
                ucLMReceived._ucLMReceived.Dock = DockStyle.Fill;
                ucLMReceived._ucLMReceived.BringToFront();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
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

        private void lblCommenDetails_Click(object sender, EventArgs e)
        {
            //COMMON DETAILS FORM OPEN
            frmCommonDetails frmCom = new frmCommonDetails();
            frmCom.ShowDialog();
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

        private void btnSurveyor_Click(object sender, EventArgs e)
        {
            DefaultColorSetAllMenuButtons(pnlLeftMenu);//DEFAULT COLOR SET LEFT MENU ALL BUTTONS
            btnSurveyor.BackColor = clickColor;

            MenuButtonDefaultValSet();//LEFT MENU ALL BUTTON BLUE COLOR LINE DISABLE
            _btnSurveyor = true;

            //USER CONTROL SURVEYOR OPEN
            pnlMain.Controls.Clear();
            if(!pnlMain.Controls.Contains(ucSurveyor._Surveyor))
            {
                pnlMain.Controls.Add(ucSurveyor._Surveyor);
                ucSurveyor._Surveyor.Dock = DockStyle.Fill;
                ucSurveyor._Surveyor.BringToFront();
            }
        }

        private void btnHome_Paint(object sender, PaintEventArgs e)
        {
            //CLICK COLOR OR LEAVE COLOR SET
            if (_btnHome == true)
                ButtonLeftBlueColorLine_Show(sender, e);
            else
                ButtonLeftBlueColorLine_Hide(sender, e);
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