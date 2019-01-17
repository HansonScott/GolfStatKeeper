using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper.Panels
{
    public partial class PanelCourse : PanelTemplate
    {
        public enum CourseInfoRows
        {
            Tee = 0,
            Slope = 1,
            Rating = 2,
        }
        public enum ScoreCardRows
        {
            HoleNumber = 0,
            Par = 1,
            Length = 2,
            HCP = 3,

        }

        public Course CurrentCourse;

        public PanelCourse()
        {
            InitializeComponent();
            SetupCourseDataGrid();
            SetupHoleDataGrid();
        }

        private void SetupCourseDataGrid()
        {
            dgvCourseData.Rows.Clear();
            dgvCourseData.Columns.Clear();

            dgvCourseData.Columns.Add("Column1", "");
            dgvCourseData.Columns.Add("Column2", "");

            dgvCourseData.Columns[0].Width = 50;

            dgvCourseData.Rows.Add("Tee", "");
            dgvCourseData.Rows.Add("Slope", "");
            dgvCourseData.Rows.Add("Rating", "");

        }

        private void SetupHoleDataGrid()
        {
            dgvHoleData.Rows.Clear();
            dgvHoleData.Columns.Clear();

            for (int i = 0; i < 20; i++)
            {
                dgvHoleData.Columns.Add("Column" + i, i.ToString());
            }

            dgvHoleData.Columns[0].Width = 40;
            dgvHoleData.Columns[19].Width = 40;

            string[] hole = new string[20];
            hole[0] = "Hole";
            for(int i = 1; i < 19; i++)
            {
                hole[i] = i.ToString();
            }
            hole[19] = "Total";
            dgvHoleData.Rows.Add(hole);

            string[] par = new string[20];
            par[0] = "Par";
            dgvHoleData.Rows.Add(par);

            string[] length = new string[20];
            length[0] = "Length";
            dgvHoleData.Rows.Add(length);

            string[] hcp = new string[20];
            hcp[0] = "HCP";
            dgvHoleData.Rows.Add(hcp);
        }

        private void btnCreateCourse_Click(object sender, EventArgs e)
        {
            CurrentCourse = null;
            tbCourseName.Text = string.Empty;
            
            SetupCourseDataGrid();
            SetupHoleDataGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tee = dgvCourseData.Rows[(int)CourseInfoRows.Tee].Cells[1].Value.ToString();
            string slope = dgvCourseData.Rows[(int)CourseInfoRows.Slope].Cells[1].Value.ToString();
            string rating = dgvCourseData.Rows[(int)CourseInfoRows.Rating].Cells[1].Value.ToString();

            string[] holes = GetHoleDataAsString();

            DAC.SaveCourse(CurrentCourse.ID.ToString(), tbCourseName.Text, tee, slope, rating, holes);
        }

        private string[] GetHoleDataAsString()
        {
            throw new NotImplementedException();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
