using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelStatsTrends : PanelTemplate
    {
        public PanelStatsTrends()
        {
            InitializeComponent();

            if(FormMain.IsAppRunning)
            {
                PopulateCoursesGrid();
            }

        }

        private void PopulateCoursesGrid()
        {
            Course[] courses = DAC.GetCourses();

            for (int i = 0; i < courses.Length; i++)
            {
                Course c = courses[i];
                int r = dgvCourses.Rows.Add();
                dgvCourses.Rows[r].Cells[0].Value = c.CourseAndTee;
                dgvCourses.Rows[r].Tag = c; // save the course for later
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Course[] courses = GetSelectedCourses();
            this.chart1.ShowTheseColumns[(int)Chart.TrendItems.Score] = cbScore.Checked;
            this.chart1.ShowTheseColumns[(int)Chart.TrendItems.Fairways] = cbFairways.Checked;
            this.chart1.ShowTheseColumns[(int)Chart.TrendItems.Greens] = cbGIR.Checked;
            this.chart1.ShowTheseColumns[(int)Chart.TrendItems.Putts] = cbPutts.Checked;
            this.chart1.ShowTheseColumns[(int)Chart.TrendItems.Penalties] = cbPenalties.Checked;

            this.chart1.GenerateStats(courses, dtpFrom.Value, dtpTo.Value);
            this.chart1.Refresh();
        }

        private Course[] GetSelectedCourses()
        {
            List<Course> c = new List<Course>();

            if(dgvCourses.SelectedRows.Count == 0)
            {
                foreach(DataGridViewRow row in dgvCourses.Rows)
                {
                    c.Add(row.Tag as Course);
                }
            }
            else
            {
                foreach(DataGridViewRow row in dgvCourses.SelectedRows)
                {
                    c.Add(row.Tag as Course);
                }
            }

            return c.ToArray();
        }
    }
}
