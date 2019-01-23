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
            Length = 3,
            Result = 4,
        }
        #endregion

        bool IsLoading = true;
        bool isDirty = false;
        private Round m_thisRound;

        #region Constructor and Setup
        public PanelRound(): this(-1){}
        public PanelRound(int RoundID)
        {
            InitializeComponent();

            PopulateCBCourses();
            SetupEmptyScoreCard();
            SetupShotDetailsGridWithPlayerClubs();

            if (RoundID != -1)
            {
                // an existing round being reviewed/edited
                LoadRoundData(RoundID);
            }
            else
            {
                m_thisRound = new Round();
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
            if (FormMain.thisForm.CurrentPlayer != null)
            {
                 clubs = FormMain.thisForm.CurrentPlayer.Bag.Clubs;
            }
            else
            {
                clubs = GolfBag.NewBag().Clubs;                
            }

            (dgvShots.Columns[(int)ShotsColumns.Club] as DataGridViewComboBoxColumn).DataSource = clubs;
        }
        private void LoadRoundData(int roundID)
        {
            // get round object from file
            m_thisRound = DAC.GetRoundByID(roundID);

            // load summary fields
            dtWhen.Value = m_thisRound.When;
            cbCourse.SelectedItem = m_thisRound.Course;
            cbConditions.Text = Enum.GetName(typeof(Round.RoundConditions), m_thisRound.Conditions);

            // load holes
            SetupEmptyScoreCard();
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
        private void SetupEmptyScoreCard()
        {
            // add the row header column
            dgvHoles.Columns.Add("ColumnHeader", "");

            // add all the holes
            int ColumnNumber = 0;
            foreach (HoleScore h in m_thisRound.HolesPlayed)
            {
                dgvHoles.Columns.Add("Column" + ColumnNumber++, h.HolePlayed.HoleNumber.ToString());
            }

            // add the totals column
            dgvHoles.Columns.Add("ColumnTotals", "");

            // populate intended default rows
            // NOTE: abide by the enum order - HolesRows
            DataGridViewRow rowHoleNumber = new DataGridViewRow();
            rowHoleNumber.Cells[0].Value = "Hole Number";
            dgvHoles.Rows.Add(rowHoleNumber);

            DataGridViewRow rowPar = new DataGridViewRow();
            rowPar.Cells[0].Value = "Par";
            dgvHoles.Rows.Add(rowPar);

            DataGridViewRow rowScore = new DataGridViewRow();
            rowScore.Cells[0].Value = "Score";
            dgvHoles.Rows.Add(rowScore);

            DataGridViewRow rowFwy = new DataGridViewRow();
            rowFwy.Cells[0].Value = "Fairway Hit";
            dgvHoles.Rows.Add(rowFwy);

            DataGridViewRow rowGrn = new DataGridViewRow();
            rowGrn.Cells[0].Value = "Green Hit";
            dgvHoles.Rows.Add(rowGrn);

            DataGridViewRow rowPutts = new DataGridViewRow();
            rowPutts.Cells[0].Value = "Putts";
            dgvHoles.Rows.Add(rowPutts);
        }
        #endregion

        #region UI Event Handlers
        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear score card
            SetupEmptyScoreCard();

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
            if (dgvHoles.SelectedColumns.Count == 1)
            {
                int holeNumber = dgvHoles.SelectedColumns[0].Index;
                HoleScore h = m_thisRound.HolesPlayed[holeNumber];
                LoadShots(h);
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
                shotRow.Cells[(int)ShotsColumns.Length].Value = s.ActualDistance;
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
                s.ActualDistance = Int32.Parse(row.Cells[(int)ShotsColumns.Length].Value.ToString());
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
