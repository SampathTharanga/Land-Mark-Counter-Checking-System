namespace LMCC_System
{
    partial class frmUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.txtSecAns = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.cbxSecQue = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbxDivision = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(23, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Type :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(23, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Username :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(407, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Users Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Re-enter Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(476, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "E-mail :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Security Question :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(476, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Mobile :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(476, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Security Answer :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(476, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Division :";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(146, 90);
            this.txtPass.MaxLength = 12;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(271, 20);
            this.txtPass.TabIndex = 27;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(146, 123);
            this.txtConfirmPass.MaxLength = 12;
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(271, 20);
            this.txtConfirmPass.TabIndex = 28;
            this.txtConfirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPass_Validating);
            // 
            // txtSecAns
            // 
            this.txtSecAns.Location = new System.Drawing.Point(587, 23);
            this.txtSecAns.MaxLength = 50;
            this.txtSecAns.Name = "txtSecAns";
            this.txtSecAns.Size = new System.Drawing.Size(271, 20);
            this.txtSecAns.TabIndex = 29;
            this.txtSecAns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecAns_KeyPress);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(587, 91);
            this.txtMobile.MaxLength = 10;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(271, 20);
            this.txtMobile.TabIndex = 30;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            this.txtMobile.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobile_Validating);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(587, 60);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(271, 20);
            this.txtEmail.TabIndex = 32;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "District",
            "Divisional"});
            this.cbxType.Location = new System.Drawing.Point(146, 56);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(271, 21);
            this.cbxType.TabIndex = 33;
            // 
            // cbxSecQue
            // 
            this.cbxSecQue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecQue.FormattingEnabled = true;
            this.cbxSecQue.Items.AddRange(new object[] {
            "What is your nick name?",
            "What is your favorite actress?",
            "What is your favorite animal?",
            "What is your favorite place?"});
            this.cbxSecQue.Location = new System.Drawing.Point(146, 156);
            this.cbxSecQue.Name = "cbxSecQue";
            this.cbxSecQue.Size = new System.Drawing.Size(271, 21);
            this.cbxSecQue.TabIndex = 34;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(146, 23);
            this.txtUsername.MaxLength = 15;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(271, 20);
            this.txtUsername.TabIndex = 35;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToResizeColumns = false;
            this.dgvUser.AllowUserToResizeRows = false;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(19, 318);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.Size = new System.Drawing.Size(881, 213);
            this.dgvUser.TabIndex = 36;
            this.dgvUser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvUser_MouseDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::LMCC_System.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(677, 187);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 28);
            this.btnAdd.TabIndex = 42;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(815, 542);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnnClear
            // 
            this.btnnClear.Image = global::LMCC_System.Properties.Resources.clear;
            this.btnnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnClear.Location = new System.Drawing.Point(773, 187);
            this.btnnClear.Name = "btnnClear";
            this.btnnClear.Size = new System.Drawing.Size(85, 28);
            this.btnnClear.TabIndex = 44;
            this.btnnClear.Text = "Clear";
            this.btnnClear.UseVisualStyleBackColor = false;
            this.btnnClear.Click += new System.EventHandler(this.btnnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxDivision);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnnClear);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.cbxSecQue);
            this.groupBox1.Controls.Add(this.cbxType);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.txtSecAns);
            this.groupBox1.Controls.Add(this.txtConfirmPass);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(19, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 232);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(30, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(572, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "*** Important : Must remember, you can not change again \"Username\" and \"Division\"" +
    ". Also you can not delete any user.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbxDivision
            // 
            this.cbxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDivision.FormattingEnabled = true;
            this.cbxDivision.Location = new System.Drawing.Point(587, 126);
            this.cbxDivision.Name = "cbxDivision";
            this.cbxDivision.Size = new System.Drawing.Size(271, 21);
            this.cbxDivision.TabIndex = 48;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(919, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(935, 623);
            this.MinimumSize = new System.Drawing.Size(935, 623);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users Details";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.TextBox txtSecAns;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.ComboBox cbxSecQue;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbxDivision;
    }
}