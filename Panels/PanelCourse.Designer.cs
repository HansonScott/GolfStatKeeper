namespace GolfStatKeeper.Panels
{
    partial class PanelCourse
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCourseName = new System.Windows.Forms.Label();
            this.tbCourseName = new System.Windows.Forms.TextBox();
            this.dgvCourseData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreateCourse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblHoleData = new System.Windows.Forms.Label();
            this.dgvHoleData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoleData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Location = new System.Drawing.Point(3, 9);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(74, 13);
            this.lblCourseName.TabIndex = 0;
            this.lblCourseName.Text = "Course Name:";
            // 
            // tbCourseName
            // 
            this.tbCourseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCourseName.Location = new System.Drawing.Point(83, 7);
            this.tbCourseName.Name = "tbCourseName";
            this.tbCourseName.Size = new System.Drawing.Size(356, 20);
            this.tbCourseName.TabIndex = 1;
            // 
            // dgvCourseData
            // 
            this.dgvCourseData.AllowUserToAddRows = false;
            this.dgvCourseData.AllowUserToDeleteRows = false;
            this.dgvCourseData.AllowUserToResizeColumns = false;
            this.dgvCourseData.AllowUserToResizeRows = false;
            this.dgvCourseData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourseData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourseData.ColumnHeadersVisible = false;
            this.dgvCourseData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvCourseData.Location = new System.Drawing.Point(83, 33);
            this.dgvCourseData.MultiSelect = false;
            this.dgvCourseData.Name = "dgvCourseData";
            this.dgvCourseData.RowHeadersVisible = false;
            this.dgvCourseData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCourseData.Size = new System.Drawing.Size(163, 72);
            this.dgvCourseData.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            // 
            // btnCreateCourse
            // 
            this.btnCreateCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCourse.Location = new System.Drawing.Point(445, 4);
            this.btnCreateCourse.Name = "btnCreateCourse";
            this.btnCreateCourse.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCourse.TabIndex = 3;
            this.btnCreateCourse.Text = "Create New";
            this.btnCreateCourse.UseVisualStyleBackColor = true;
            this.btnCreateCourse.Click += new System.EventHandler(this.btnCreateCourse_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(526, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(445, 33);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(526, 33);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblHoleData
            // 
            this.lblHoleData.AutoSize = true;
            this.lblHoleData.Location = new System.Drawing.Point(14, 125);
            this.lblHoleData.Name = "lblHoleData";
            this.lblHoleData.Size = new System.Drawing.Size(55, 13);
            this.lblHoleData.TabIndex = 7;
            this.lblHoleData.Text = "Hole Data";
            // 
            // dgvHoleData
            // 
            this.dgvHoleData.AllowUserToAddRows = false;
            this.dgvHoleData.AllowUserToDeleteRows = false;
            this.dgvHoleData.AllowUserToOrderColumns = true;
            this.dgvHoleData.AllowUserToResizeRows = false;
            this.dgvHoleData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoleData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoleData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoleData.ColumnHeadersVisible = false;
            this.dgvHoleData.Location = new System.Drawing.Point(3, 141);
            this.dgvHoleData.Name = "dgvHoleData";
            this.dgvHoleData.RowHeadersVisible = false;
            this.dgvHoleData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvHoleData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHoleData.Size = new System.Drawing.Size(601, 95);
            this.dgvHoleData.TabIndex = 8;
            // 
            // PanelCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHoleData);
            this.Controls.Add(this.lblHoleData);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCreateCourse);
            this.Controls.Add(this.dgvCourseData);
            this.Controls.Add(this.tbCourseName);
            this.Controls.Add(this.lblCourseName);
            this.Name = "PanelCourse";
            this.Size = new System.Drawing.Size(604, 446);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoleData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.TextBox tbCourseName;
        private System.Windows.Forms.DataGridView dgvCourseData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnCreateCourse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblHoleData;
        private System.Windows.Forms.DataGridView dgvHoleData;
    }
}
