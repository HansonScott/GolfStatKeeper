namespace GolfStatKeeper.Panels
{
    partial class PanelStats
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSummary = new System.Windows.Forms.TabPage();
            this.tpTrends = new System.Windows.Forms.TabPage();
            this.tpClubSpecific = new System.Windows.Forms.TabPage();
            this.panelStatsSummary1 = new GolfStatKeeper.Panels.PanelStatsSummary();
            this.panelStatsTrends1 = new GolfStatKeeper.Panels.PanelStatsTrends();
            this.panelStatsClubs1 = new GolfStatKeeper.Panels.PanelStatsClubs();
            this.tabControl1.SuspendLayout();
            this.tpSummary.SuspendLayout();
            this.tpTrends.SuspendLayout();
            this.tpClubSpecific.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpSummary);
            this.tabControl1.Controls.Add(this.tpTrends);
            this.tabControl1.Controls.Add(this.tpClubSpecific);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(537, 415);
            this.tabControl1.TabIndex = 0;
            // 
            // tpSummary
            // 
            this.tpSummary.Controls.Add(this.panelStatsSummary1);
            this.tpSummary.Location = new System.Drawing.Point(4, 22);
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tpSummary.Size = new System.Drawing.Size(529, 389);
            this.tpSummary.TabIndex = 0;
            this.tpSummary.Text = "Summary";
            this.tpSummary.UseVisualStyleBackColor = true;
            // 
            // tpTrends
            // 
            this.tpTrends.Controls.Add(this.panelStatsTrends1);
            this.tpTrends.Location = new System.Drawing.Point(4, 22);
            this.tpTrends.Name = "tpTrends";
            this.tpTrends.Padding = new System.Windows.Forms.Padding(3);
            this.tpTrends.Size = new System.Drawing.Size(529, 389);
            this.tpTrends.TabIndex = 1;
            this.tpTrends.Text = "Trends";
            this.tpTrends.UseVisualStyleBackColor = true;
            // 
            // tpClubSpecific
            // 
            this.tpClubSpecific.Controls.Add(this.panelStatsClubs1);
            this.tpClubSpecific.Location = new System.Drawing.Point(4, 22);
            this.tpClubSpecific.Name = "tpClubSpecific";
            this.tpClubSpecific.Size = new System.Drawing.Size(529, 389);
            this.tpClubSpecific.TabIndex = 2;
            this.tpClubSpecific.Text = "Club Specific";
            this.tpClubSpecific.UseVisualStyleBackColor = true;
            // 
            // panelStatsSummary1
            // 
            this.panelStatsSummary1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatsSummary1.Location = new System.Drawing.Point(6, 3);
            this.panelStatsSummary1.Name = "panelStatsSummary1";
            this.panelStatsSummary1.Size = new System.Drawing.Size(517, 383);
            this.panelStatsSummary1.TabIndex = 0;
            // 
            // panelStatsTrends1
            // 
            this.panelStatsTrends1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatsTrends1.Location = new System.Drawing.Point(3, 3);
            this.panelStatsTrends1.Name = "panelStatsTrends1";
            this.panelStatsTrends1.Size = new System.Drawing.Size(526, 386);
            this.panelStatsTrends1.TabIndex = 0;
            // 
            // panelStatsClubs1
            // 
            this.panelStatsClubs1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatsClubs1.Location = new System.Drawing.Point(3, 3);
            this.panelStatsClubs1.Name = "panelStatsClubs1";
            this.panelStatsClubs1.Size = new System.Drawing.Size(523, 386);
            this.panelStatsClubs1.TabIndex = 0;
            // 
            // PanelStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "PanelStats";
            this.Size = new System.Drawing.Size(543, 421);
            this.tabControl1.ResumeLayout(false);
            this.tpSummary.ResumeLayout(false);
            this.tpTrends.ResumeLayout(false);
            this.tpClubSpecific.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSummary;
        private System.Windows.Forms.TabPage tpTrends;
        private System.Windows.Forms.TabPage tpClubSpecific;
        private PanelStatsSummary panelStatsSummary1;
        private PanelStatsTrends panelStatsTrends1;
        private PanelStatsClubs panelStatsClubs1;
    }
}
