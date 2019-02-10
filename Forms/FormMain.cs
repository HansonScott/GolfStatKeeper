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

        public static bool IsAppRunning = false;

        #region Class Declarations
        private Player m_CurrentPlayer;

        #region Panels Declarations
        public PanelRoundSummary panelRoundSummary1;
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
                if (m_CurrentPlayer != null)
                {
                    thisForm.Text = "Golf Stat Keeper - " + m_CurrentPlayer.Name;
                }
                else
                {
                    thisForm.Text = "Golf Stat Keeper";
                }
            }
        }
        #endregion

        #region MAIN
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DAC.DATA_PATH = @"D:\Program Files (x86)\GolfStatKeeper";


            bool Install = DAC.CheckInstalled();
            // regardless of the install, run the app.
            FormMain.IsAppRunning = true;
            Application.Run(new FormMain());
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
                panelPlayer1.SetForNewPlayer();
                panelPlayer1.PrepopulateGolfBagWithDefaults();
            }
            else
            {
                panelPlayer1.LoadPlayer(CurrentPlayer);
            }
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

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(e.TabPage.Text == "Rounds")
            {
                thisForm.panelRoundSummary1.LoadRoundSummaries();
            }
        }
    }
}