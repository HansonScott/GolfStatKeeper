namespace GolfStatKeeper.Panels
{
    partial class PanelPlayer
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
            this.lblName = new System.Windows.Forms.Label();
            this.gbGolfBag = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvGolfBag = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbPlayerName = new System.Windows.Forms.ComboBox();
            this.lblPlayerID = new System.Windows.Forms.Label();
            this.gbGolfBag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGolfBag)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Player Name:";
            // 
            // gbGolfBag
            // 
            this.gbGolfBag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGolfBag.Controls.Add(this.btnDelete);
            this.gbGolfBag.Controls.Add(this.btnSave);
            this.gbGolfBag.Controls.Add(this.dgvGolfBag);
            this.gbGolfBag.Location = new System.Drawing.Point(0, 45);
            this.gbGolfBag.Name = "gbGolfBag";
            this.gbGolfBag.Size = new System.Drawing.Size(454, 409);
            this.gbGolfBag.TabIndex = 2;
            this.gbGolfBag.TabStop = false;
            this.gbGolfBag.Text = "Golf Bag";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(292, 380);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(373, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvGolfBag
            // 
            this.dgvGolfBag.AllowUserToResizeRows = false;
            this.dgvGolfBag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGolfBag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGolfBag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGolfBag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
            this.dgvGolfBag.Location = new System.Drawing.Point(6, 34);
            this.dgvGolfBag.Name = "dgvGolfBag";
            this.dgvGolfBag.Size = new System.Drawing.Size(442, 340);
            this.dgvGolfBag.TabIndex = 0;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 25.38071F;
            this.Column3.HeaderText = "ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 74.87309F;
            this.Column1.HeaderText = "Club Type";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 149.7462F;
            this.Column2.HeaderText = "Club Name (Brand, Pet name, etc.)";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cbPlayerName
            // 
            this.cbPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPlayerName.FormattingEnabled = true;
            this.cbPlayerName.Location = new System.Drawing.Point(89, 7);
            this.cbPlayerName.Name = "cbPlayerName";
            this.cbPlayerName.Size = new System.Drawing.Size(330, 21);
            this.cbPlayerName.TabIndex = 3;
            this.cbPlayerName.SelectedValueChanged += new System.EventHandler(this.cbPlayerName_SelectedValueChanged);
            // 
            // lblPlayerID
            // 
            this.lblPlayerID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerID.Location = new System.Drawing.Point(426, 10);
            this.lblPlayerID.Name = "lblPlayerID";
            this.lblPlayerID.Size = new System.Drawing.Size(22, 18);
            this.lblPlayerID.TabIndex = 4;
            this.lblPlayerID.Text = "0";
            // 
            // PanelPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPlayerID);
            this.Controls.Add(this.cbPlayerName);
            this.Controls.Add(this.gbGolfBag);
            this.Controls.Add(this.lblName);
            this.Name = "PanelPlayer";
            this.Size = new System.Drawing.Size(457, 457);
            this.gbGolfBag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGolfBag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox gbGolfBag;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvGolfBag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ComboBox cbPlayerName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblPlayerID;
    }
}
