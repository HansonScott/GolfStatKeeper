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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRawScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblNetScore = new System.Windows.Forms.Label();
            this.lblAdjustedScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShotsWasted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.dgvShotsWasted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvShotsWasted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShotsWasted.Location = new System.Drawing.Point(6, 209);
            this.dgvShotsWasted.MultiSelect = false;
            this.dgvShotsWasted.Name = "dgvShotsWasted";
            this.dgvShotsWasted.RowHeadersVisible = false;
            this.dgvShotsWasted.Size = new System.Drawing.Size(523, 200);
            this.dgvShotsWasted.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(573, 284);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 26);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(553, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "-";
            // 
            // lblRawScore
            // 
            this.lblRawScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRawScore.AutoSize = true;
            this.lblRawScore.Location = new System.Drawing.Point(563, 209);
            this.lblRawScore.Name = "lblRawScore";
            this.lblRawScore.Size = new System.Drawing.Size(63, 13);
            this.lblRawScore.TabIndex = 9;
            this.lblRawScore.Text = "Raw Score:";
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(575, 240);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(51, 20);
            this.lblScore.TabIndex = 10;
            this.lblScore.Text = "label2";
            // 
            // lblNetScore
            // 
            this.lblNetScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetScore.AutoSize = true;
            this.lblNetScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetScore.Location = new System.Drawing.Point(569, 367);
            this.lblNetScore.Name = "lblNetScore";
            this.lblNetScore.Size = new System.Drawing.Size(51, 20);
            this.lblNetScore.TabIndex = 12;
            this.lblNetScore.Text = "label2";
            // 
            // lblAdjustedScore
            // 
            this.lblAdjustedScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdjustedScore.AutoSize = true;
            this.lblAdjustedScore.Location = new System.Drawing.Point(563, 336);
            this.lblAdjustedScore.Name = "lblAdjustedScore";
            this.lblAdjustedScore.Size = new System.Drawing.Size(82, 13);
            this.lblAdjustedScore.TabIndex = 11;
            this.lblAdjustedScore.Text = "Adjusted Score:";
            // 
            // PanelRoundAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNetScore);
            this.Controls.Add(this.lblAdjustedScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblRawScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dgvShotsWasted);
            this.Controls.Add(this.dgvHoles);
            this.Name = "PanelRoundAnalyzer";
            this.Size = new System.Drawing.Size(669, 412);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShotsWasted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoles;
        private System.Windows.Forms.DataGridView dgvShotsWasted;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRawScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblNetScore;
        private System.Windows.Forms.Label lblAdjustedScore;
    }
}
