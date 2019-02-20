namespace GolfStatKeeper.Panels
{
    partial class PanelStatsSummary
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
            this.dgvHoleSummary = new System.Windows.Forms.DataGridView();
            this.Item1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDriving = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvIrons = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPutting = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoleSummary)).BeginInit();
            this.gbSummary.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriving)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIrons)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPutting)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Controls.Add(this.dgvCourses);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.dtpTo);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.dtpFrom);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(230, 233);
            this.gbFilter.TabIndex = 0;
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
            this.dgvCourses.SelectionChanged += new System.EventHandler(this.dgvCourses_SelectionChanged);
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
            // dgvHoleSummary
            // 
            this.dgvHoleSummary.AllowUserToAddRows = false;
            this.dgvHoleSummary.AllowUserToDeleteRows = false;
            this.dgvHoleSummary.AllowUserToResizeRows = false;
            this.dgvHoleSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoleSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoleSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoleSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item1,
            this.Value1,
            this.ColumnSpacer,
            this.Item2,
            this.Value2});
            this.dgvHoleSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHoleSummary.Location = new System.Drawing.Point(6, 19);
            this.dgvHoleSummary.Name = "dgvHoleSummary";
            this.dgvHoleSummary.RowHeadersVisible = false;
            this.dgvHoleSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHoleSummary.Size = new System.Drawing.Size(430, 184);
            this.dgvHoleSummary.TabIndex = 1;
            // 
            // Item1
            // 
            this.Item1.HeaderText = "Item";
            this.Item1.Name = "Item1";
            // 
            // Value1
            // 
            this.Value1.FillWeight = 50F;
            this.Value1.HeaderText = "Value";
            this.Value1.Name = "Value1";
            // 
            // ColumnSpacer
            // 
            this.ColumnSpacer.FillWeight = 20F;
            this.ColumnSpacer.HeaderText = "";
            this.ColumnSpacer.Name = "ColumnSpacer";
            // 
            // Item2
            // 
            this.Item2.HeaderText = "Item";
            this.Item2.Name = "Item2";
            // 
            // Value2
            // 
            this.Value2.FillWeight = 50F;
            this.Value2.HeaderText = "Value";
            this.Value2.Name = "Value2";
            // 
            // gbSummary
            // 
            this.gbSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSummary.Controls.Add(this.dgvHoleSummary);
            this.gbSummary.Location = new System.Drawing.Point(239, 3);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(442, 209);
            this.gbSummary.TabIndex = 2;
            this.gbSummary.TabStop = false;
            this.gbSummary.Text = "Hole Summary";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dgvDriving);
            this.groupBox1.Location = new System.Drawing.Point(3, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 166);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driving";
            // 
            // dgvDriving
            // 
            this.dgvDriving.AllowUserToAddRows = false;
            this.dgvDriving.AllowUserToDeleteRows = false;
            this.dgvDriving.AllowUserToResizeRows = false;
            this.dgvDriving.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDriving.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDriving.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriving.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvDriving.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDriving.Location = new System.Drawing.Point(9, 19);
            this.dgvDriving.Name = "dgvDriving";
            this.dgvDriving.RowHeadersVisible = false;
            this.dgvDriving.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDriving.Size = new System.Drawing.Size(215, 141);
            this.dgvDriving.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Item";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 25F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.dgvIrons);
            this.groupBox2.Location = new System.Drawing.Point(233, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 166);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Irons";
            // 
            // dgvIrons
            // 
            this.dgvIrons.AllowUserToAddRows = false;
            this.dgvIrons.AllowUserToDeleteRows = false;
            this.dgvIrons.AllowUserToResizeRows = false;
            this.dgvIrons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIrons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIrons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIrons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvIrons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIrons.Location = new System.Drawing.Point(9, 19);
            this.dgvIrons.Name = "dgvIrons";
            this.dgvIrons.RowHeadersVisible = false;
            this.dgvIrons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvIrons.Size = new System.Drawing.Size(215, 141);
            this.dgvIrons.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Item";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 25F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvPutting);
            this.groupBox3.Location = new System.Drawing.Point(463, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 166);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Putting";
            // 
            // dgvPutting
            // 
            this.dgvPutting.AllowUserToAddRows = false;
            this.dgvPutting.AllowUserToDeleteRows = false;
            this.dgvPutting.AllowUserToResizeRows = false;
            this.dgvPutting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPutting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPutting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPutting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvPutting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPutting.Location = new System.Drawing.Point(9, 19);
            this.dgvPutting.Name = "dgvPutting";
            this.dgvPutting.RowHeadersVisible = false;
            this.dgvPutting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPutting.Size = new System.Drawing.Size(206, 141);
            this.dgvPutting.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Item";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 25F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // PanelStatsSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSummary);
            this.Controls.Add(this.gbFilter);
            this.Name = "PanelStatsSummary";
            this.Size = new System.Drawing.Size(684, 421);
            this.Load += new System.EventHandler(this.PanelStatsSummary_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoleSummary)).EndInit();
            this.gbSummary.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriving)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIrons)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPutting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.DataGridView dgvHoleSummary;
        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoundCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpacer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDriving;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvIrons;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPutting;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
