﻿namespace UTR_APP.Forms
{
    partial class NewEmployeeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.fullNameTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentCB = new System.Windows.Forms.ComboBox();
            this.emplyeeIDTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.emplTypeCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.errorLbl = new System.Windows.Forms.Label();
            this.roleTypesCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Full Name:";
            // 
            // fullNameTB
            // 
            this.fullNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameTB.Location = new System.Drawing.Point(25, 61);
            this.fullNameTB.Name = "fullNameTB";
            this.fullNameTB.Size = new System.Drawing.Size(355, 29);
            this.fullNameTB.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roleTypesCB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fullNameTB);
            this.groupBox1.Controls.Add(this.departmentCB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.emplTypeCB);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 279);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employment Information:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employee ID:";
            // 
            // departmentCB
            // 
            this.departmentCB.FormattingEnabled = true;
            this.departmentCB.Location = new System.Drawing.Point(182, 181);
            this.departmentCB.Name = "departmentCB";
            this.departmentCB.Size = new System.Drawing.Size(160, 29);
            this.departmentCB.TabIndex = 13;
            // 
            // emplyeeIDTB
            // 
            this.emplyeeIDTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emplyeeIDTB.Enabled = false;
            this.emplyeeIDTB.Location = new System.Drawing.Point(168, 118);
            this.emplyeeIDTB.Name = "emplyeeIDTB";
            this.emplyeeIDTB.Size = new System.Drawing.Size(160, 29);
            this.emplyeeIDTB.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Department:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Employement Type:";
            // 
            // emplTypeCB
            // 
            this.emplTypeCB.FormattingEnabled = true;
            this.emplTypeCB.Location = new System.Drawing.Point(182, 120);
            this.emplTypeCB.Name = "emplTypeCB";
            this.emplTypeCB.Size = new System.Drawing.Size(160, 29);
            this.emplTypeCB.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Generated password:";
            // 
            // passwordTB
            // 
            this.passwordTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTB.Enabled = false;
            this.passwordTB.Location = new System.Drawing.Point(30, 61);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(298, 29);
            this.passwordTB.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.generateBtn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.emplyeeIDTB);
            this.groupBox2.Controls.Add(this.passwordTB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(448, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 279);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Login information";
            // 
            // generateBtn
            // 
            this.generateBtn.Image = global::UTR_APP.Properties.Resources.magic_wand;
            this.generateBtn.Location = new System.Drawing.Point(122, 202);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(147, 38);
            this.generateBtn.TabIndex = 16;
            this.generateBtn.Text = "Generate";
            this.generateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.generateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // button2
            // 
            this.button2.Image = global::UTR_APP.Properties.Resources.floppy_disk;
            this.button2.Location = new System.Drawing.Point(662, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 38);
            this.button2.TabIndex = 17;
            this.button2.Text = "Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Image = global::UTR_APP.Properties.Resources.logout;
            this.button3.Location = new System.Drawing.Point(12, 401);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 38);
            this.button3.TabIndex = 18;
            this.button3.Text = "Close";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLbl.Location = new System.Drawing.Point(12, 317);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(52, 21);
            this.errorLbl.TabIndex = 19;
            this.errorLbl.Text = "label4";
            // 
            // roleTypesCB
            // 
            this.roleTypesCB.FormattingEnabled = true;
            this.roleTypesCB.Location = new System.Drawing.Point(182, 235);
            this.roleTypesCB.Name = "roleTypesCB";
            this.roleTypesCB.Size = new System.Drawing.Size(160, 29);
            this.roleTypesCB.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "Role:";
            // 
            // NewEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(846, 451);
            this.Controls.Add(this.errorLbl);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NewEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new employee details";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fullNameTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox departmentCB;
        private System.Windows.Forms.TextBox emplyeeIDTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox emplTypeCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label errorLbl;
        private System.Windows.Forms.ComboBox roleTypesCB;
        private System.Windows.Forms.Label label4;
    }
}