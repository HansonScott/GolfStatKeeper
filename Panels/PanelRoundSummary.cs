using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelRoundSummary : PanelTemplate
    {
        public enum RoundGridColumns
        {
            Date = 0,
            CourseTee = 1,
            Fairways = 2,
            Greens = 3,
            Putts = 4,
            Penalties = 5,
            Score = 6,
        }

        public PanelRoundSummary()
        {
            InitializeComponent();
        }

        public void LoadRoundSummaries()
        {
            if (FormMain.thisForm.CurrentPlayer == null) { return; }

            dgvRounds.Rows.Clear();

            Round[] rounds = DAC.GetRoundsSummaryOnly();

            int grandScore = 0;
            int grandFairways = 0;
            int grandGreens = 0;
            int grandPutts = 0;
            int grandPenalties = 0;

            foreach (Round r in rounds)
            {
                int rowIndex = dgvRounds.Rows.Add();
                DataGridViewRow row = dgvRounds.Rows[rowIndex];
                row.Tag = r.ID;
                row.Cells[(int)RoundGridColumns.Date].Value = r.When.ToString("yyyy-MMM-dd");
                row.Cells[(int)RoundGridColumns.CourseTee].Value = r.Course.CourseAndTee;
                row.Cells[(int)RoundGridColumns.Fairways].Value = (r.TotalFairwaysHit * 100 / r.Course.GetTotalFairways()) + "%";
                row.Cells[(int)RoundGridColumns.Greens].Value = r.TotalGreensHit;
                row.Cells[(int)RoundGridColumns.Putts].Value = r.TotalPutts;
                row.Cells[(int)RoundGridColumns.Penalties].Value = r.TotalPenaltyStrokes;
                row.Cells[(int)RoundGridColumns.Score].Value = r.TotalScore;

                // capture grand numbers for overall summary stats
                grandScore += r.TotalScore;
                grandFairways += r.TotalFairwaysHit;
                grandGreens += r.TotalGreensHit;
                grandPutts += r.TotalPutts;
                grandPenalties += r.TotalPenaltyStrokes;
            }

            // now that we're done with all the rows, make the summary averages
            dgvSummaryStats.Rows.Clear();
            if (rounds != null && rounds.Length > 0)
            {
                string fairways = (int)(grandFairways / rounds.Length) + "%";
                string greens = (int)(grandGreens / rounds.Length) + "%";
                string putts = (int)(grandPutts / rounds.Length) + "%";
                string penalties = (int)(grandPenalties / rounds.Length) + "%";
                string score = (int)(grandScore / rounds.Length) + "%";

                dgvSummaryStats.Rows.Add(fairways, greens, penalties, score);
            }
            else
            {
                // summary if no rounds?
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            FormRoundDetails frm = new FormRoundDetails();
            frm.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //?
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(dgvRounds.SelectedRows.Count == 1)
            {
                int rID = (dgvRounds.SelectedRows[0].Tag as int?).Value;
                HandleOpenRound(rID);
            }
        }

        private void HandleOpenRound(int ID)
        {
            FormRoundDetails frm = new FormRoundDetails();
            frm.panelRound1.LoadRoundData(ID);
            frm.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvRounds.SelectedRows.Count == 1)
            {
                HandleDeleteSelectedRound(dgvRounds.SelectedRows[0].Tag as int?);
            }
        }

        private void HandleDeleteSelectedRound(int? rID)
        {
            if (!rID.HasValue) { return; }
            int ID = rID.Value;

            if (MessageBox.Show("Are you sure you want to delete this selected round and all it's data?", "Delete Round?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DAC.DeleteRoundByID(ID);

                // refresh grid
                LoadRoundSummaries();
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {

        }

        private void dgvRounds_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = (dgvRounds.SelectedRows.Count == 1);
            btnOpen.Enabled = (dgvRounds.SelectedRows.Count == 1);
        }
    }
}
