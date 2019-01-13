using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GolfStatKeeper.Panels;

namespace GolfStatKeeper
{
    public partial class FormMain : Form
    {
        public static FormMain thisForm;

        #region Class Declarations
        private Player m_CurrentPlayer;

        #region Panels Declarations
        public PanelPlayer PanelPlayer1;
        public PanelCourse PanelCourse1;
        public PanelRoundSummary PanelRoundSummary1;
        public PanelRound PanelRound1;
        public PanelStats PanelStats1;
        public PanelChart PanelChart1;
        public PanelClubStats PanelClubStats1;
        public PanelNotes PanelNotes1;
        public PanelRoundAnalyzer PanelRoundAnalyzer1;
        public PanelHelp PanelHelp1;
        public PanelAbout PanelAbout1;
        #endregion
        #endregion

        #region Public Properties
        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set
            {
                m_CurrentPlayer = value;
                thisForm.Text = "Golf Stat Keeper - " + m_CurrentPlayer.Name;
            }
        }
        #endregion

        #region MAIN
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool Install = DAC.CheckInstalled();
            // regardless of the install, run the app.
            Application.Run(new FormMain());
            //Application.Run(new FormTest());
        }
        #endregion

        #region Constructor
        public FormMain()
        {
            thisForm = this;
            InitializeComponent();

            // load current player before any panels
            bool NewPlayer = LoadCurrentPlayer();
            if (NewPlayer)
            {
                LoadPlayerPanel();
            }
            else
            {
                LoadRoundSummaryPanel();
            }

            this.Shown += new EventHandler(FormMain_Shown);
        }

        void FormMain_Shown(object sender, EventArgs e)
        {
            if (CurrentPlayer == null)
            {
                MessageBox.Show("Please start by setting up a player", "Welcome New Player", MessageBoxButtons.OK);
            }
        }

        private bool LoadCurrentPlayer()
        {
            Player[] Players = DAC.GetPlayers();

            if (Players == null || Players.Length == 0) 
            {
                return true; 
            }

            // if there is a currentPlayer set in the config, use it.
            string p = DAC.GetCurrentPlayer();
            if (!String.IsNullOrEmpty(p))
            {
                CurrentPlayer = DAC.GetPlayerByID(p);
            }
            else
            {
                // load the first one.
                CurrentPlayer = Players[0];
            }
            return false;
        }
        #endregion

        #region Menu Events
        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPlayerPanel();
        }
        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCoursePanel();
        }
        private void roundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadRoundSummaryPanel();
        }
        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadStatsPanel();
        }
        private void chartOverTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChartPanel();
        }
        private void clubSpecificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadClubStatsPanel();
        }
        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNotesPanel();
        }
        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadHelpPanel();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAboutPanel();
        }
        #endregion

        #region Public Methods
        public void SetCurrentPlayer(Player p)
        {
            CurrentPlayer = p;
            DAC.SetCurrentPlayer(p);

            // clear out the various panels that should change.
            this.PanelStats1 = null;
            this.PanelRoundSummary1 = null;
            this.PanelRoundAnalyzer1 = null;
            this.PanelRound1 = null;
            this.PanelNotes1 = null;
            this.PanelCourse1 = null;
            this.PanelClubStats1 = null;
            this.PanelChart1 = null;
        }
        #endregion

        #region Private Functions
        private void FormMain_Resize(object sender, EventArgs e)
        {
            ResizeCurrentPanel();
        }
        private void ResizeCurrentPanel()
        {
            this.CurrentPanel.Height = this.Height - 74;
            this.CurrentPanel.Width = this.Width - 32;

            if (CurrentPanel is PanelPlayer)
            {
                (CurrentPanel as PanelPlayer).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelCourse)
            {
                (CurrentPanel as PanelCourse).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelStats)
            {
                (CurrentPanel as PanelStats).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelChart)
            {
                (CurrentPanel as PanelChart).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelRound)
            {
                (CurrentPanel as PanelRound).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelRoundSummary)
            {
                (CurrentPanel as PanelRoundSummary).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelClubStats)
            {
                (CurrentPanel as PanelClubStats).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelNotes)
            {
                (CurrentPanel as PanelNotes).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelRoundAnalyzer)
            {
                (CurrentPanel as PanelRoundAnalyzer).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelHelp)
            {
                (CurrentPanel as PanelHelp).ResizeInnerControls();
            }
            else if (CurrentPanel is PanelAbout)
            {
                (CurrentPanel as PanelAbout).ResizeInnerControls();
            }
        }
        public void LoadPlayerPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelPlayer1 == null) { PanelPlayer1 = new PanelPlayer(); }
            CurrentPanel = PanelPlayer1;
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        public void LoadCoursePanel()
        {
            this.Controls.Remove(CurrentPanel);
            CurrentPanel = new PanelCourse();
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
            //(CurrentPanel as PanelCourse).ResetFocus();
        }
        public void LoadRoundSummaryPanel()
        {
            this.Controls.Remove(CurrentPanel);
            CurrentPanel = new PanelRoundSummary();
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        public void LoadRoundPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelRound1 == null) { PanelRound1 = new PanelRound(); }
            CurrentPanel = PanelRound1;
            PanelRound1.PopulateCourseCombo();
            PanelRound1.RefreshCourseData();
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        public void LoadStatsPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelStats1 == null) { PanelStats1 = new PanelStats(); }
            PanelStats1.SetTheseRounds();
            CurrentPanel = PanelStats1;
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        public void LoadChartPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelChart1 == null) { PanelChart1 = new PanelChart(); }
            CurrentPanel = PanelChart1;
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        public void LoadClubStatsPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelClubStats1 == null) { PanelClubStats1 = new PanelClubStats(); }
            CurrentPanel = PanelClubStats1;
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        public void LoadNotesPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelNotes1 == null) { PanelNotes1 = new PanelNotes(); }
            CurrentPanel = PanelNotes1;
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        public void LoadRoundAnalyzerPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelRoundAnalyzer1 == null) { PanelRoundAnalyzer1 = new PanelRoundAnalyzer(); }
            CurrentPanel = PanelRoundAnalyzer1;
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        public void LoadHelpPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelHelp1 == null) { PanelHelp1 = new PanelHelp(); }
            CurrentPanel = PanelHelp1;
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        private void LoadAboutPanel()
        {
            this.Controls.Remove(CurrentPanel);
            if (PanelAbout1 == null) { PanelAbout1 = new PanelAbout(); }
            CurrentPanel = PanelAbout1;
            this.Controls.Add(CurrentPanel);
            ResizeCurrentPanel();
        }
        #endregion
    }
}