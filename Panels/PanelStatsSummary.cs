using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelStatsSummary : PanelTemplate
    {
        private enum SummaryRows
        {
            NumberOfRounds_Penalties = 0,
            AvgTotalScore_Birdies = 1,
            AvgScorePar3_Pars = 2,
            AvgScorePar4_Bogies = 3,
            AvgScorePar5_Doubles = 4,
            HolesPerEagle_Others = 5,
        }
        private enum DrivingRows
        {
            Fairways = 0,
            Distance = 1,
            Longest = 2,
            Hazards = 3,
            OBs = 4,
        }
        private enum IronRows
        {
            GIR = 0,
            Distance = 1,
            FavoriteClub = 2,
            SandShots = 3,
            SandSaves = 4,
        }
        private enum PuttingRows
        {
            PuttsPerRound = 0,
            PuttsPerGIR = 1,
            ThreePuttsPerRound = 2,
            ThreePuttDistance = 3,
            AvgBirdyPuttDistance = 4,
        }

        public PanelStatsSummary()
        {
            InitializeComponent();

            if(FormMain.IsAppRunning)
            {
                PopulateCourses();
            }
        }

        private void PopulateCourses()
        {
            Course[] courses = DAC.GetCourses();

            for(int i = 0; i < courses.Length; i++)
            {
                Course c = courses[i];
                int r = dgvCourses.Rows.Add();
                dgvCourses.Rows[r].Cells[0].Value = c.CourseAndTee;
                dgvCourses.Rows[r].Tag = c; // save the course for later
            }
        }

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void PanelStatsSummary_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<Course> Courses = new List<Course>();
            // get selected courses
            if(dgvCourses.SelectedRows.Count == 0)
            {
                // then use all the courses
                foreach(DataGridViewRow r in dgvCourses.Rows)
                {
                    Courses.Add(r.Tag as Course);
                }
            }
            else
            {
                // then use the selected courses
                foreach (DataGridViewRow r in dgvCourses.SelectedRows)
                {
                    Courses.Add(r.Tag as Course);
                }
            }

            // get the dates
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;

            // load rounds for these, Summaries only
            Round[] rounds = DAC.GetRoundsByCoursesAndDates(Courses.ToArray(), from, to, true);

            // update grid
            PopulateStats(rounds);
        }

        private void PopulateStats(Round[] rounds)
        {
            
        }
    }
}
