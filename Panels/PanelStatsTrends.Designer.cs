namespace GolfStatKeeper.Panels
{
    partial class PanelStatsTrends
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoundCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cbPenalties = new System.Windows.Forms.CheckBox();
            this.cbPutts = new System.Windows.Forms.CheckBox();
            this.cbGIR = new System.Windows.Forms.CheckBox();
            this.cbFairways = new System.Windows.Forms.CheckBox();
            this.cbScore = new System.Windows.Forms.CheckBox();
            this.chart1 = new GolfStatKeeper.Chart();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.gbItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Controls.Add(this.dgvCourses);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.dtpTo);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.dtpFrom);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(230, 233);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select Courses";
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.AllowUserToResizeRows = false;
            this.dgvCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Course,
            this.RoundCount});
            this.dgvCourses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCourses.Location = new System.Drawing.Point(6, 73);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(218, 154);
            this.dgvCourses.TabIndex = 4;
            // 
            // Course
            // 
            this.Course.HeaderText = "Course";
            this.Course.Name = "Course";
            // 
            // RoundCount
            // 
            this.RoundCount.FillWeight = 20F;
            this.RoundCount.HeaderText = "#";
            this.RoundCount.Name = "RoundCount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(122, 34);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(99, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(6, 34);
            this.dtpFrom.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(99, 20);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.Value = new System.DateTime(1990, 1, 1, 22, 24, 0, 0);
            // 
            // gbItems
            // 
            this.gbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbItems.BackColor = System.Drawing.Color.Gray;
            this.gbItems.Controls.Add(this.btnGenerate);
            this.gbItems.Controls.Add(this.cbPenalties);
            this.gbItems.Controls.Add(this.cbPutts);
            this.gbItems.Controls.Add(this.cbGIR);
            this.gbItems.Controls.Add(this.cbFairways);
            this.gbItems.Controls.Add(this.cbScore);
            this.gbItems.Location = new System.Drawing.Point(3, 242);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(230, 259);
            this.gbItems.TabIndex = 2;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Items to Chart";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(44, 119);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cbPenalties
            // 
            this.cbPenalties.AutoSize = true;
            this.cbPenalties.ForeColor = System.Drawing.Color.Red;
            this.cbPenalties.Location = new System.Drawing.Point(122, 76);
            this.cbPenalties.Name = "cbPenalties";
            this.cbPenalties.Size = new System.Drawing.Size(69, 17);
            this.cbPenalties.TabIndex = 4;
            this.cbPenalties.Text = "Penalties";
            this.cbPenalties.UseVisualStyleBackColor = true;
            // 
            // cbPutts
            // 
            this.cbPutts.AutoSize = true;
            this.cbPutts.ForeColor = System.Drawing.Color.Orange;
            this.cbPutts.Location = new System.Drawing.Point(9, 76);
            this.cbPutts.Name = "cbPutts";
            this.cbPutts.Size = new System.Drawing.Size(50, 17);
            this.cbPutts.TabIndex = 3;
            this.cbPutts.Text = "Putts";
            this.cbPutts.UseVisualStyleBackColor = true;
            // 
            // cbGIR
            // 
            this.cbGIR.AutoSize = true;
            this.cbGIR.ForeColor = System.Drawing.Color.Blue;
            this.cbGIR.Location = new System.Drawing.Point(122, 53);
            this.cbGIR.Name = "cbGIR";
            this.cbGIR.Size = new System.Drawing.Size(56, 17);
            this.cbGIR.TabIndex = 2;
            this.cbGIR.Text = "GIR %";
            this.cbGIR.UseVisualStyleBackColor = true;
            // 
            // cbFairways
            // 
            this.cbFairways.AutoSize = true;
            this.cbFairways.ForeColor = System.Drawing.Color.Yellow;
            this.cbFairways.Location = new System.Drawing.Point(9, 53);
            this.cbFairways.Name = "cbFairways";
            this.cbFairways.Size = new System.Drawing.Size(73, 17);
            this.cbFairways.TabIndex = 1;
            this.cbFairways.Text = "Fairway %";
            this.cbFairways.UseVisualStyleBackColor = true;
            // 
            // cbScore
            // 
            this.cbScore.AutoSize = true;
            this.cbScore.ForeColor = System.Drawing.Color.White;
            this.cbScore.Location = new System.Drawing.Point(9, 30);
            this.cbScore.Name = "cbScore";
            this.cbScore.Size = new System.Drawing.Size(54, 17);
            this.cbScore.TabIndex = 0;
            this.cbScore.Text = "Score";
            this.cbScore.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.DataSource = null;
            this.chart1.Location = new System.Drawing.Point(239, 3);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(499, 501);
            this.chart1.TabIndex = 3;
            // 
            // PanelStatsTrends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.gbItems);
            this.Controls.Add(this.gbFilter);
            this.Name = "PanelStatsTrends";
            this.Size = new System.Drawing.Size(738, 504);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.gbItems.ResumeLayout(false);
            this.gbItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoundCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.CheckBox cbScore;
        private System.Windows.Forms.CheckBox cbPutts;
        private System.Windows.Forms.CheckBox cbGIR;
        private System.Windows.Forms.CheckBox cbFairways;
        private System.Windows.Forms.CheckBox cbPenalties;
        private System.Windows.Forms.Button btnGenerate;
        private Chart chart1;
    }
}
