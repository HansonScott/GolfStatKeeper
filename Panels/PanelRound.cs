using System;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelRound : PanelTemplate
    {
        #region Private Enums
        private enum HolesRows
        {
            HoleNumber = 0,
            Par = 1,
            Score = 2,
            Fairway = 3,
            Green = 4,
            Putts = 5,
        }
        private enum ShotsColumns
        {
            ShotNumber = 0,
            Lie = 1,
            Club = 2,
            Intended_Flight = 3,
            Intended_Length = 4,
            Actual_Flight = 5,
            Actual_Length = 6,
            Result = 7,
        }
        #endregion

        bool IsLoading = true;
        private bool m_isDirty;
        private bool isDirty
        {
            get { return m_isDirty; }
            set
            {
                m_isDirty = value;
                this.btnSave.Enabled = value;
            }
        }
        private Round m_thisRound;

        #region Constructor and Setup
        public PanelRound(): this(-1){}
        public PanelRound(int RoundID)
        {
            InitializeComponent();

            if (FormMain.IsAppRunning)
            {
                PopulateCBCourses();
            }

            SetupShotDetailsGridWithPlayerClubs();

            if (RoundID != -1)
            {
                // an existing round being reviewed/edited
                LoadRoundData(RoundID);
            }
            else
            {
                m_thisRound = new Round();
                SetupEmptyScoreCard(18);
            }

            IsLoading = false;
        }

        private void PopulateCBCourses()
        {
            cbCourse.DataSource = DAC.GetCourses();
            cbCourse.DisplayMember = "CourseAndTee";
        }
        private void SetupShotDetailsGridWithPlayerClubs()
        {
            (dgvShots.Columns[(int)ShotsColumns.Club] as DataGridViewComboBoxColumn).DisplayMember = "Name";

            Club[] clubs;
            if (FormMain.IsAppRunning &&
                FormMain.thisForm.CurrentPlayer != null)
            {
                 clubs = FormMain.thisForm.CurrentPlayer.Bag.Clubs;
            }
            else
            {
                clubs = GolfBag.NewBag().Clubs;                
            }

            (dgvShots.Columns[(int)ShotsColumns.Club] as DataGridViewComboBoxColumn).DataSource = clubs;
        }
        public void LoadRoundData(int roundID)
        {
            // get round object from file
            m_thisRound = DAC.GetRoundByID(roundID);

            // load summary fields
            dtWhen.Value = m_thisRound.When;
            cbCourse.SelectedItem = m_thisRound.Course;
            cbConditions.Text = Enum.GetName(typeof(Round.RoundConditions), m_thisRound.Conditions);

            // load holes
            SetupEmptyScoreCard(m_thisRound.Course.Holes.Length);
            PopulateScoreCardWithHoleSummary();
        }
        private void PopulateScoreCardWithHoleSummary()
        {
            int ColumnNumber = 1;
            foreach (HoleScore h in m_thisRound.HolesPlayed)
            {
                dgvHoles.Rows[(int)HolesRows.HoleNumber].Cells[ColumnNumber].Value = h.HolePlayed.HoleNumber;
                dgvHoles.Rows[(int)HolesRows.Score].Cells[ColumnNumber].Value = h.Score;
                dgvHoles.Rows[(int)HolesRows.Fairway].Cells[ColumnNumber].Value = (h.FairwayWasHit() ? "X" : ""); // interpret the boolean for display
                dgvHoles.Rows[(int)HolesRows.Green].Cells[ColumnNumber].Value = (h.GreenWasHit() ? "X" : "");
                dgvHoles.Rows[(int)HolesRows.Putts].Cells[ColumnNumber++].Value = h.GetPuttsForHole();
            }

            PopulateSummaryTotals();
        }
        private void PopulateSummaryTotals()
        {
            // score
            dgvHoles.Rows[(int)HolesRows.Score].Cells[20].Value = m_thisRound.TotalScore;

            // fairways - as a fraction string
            string f = m_thisRound.TotalFairwaysHit + " / " + m_thisRound.Course.GetTotalFairways();
            dgvHoles.Rows[(int)HolesRows.Fairway].Cells[20].Value = f;

            // greens
            dgvHoles.Rows[(int)HolesRows.Green].Cells[20].Value = m_thisRound.TotalGreensHit;

            // putts
            dgvHoles.Rows[(int)HolesRows.Putts].Cells[20].Value = m_thisRound.TotalPutts;
        }
        private void SetupEmptyScoreCard(int holeCount)
        {
            dgvHoles.Columns.Clear();

            // add the row header column
            AddColumn(dgvHoles, "", "ColumnHeaderText");

            // add all the holes
            int ColumnNumber = 0;
            for(int h = 0; h < holeCount; h++)
            {
                AddColumn(dgvHoles, "Column" + ColumnNumber++, h.ToString());
            }

            // add the totals column
            AddColumn(dgvHoles, "ColumnTotals", "");

            // populate intended default rows
            // NOTE: abide by the enum order - HolesRows
            dgvHoles.Rows.Add("Hole Number", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18");
            dgvHoles.Rows.Add("Par", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Score", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Fairway Hit", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Green Hit", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Putts", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        }

        private void AddColumn(DataGridView dgv, string headerTxt, string name)
        {
            DataGridViewColumn col = new DataGridViewColumn(new DataGridViewTextBoxCell());
            col.HeaderText = headerTxt;
            col.Name = name;
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(col);
        }
        #endregion

        #region UI Event Handlers
        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormMain.IsAppRunning) { return; }

            if (cbCourse.SelectedItem == null) { return; }

            // reset score card
            SetupEmptyScoreCard((cbCourse.SelectedItem as Course).Holes.Length);


            // populate tees combo
            PopulateEmptyScoreCardFromCourseAndTees(cbCourse.SelectedItem as Course);
            if(!IsLoading)
            {
                isDirty = true;
            }
        }
        private void dtWhen_ValueChanged(object sender, EventArgs e)
        {
            if (m_thisRound.When != dtWhen.Value)
            {
                m_thisRound.When = dtWhen.Value;
                if (!IsLoading)
                {
                    isDirty = true;
                }
            }
        }
        private void cbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormMain.IsAppRunning) { return; }

            Round.RoundConditions RoundConditions = (Round.RoundConditions)Enum.Parse(typeof(Round.RoundConditions), cbConditions.SelectedValue.ToString());

            if (RoundConditions != m_thisRound.Conditions)
            {
                m_thisRound.Conditions = RoundConditions;
                if (!IsLoading)
                {
                    isDirty = true;
                }
            }
        }
        private void dgvHolesPlayed_SelectionChanged(object sender, EventArgs e)
        {
            if (!FormMain.IsAppRunning) { return; }

            if (dgvHoles.SelectedColumns.Count == 1)
            {
                int holeNumber = dgvHoles.SelectedColumns[0].Index;
                if (holeNumber > 0 &&
                    holeNumber < m_thisRound.HolesPlayed.Count)
                {
                    HoleScore h = m_thisRound.HolesPlayed[holeNumber];
                    LoadShots(h);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            HandleRoundSave();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // prompt then close
            if (isDirty)
            {
                DialogResult res = MessageBox.Show("The values in this round have changed, do you want to save first?", "Changes made", MessageBoxButtons.YesNoCancel);

                if (res == DialogResult.Cancel) { return; }
                else if (res == DialogResult.Yes) { HandleRoundSave(); }
                // else if no, just close - falls through to below.
            }

            // close parent form and return to round summary list.
            this.ParentForm.Close();
        }
        private void btnSaveHole_Click(object sender, EventArgs e)
        {
            HandleSaveHole();
        }
        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            HandleSaveHole();

            // highlight and load the next hole
            int holeNumber = dgvHoles.SelectedColumns[0].Index;

            dgvHoles.SelectedColumns[holeNumber].Selected = false;
            if (holeNumber < 19)
            {
                dgvHoles.SelectedColumns[holeNumber++].Selected = true;

                // should trigger the load by going through the selection changed handler
                //HoleScore h = m_thisRound.HolesPlayed[holeNumber];
                //LoadShots(h);
            }
        }
        #endregion

        #region Private Functions
        private void LoadShots(HoleScore holePlayed)
        {
            this.nud_Penalties.Value = holePlayed.PenaltyStrokes;

            foreach(Shot s in holePlayed.Shots)
            {
                DataGridViewRow shotRow = new DataGridViewRow();

                shotRow.Cells[(int)ShotsColumns.ShotNumber].Value = s.ShotNumber;
                shotRow.Cells[(int)ShotsColumns.Lie].Value = s.Lie;
                shotRow.Cells[(int)ShotsColumns.Club].Value = s.Club;
                shotRow.Cells[(int)ShotsColumns.Intended_Flight].Value = s.TargetFlight;
                shotRow.Cells[(int)ShotsColumns.Intended_Length].Value = s.TargetDistance;
                shotRow.Cells[(int)ShotsColumns.Actual_Flight].Value = s.ActualFlight;
                shotRow.Cells[(int)ShotsColumns.Actual_Length].Value = s.ActualDistance;
                shotRow.Cells[(int)ShotsColumns.Result].Value = s.ActualResult;

                dgvShots.Rows.Add(shotRow);
            }
        }
        private void PopulateEmptyScoreCardFromCourseAndTees(Course course)
        {
            for(int i = 0; i < course.Holes.Length; i++)
            {
                this.dgvHoles.Rows[(int)HolesRows.Par].Cells[i + 1].Value = course.Holes[i].Par;
            }
        }
        private void HandleSaveHole()
        {
            // gather details from this hole
            HoleScore hole = new HoleScore();
            hole.PenaltyStrokes = (int)nud_Penalties.Value;

            foreach (DataGridViewRow row in dgvShots.Rows)
            {
                Shot s = new Shot();

                s.ShotNumber = Int32.Parse(row.Cells[(int)ShotsColumns.ShotNumber].Value.ToString());
                s.Lie = (Shot.BallLie)Enum.Parse(typeof(Shot.BallLie), row.Cells[(int)ShotsColumns.Lie].Value.ToString());
                s.Club = (ClubType)Enum.Parse(typeof(ClubType), row.Cells[(int)ShotsColumns.Club].Value.ToString());
                s.TargetDistance = Int32.Parse(row.Cells[(int)ShotsColumns.Intended_Length].Value.ToString());
                s.TargetFlight = (Shot.BallFlight)Enum.Parse(typeof(Shot.BallFlight), row.Cells[(int)ShotsColumns.Intended_Flight].Value.ToString());
                s.ActualDistance = Int32.Parse(row.Cells[(int)ShotsColumns.Actual_Length].Value.ToString());
                s.ActualFlight = (Shot.BallFlight)Enum.Parse(typeof(Shot.BallFlight), row.Cells[(int)ShotsColumns.Actual_Flight].Value.ToString());
                s.ActualResult = (Shot.ShotResult)Enum.Parse(typeof(Shot.ShotResult), row.Cells[(int)ShotsColumns.Result].Value.ToString());
            }

            // store back to this hole in thisRound.
            int holeNumber = dgvHoles.SelectedColumns[0].Index;
            m_thisRound.HolesPlayed[holeNumber] = hole;

            // repopulate scorecard with changes
            PopulateScoreCardWithHoleSummary();
        }
        private void HandleRoundSave()
        {
            if(m_thisRound.ID == -1)
            {
                DAC.AddRound(m_thisRound);
            }
            else
            {
                DAC.SaveRound(m_thisRound);
            }
        }
        #endregion
    }
}
