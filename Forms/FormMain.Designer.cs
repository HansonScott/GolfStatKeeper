using System.Windows.Forms;
namespace GolfStatKeeper
{
    partial class FormMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.panelPlayer1 = new GolfStatKeeper.Panels.PanelPlayer();
            this.tabCourses = new System.Windows.Forms.TabPage();
            this.panelCourse1 = new GolfStatKeeper.Panels.PanelCourse();
            this.tabRounds = new System.Windows.Forms.TabPage();
            this.panelRoundSummary1 = new GolfStatKeeper.Panels.PanelRoundSummary();
            this.tabStats = new System.Windows.Forms.TabPage();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.panelHelp2 = new GolfStatKeeper.Panels.PanelHelp();
            this.panelStats2 = new GolfStatKeeper.Panels.PanelStats();
            this.tabControl1.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            this.tabCourses.SuspendLayout();
            this.tabRounds.SuspendLayout();
            this.tabStats.SuspendLayout();
            this.tabHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPlayers);
            this.tabControl1.Controls.Add(this.tabCourses);
            this.tabControl1.Controls.Add(this.tabRounds);
            this.tabControl1.Controls.Add(this.tabStats);
            this.tabControl1.Controls.Add(this.tabNotes);
            this.tabControl1.Controls.Add(this.tabHelp);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 566);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPlayers
            // 
            this.tabPlayers.Controls.Add(this.panelPlayer1);
            this.tabPlayers.Location = new System.Drawing.Point(4, 22);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayers.Size = new System.Drawing.Size(717, 540);
            this.tabPlayers.TabIndex = 0;
            this.tabPlayers.Text = "Players";
            this.tabPlayers.UseVisualStyleBackColor = true;
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlayer1.CurrentPlayer = null;
            this.panelPlayer1.Location = new System.Drawing.Point(8, 6);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(703, 528);
            this.panelPlayer1.TabIndex = 0;
            // 
            // tabCourses
            // 
            this.tabCourses.Controls.Add(this.panelCourse1);
            this.tabCourses.Location = new System.Drawing.Point(4, 22);
            this.tabCourses.Name = "tabCourses";
            this.tabCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tabCourses.Size = new System.Drawing.Size(717, 540);
            this.tabCourses.TabIndex = 1;
            this.tabCourses.Text = "Courses";
            this.tabCourses.UseVisualStyleBackColor = true;
            // 
            // panelCourse1
            // 
            this.panelCourse1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCourse1.Location = new System.Drawing.Point(0, 3);
            this.panelCourse1.Name = "panelCourse1";
            this.panelCourse1.Size = new System.Drawing.Size(714, 537);
            this.panelCourse1.TabIndex = 0;
            // 
            // tabRounds
            // 
            this.tabRounds.Controls.Add(this.panelRoundSummary1);
            this.tabRounds.Location = new System.Drawing.Point(4, 22);
            this.tabRounds.Name = "tabRounds";
            this.tabRounds.Size = new System.Drawing.Size(717, 540);
            this.tabRounds.TabIndex = 2;
            this.tabRounds.Text = "Rounds";
            this.tabRounds.UseVisualStyleBackColor = true;
            // 
            // panelRoundSummary1
            // 
            this.panelRoundSummary1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRoundSummary1.Location = new System.Drawing.Point(3, 3);
            this.panelRoundSummary1.Name = "panelRoundSummary1";
            this.panelRoundSummary1.Size = new System.Drawing.Size(711, 534);
            this.panelRoundSummary1.TabIndex = 0;
            // 
            // tabStats
            // 
            this.tabStats.Controls.Add(this.panelStats2);
            this.tabStats.Location = new System.Drawing.Point(4, 22);
            this.tabStats.Name = "tabStats";
            this.tabStats.Size = new System.Drawing.Size(717, 540);
            this.tabStats.TabIndex = 3;
            this.tabStats.Text = "Stats";
            this.tabStats.UseVisualStyleBackColor = true;
            // 
            // tabNotes
            // 
            this.tabNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tabNotes.Location = new System.Drawing.Point(4, 22);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Size = new System.Drawing.Size(717, 540);
            this.tabNotes.TabIndex = 4;
            this.tabNotes.Text = "Notes";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // tabHelp
            // 
            this.tabHelp.Controls.Add(this.panelHelp2);
            this.tabHelp.Location = new System.Drawing.Point(4, 22);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Size = new System.Drawing.Size(717, 540);
            this.tabHelp.TabIndex = 5;
            this.tabHelp.Text = "Help";
            this.tabHelp.UseVisualStyleBackColor = true;
            // 
            // panelHelp2
            // 
            this.panelHelp2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHelp2.Location = new System.Drawing.Point(8, 3);
            this.panelHelp2.Name = "panelHelp2";
            this.panelHelp2.Size = new System.Drawing.Size(706, 534);
            this.panelHelp2.TabIndex = 0;
            // 
            // panelStats2
            // 
            this.panelStats2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStats2.Location = new System.Drawing.Point(3, 3);
            this.panelStats2.Name = "panelStats2";
            this.panelStats2.Size = new System.Drawing.Size(711, 534);
            this.panelStats2.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 566);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Golf Stat Keeper";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPlayers.ResumeLayout(false);
            this.tabCourses.ResumeLayout(false);
            this.tabRounds.ResumeLayout(false);
            this.tabStats.ResumeLayout(false);
            this.tabHelp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public UserControl CurrentPanel;
        private TabControl tabControl1;
        private TabPage tabPlayers;
        private TabPage tabCourses;
        private TabPage tabRounds;
        private TabPage tabStats;
        private TabPage tabNotes;
        private TabPage tabHelp;
        private Panels.PanelPlayer panelPlayer1;
        private Panels.PanelCourse panelCourse1;
        private Panels.PanelHelp panelHelp2;
        private Panels.PanelStats panelStats2;
    }
}

