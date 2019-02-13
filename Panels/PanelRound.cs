using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelRound : PanelTemplate
    {
        #region Private Enums
        private enum HolesRows
        {
            HoleNumber = 0,
            Length = 1,
            Par = 2,
            Score = 3,
            Fairway = 4,
            Green = 5,
            Putts = 6,
        }
        private enum ShotsColumns
        {
            Lie = 0,
            Club = 1,
            Intended_Flight = 2,
            Intended_Length = 3,
            Result = 4,
            Actual_Flight = 5,
            Actual_Length = 6,
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

            if (!FormMain.IsAppRunning) { return; }

            PopulateCBCourses();

            PopulateCBConditions();

            SetupShotDetailsGridWithPlayerClubs();

            if (RoundID != -1)
            {
                // an existing round being reviewed/edited
                LoadRoundData(RoundID);
            }
            else
            {
                SetupNewRound();
                SetupEmptyScoreCard(cbCourse.Items[0] as Course);
            }

            IsLoading = false;
        }

        private void SetupNewRound()
        {
            m_thisRound = new Round();
            m_thisRound.Course = (cbCourse.SelectedItem as Course);
            m_thisRound.HolesPlayed = new System.Collections.Generic.List<HoleScore>(m_thisRound.Course.Holes.Length);
            UpdateRoundFromUI();
        }
        private void UpdateRoundFromUI()
        {
            m_thisRound.Course = (cbCourse.SelectedItem as Course);
            m_thisRound.Conditions = (Round.RoundConditions)(Enum.Parse(typeof(Round.RoundConditions), (cbConditions.SelectedItem as CBItem).Name));
            m_thisRound.Player = FormMain.thisForm.CurrentPlayer;
            m_thisRound.When = dtWhen.Value;
        }
        private void PopulateCBConditions()
        {
            ComboBoxUtil.PopulateCBFromEnum(cbConditions, typeof(Round.RoundConditions));
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
            (dgvShots.Columns[(int)ShotsColumns.Lie] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(Shot.BallLie));
            (dgvShots.Columns[(int)ShotsColumns.Intended_Flight] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(Shot.BallFlight));
            (dgvShots.Columns[(int)ShotsColumns.Actual_Flight] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(Shot.BallFlight));
            (dgvShots.Columns[(int)ShotsColumns.Result] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(Shot.ShotResult));
        }
        private void PopulateScoreCardWithHoleSummary()
        {
            int ColumnNumber = 1;
            if (m_thisRound.HolesPlayed != null)
            {
                foreach (HoleScore h in m_thisRound.HolesPlayed)
                {
                    if (h != null)
                    {
                        //dgvHoles.Rows[(int)HolesRows.HoleNumber].Cells[ColumnNumber].Value = h.HolePlayed.HoleNumber;
                        dgvHoles.Rows[(int)HolesRows.Score].Cells[ColumnNumber].Value = h.Score;
                        dgvHoles.Rows[(int)HolesRows.Fairway].Cells[ColumnNumber].Value = (h.FairwayWasHit ? "X" : ""); // interpret the boolean for display
                        dgvHoles.Rows[(int)HolesRows.Green].Cells[ColumnNumber].Value = (h.GreenWasHit ? "X" : "");
                        dgvHoles.Rows[(int)HolesRows.Putts].Cells[ColumnNumber].Value = h.PuttsForHole;
                    }

                    ColumnNumber++;
                }
            }
            PopulateSummaryTotals();
        }
        private void PopulateSummaryTotals()
        {
            int totalsColumn = 19;

            // update round from holes
            m_thisRound.UpdateTotalsFromHolesPlayed();

            // length
            dgvHoles.Rows[(int)HolesRows.Length].Cells[totalsColumn].Value = m_thisRound.Course.GetTotalLength();

            // par
            dgvHoles.Rows[(int)HolesRows.Par].Cells[totalsColumn].Value = m_thisRound.Course.GetTotalPar();

            // score
            dgvHoles.Rows[(int)HolesRows.Score].Cells[totalsColumn].Value = m_thisRound.TotalScore;

            // fairways - as a fraction string
            string f = m_thisRound.TotalFairwaysHit + " / " + m_thisRound.Course.GetTotalFairways();
            dgvHoles.Rows[(int)HolesRows.Fairway].Cells[totalsColumn].Value = f;

            // greens
            dgvHoles.Rows[(int)HolesRows.Green].Cells[totalsColumn].Value = m_thisRound.TotalGreensHit;

            // putts
            dgvHoles.Rows[(int)HolesRows.Putts].Cells[totalsColumn].Value = m_thisRound.TotalPutts;
        }
        private void SetupEmptyScoreCard(Course c)
        {
            dgvHoles.Columns.Clear();

            // add the row header column
            AddColumn(dgvHoles, "", "ColumnHeaderText");

            // add all the holes
            int ColumnNumber = 0;
            if (c != null)
            {
                for (int h = 0; h < c.Holes.Length; h++)
                {
                    AddColumn(dgvHoles, "Column" + ColumnNumber++, h.ToString());
                }
            }
            else
            {
                for (int h = 0; h < 18; h++)
                {
                    AddColumn(dgvHoles, "Column" + ColumnNumber++, h.ToString());
                }
            }
            // add the totals column
            AddColumn(dgvHoles, "ColumnTotals", "");

            // populate intended default rows
            // NOTE: abide by the enum order - HolesRows
            dgvHoles.Rows.Add("Hole Number", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18");

            dgvHoles.Rows.Add("Length", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Par", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Score", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Fairway Hit", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Green Hit", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Putts", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            if(c != null) { PopulateEmptyScoreCardFromCourseAndTees(c); }
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
            if (IsLoading) { return; }

            if (cbCourse.SelectedItem == null) { return; }

            // reset score card
            Course c = (cbCourse.SelectedItem as Course);
            UpdateRoundFromUI();

            SetupEmptyScoreCard(c);

            // populate tees combo
            PopulateEmptyScoreCardFromCourseAndTees(c);

            m_thisRound.HolesPlayed.Capacity = c.Holes.Length;
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

            if (this.m_thisRound != null &&
                RoundConditions != m_thisRound.Conditions)
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

            // if we selected anything, clear the grid below before determining what to load.
            dgvShots.Rows.Clear();
            
            if (dgvHoles.SelectedColumns.Count == 1)
            {
                int holeNumber = dgvHoles.SelectedColumns[0].DisplayIndex;

                // only allow adding of shots if a column is selected that is a normal hole.
                dgvShots.AllowUserToAddRows = (dgvHoles.SelectedColumns[0].DisplayIndex > 0 && 
                                                dgvHoles.SelectedColumns[0].DisplayIndex < 19);

                // if we have shots for this hole, load them
                if (holeNumber == 0) { } // this is the row header, do nothing
                else if (holeNumber > m_thisRound.Course.Holes.Length) { } // totals column, do nothing
                else if (holeNumber < m_thisRound.HolesPlayed.Count) // if we have hole data for this so far
                {
                    HoleScore h = m_thisRound.HolesPlayed[holeNumber - 1];
                    LoadShots(h);
                }
                else // this is a new hole played, create an empty slot for the shots.
                {
                    for (int i = 0; i < holeNumber; i++)
                    {
                        if (m_thisRound.HolesPlayed.Count <= i ||
                            m_thisRound.HolesPlayed[i] == null)
                        {
                            HoleScore hs = new HoleScore();
                            hs.HolePlayed = m_thisRound.Course.Holes[i];
                            m_thisRound.HolesPlayed.Add(hs);
                        }
                    }
                }
            }
        }
        private void dgvHoles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsLoading) { return; }

            // otherwise, update things
            CaptureHoleSummaryIfNoShots();
            PopulateSummaryTotals();

            // and set the round as dirty
            isDirty = true;
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

        private void dgvShots_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsLoading) { return; }

            // if we hit the shot as intended, then copy the intended values over to the actual values
            if (e.ColumnIndex == (int)ShotsColumns.Result)
            {
                if (this.dgvShots.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() ==
                    (Shot.ShotResult.As_intended).ToString())
                {
                    this.dgvShots.Rows[e.RowIndex].Cells[(int)ShotsColumns.Actual_Flight].Value =
                        this.dgvShots.Rows[e.RowIndex].Cells[(int)ShotsColumns.Intended_Flight].Value;

                    this.dgvShots.Rows[e.RowIndex].Cells[(int)ShotsColumns.Actual_Length].Value =
                        this.dgvShots.Rows[e.RowIndex].Cells[(int)ShotsColumns.Intended_Length].Value;

                }
            }

            // when we choose a lie, assume the club, if we can.
            if (e.ColumnIndex == (int)ShotsColumns.Lie)
            {
                if (this.dgvShots.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == (Shot.BallLie.Tee).ToString())
                {
                    this.dgvShots.Rows[e.RowIndex].Cells[(int)ShotsColumns.Club].Value = GetClubByType(ClubType.Driver).Name; // driver
                }
                else if (this.dgvShots.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == (Shot.BallLie.Sand).ToString())
                {
                    this.dgvShots.Rows[e.RowIndex].Cells[(int)ShotsColumns.Club].Value = GetClubByType(ClubType.Wedge_Sand).Name; // sand wedge
                }
                else if (this.dgvShots.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == (Shot.BallLie.Green).ToString())
                {
                    this.dgvShots.Rows[e.RowIndex].Cells[(int)ShotsColumns.Club].Value = GetClubByType(ClubType.Putter).Name; // putter
                    this.dgvShots.Rows[e.RowIndex].Cells[(int)ShotsColumns.Intended_Flight].Value = Shot.BallFlight.Straight.ToString(); // putter
                }
            }
        }

        private Club GetClubByType(ClubType ct)
        {
            Club[] clubs = FormMain.thisForm.CurrentPlayer.Bag.Clubs;
            foreach(Club c in clubs)
            {
                if(c.ClubType == ct) { return c; }
            }

            return null;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvShots.SelectedCells[0].RowIndex;
            dgvShots.Rows.RemoveAt(r);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvShots.Rows.Add();
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            int r = dgvShots.SelectedCells[0].RowIndex;
            DataGridViewRow rowToMove = dgvShots.Rows[r];
            dgvShots.Rows.Remove(rowToMove);
            dgvShots.Rows.Insert(Math.Max(r - 1, 0), rowToMove);
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            int r = dgvShots.SelectedCells[0].RowIndex;
            DataGridViewRow rowToMove = dgvShots.Rows[r];
            dgvShots.Rows.Remove(rowToMove);
            dgvShots.Rows.Insert(Math.Min(r + 1, dgvShots.Rows.Count - 1), rowToMove);
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

            dgvHoles.SelectedColumns[0].Selected = false;
            if (holeNumber < 19)
            {
                dgvHoles.Columns[holeNumber + 1].Selected = true;

                // should trigger the load by going through the selection changed handler
                //HoleScore h = m_thisRound.HolesPlayed[holeNumber];
                //LoadShots(h);
            }
        }
        #endregion

        #region Public Methods
        public void LoadRoundData(int roundID)
        {
            this.IsLoading = true;

            // get round object from file
            m_thisRound = DAC.GetRoundByID(roundID);

            // load summary fields
            dtWhen.Value = m_thisRound.When;
            cbCourse.SelectedItem = m_thisRound.Course;
            cbConditions.Text = Enum.GetName(typeof(Round.RoundConditions), m_thisRound.Conditions);

            // load holes
            SetupEmptyScoreCard(m_thisRound.Course);
            PopulateScoreCardWithHoleSummary();

            this.IsLoading = false;
        }
        #endregion

        #region Private Functions
        private void LoadShots(HoleScore holePlayed)
        {
            this.nud_Penalties.Value = holePlayed.PenaltyStrokes;

            foreach(Shot s in holePlayed.Shots)
            {
                int newRowIndex = dgvShots.Rows.Add();
                DataGridViewRow shotRow = dgvShots.Rows[newRowIndex];

                shotRow.Cells[(int)ShotsColumns.Lie].Value = s.Lie.ToString();
                string c = GetClubNameFromClubType(s.Club.ToString());
                shotRow.Cells[(int)ShotsColumns.Club].Value = c;
                shotRow.Cells[(int)ShotsColumns.Intended_Flight].Value = s.TargetFlight.ToString();
                shotRow.Cells[(int)ShotsColumns.Intended_Length].Value = s.TargetDistance;
                shotRow.Cells[(int)ShotsColumns.Result].Value = s.ActualResult.ToString();
                shotRow.Cells[(int)ShotsColumns.Actual_Flight].Value = s.ActualFlight.ToString();
                shotRow.Cells[(int)ShotsColumns.Actual_Length].Value = s.ActualDistance;
            }
        }
        private string GetClubNameFromClubType(string clubType)
        {
            // comes in as a custom name, needs to map back to the generic type
            foreach (Club c in FormMain.thisForm.CurrentPlayer.Bag.Clubs)
            {
                if (c.ClubType.ToString() == clubType) { return c.Name; }
            }

            return null;
        }
        private void PopulateEmptyScoreCardFromCourseAndTees(Course course)
        {
            for(int i = 0; i < course.Holes.Length; i++)
            {
                this.dgvHoles.Rows[(int)HolesRows.Par].Cells[i + 1].Value = course.Holes[i].Par;
                this.dgvHoles.Rows[(int)HolesRows.Length].Cells[i + 1].Value = course.Holes[i].Length;
            }
        }
        private void HandleSaveHole()
        {
            // gather details from this hole
            HoleScore hole = new HoleScore();
            hole.PenaltyStrokes = (int)nud_Penalties.Value;

            // save each shot
            foreach (DataGridViewRow row in dgvShots.Rows)
            {
                if (row.IsNewRow) { continue; }

                Shot s = new Shot();

                object valShotNumber = row.Index + 1;
                if (valShotNumber != null)
                {
                    int isn;
                    if(Int32.TryParse(valShotNumber.ToString(), out isn))
                    {
                        s.ShotNumber = isn;
                    }
                }

                object valLie = row.Cells[(int)ShotsColumns.Lie].Value;
                if (valLie != null)
                {
                    s.Lie = (Shot.BallLie)Enum.Parse(typeof(Shot.BallLie), valLie.ToString());
                }

                object valClub = row.Cells[(int)ShotsColumns.Club].Value;
                if (valClub != null)
                {
                    object valClubType = GetClubTypeFromClubName(valClub);

                    s.Club = (ClubType)Enum.Parse(typeof(ClubType), valClubType.ToString());
                }

                object valTargetDistance = row.Cells[(int)ShotsColumns.Intended_Length].Value;
                if (valTargetDistance != null)
                {
                    int itd;
                    if(Int32.TryParse(valTargetDistance.ToString(), out itd))
                    {
                        s.TargetDistance = itd;
                    }
                }

                object valTargetFlight = row.Cells[(int)ShotsColumns.Intended_Flight].Value;
                if (valTargetFlight != null)
                {
                    s.TargetFlight = (Shot.BallFlight)Enum.Parse(typeof(Shot.BallFlight), valTargetFlight.ToString());
                }

                object valActualDistance = row.Cells[(int)ShotsColumns.Actual_Length].Value;
                if (valActualDistance != null)
                {
                    int iad;
                    if (Int32.TryParse(valActualDistance.ToString(), out iad))
                    {
                        s.ActualDistance = iad;
                    }
                }

                object valActualFlight = row.Cells[(int)ShotsColumns.Actual_Flight].Value;
                if (valActualFlight != null)
                {
                    s.ActualFlight = (Shot.BallFlight)Enum.Parse(typeof(Shot.BallFlight), valActualFlight.ToString());
                }

                object valShotResult = row.Cells[(int)ShotsColumns.Result].Value;
                if (valShotResult != null)
                {
                    s.ActualResult = (Shot.ShotResult)Enum.Parse(typeof(Shot.ShotResult), valShotResult.ToString());
                }
                hole.Shots.Add(s);
            }

            // store back to this hole in thisRound.
            int holeNumber = dgvHoles.SelectedColumns[0].DisplayIndex;

            // capture the course's hole that this score is for
            if(m_thisRound != null && m_thisRound.Course != null)
            {
                hole.HolePlayed = m_thisRound.Course.Holes[holeNumber - 1];
            }
            else
            {
                hole.HolePlayed = (cbCourse.SelectedItem as Course).Holes[holeNumber - 1];
            }

            // and store this score back to this round
            if (m_thisRound.HolesPlayed.Count >= holeNumber &&
                m_thisRound.HolesPlayed[holeNumber - 1] != null)
            {
                m_thisRound.HolesPlayed[holeNumber - 1] = hole;
            }
            else
            {
                m_thisRound.HolesPlayed.Add(hole);
            }

            m_thisRound.UpdateTotalsFromHolesPlayed();

            // repopulate scorecard with changes
            PopulateScoreCardWithHoleSummary();
        }
        private object GetClubTypeFromClubName(object valClub)
        {
            // comes in as a custom name, needs to map back to the generic type
            foreach(Club c in FormMain.thisForm.CurrentPlayer.Bag.Clubs)
            {
                if(c.Name == valClub.ToString()) { return c.ClubType; }
            }

            return null;
        }
        private void HandleRoundSave()
        {
            CaptureHoleSummaryIfNoShots();

            if(m_thisRound.ID == -1)
            {
                DAC.AddRound(m_thisRound);
                MessageBox.Show("Round added");
            }
            else
            {
                DAC.SaveRound(m_thisRound);
                MessageBox.Show("Round saved.");
            }

            this.isDirty = false;
        }

        private void CaptureHoleSummaryIfNoShots()
        {
            // foreach hole, if there are no shots, then capture the summaries at least.
            for(int i = 1; i < dgvHoles.Columns.Count - 1; i++)
            {
                // if grid has no values, skip
                if (dgvHoles.Rows[(int)HolesRows.Score].Cells[i].Value == null ||
                    dgvHoles.Rows[(int)HolesRows.Score].Cells[i].Value.ToString() == String.Empty) { continue; }

                // if grid has values, then
                else
                {
                    // if thisRound.thisHole has shots, skip
                    if(m_thisRound.HolesPlayed != null && 
                        m_thisRound.HolesPlayed.Count > i &&
                        m_thisRound.HolesPlayed[i].Shots != null &&
                        m_thisRound.HolesPlayed[i].Shots.Count > 0)
                        { continue; }

                    // if thisRound.thisHole doesn't have shots
                    if (m_thisRound.HolesPlayed == null) { m_thisRound.HolesPlayed = new List<HoleScore>(); }
                    while (m_thisRound.HolesPlayed.Count < i) { m_thisRound.HolesPlayed.Add(new HoleScore()); }

                    // capture summary to thisHole
                    HoleScore h = m_thisRound.HolesPlayed[i - 1];

                    object sobj = dgvHoles.Rows[(int)HolesRows.Score].Cells[i].Value;
                    if(sobj != null)
                    {
                        int sval = 0;
                        if (Int32.TryParse(sobj.ToString(), out sval)) { h.Score = sval; }
                    }

                    object fObj = dgvHoles.Rows[(int)HolesRows.Fairway].Cells[i].Value;
                    h.FairwayWasHit = (fObj != null && fObj.ToString() != string.Empty && 
                                    (fObj.ToString() == "X" || fObj.ToString() == "Y" || fObj.ToString() == "1"));

                    object gObj = dgvHoles.Rows[(int)HolesRows.Green].Cells[i].Value;
                    h.GreenWasHit = (gObj != null && gObj.ToString() != string.Empty &&
                                    (gObj.ToString() == "X" || gObj.ToString() == "Y" || gObj.ToString() == "1"));

                    object pobj = dgvHoles.Rows[(int)HolesRows.Putts].Cells[i].Value;
                    if(pobj != null)
                    {
                        int pval = 0;
                        if (Int32.TryParse(pobj.ToString(), out pval)) { h.PuttsForHole = pval; }
                    }
                }
            }
        }
        #endregion
    }
}
