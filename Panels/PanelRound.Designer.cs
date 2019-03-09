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
            this.components = new System.ComponentModel.Container();
            this.dtWhen = new System.Windows.Forms.DateTimePicker();
            this.cbCourse = new System.Windows.Forms.ComboBox();
            this.cbConditions = new System.Windows.Forms.ComboBox();
            this.dgvHoles = new System.Windows.Forms.DataGridView();
            this.dgvShots = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ballLieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ballFlightBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.shotResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nud_Penalties = new System.Windows.Forms.NumericUpDown();
            this.lblPenalties = new System.Windows.Forms.Label();
            this.btnSaveHole = new System.Windows.Forms.Button();
            this.btnSaveNext = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnPopulateShots = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballLieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballFlightBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shotResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Penalties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtWhen
            // 
            this.dtWhen.CustomFormat = "MMM dd,  yyyy";
            this.dtWhen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWhen.Location = new System.Drawing.Point(0, 37);
            this.dtWhen.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtWhen.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtWhen.Name = "dtWhen";
            this.dtWhen.Size = new System.Drawing.Size(118, 20);
            this.dtWhen.TabIndex = 0;
            this.dtWhen.ValueChanged += new System.EventHandler(this.dtWhen_ValueChanged);
            // 
            // cbCourse
            // 
            this.cbCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCourse.FormattingEnabled = true;
            this.cbCourse.Location = new System.Drawing.Point(3, 10);
            this.cbCourse.Name = "cbCourse";
            this.cbCourse.Size = new System.Drawing.Size(471, 21);
            this.cbCourse.TabIndex = 1;
            this.cbCourse.SelectedIndexChanged += new System.EventHandler(this.cbCourse_SelectedIndexChanged);
            // 
            // cbConditions
            // 
            this.cbConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConditions.FormattingEnabled = true;
            this.cbConditions.Location = new System.Drawing.Point(124, 37);
            this.cbConditions.Name = "cbConditions";
            this.cbConditions.Size = new System.Drawing.Size(350, 21);
            this.cbConditions.TabIndex = 3;
            this.cbConditions.SelectedIndexChanged += new System.EventHandler(this.cbConditions_SelectedIndexChanged);
            // 
            // dgvHoles
            // 
            this.dgvHoles.AllowUserToAddRows = false;
            this.dgvHoles.AllowUserToDeleteRows = false;
            this.dgvHoles.AllowUserToResizeRows = false;
            this.dgvHoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoles.ColumnHeadersVisible = false;
            this.dgvHoles.Location = new System.Drawing.Point(0, 67);
            this.dgvHoles.MultiSelect = false;
            this.dgvHoles.Name = "dgvHoles";
            this.dgvHoles.RowHeadersVisible = false;
            this.dgvHoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.dgvHoles.Size = new System.Drawing.Size(451, 175);
            this.dgvHoles.TabIndex = 4;
            this.dgvHoles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoles_CellValueChanged);
            this.dgvHoles.SelectionChanged += new System.EventHandler(this.dgvHolesPlayed_SelectionChanged);
            // 
            // dgvShots
            // 
            this.dgvShots.AllowUserToAddRows = false;
            this.dgvShots.AllowUserToDeleteRows = false;
            this.dgvShots.AllowUserToResizeRows = false;
            this.dgvShots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvShots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column6});
            this.dgvShots.Location = new System.Drawing.Point(0, 248);
            this.dgvShots.MultiSelect = false;
            this.dgvShots.Name = "dgvShots";
            this.dgvShots.RowHeadersWidth = 25;
            this.dgvShots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvShots.ShowEditingIcon = false;
            this.dgvShots.Size = new System.Drawing.Size(451, 152);
            this.dgvShots.TabIndex = 5;
            this.dgvShots.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShots_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.DataSource = this.ballLieBindingSource;
            this.Column1.HeaderText = "Lie";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 46;
            // 
            // ballLieBindingSource
            // 
            this.ballLieBindingSource.DataSource = typeof(GolfStatKeeper.Shot.BallLie);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Club";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 53;
            // 
            // Column7
            // 
            this.Column7.DataSource = this.ballFlightBindingSource;
            this.Column7.HeaderText = "Intended Ball Flight";
            this.Column7.Name = "Column7";
            this.Column7.Width = 70;
            // 
            // ballFlightBindingSource
            // 
            this.ballFlightBindingSource.DataSource = typeof(GolfStatKeeper.Shot.BallFlight);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Intended Length";
            this.Column4.Name = "Column4";
            this.Column4.Width = 101;
            // 
            // Column5
            // 
            this.Column5.DataSource = this.shotResultBindingSource;
            this.Column5.HeaderText = "Result";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 62;
            // 
            // shotResultBindingSource
            // 
            this.shotResultBindingSource.DataSource = typeof(GolfStatKeeper.Shot.ShotResult);
            // 
            // Column8
            // 
            this.Column8.DataSource = this.ballFlightBindingSource;
            this.Column8.HeaderText = "Actual Ball Flight";
            this.Column8.Name = "Column8";
            this.Column8.Width = 59;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Actual Length";
            this.Column6.Name = "Column6";
            this.Column6.Width = 90;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnCancel.Location = new System.Drawing.Point(480, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nud_Penalties
            // 
            this.nud_Penalties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Penalties.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_Penalties.Location = new System.Drawing.Point(457, 264);
            this.nud_Penalties.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Penalties.Name = "nud_Penalties";
            this.nud_Penalties.Size = new System.Drawing.Size(39, 23);
            this.nud_Penalties.TabIndex = 19;
            // 
            // lblPenalties
            // 
            this.lblPenalties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPenalties.AutoSize = true;
            this.lblPenalties.Location = new System.Drawing.Point(454, 248);
            this.lblPenalties.Name = "lblPenalties";
            this.lblPenalties.Size = new System.Drawing.Size(84, 13);
            this.lblPenalties.TabIndex = 20;
            this.lblPenalties.Text = "Penalty Strokes:";
            // 
            // btnSaveHole
            // 
            this.btnSaveHole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveHole.Location = new System.Drawing.Point(457, 347);
            this.btnSaveHole.Name = "btnSaveHole";
            this.btnSaveHole.Size = new System.Drawing.Size(98, 23);
            this.btnSaveHole.TabIndex = 21;
            this.btnSaveHole.Text = "Save Hole";
            this.btnSaveHole.UseVisualStyleBackColor = true;
            this.btnSaveHole.Click += new System.EventHandler(this.btnSaveHole_Click);
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNext.Location = new System.Drawing.Point(457, 376);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.Size = new System.Drawing.Size(98, 23);
            this.btnSaveNext.TabIndex = 22;
            this.btnSaveNext.Text = "Save and Next";
            this.btnSaveNext.UseVisualStyleBackColor = true;
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(457, 291);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.Location = new System.Drawing.Point(489, 291);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(26, 23);
            this.BtnDelete.TabIndex = 24;
            this.BtnDelete.Text = "-";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(457, 318);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(26, 23);
            this.btnUp.TabIndex = 25;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(489, 318);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(26, 23);
            this.btnDown.TabIndex = 26;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnPopulateShots
            // 
            this.btnPopulateShots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPopulateShots.Location = new System.Drawing.Point(457, 177);
            this.btnPopulateShots.Name = "btnPopulateShots";
            this.btnPopulateShots.Size = new System.Drawing.Size(98, 65);
            this.btnPopulateShots.TabIndex = 27;
            this.btnPopulateShots.Text = "Populate Shots From Hole Summary";
            this.btnPopulateShots.UseVisualStyleBackColor = true;
            this.btnPopulateShots.Click += new System.EventHandler(this.btnPopulateShots_Click);
            // 
            // PanelRound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPopulateShots);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSaveNext);
            this.Controls.Add(this.btnSaveHole);
            this.Controls.Add(this.lblPenalties);
            this.Controls.Add(this.nud_Penalties);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvShots);
            this.Controls.Add(this.dgvHoles);
            this.Controls.Add(this.cbConditions);
            this.Controls.Add(this.cbCourse);
            this.Controls.Add(this.dtWhen);
            this.Name = "PanelRound";
            this.Size = new System.Drawing.Size(561, 400);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballLieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballFlightBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shotResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Penalties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtWhen;
        private System.Windows.Forms.ComboBox cbCourse;
        private System.Windows.Forms.ComboBox cbConditions;
        private System.Windows.Forms.DataGridView dgvHoles;
        private System.Windows.Forms.DataGridView dgvShots;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource ballLieBindingSource;
        private System.Windows.Forms.BindingSource shotResultBindingSource;
        private System.Windows.Forms.NumericUpDown nud_Penalties;
        private System.Windows.Forms.Label lblPenalties;
        private System.Windows.Forms.Button btnSaveHole;
        private System.Windows.Forms.Button btnSaveNext;
        private System.Windows.Forms.BindingSource ballFlightBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnPopulateShots;
    }
}
