namespace GolfStatKeeper.Panels
{
    partial class PanelRound
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
            this.dtWhen = new System.Windows.Forms.DateTimePicker();
            this.cbCourse = new System.Windows.Forms.ComboBox();
            this.cbTees = new System.Windows.Forms.ComboBox();
            this.cbConditions = new System.Windows.Forms.ComboBox();
            this.dgvHolesPlayed = new System.Windows.Forms.DataGridView();
            this.dgvHoleDetails = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolesPlayed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoleDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dtWhen
            // 
            this.dtWhen.CustomFormat = "MMM dd,  yyyy";
            this.dtWhen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWhen.Location = new System.Drawing.Point(0, 37);
            this.dtWhen.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtWhen.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtWhen.Name = "dtWhen";
            this.dtWhen.Size = new System.Drawing.Size(118, 20);
            this.dtWhen.TabIndex = 0;
            // 
            // cbCourse
            // 
            this.cbCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCourse.FormattingEnabled = true;
            this.cbCourse.Location = new System.Drawing.Point(3, 10);
            this.cbCourse.Name = "cbCourse";
            this.cbCourse.Size = new System.Drawing.Size(248, 21);
            this.cbCourse.TabIndex = 1;
            this.cbCourse.SelectedIndexChanged += new System.EventHandler(this.cbCourse_SelectedIndexChanged);
            // 
            // cbTees
            // 
            this.cbTees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTees.FormattingEnabled = true;
            this.cbTees.Location = new System.Drawing.Point(257, 10);
            this.cbTees.Name = "cbTees";
            this.cbTees.Size = new System.Drawing.Size(102, 21);
            this.cbTees.TabIndex = 2;
            this.cbTees.SelectedIndexChanged += new System.EventHandler(this.cbTees_SelectedIndexChanged);
            // 
            // cbConditions
            // 
            this.cbConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConditions.FormattingEnabled = true;
            this.cbConditions.Location = new System.Drawing.Point(124, 37);
            this.cbConditions.Name = "cbConditions";
            this.cbConditions.Size = new System.Drawing.Size(235, 21);
            this.cbConditions.TabIndex = 3;
            // 
            // dgvHolesPlayed
            // 
            this.dgvHolesPlayed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHolesPlayed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHolesPlayed.Location = new System.Drawing.Point(0, 67);
            this.dgvHolesPlayed.MultiSelect = false;
            this.dgvHolesPlayed.Name = "dgvHolesPlayed";
            this.dgvHolesPlayed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.dgvHolesPlayed.Size = new System.Drawing.Size(555, 150);
            this.dgvHolesPlayed.TabIndex = 4;
            this.dgvHolesPlayed.SelectionChanged += new System.EventHandler(this.dgvHolesPlayed_SelectionChanged);
            // 
            // dgvHoleDetails
            // 
            this.dgvHoleDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHoleDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoleDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dgvHoleDetails.Location = new System.Drawing.Point(0, 232);
            this.dgvHoleDetails.Name = "dgvHoleDetails";
            this.dgvHoleDetails.RowHeadersVisible = false;
            this.dgvHoleDetails.Size = new System.Drawing.Size(436, 150);
            this.dgvHoleDetails.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(480, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(480, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Column3
            // 
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "Shot Number";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Lie";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Club";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Length";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Result";
            this.Column5.Name = "Column5";
            // 
            // PanelRound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvHoleDetails);
            this.Controls.Add(this.dgvHolesPlayed);
            this.Controls.Add(this.cbConditions);
            this.Controls.Add(this.cbTees);
            this.Controls.Add(this.cbCourse);
            this.Controls.Add(this.dtWhen);
            this.Name = "PanelRound";
            this.Size = new System.Drawing.Size(561, 382);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolesPlayed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoleDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtWhen;
        private System.Windows.Forms.ComboBox cbCourse;
        private System.Windows.Forms.ComboBox cbTees;
        private System.Windows.Forms.ComboBox cbConditions;
        private System.Windows.Forms.DataGridView dgvHolesPlayed;
        private System.Windows.Forms.DataGridView dgvHoleDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
