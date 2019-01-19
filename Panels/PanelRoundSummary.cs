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
                DataGridViewRow row = new DataGridViewRow();
                row.Cells[(int)RoundGridColumns.Date].Value = r.When.ToString("yyyy-MMM-dd");
                row.Cells[(int)RoundGridColumns.CourseTee].Value = r.Course.CourseAndTee;
                row.Cells[(int)RoundGridColumns.Fairways].Value = (r.TotalFairwaysHit * 100 / r.Course.GetTotalFairways()) + "%";
                row.Cells[(int)RoundGridColumns.Greens].Value = r.TotalGreensHit;
                row.Cells[(int)RoundGridColumns.Putts].Value = r.TotalPutts;
                row.Cells[(int)RoundGridColumns.Penalties].Value = r.TotalPenaltyStrokes;
                row.Cells[(int)RoundGridColumns.Score].Value = r.TotalScore;

                dgvRounds.Rows.Add(row);

                // capture grand numbers for overall summary stats
                grandScore += r.TotalScore;
                grandFairways += r.TotalFairwaysHit;
                grandGreens += r.TotalGreensHit;
                grandPutts += r.TotalPutts;
                grandPenalties += r.TotalPenaltyStrokes;
            }

            // now that we're done with all the rows, make the summary averages
            dgvSummaryStats.Rows.Clear();
            string fairways = (int)(grandFairways / rounds.Length) + "%";
            string greens = (int)(grandGreens / rounds.Length) + "%";
            string putts = (int)(grandPutts / rounds.Length) + "%";
            string penalties = (int)(grandPenalties / rounds.Length) + "%";
            string score = (int)(grandScore / rounds.Length) + "%";

            dgvSummaryStats.Rows.Add(fairways, greens, penalties, score);
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {

        }
    }
}
