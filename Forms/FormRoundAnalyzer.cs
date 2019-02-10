using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper
{
    public partial class FormRoundAnalyzer : Form
    {
        private Panels.PanelRoundAnalyzer panelRoundAnalyzer1;

        public FormRoundAnalyzer()
        {
            InitializeComponent();
        }

        public void LoadRound(Round r)
        {
            this.panelRoundAnalyzer1.LoadRound(r);
        }
    }
}
