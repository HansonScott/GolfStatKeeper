namespace GolfStatKeeper.Panels
{
    partial class PanelStatsClubs
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
            this.accuracyMap1 = new GolfStatKeeper.AccuracyMap();
            this.cbClubs = new System.Windows.Forms.ComboBox();
            this.lblClubs = new System.Windows.Forms.Label();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            this.SuspendLayout();
            // 
            // accuracyMap1
            // 
            this.accuracyMap1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accuracyMap1.DataSource = null;
            this.accuracyMap1.Location = new System.Drawing.Point(215, 3);
            this.accuracyMap1.Name = "accuracyMap1";
            this.accuracyMap1.Size = new System.Drawing.Size(570, 477);
            this.accuracyMap1.TabIndex = 0;
            // 
            // cbClubs
            // 
            this.cbClubs.FormattingEnabled = true;
            this.cbClubs.Location = new System.Drawing.Point(6, 29);
            this.cbClubs.Name = "cbClubs";
            this.cbClubs.Size = new System.Drawing.Size(121, 21);
            this.cbClubs.TabIndex = 1;
            // 
            // lblClubs
            // 
            this.lblClubs.AutoSize = true;
            this.lblClubs.Location = new System.Drawing.Point(3, 13);
            this.lblClubs.Name = "lblClubs";
            this.lblClubs.Size = new System.Drawing.Size(72, 13);
            this.lblClubs.TabIndex = 2;
            this.lblClubs.Text = "Select a club:";
            // 
            // dgvStats
            // 
            this.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStats.Location = new System.Drawing.Point(6, 56);
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.Size = new System.Drawing.Size(203, 424);
            this.dgvStats.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(133, 27);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load Stats";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // PanelStatsClubs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvStats);
            this.Controls.Add(this.lblClubs);
            this.Controls.Add(this.cbClubs);
            this.Controls.Add(this.accuracyMap1);
            this.Name = "PanelStatsClubs";
            this.Size = new System.Drawing.Size(788, 483);
            this.Load += new System.EventHandler(this.PanelStatsClubs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccuracyMap accuracyMap1;
        private System.Windows.Forms.ComboBox cbClubs;
        private System.Windows.Forms.Label lblClubs;
        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.Button btnLoad;
    }
}
