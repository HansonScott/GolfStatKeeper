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

        private Player m_CurrentPlayer;
        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set
            {
                m_CurrentPlayer = value;
                FormMain.thisForm.CurrentPlayer = value;
            }
            
        }

        public PanelPlayer()
        {
            InitializeComponent();

            // set content of the combo box column
            (dgvGolfBag.Columns[(int)GolfBagColumns.Type] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(GolfStatKeeper.ClubType));
        }

        internal void SetForNewPlayer()
        {
            lblName.Text = "Player Name:";
            tbPlayerName.Text = String.Empty;
            tbPlayerName.Visible = true;
            btnDelete.Enabled = false;

            CurrentPlayer = null;
            PrepopulateGolfBagWithDefaults();
        }

        public void LoadPlayer(Player P)
        {
            lblName.Text = P.Name;
            tbPlayerName.Visible = false;
            btnDelete.Enabled = true;

            CurrentPlayer = P;
            PopulateGolfBag(P.Bag);

            // store the new current player for other tabs' data.
            FormMain.thisForm.CurrentPlayer = P;
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
            DAC.DeletePlayerID(CurrentPlayer.ID.ToString());
            CurrentPlayer = null;
            dgvGolfBag.Rows.Clear();
            lblName.Text = String.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(CurrentPlayer != null)
            {
                DAC.SavePlayer(CurrentPlayer.ID, DAC.SafeString(lblName.Text), GetClubsStringFromGrid());
            }
            else
            {
                int id = Player.GetNextPlayerID();
                DAC.AddNewPlayer(id, DAC.SafeString(tbPlayerName.Text), GetClubsStringFromGrid());

                LoadPlayer(DAC.GetPlayerByID(id.ToString()));
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
            string result = bag.ToString();

            return result;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetForNewPlayer();
        }

        private void btnOpenPlayer_Click(object sender, EventArgs e)
        {
            FormPlayerSelector fm = new FormPlayerSelector();
            DialogResult res = fm.ShowDialog();

            if(res == DialogResult.OK)
            {
                LoadPlayer(fm.SelectedPlayer);
            }
        }
    }
}
