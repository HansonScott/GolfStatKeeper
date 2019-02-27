using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GolfStatKeeper.CoreObjects;

namespace GolfStatKeeper.Panels
{
    public partial class PanelStatsClubs : PanelTemplate
    {
        public PanelStatsClubs()
        {
            InitializeComponent();
        }

        private void PanelStatsClubs_Load(object sender, EventArgs e)
        {
            if (FormMain.IsAppRunning)
            {
                LoadClubs();
            }
        }
        private void LoadClubs()
        {
            this.cbClubs.DisplayMember = "Name";
            this.cbClubs.DataSource = DAC.GetClubsForCurrentPlayer();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // get the data from the rounds
            Club c = (cbClubs.SelectedValue as Club);
            Round[] rounds = DAC.GetRounds(true);

            // analyze and get the essential data for this club
            List<ClubStat> clubStats = SetDataSetByRoundsAndClub(rounds, c);

            // discern data points for the accuracy map
            int[,] accuracyData = GetAccuracyMapData(clubStats);
            this.accuracyMap1.DataSource = accuracyData;
            this.accuracyMap1.Refresh();

            LoadGridOfData(clubStats);
        }

        private List<ClubStat> SetDataSetByRoundsAndClub(Round[] rounds, Club c)
        {
            List<ClubStat> results = new List<ClubStat>();

            foreach (Round r in rounds)
            {
                if (r.HolesPlayed == null || r.HolesPlayed.Count == 0) { continue; }

                foreach (HoleScore h in r.HolesPlayed)
                {
                    if (h.Shots == null || h.Shots.Count == 0) { continue; }

                    foreach (Shot s in h.Shots)
                    {
                        if (s.Club == c.ClubType)
                        {
                            ClubStat cs = new ClubStat();
                            cs.club = c;
                            cs.shot = s;
                            cs.holeScore = h;
                            results.Add(cs);
                        }
                    }
                }
            }

            return results;
        }
        private int[,] GetAccuracyMapData(List<ClubStat> clubStats)
        {
            int[,] accuracyData = new int[Enum.GetNames(typeof(AccuracyMap.AccuracyLength)).Length, Enum.GetNames(typeof(AccuracyMap.AccuracyWidth)).Length];
            foreach (ClubStat cs in clubStats)
            {
                // capture the length difference
                double dLenPercent = cs.shot.ActualDistance / cs.shot.TargetDistance;
                int len = (int)AccuracyMap.AccuracyLength.AsIntended;
                if (dLenPercent < 0.8) { len = (int)AccuracyMap.AccuracyLength.VeryShort; }
                else if (dLenPercent < 0.9) { len = (int)AccuracyMap.AccuracyLength.Short; }
                else if (dLenPercent < 0.95) { len = (int)AccuracyMap.AccuracyLength.EdgeShort; }
                else if (dLenPercent > 1.05) { len = (int)AccuracyMap.AccuracyLength.EdgeLong; }
                else if (dLenPercent > 1.1) { len = (int)AccuracyMap.AccuracyLength.Long; }
                else if (dLenPercent > 1.2) { len = (int)AccuracyMap.AccuracyLength.VeryLong; }
                else { len = (int)AccuracyMap.AccuracyLength.AsIntended; }

                // capture the difference between target and actual direction
                // hook, pull, draw, straight, fade, push, slice
                Shot.BallFlight dirTarget = cs.shot.TargetFlight;
                Shot.BallFlight dirActual = cs.shot.ActualFlight;
                int dirDiff = (int)AccuracyMap.AccuracyWidth.AsIntended;

                int dirT = 0;
                int dirA = 0;

                if (dirTarget == Shot.BallFlight.Hook) { dirT = -3; }
                else if (dirTarget == Shot.BallFlight.Pull) { dirT = -2; }
                else if (dirTarget == Shot.BallFlight.Draw) { dirT = -1; }
                else if (dirTarget == Shot.BallFlight.Straight) { dirT = 0; }
                else if (dirTarget == Shot.BallFlight.Fade) { dirT = 1; }
                else if (dirTarget == Shot.BallFlight.Push) { dirT = 2; }
                else if (dirTarget == Shot.BallFlight.Slice) { dirT = 3; }
                else { } // assume straight if not a directional...

                if (dirActual == Shot.BallFlight.Hook) { dirA = -3; }
                else if (dirActual == Shot.BallFlight.Pull) { dirA = -2; }
                else if (dirActual == Shot.BallFlight.Draw) { dirA = -1; }
                else if (dirActual == Shot.BallFlight.Straight) { dirA = 0; }
                else if (dirActual == Shot.BallFlight.Fade) { dirA = 1; }
                else if (dirActual == Shot.BallFlight.Push) { dirA = 2; }
                else if (dirActual == Shot.BallFlight.Slice) { dirA = 3; }
                else { } // assume straight if not a directional...

                int diff = dirA - dirT;
                switch (diff)
                {
                    case -6:
                    case -5:
                    case -4:
                    case -3:
                        dirDiff = (int)AccuracyMap.AccuracyWidth.VeryLeft;
                        break;
                    case -2:
                        dirDiff = (int)AccuracyMap.AccuracyWidth.Left;
                        break;
                    case -1:
                        dirDiff = (int)AccuracyMap.AccuracyWidth.EdgeLeft;
                        break;
                    case 0:
                        dirDiff = (int)AccuracyMap.AccuracyWidth.AsIntended;
                        break;
                    case 1:
                        dirDiff = (int)AccuracyMap.AccuracyWidth.EdgeRight;
                        break;
                    case 2:
                        dirDiff = (int)AccuracyMap.AccuracyWidth.Right;
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        dirDiff = (int)AccuracyMap.AccuracyWidth.VeryRight;
                        break;
                    default:
                        break;
                }

                // now apply the length difference and directional difference to the dataset
                accuracyData[len, dirDiff]++;

            } // end foreach club

            return accuracyData;
        }

        private void LoadGridOfData(List<ClubStat> clubStats)
        {
            dgvStats.Rows.Clear();
            dgvStats.Columns.Clear();

            dgvStats.Columns.Add("Item", "Item");
            dgvStats.Columns.Add("Value", "Value");

            dgvStats.Rows.Add(new string[] {"Total Shots", clubStats.Count.ToString()});
            int max = 0;
            int total = 0;
            foreach(ClubStat cs in clubStats)
            {
                max = Math.Max(max, cs.shot.ActualDistance);
                total += cs.shot.ActualDistance;
            }
            dgvStats.Rows.Add(new string[] { "Max Distance", max.ToString() });
            dgvStats.Rows.Add(new string[] { "Avg Distance", ((double)total / (double)clubStats.Count).ToString("F2")});
        }
    }
}
