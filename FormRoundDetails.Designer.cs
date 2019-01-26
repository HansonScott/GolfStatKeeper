namespace GolfStatKeeper
{
    partial class FormRoundDetails
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
            this.panelRound1 = new GolfStatKeeper.Panels.PanelRound();
            this.SuspendLayout();
            // 
            // panelRound1
            // 
            this.panelRound1.Location = new System.Drawing.Point(12, 12);
            this.panelRound1.Name = "panelRound1";
            this.panelRound1.Size = new System.Drawing.Size(776, 426);
            this.panelRound1.TabIndex = 0;
            // 
            // FormRoundDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelRound1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRoundDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Round Details";
            this.ResumeLayout(false);

        }

        #endregion
    }
}