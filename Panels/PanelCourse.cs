using System;
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
            string tee = dgvCourseData.Rows[(int)CourseInfoRows.Tee].Cells[1].Value.ToString();
            string slope = dgvCourseData.Rows[(int)CourseInfoRows.Slope].Cells[1].Value.ToString();
            string rating = dgvCourseData.Rows[(int)CourseInfoRows.Rating].Cells[1].Value.ToString();

            Hole[] holes = GetHoleData();

            if (CurrentCourse == null)
            {
                int newID = DAC.AddCourse(tbCourseName.Text, tee, slope, rating, Course.GetHolesString(holes));
                CurrentCourse = DAC.GetCourseByID(newID.ToString());
            }
            else
            {
                DAC.SaveCourse(CurrentCourse.ID.ToString(), tbCourseName.Text, tee, slope, rating, Course.GetHolesString(holes));
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
            Hole[] holes = new Hole[dgvHoleData.Columns.Count - 2];  //-2 for the row header and totals columns
            string[] holeData = new string[holes.Length];
            for (int i = 0; i < holes.Length; i++)
            {
                string holeNumber = dgvHoleData.Rows[(int)ScoreCardRows.HoleNumber].Cells[i + 1].Value.ToString();
                string length = dgvHoleData.Rows[(int)ScoreCardRows.Length].Cells[i + 1].Value.ToString();
                string par = dgvHoleData.Rows[(int)ScoreCardRows.Par].Cells[i + 1].Value.ToString();
                string HCP = dgvHoleData.Rows[(int)ScoreCardRows.HCP].Cells[i + 1].Value.ToString();

                int iHoleNumber; Int32.TryParse(holeNumber, out iHoleNumber);
                int iLength; Int32.TryParse(length, out iLength);
                int iPar; Int32.TryParse(par, out iPar);
                int iHCP; Int32.TryParse(HCP, out iHCP);

                holes[i] = new Hole(iHoleNumber, iLength, iPar, iHCP);

                holeData[i] = holes[i].ToDataString(false);
            }

            return holes;
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
