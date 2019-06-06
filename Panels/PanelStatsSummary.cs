using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelStatsSummary : PanelTemplate
    {
        private enum SummaryRows
        {
            NumberOfRounds_Penalties = 0,
            AvgTotalScore_Birdies = 1,
            AvgScorePar3_Pars = 2,
            AvgScorePar4_Bogies = 3,
            AvgScorePar5_Doubles = 4,
            HolesPerEagle_Others = 5,
        }
        private enum DrivingRows
        {
            Fairways = 0,
            Distance = 1,
            Longest = 2,
            Hazards = 3,
            OBs = 4,
        }
        private enum IronRows
        {
            GIR = 0,
            Distance = 1,
            FavoriteClub = 2,
            SandShots = 3,
            SandSaves = 4,
        }
        private enum PuttingRows
        {
            PuttsPerRound = 0,
            PuttsPerGIR = 1,
            ThreePuttsPerRound = 2,
            ThreePuttDistance = 3,
            AvgBirdyPuttDistance = 4,
        }

        private bool isLoading = false;

        #region Constructor, setup, and on load
        public PanelStatsSummary()
        {
            InitializeComponent();
            dtpTo.Value = DateTime.Today;


            if (FormMain.IsAppRunning)
            {
                PopulateCourses();
            }

            LoadGridEmptyRows();
        }

        private void PopulateCourses()
        {
            Course[] courses = DAC.GetCourses();

            for(int i = 0; i < courses.Length; i++)
            {
                Course c = courses[i];
                int r = dgvCourses.Rows.Add();
                dgvCourses.Rows[r].Cells[0].Value = c.CourseAndTee;
                dgvCourses.Rows[r].Tag = c; // save the course for later
            }
        }
        private void LoadGridEmptyRows()
        {
            //Hole Summary
            dgvHoleSummary.Rows.Add();
            dgvHoleSummary.Rows[(int)SummaryRows.NumberOfRounds_Penalties].Cells[0].Value = "Number of Rounds:";
            dgvHoleSummary.Rows[(int)SummaryRows.NumberOfRounds_Penalties].Cells[3].Value = "Penalties / Rnd:";

            dgvHoleSummary.Rows.Add();
            dgvHoleSummary.Rows[(int)SummaryRows.AvgTotalScore_Birdies].Cells[0].Value = "Avg Total Score:";
            dgvHoleSummary.Rows[(int)SummaryRows.AvgTotalScore_Birdies].Cells[3].Value = "Birdies / Rnd";

            dgvHoleSummary.Rows.Add();
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar3_Pars].Cells[0].Value = "Avg Score Par 3's:";
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar3_Pars].Cells[3].Value = "Pars / Rnd";

            dgvHoleSummary.Rows.Add();
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar4_Bogies].Cells[0].Value = "Avg Score Par 4's:";
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar4_Bogies].Cells[3].Value = "Bogies / Rnd";

            dgvHoleSummary.Rows.Add();
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar5_Doubles].Cells[0].Value = "Avg Score Par 5's:";
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar5_Doubles].Cells[3].Value = "Doubles / Rnd";

            dgvHoleSummary.Rows.Add();
            dgvHoleSummary.Rows[(int)SummaryRows.HolesPerEagle_Others].Cells[0].Value = "Holes per Eagle:";
            dgvHoleSummary.Rows[(int)SummaryRows.HolesPerEagle_Others].Cells[3].Value = "Others / Rnd";

            // Driving
            dgvDriving.Rows.Add();
            dgvDriving.Rows[(int)DrivingRows.Fairways].Cells[0].Value = "Avg Fairway %:";

            dgvDriving.Rows.Add();
            dgvDriving.Rows[(int)DrivingRows.Distance].Cells[0].Value = "Avg Driving Dist:";

            dgvDriving.Rows.Add();
            dgvDriving.Rows[(int)DrivingRows.Longest].Cells[0].Value = "Longest Drive:";

            dgvDriving.Rows.Add();
            dgvDriving.Rows[(int)DrivingRows.Hazards].Cells[0].Value = "Avg Drive to Hzd Per Rnd:";

            dgvDriving.Rows.Add();
            dgvDriving.Rows[(int)DrivingRows.OBs].Cells[0].Value = "Avg Drive to OB Per Rnd:";


            // Irons
            dgvIrons.Rows.Add();
            dgvIrons.Rows[(int)IronRows.GIR].Cells[0].Value = "Avg GIR %:";

            dgvIrons.Rows.Add();
            dgvIrons.Rows[(int)IronRows.Distance].Cells[0].Value = "Avg Approach Dist:";

            dgvIrons.Rows.Add();
            dgvIrons.Rows[(int)IronRows.FavoriteClub].Cells[0].Value = "Fav. Approach Club:";

            dgvIrons.Rows.Add();
            dgvIrons.Rows[(int)IronRows.SandShots].Cells[0].Value = "Sand Shots Per Rnd:";

            dgvIrons.Rows.Add();
            dgvIrons.Rows[(int)IronRows.SandSaves].Cells[0].Value = "Sand Save %:";

            // Putting
            dgvPutting.Rows.Add();
            dgvPutting.Rows[(int)PuttingRows.PuttsPerRound].Cells[0].Value = "Avg Putts Per Rnd:";

            dgvPutting.Rows.Add();
            dgvPutting.Rows[(int)PuttingRows.PuttsPerGIR].Cells[0].Value = "Avg Putts Per GIR:";

            dgvPutting.Rows.Add();
            dgvPutting.Rows[(int)PuttingRows.ThreePuttsPerRound].Cells[0].Value = "Avg 3 Putts Per Rnd:";

            dgvPutting.Rows.Add();
            dgvPutting.Rows[(int)PuttingRows.ThreePuttDistance].Cells[0].Value = "Avg 3 Putt Dist:";

            dgvPutting.Rows.Add();
            dgvPutting.Rows[(int)PuttingRows.AvgBirdyPuttDistance].Cells[0].Value = "Avg Birdie Putt Dist:";
        }

        private void PanelStatsSummary_Load(object sender, EventArgs e)
        {
            isLoading = true;

            for (int r = 0; r < dgvCourses.Rows.Count; r++)
            {
                dgvCourses.Rows[r].Cells[1].Value = GetRoundCountForCourse((dgvCourses.Rows[r].Tag as Course).ID);
            }

            // because we are on the first view, clear the selection to load all data by default.
            dgvCourses.ClearSelection();

            isLoading = false;

            Round[] rounds = LoadData();
            PopulateStats(rounds);

        }
        private string GetRoundCountForCourse(int cID)
        {
            if(PanelRoundSummary.CurrentRounds == null)
            {
                PanelRoundSummary.CurrentRounds = DAC.GetRoundsSummaryOnly();
            }

            int result = 0;
            foreach(Round r in PanelRoundSummary.CurrentRounds)
            {
                if(r.Course.ID == cID) { result++;}
            }

            return result.ToString();
        }
        #endregion

        #region UI Event Handlers
        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            Round[] rounds = LoadData();
            PopulateStats(rounds);
        }
        private void Rb18s_CheckedChanged(object sender, EventArgs e)
        {
            Round[] rounds = LoadData();
            PopulateStats(rounds);
        }
        #endregion

        private Round[] LoadData()
        {
            List<Course> Courses = new List<Course>();
            // get selected courses
            if(dgvCourses.SelectedRows.Count == 0)
            {
                // then use all the courses
                foreach(DataGridViewRow r in dgvCourses.Rows)
                {
                    Courses.Add(r.Tag as Course);
                }
            }
            else
            {
                // then use the selected courses
                foreach (DataGridViewRow r in dgvCourses.SelectedRows)
                {
                    Courses.Add(r.Tag as Course);
                }
            }

            // get the dates
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;

            // load rounds for these, Summaries only
            Round[] rounds = DAC.GetRoundsByCoursesAndDates(Courses.ToArray(), from, to, true);

            rounds = Round.FilterRoundsBy18sOr8s(rounds, rb18s.Checked);

            return rounds;
        }

        private void PopulateStats(Round[] rounds)
        {
            if(rounds == null || rounds.Length == 0) { return; }

            if (isLoading) { return; }

            #region Setup Variables
            #region Summary Variables
            List<int> ScoresPar3 = new List<int>();
            List<int> ScoresPar4 = new List<int>();
            List<int> ScoresPar5 = new List<int>();

            int Eagles = 0;
            int Birdies = 0;
            int Pars = 0;
            int Bogies = 0;
            int Doubles = 0;
            int Others = 0;

            int Penalties = 0;
            #endregion
            #region Driving Variables
            int FairwaysHit = 0;
            List<int> Drives = new List<int>();
            int LongestDrive = 0;
            int DriveHazards = 0;
            int DriveOB = 0;
            #endregion
            #region Irons
            int GIR = 0;
            Dictionary<ClubType, int> ApproachClubs = new Dictionary<ClubType, int>();
            List<int> ApproachDistances = new List<int>();
            int TotalSandShots = 0;
            int TotalHolesInSand = 0;
            int TotalSandSaves = 0;
            #endregion
            #region Putts
            int totalPutts = 0;
            List<int> PuttsPerGIR = new List<int>();
            int ThreePuttCount = 0;
            List<int> ThreePuttDist = new List<int>();
            List<int> BirdiePuttDist = new List<int>();
            #endregion
            #endregion

            #region Calculate Values
            int roundsWithShots = 0;
            int roundsWithFGs = 0;
            int roundsWithPutts = 0;

            foreach (Round r in rounds)
            {
                // determine if this rounds had shots entered.
                if(r.HolesPlayed != null && r.HolesPlayed.Count > 0 && r.HolesPlayed[0] != null) // check the first hole
                {
                    if(r.HolesPlayed[0].Shots != null && r.HolesPlayed[0].Shots.Count > 0)
                    {
                        roundsWithShots++;
                    }
                }

                foreach (HoleScore h in r.HolesPlayed)
                {
                    if (h.HolePlayed.Par == 3) { ScoresPar3.Add(h.Score); }
                    else if (h.HolePlayed.Par == 4) { ScoresPar4.Add(h.Score); }
                    else { ScoresPar5.Add(h.Score); }

                    int diff = h.Score - h.HolePlayed.Par;
                    switch(diff)
                    {
                        case -2: Eagles++; break;
                        case -1: Birdies++; break;
                        case 0: Pars++; break;
                        case 1: Bogies++; break;
                        case 2: Doubles++; break;
                        default: Others++; break;
                    }

                    if(h.PenaltyStrokes > 0)
                    {
                        Penalties += h.PenaltyStrokes;
                        if(h.Shots != null && h.Shots.Count > 0 && h.Shots[0].Club == ClubType.Driver && h.Shots[0].ActualResult == Shot.ShotResult.Hazard)
                        {
                            DriveHazards++;
                        }
                        else if (h.Shots != null && h.Shots.Count > 0 && h.Shots[0].Club == ClubType.Driver && h.Shots[0].ActualResult == Shot.ShotResult.OB)
                        {
                            DriveOB++;
                        }
                    }

                    if (h.FairwayWasHit) { FairwaysHit++; }
                    int dist = h.GetDrivingDistance(true);
                    if (dist > 0)
                    {
                        Drives.Add(dist);
                        LongestDrive = Math.Max(LongestDrive, dist);
                    }

                    int p = h.PuttsForHole;
                    if (h.GreenWasHit)
                    {
                        GIR++;
                        PuttsPerGIR.Add(p);

                        if(h.Score == h.HolePlayed.Par - 1)
                        {
                            BirdiePuttDist.Add(h.GetPuttingDistance());
                        }
                    }

                    Shot s = h.GetApproachShot();
                    if(s != null)
                    {
                        ApproachDistances.Add(s.ActualDistance);
                        if(ApproachClubs.ContainsKey(s.Club))
                        {
                            ApproachClubs[s.Club] = ApproachClubs[s.Club] + 1;
                        }
                        else
                        {
                            ApproachClubs.Add(s.Club, 1);
                        }
                    }

                    int sands = h.GetSandShots();
                    if(sands > 0)
                    {
                        TotalHolesInSand++;
                        TotalSandShots += sands;

                        if (sands == 1 && h.Score == h.HolePlayed.Par)
                        {
                            TotalSandSaves++;
                        }
                    }
                    totalPutts += p;
                    if(p >= 3)
                    {
                        ThreePuttCount++;
                        ThreePuttDist.Add(h.GetPuttingDistance());
                    }

                }// end foreach hole in this round

                if(r.TotalGreensHit > 0 || r.TotalFairwaysHit > 0) { roundsWithFGs++; }

                if(r.TotalPutts > 0) { roundsWithPutts++; }

            } // end foreach round
            #endregion

            #region Populate Grid Rows
            #region Populate Summary Rows
            int total3s = SumList(ScoresPar3);
            int total4s = SumList(ScoresPar4);
            int total5s = SumList(ScoresPar5);
            int totalScores = total3s + total4s + total5s;
            dgvHoleSummary.Rows[(int)SummaryRows.NumberOfRounds_Penalties].Cells[1].Value = rounds.Length;
            dgvHoleSummary.Rows[(int)SummaryRows.AvgTotalScore_Birdies].Cells[1].Value = ((double)totalScores / (double)rounds.Length).ToString("F2");
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar3_Pars].Cells[1].Value = ((double)total3s / (double)ScoresPar3.Count).ToString("F2");
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar4_Bogies].Cells[1].Value = ((double)total4s / (double)ScoresPar4.Count).ToString("F2");
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar5_Doubles].Cells[1].Value = ((double)total5s / (double)ScoresPar5.Count).ToString("F2");
            if(Eagles > 0)
            {
                dgvHoleSummary.Rows[(int)SummaryRows.HolesPerEagle_Others].Cells[1].Value = ((double)(ScoresPar3.Count + ScoresPar4.Count + ScoresPar5.Count) / (double)Eagles).ToString("F2");
            }
            else
            {
                dgvHoleSummary.Rows[(int)SummaryRows.HolesPerEagle_Others].Cells[1].Value = "-";
            }

            dgvHoleSummary.Rows[(int)SummaryRows.NumberOfRounds_Penalties].Cells[4].Value = ((double)Penalties / (double)rounds.Length).ToString("F2");
            dgvHoleSummary.Rows[(int)SummaryRows.AvgTotalScore_Birdies].Cells[4].Value = ((double)Birdies / (double)rounds.Length).ToString("F2");
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar3_Pars].Cells[4].Value = ((double)Pars / (double)rounds.Length).ToString("F2");
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar4_Bogies].Cells[4].Value = ((double)Bogies / (double)rounds.Length).ToString("F2");
            dgvHoleSummary.Rows[(int)SummaryRows.AvgScorePar5_Doubles].Cells[4].Value = ((double)Doubles / (double)rounds.Length).ToString("F2");
            dgvHoleSummary.Rows[(int)SummaryRows.HolesPerEagle_Others].Cells[4].Value = ((double)Others / (double)rounds.Length).ToString("F2");
            #endregion
            #region Populate Driving Rows
            groupBox1.Text = $"Driving ({roundsWithShots} rnds)";
            dgvDriving.Rows[(int)DrivingRows.Fairways].Cells[0].Value = $"Avg Fairway % ({roundsWithFGs} rnds)";
            dgvDriving.Rows[(int)DrivingRows.Fairways].Cells[1].Value = ((double)FairwaysHit * 100 / (double)(ScoresPar4.Count + ScoresPar5.Count)).ToString("F2");
            int driveDist = SumList(Drives);
            dgvDriving.Rows[(int)DrivingRows.Distance].Cells[1].Value = ((double)driveDist / (double)(Drives.Count)).ToString("F2");
            dgvDriving.Rows[(int)DrivingRows.Longest].Cells[1].Value = LongestDrive;
            dgvDriving.Rows[(int)DrivingRows.Hazards].Cells[1].Value = ((double)DriveHazards / (double)(roundsWithShots)).ToString("F2");
            dgvDriving.Rows[(int)DrivingRows.OBs].Cells[1].Value = ((double)DriveOB / (double)(roundsWithShots)).ToString("F2");
            #endregion
            #region Populate Iron Rows
            groupBox2.Text = $"Irons ({roundsWithShots} rnds)";
            dgvIrons.Rows[(int)IronRows.GIR].Cells[0].Value = $"Avg GIR % ({roundsWithFGs} rnds):";
            dgvIrons.Rows[(int)IronRows.GIR].Cells[1].Value = ((double)GIR / (double)(roundsWithShots)).ToString("F2");
            dgvIrons.Rows[(int)IronRows.Distance].Cells[1].Value = ((double)SumList(ApproachDistances) / (double)(ApproachDistances.Count)).ToString("F2");
            ClubType t = GetFavoriteApproachClub(ApproachClubs);
            dgvIrons.Rows[(int)IronRows.FavoriteClub].Cells[1].Value = Club.GetClubNameFromClubType(t);
            dgvIrons.Rows[(int)IronRows.SandShots].Cells[1].Value = ((double)TotalSandShots / (double)roundsWithShots).ToString("F2");
            dgvIrons.Rows[(int)IronRows.SandSaves].Cells[1].Value = ((double)TotalSandSaves * 100 / (double)TotalHolesInSand).ToString("F2");
            #endregion
            #region Populate Putting Rows
            groupBox3.Text = $"Putting ({roundsWithPutts} rnds)";
            dgvPutting.Rows[(int)PuttingRows.PuttsPerRound].Cells[1].Value = ((double)totalPutts / (double)(ScoresPar3.Count + ScoresPar4.Count + ScoresPar5.Count)).ToString("F2");
            dgvPutting.Rows[(int)PuttingRows.PuttsPerGIR].Cells[1].Value = ((double)SumList(PuttsPerGIR)/ (double)(PuttsPerGIR.Count)).ToString("F2");
            dgvPutting.Rows[(int)PuttingRows.ThreePuttsPerRound].Cells[1].Value = ((double)ThreePuttCount / (double)(rounds.Length)).ToString("F2");

            dgvPutting.Rows[(int)PuttingRows.ThreePuttDistance].Cells[0].Value = $"Avg 3 Putt Dist ({roundsWithShots} rnds): ";
            dgvPutting.Rows[(int)PuttingRows.ThreePuttDistance].Cells[1].Value = ((double)SumList(ThreePuttDist) / (double)(ThreePuttDist.Count)).ToString("F2");

            dgvPutting.Rows[(int)PuttingRows.AvgBirdyPuttDistance].Cells[0].Value = $"Avg Birdie Putt Dist ({roundsWithShots} rnds):";
            dgvPutting.Rows[(int)PuttingRows.AvgBirdyPuttDistance].Cells[1].Value = ((double)SumList(BirdiePuttDist) / (double)(BirdiePuttDist.Count)).ToString("F2");
            #endregion
            #endregion
        }

        private ClubType GetFavoriteApproachClub(Dictionary<ClubType, int> approachClubs)
        {
            ClubType Fav = ClubType.Wedge_Pitching;
            int usage = 0;
            foreach(ClubType c in approachClubs.Keys)
            {
                if(approachClubs[c] >= usage)
                { Fav = c; usage = approachClubs[c]; }
            }

            return Fav;
        }

        private int SumList(List<int> l)
        {
            int result = 0;
            foreach(int i in l) { result += i; }
            return result;
        }
    }
}
