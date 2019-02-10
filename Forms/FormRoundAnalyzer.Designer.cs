namespace GolfStatKeeper
{
    partial class FormRoundAnalyzer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelRoundAnalyzer1 = new GolfStatKeeper.Panels.PanelRoundAnalyzer();
            this.SuspendLayout();
            // 
            // panelRoundAnalyzer1
            // 
            this.panelRoundAnalyzer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRoundAnalyzer1.Location = new System.Drawing.Point(1, 1);
            this.panelRoundAnalyzer1.Name = "panelRoundAnalyzer1";
            this.panelRoundAnalyzer1.Size = new System.Drawing.Size(799, 449);
            this.panelRoundAnalyzer1.TabIndex = 0;
            // 
            // FormRoundAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRoundAnalyzer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRoundAnalyzer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Round Analyzer";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
    }
}