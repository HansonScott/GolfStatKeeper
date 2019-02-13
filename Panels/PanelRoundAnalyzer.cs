using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelRoundAnalyzer : PanelTemplate
    {
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

        private Round m_thisRound;
        private List<ShotWasted> m_ThisShotsWasted;

        public PanelRoundAnalyzer()
        {
            InitializeComponent();

            if (!FormMain.IsAppRunning) { return; }
        }

        public void LoadRound(Round r)
        {
            m_thisRound = r;
            SetupEmptyScoreCard(r.Course);
            PopulateScoreCardWithHoleSummary();

            SetupShotsWastedGrid();
            AnalyzeRound(r);
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

            // populate intended default rows
            // NOTE: abide by the enum order - HolesRows
            dgvHoles.Rows.Add("Hole Number", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18");

            dgvHoles.Rows.Add("Length", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Par", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Score", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Fairway Hit", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Green Hit", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dgvHoles.Rows.Add("Putts", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            if (c != null) { PopulateEmptyScoreCardFromCourseAndTees(c); }
        }
        private void PopulateEmptyScoreCardFromCourseAndTees(Course course)
        {
            for (int i = 0; i < course.Holes.Length; i++)
            {
                this.dgvHoles.Rows[(int)HolesRows.Par].Cells[i + 1].Value = course.Holes[i].Par;
                this.dgvHoles.Rows[(int)HolesRows.Length].Cells[i + 1].Value = course.Holes[i].Length;
            }
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
        }
        private void AddColumn(DataGridView dgv, string headerTxt, string name)
        {
            DataGridViewColumn col = new DataGridViewColumn(new DataGridViewTextBoxCell());
            col.HeaderText = headerTxt;
            col.Name = name;
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(col);
        }
        private void SetupShotsWastedGrid()
        {
            dgvShotsWasted.Columns.Add("Type", "Type");
            dgvShotsWasted.Columns.Add("HoleNumber", "Hole Number");
            dgvShotsWasted.Columns.Add("Club", "Club");
            //dgvShotsWasted.Columns.Add("ShotNumber", "Shot Number");
        }
        private void AnalyzeRound(Round r)
        {
            List<ShotWasted> results = new List<ShotWasted>();
            foreach(HoleScore h in r.HolesPlayed)
            {
                List<ShotWasted> w = ShotWasted.FindWastedShots(h);
                results.AddRange(w);
            }

            ShotWasted.SortList(ref results);

            m_ThisShotsWasted = results;

            PopulateShotsWasted();
        }
        private void PopulateShotsWasted()
        {
            dgvShotsWasted.Rows.Clear();

            int count = (int)this.numericUpDown1.Value;

            this.lblScore.Text = m_thisRound.TotalScore.ToString();
            this.lblNetScore.Text = (m_thisRound.TotalScore - count).ToString();

            for(int i = 0; i < count && i < m_ThisShotsWasted.Count; i++)
            {
                ShotWasted w = m_ThisShotsWasted[i];
                int ID = dgvShotsWasted.Rows.Add();
                DataGridViewRow row = dgvShotsWasted.Rows[ID];
                row.Cells["Type"].Value = w.type;
                row.Cells["HoleNumber"].Value = w.holeNumber;
                row.Cells["Club"].Value = GetClubName(w.club);
                //row.Cells["ShotNumber"].Value = w.shotNumber;
            }
        }

        private string GetClubName(ClubType club)
        {
            foreach(Club c in FormMain.thisForm.CurrentPlayer.Bag.Clubs)
            {
                if(c.ClubType == club) { return c.Name; }
            }

            return null;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PopulateShotsWasted();
        }
    }
}
