using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper
{
    public partial class FormPlayerSelector : Form
    {
        public Player SelectedPlayer
        {
            get
            {
                if (cbPlayer.DataSource != null &&
                    cbPlayer.SelectedValue != null)
                {
                    return (cbPlayer.SelectedValue as Player);
                }
                else
                {
                    return null;
                }
            }
        }

        public FormPlayerSelector()
        {
            InitializeComponent();
        }

        private void FormPlayerSelector_Shown(object sender, EventArgs e)
        {
            LoadPossiblePlayers();
        }
        public void LoadPossiblePlayers()
        {
            cbPlayer.DataSource = DAC.GetPlayers();
            cbPlayer.DisplayMember = "Name";
        }
    }
}
