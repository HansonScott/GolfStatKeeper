using System;
using System.Collections.Generic;
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

        #region Constructor and Setup functions
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
        #endregion

        #region Event handlers
        private void btnCreateCourse_Click(object sender, EventArgs e)
        {
            CurrentCourse = null;
            tbCourseName.Text = string.Empty;
            
            SetupCourseDataGrid();
            SetupHoleDataGrid();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbCourseName.Text == String.Empty) { MessageBox.Show("Missing course name."); return; }

            string tee = dgvCourseData.Rows[(int)CourseInfoRows.Tee].Cells[1].Value.ToString();
            if(tee == String.Empty) { MessageBox.Show("Missing tee."); return; }
            string slope = dgvCourseData.Rows[(int)CourseInfoRows.Slope].Cells[1].Value.ToString();
            if (slope == String.Empty) { MessageBox.Show("Missing slope."); return; }
            string rating = dgvCourseData.Rows[(int)CourseInfoRows.Rating].Cells[1].Value.ToString();
            if (rating == String.Empty) { MessageBox.Show("Missing rating."); return; }

            Hole[] holes = GetHoleData();

            if(holes == null || holes.Length == 0) { MessageBox.Show("Missing hole data."); return; }

            if (CurrentCourse == null)
            {
                int newID = DAC.AddCourse(tbCourseName.Text, tee, slope, rating, Course.GetHolesString(holes));
                CurrentCourse = DAC.GetCourseByID(newID.ToString());

                MessageBox.Show("Course added.");
            }
            else
            {
                DAC.SaveCourse(CurrentCourse.ID.ToString(), tbCourseName.Text, tee, slope, rating, Course.GetHolesString(holes));
                MessageBox.Show("Course saved.");
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            FormCourseSelector fcs = new FormCourseSelector();
            DialogResult res = fcs.ShowDialog();
            if(res == DialogResult.OK)
            {
                LoadCourse(fcs.SelectedCourse);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(CurrentCourse == null) { return; }

            DAC.DeleteCourseByID(CurrentCourse.ID.ToString());
            CurrentCourse = null;
            tbCourseName.Text = string.Empty;

            SetupCourseDataGrid();
            SetupHoleDataGrid();
        }
        #endregion

        #region Private Functions
        private Hole[] GetHoleData()
        {
            List<Hole> holes = new List<Hole>();  //-2 for the row header and totals columns
            for (int i = 0; i < (dgvHoleData.Columns.Count - 2); i++)
            {
                string holeNumber = dgvHoleData.Rows[(int)ScoreCardRows.HoleNumber].Cells[i + 1].Value.ToString();
                object vLength = dgvHoleData.Rows[(int)ScoreCardRows.Length].Cells[i + 1].Value;
                if(vLength == null) { continue; }
                string length = vLength.ToString();
                object vPar = dgvHoleData.Rows[(int)ScoreCardRows.Par].Cells[i + 1].Value;
                if(vPar == null) { continue; }
                string par = vPar.ToString();
                object vHCP = dgvHoleData.Rows[(int)ScoreCardRows.HCP].Cells[i + 1].Value;
                if(vHCP == null) { continue; }
                string HCP = vHCP.ToString();

                int iHoleNumber; Int32.TryParse(holeNumber, out iHoleNumber);
                int iLength; Int32.TryParse(length, out iLength);
                int iPar; Int32.TryParse(par, out iPar);
                int iHCP; Int32.TryParse(HCP, out iHCP);

                holes.Add(new Hole(iHoleNumber, iLength, iPar, iHCP));
            }

            return holes.ToArray();
        }
        private void LoadCourse(Course c)
        {
            this.CurrentCourse = c;

            tbCourseName.Text = c.Name;
            dgvCourseData.Rows[(int)CourseInfoRows.Tee].Cells[1].Value = c.Tees;
            dgvCourseData.Rows[(int)CourseInfoRows.Slope].Cells[1].Value = c.Slope;
            dgvCourseData.Rows[(int)CourseInfoRows.Rating].Cells[1].Value = c.Rating;

            for (int i = 0; i < c.Holes.Length; i++)
            {
                dgvHoleData.Rows[(int)ScoreCardRows.HoleNumber].Cells[i + 1].Value = c.Holes[i].HoleNumber;
                dgvHoleData.Rows[(int)ScoreCardRows.Length].Cells[i + 1].Value = c.Holes[i].Length;
                dgvHoleData.Rows[(int)ScoreCardRows.Par].Cells[i + 1].Value = c.Holes[i].Par;
                dgvHoleData.Rows[(int)ScoreCardRows.HCP].Cells[i + 1].Value = c.Holes[i].HCP;
            }

            dgvHoleData.Rows[(int)ScoreCardRows.Length].Cells[19].Value = c.GetTotalLength();
            dgvHoleData.Rows[(int)ScoreCardRows.Par].Cells[19].Value = c.GetTotalPar();
        }
        #endregion
    }
}
