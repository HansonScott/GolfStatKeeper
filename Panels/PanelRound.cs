using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelRound : PanelTemplate
    {
        private int ThisRoundID;
        public PanelRound(): this(-1){}
        public PanelRound(int RoundID)
        {
            InitializeComponent();

            LoadRoundData(RoundID);
        }

        private void LoadRoundData(int roundID)
        {
            if (roundID == -1) { return; }

            this.ThisRoundID = roundID;

            Round thisRound = DAC.GetRoundByID(roundID);

            dtWhen.Value = thisRound.When;
            cbCourse.Text = thisRound.Course.Name;
            cbTees.Text = thisRound.Course.Tees;
            cbConditions.Text = Enum.GetName(typeof(Round.RoundConditions), thisRound.Conditions);

            int ColumnNumber = 0;
            foreach (HoleScore h in thisRound.HolesPlayed)
            {
                dgvHolesPlayed.Columns.Add("Column" + ColumnNumber++, h.HolePlayed.HoleNumber.ToString());
            }

            ColumnNumber = 0;
            DataGridViewRow rowHoleNumber = new DataGridViewRow();
            dgvHolesPlayed.Rows.Add(rowHoleNumber);
            DataGridViewRow rowScore = new DataGridViewRow();
            dgvHolesPlayed.Rows.Add(rowScore);
            DataGridViewRow rowFwy = new DataGridViewRow();
            dgvHolesPlayed.Rows.Add(rowFwy);
            DataGridViewRow rowGrn = new DataGridViewRow();
            dgvHolesPlayed.Rows.Add(rowGrn);
            DataGridViewRow rowPutts = new DataGridViewRow();
            dgvHolesPlayed.Rows.Add(rowPutts);

            foreach (HoleScore h in thisRound.HolesPlayed)
            {
                rowHoleNumber.Cells[ColumnNumber].Value = h.HolePlayed.HoleNumber;
                rowScore.Cells[ColumnNumber].Value = h.Score;
                rowFwy.Cells[ColumnNumber].Value = (h.FairwayWasHit() ? "X" : "");
                rowGrn.Cells[ColumnNumber].Value = (h.GreenWasHit() ? "X" : "");
                rowPutts.Cells[ColumnNumber].Value = h.GetPuttsForHole();
            }
        }

        private void dgvHolesPlayed_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHolesPlayed.SelectedColumns.Count == 1)
            {
                LoadShotDetails(dgvHolesPlayed.SelectedColumns[0]);
            }
        }

        private void LoadShotDetails(DataGridViewColumn col)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // save and close

            //ThisRoundID - if value is -1, add new
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // prompt then close
        }

        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear score card

            // populate tees combo
        }

        private void cbTees_SelectedIndexChanged(object sender, EventArgs e)
        {
            // populate score card
        }
    }
}
