namespace UTR_APP.Forms
{
    partial class SettingsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentCB = new System.Windows.Forms.ComboBox();
            this.emplyeeIDTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.emplTypeCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.adressTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fullNameTB = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sumRB = new System.Windows.Forms.RadioButton();
            this.periodRB = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.weeklyNotCheckB = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.newPwd2TB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.newPwd1TB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.currentPwdTB = new System.Windows.Forms.TextBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.errorLbl = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 368);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.emailTB);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.adressTB);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.fullNameTB);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(787, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Information";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.departmentCB);
            this.groupBox1.Controls.Add(this.emplyeeIDTB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.emplTypeCB);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(418, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 276);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employment Information:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employee ID:";
            // 
            // departmentCB
            // 
            this.departmentCB.Enabled = false;
            this.departmentCB.FormattingEnabled = true;
            this.departmentCB.Location = new System.Drawing.Point(167, 206);
            this.departmentCB.Name = "departmentCB";
            this.departmentCB.Size = new System.Drawing.Size(160, 28);
            this.departmentCB.TabIndex = 13;
            // 
            // emplyeeIDTB
            // 
            this.emplyeeIDTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emplyeeIDTB.Enabled = false;
            this.emplyeeIDTB.Location = new System.Drawing.Point(167, 38);
            this.emplyeeIDTB.Name = "emplyeeIDTB";
            this.emplyeeIDTB.Size = new System.Drawing.Size(160, 27);
            this.emplyeeIDTB.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Department:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Employement Type:";
            // 
            // emplTypeCB
            // 
            this.emplTypeCB.Enabled = false;
            this.emplTypeCB.FormattingEnabled = true;
            this.emplTypeCB.Location = new System.Drawing.Point(167, 118);
            this.emplTypeCB.Name = "emplTypeCB";
            this.emplTypeCB.Size = new System.Drawing.Size(160, 28);
            this.emplTypeCB.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email address:";
            // 
            // emailTB
            // 
            this.emailTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailTB.Location = new System.Drawing.Point(21, 225);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(377, 27);
            this.emailTB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address:";
            // 
            // adressTB
            // 
            this.adressTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adressTB.Location = new System.Drawing.Point(21, 141);
            this.adressTB.Name = "adressTB";
            this.adressTB.Size = new System.Drawing.Size(377, 27);
            this.adressTB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Full Name:";
            // 
            // fullNameTB
            // 
            this.fullNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameTB.Location = new System.Drawing.Point(21, 59);
            this.fullNameTB.Name = "fullNameTB";
            this.fullNameTB.Size = new System.Drawing.Size(377, 27);
            this.fullNameTB.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.sumRB);
            this.tabPage2.Controls.Add(this.periodRB);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.weeklyNotCheckB);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(787, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notification and Registration Settings";
            // 
            // sumRB
            // 
            this.sumRB.AutoSize = true;
            this.sumRB.Location = new System.Drawing.Point(553, 142);
            this.sumRB.Name = "sumRB";
            this.sumRB.Size = new System.Drawing.Size(162, 24);
            this.sumRB.TabIndex = 5;
            this.sumRB.TabStop = true;
            this.sumRB.Text = "Sum of time - based";
            this.sumRB.UseVisualStyleBackColor = true;
            // 
            // periodRB
            // 
            this.periodRB.AutoSize = true;
            this.periodRB.Location = new System.Drawing.Point(53, 142);
            this.periodRB.Name = "periodRB";
            this.periodRB.Size = new System.Drawing.Size(115, 24);
            this.periodRB.TabIndex = 4;
            this.periodRB.TabStop = true;
            this.periodRB.Text = "Period-based";
            this.periodRB.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Time registration style";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(203, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "(Email required)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(357, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Weekly notification about sum of hours and statistics";
            // 
            // weeklyNotCheckB
            // 
            this.weeklyNotCheckB.AutoSize = true;
            this.weeklyNotCheckB.Location = new System.Drawing.Point(16, 48);
            this.weeklyNotCheckB.Name = "weeklyNotCheckB";
            this.weeklyNotCheckB.Size = new System.Drawing.Size(155, 24);
            this.weeklyNotCheckB.TabIndex = 0;
            this.weeklyNotCheckB.Text = "Weekly notification";
            this.weeklyNotCheckB.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.pictureBox3);
            this.tabPage3.Controls.Add(this.pictureBox2);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.newPwd2TB);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.newPwd1TB);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.currentPwdTB);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(787, 332);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Password Change";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::UTR_APP.Properties.Resources.view;
            this.pictureBox3.Location = new System.Drawing.Point(414, 213);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::UTR_APP.Properties.Resources.view;
            this.pictureBox2.Location = new System.Drawing.Point(414, 129);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UTR_APP.Properties.Resources.view;
            this.pictureBox1.Location = new System.Drawing.Point(414, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "New Password Again:";
            // 
            // newPwd2TB
            // 
            this.newPwd2TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newPwd2TB.Location = new System.Drawing.Point(21, 212);
            this.newPwd2TB.Name = "newPwd2TB";
            this.newPwd2TB.Size = new System.Drawing.Size(377, 27);
            this.newPwd2TB.TabIndex = 12;
            this.newPwd2TB.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "New Password:";
            // 
            // newPwd1TB
            // 
            this.newPwd1TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newPwd1TB.Location = new System.Drawing.Point(21, 128);
            this.newPwd1TB.Name = "newPwd1TB";
            this.newPwd1TB.Size = new System.Drawing.Size(377, 27);
            this.newPwd1TB.TabIndex = 10;
            this.newPwd1TB.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "Current Password:";
            // 
            // currentPwdTB
            // 
            this.currentPwdTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentPwdTB.Enabled = false;
            this.currentPwdTB.Location = new System.Drawing.Point(21, 46);
            this.currentPwdTB.Name = "currentPwdTB";
            this.currentPwdTB.Size = new System.Drawing.Size(377, 27);
            this.currentPwdTB.TabIndex = 8;
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::UTR_APP.Properties.Resources.logout;
            this.closeBtn.Location = new System.Drawing.Point(10, 415);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(151, 38);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Close";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Image = global::UTR_APP.Properties.Resources.floppy_disk;
            this.saveBtn.Location = new System.Drawing.Point(644, 415);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(147, 38);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "Save";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLbl.ForeColor = System.Drawing.Color.IndianRed;
            this.errorLbl.Location = new System.Drawing.Point(12, 383);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(51, 20);
            this.errorLbl.TabIndex = 14;
            this.errorLbl.Text = "[error]";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(795, 465);
            this.Controls.Add(this.errorLbl);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox emplyeeIDTB;
        private System.Windows.Forms.TextBox fullNameTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox adressTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox departmentCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox emplTypeCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton sumRB;
        private System.Windows.Forms.RadioButton periodRB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox weeklyNotCheckB;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox newPwd2TB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox newPwd1TB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox currentPwdTB;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label errorLbl;
    }
}