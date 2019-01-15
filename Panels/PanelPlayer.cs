using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelPlayer : PanelTemplate
    {
        public enum GolfBagColumns
        {
            ID = 0,
            Type = 1,
            Name = 2,
        }
        public PanelPlayer()
        {
            InitializeComponent();

            // set content of the combo box column
            (dgvGolfBag.Columns[(int)GolfBagColumns.Type] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(GolfStatKeeper.ClubType));
        }

        public void LoadPossiblePlayers(Player[] ps)
        {
            cbPlayerName.DataSource = ps;
            cbPlayerName.DisplayMember = "Name";
        }

        public void LoadPlayer(Player P)
        {
            lblPlayerID.Text = P.ID.ToString();
            PopulateGolfBag(P.Bag);
        }

        public void PrepopulateGolfBagWithDefaults()
        {
            GolfBag bag = GolfBag.NewBag();
            PopulateGolfBag(bag);
        }

        private void PopulateGolfBag(GolfBag bag)
        {
            dgvGolfBag.Rows.Clear();
            int index = 1;
            foreach (Club c in bag.Clubs)
            {
                dgvGolfBag.Rows.Add(index++, Enum.GetName(typeof(ClubType), c.ClubType), c.Name);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(lblPlayerID.Text) > 0)
            {
                DAC.SavePlayer(Int32.Parse(lblPlayerID.Text), DAC.SafeString(cbPlayerName.Text), GetClubsStringFromGrid());
            }
            else
            {
                DAC.AddNewPlayer(Player.GetNextPlayerID(), DAC.SafeString(cbPlayerName.Text), GetClubsStringFromGrid());
            }
        }

        private string GetClubsStringFromGrid()
        {
            // populate a memory object from the grid
            GolfBag bag = new GolfBag(null);
            foreach (DataGridViewRow row in dgvGolfBag.Rows)
            {
                if(row.Cells[(int)GolfBagColumns.Type].Value == null){ continue; }
                string val = row.Cells[(int)GolfBagColumns.Type].Value.ToString();
                ClubType type = (ClubType)Enum.Parse(typeof(ClubType), val);
                string name = row.Cells[(int)GolfBagColumns.Name].Value.ToString();
                bag.Clubs[row.Index] = new Club(type, name);
            }

            // get the string from the bag object
            string result = bag.SaveToFileLine();

            return result;
        }

        private void cbPlayerName_SelectedValueChanged(object sender, EventArgs e)
        {
            lblPlayerID.Text = (cbPlayerName.SelectedValue as Player).ID.ToString();
            PopulateGolfBag((cbPlayerName.SelectedValue as Player).Bag);
        }
    }
}
