using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace GolfStatKeeper.Panels
{
    public partial class PanelHelp : PanelTemplate
    {
        public PanelHelp()
        {
            InitializeComponent();

            if(FormMain.IsAppRunning)
            {
                DisplayAssemblyVersion();
            }
        }

        private void DisplayAssemblyVersion()
        {
            lblVersion.Text = Application.ProductVersion;
        }
    }
}
