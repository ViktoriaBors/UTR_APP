namespace UTR_APP.Forms
{
    partial class ProjectsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.filterTb = new System.Windows.Forms.TextBox();
            this.projectDG = new System.Windows.Forms.DataGridView();
            this.addProject = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ColumnEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isactive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.projectDG)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(740, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Double click on the a cell to edit project";
            // 
            // filterTb
            // 
            this.filterTb.Location = new System.Drawing.Point(12, 10);
            this.filterTb.Name = "filterTb";
            this.filterTb.Size = new System.Drawing.Size(487, 29);
            this.filterTb.TabIndex = 26;
            this.filterTb.TextChanged += new System.EventHandler(this.filterTb_TextChanged);
            // 
            // projectDG
            // 
            this.projectDG.AllowUserToAddRows = false;
            this.projectDG.AllowUserToDeleteRows = false;
            this.projectDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.projectDG.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.projectDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEmployeeID,
            this.ColumnName,
            this.ColumnDepId,
            this.isactive});
            this.projectDG.Location = new System.Drawing.Point(12, 50);
            this.projectDG.Name = "projectDG";
            this.projectDG.Size = new System.Drawing.Size(937, 465);
            this.projectDG.TabIndex = 24;
            this.projectDG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectDG_CellDoubleClick);
            // 
            // addProject
            // 
            this.addProject.Image = global::UTR_APP.Properties.Resources.add__1_;
            this.addProject.Location = new System.Drawing.Point(798, 537);
            this.addProject.Name = "addProject";
            this.addProject.Size = new System.Drawing.Size(151, 38);
            this.addProject.TabIndex = 27;
            this.addProject.Text = "Add Project";
            this.addProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addProject.UseVisualStyleBackColor = true;
            this.addProject.Click += new System.EventHandler(this.addProject_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::UTR_APP.Properties.Resources.logout;
            this.closeBtn.Location = new System.Drawing.Point(12, 537);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(151, 38);
            this.closeBtn.TabIndex = 25;
            this.closeBtn.Text = "Close";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(505, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(169, 21);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Show deactived projects";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ColumnEmployeeID
            // 
            this.ColumnEmployeeID.HeaderText = "ID";
            this.ColumnEmployeeID.Name = "ColumnEmployeeID";
            this.ColumnEmployeeID.ReadOnly = true;
            this.ColumnEmployeeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnEmployeeID.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnDepId
            // 
            this.ColumnDepId.HeaderText = "Description";
            this.ColumnDepId.Name = "ColumnDepId";
            this.ColumnDepId.ReadOnly = true;
            this.ColumnDepId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // isactive
            // 
            this.isactive.HeaderText = "Active";
            this.isactive.Name = "isactive";
            this.isactive.ReadOnly = true;
            // 
            // ProjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(960, 601);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addProject);
            this.Controls.Add(this.filterTb);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.projectDG);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProjectsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projects";
            ((System.ComponentModel.ISupportInitialize)(this.projectDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addProject;
        private System.Windows.Forms.TextBox filterTb;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.DataGridView projectDG;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDepId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isactive;
    }
}