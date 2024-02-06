namespace UTR_APP.Forms
{
    partial class ProjectOverviewForm
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
            this.allHistoryDG = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.projectCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.workedHoursLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chartBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.allHistoryDG)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // allHistoryDG
            // 
            this.allHistoryDG.AllowUserToAddRows = false;
            this.allHistoryDG.AllowUserToDeleteRows = false;
            this.allHistoryDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.allHistoryDG.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.allHistoryDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allHistoryDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ColumnProjectID,
            this.EmployeeID,
            this.UserID,
            this.hours,
            this.Date,
            this.ColumnName,
            this.Modified});
            this.allHistoryDG.Location = new System.Drawing.Point(12, 94);
            this.allHistoryDG.Name = "allHistoryDG";
            this.allHistoryDG.Size = new System.Drawing.Size(927, 418);
            this.allHistoryDG.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(533, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 21);
            this.label8.TabIndex = 37;
            this.label8.Text = "Filter project";
            // 
            // projectCB
            // 
            this.projectCB.FormattingEnabled = true;
            this.projectCB.Location = new System.Drawing.Point(528, 42);
            this.projectCB.Name = "projectCB";
            this.projectCB.Size = new System.Drawing.Size(206, 29);
            this.projectCB.TabIndex = 36;
            this.projectCB.SelectedIndexChanged += new System.EventHandler(this.projectCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 21);
            this.label1.TabIndex = 34;
            this.label1.Text = "From";
            // 
            // toDatePicker
            // 
            this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePicker.Location = new System.Drawing.Point(252, 42);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(135, 29);
            this.toDatePicker.TabIndex = 33;
            this.toDatePicker.Value = new System.DateTime(2024, 1, 26, 18, 25, 4, 0);
            this.toDatePicker.ValueChanged += new System.EventHandler(this.toDatePicker_ValueChanged);
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePicker.Location = new System.Drawing.Point(12, 42);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(135, 29);
            this.fromDatePicker.TabIndex = 32;
            this.fromDatePicker.Value = new System.DateTime(2024, 1, 26, 18, 25, 4, 0);
            this.fromDatePicker.ValueChanged += new System.EventHandler(this.fromDatePicker_ValueChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ColumnProjectID
            // 
            this.ColumnProjectID.HeaderText = "Project";
            this.ColumnProjectID.Name = "ColumnProjectID";
            this.ColumnProjectID.ReadOnly = true;
            this.ColumnProjectID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnProjectID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EmployeeID
            // 
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "Employee";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // hours
            // 
            this.hours.HeaderText = "Worked Hours";
            this.hours.Name = "hours";
            this.hours.ReadOnly = true;
            this.hours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Description";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Modified
            // 
            this.Modified.HeaderText = "Modified";
            this.Modified.Name = "Modified";
            this.Modified.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.workedHoursLBL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Enabled = false;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(693, 518);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 92);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            // 
            // workedHoursLBL
            // 
            this.workedHoursLBL.AutoSize = true;
            this.workedHoursLBL.Location = new System.Drawing.Point(161, 42);
            this.workedHoursLBL.Name = "workedHoursLBL";
            this.workedHoursLBL.Size = new System.Drawing.Size(19, 21);
            this.workedHoursLBL.TabIndex = 31;
            this.workedHoursLBL.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "Worked Sum Hours:";
            // 
            // chartBtn
            // 
            this.chartBtn.Image = global::UTR_APP.Properties.Resources.bar_chart;
            this.chartBtn.Location = new System.Drawing.Point(788, 39);
            this.chartBtn.Name = "chartBtn";
            this.chartBtn.Size = new System.Drawing.Size(151, 38);
            this.chartBtn.TabIndex = 40;
            this.chartBtn.Text = "See chart";
            this.chartBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chartBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chartBtn.UseVisualStyleBackColor = true;
            this.chartBtn.Click += new System.EventHandler(this.chartBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::UTR_APP.Properties.Resources.logout;
            this.closeBtn.Location = new System.Drawing.Point(12, 584);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(151, 38);
            this.closeBtn.TabIndex = 38;
            this.closeBtn.Text = "Close";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // ProjectOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(961, 634);
            this.Controls.Add(this.chartBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.projectCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.allHistoryDG);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProjectOverviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Overview";
            ((System.ComponentModel.ISupportInitialize)(this.allHistoryDG)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView allHistoryDG;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox projectCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modified;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label workedHoursLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button chartBtn;
    }
}