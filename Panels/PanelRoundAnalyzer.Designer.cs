namespace GolfStatKeeper.Panels
{
    partial class PanelRoundAnalyzer
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
            this.dgvHoles = new System.Windows.Forms.DataGridView();
            this.dgvShotsWasted = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShotsWasted)).BeginInit();
            this.SuspendLayout();
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
            this.dgvHoles.Location = new System.Drawing.Point(6, 3);
            this.dgvHoles.MultiSelect = false;
            this.dgvHoles.Name = "dgvHoles";
            this.dgvHoles.RowHeadersVisible = false;
            this.dgvHoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.dgvHoles.Size = new System.Drawing.Size(660, 175);
            this.dgvHoles.TabIndex = 5;
            // 
            // dgvShotsWasted
            // 
            this.dgvShotsWasted.AllowUserToAddRows = false;
            this.dgvShotsWasted.AllowUserToDeleteRows = false;
            this.dgvShotsWasted.AllowUserToResizeRows = false;
            this.dgvShotsWasted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShotsWasted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShotsWasted.ColumnHeadersVisible = false;
            this.dgvShotsWasted.Location = new System.Drawing.Point(6, 209);
            this.dgvShotsWasted.MultiSelect = false;
            this.dgvShotsWasted.Name = "dgvShotsWasted";
            this.dgvShotsWasted.RowHeadersVisible = false;
            this.dgvShotsWasted.Size = new System.Drawing.Size(660, 200);
            this.dgvShotsWasted.TabIndex = 6;
            // 
            // PanelRoundAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvShotsWasted);
            this.Controls.Add(this.dgvHoles);
            this.Name = "PanelRoundAnalyzer";
            this.Size = new System.Drawing.Size(669, 412);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShotsWasted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoles;
        private System.Windows.Forms.DataGridView dgvShotsWasted;
    }
}
