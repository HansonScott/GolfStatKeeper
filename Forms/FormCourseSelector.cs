using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GolfStatKeeper
{
    public partial class FormCourseSelector : Form
    {
        public Course SelectedCourse
        {
            get
            {
                if(cbCourses.DataSource != null &&
                    cbCourses.SelectedValue != null)
                {
                    return (cbCourses.SelectedValue as Course);
                }
                else
                {
                    return null;
                }
            }
        }
        public FormCourseSelector()
        {
            InitializeComponent();
        }

        private void FormCourseSelector_Shown(object sender, EventArgs e)
        {
            LoadPossibleCourses();
        }

        private void LoadPossibleCourses()
        {
            cbCourses.DataSource = DAC.GetCourses();
            cbCourses.DisplayMember = "CourseAndTee";
        }
    }
}
