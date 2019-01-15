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
            this.tabRounds = new System.Windows.Forms.TabPage();
            this.tabStats = new System.Windows.Forms.TabPage();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
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
            this.panelPlayer1.Location = new System.Drawing.Point(8, 6);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(703, 528);
            this.panelPlayer1.TabIndex = 0;
            // 
            // tabCourses
            // 
            this.tabCourses.Location = new System.Drawing.Point(4, 22);
            this.tabCourses.Name = "tabCourses";
            this.tabCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tabCourses.Size = new System.Drawing.Size(717, 540);
            this.tabCourses.TabIndex = 1;
            this.tabCourses.Text = "Courses";
            this.tabCourses.UseVisualStyleBackColor = true;
            // 
            // tabRounds
            // 
            this.tabRounds.Location = new System.Drawing.Point(4, 22);
            this.tabRounds.Name = "tabRounds";
            this.tabRounds.Size = new System.Drawing.Size(717, 540);
            this.tabRounds.TabIndex = 2;
            this.tabRounds.Text = "Rounds";
            this.tabRounds.UseVisualStyleBackColor = true;
            // 
            // tabStats
            // 
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
            this.tabHelp.Location = new System.Drawing.Point(4, 22);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Size = new System.Drawing.Size(717, 540);
            this.tabHelp.TabIndex = 5;
            this.tabHelp.Text = "Help";
            this.tabHelp.UseVisualStyleBackColor = true;
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
    }
}

