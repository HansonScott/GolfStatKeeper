using System;

namespace GolfStatKeeper
{
    public class Course: IComparable
    {
        #region Class Members and Properties
        public int ID = -1;
        public string Name;
        public string Tees;
        public decimal Slope;
        public decimal Rating;
        public Hole[] Holes;
        public string CourseAndTee
        {
            get { return "" + Name + " - " + Tees; }
        }
        #endregion

        #region Constructors
        public Course(string Name, string Tees, decimal Slope, decimal Rating, Hole[] Holes) 
            : this(-1, Name, Tees, Slope, Rating, Holes) { }

        public Course(int ID, string Name, string Tees, decimal Slope, decimal Rating, Hole[] Holes)
        {
            if (ID == -1)
            {
                this.ID = GetNextCourseID();
            }
            else
            {
                this.ID = ID;
            }
            this.Name = Name;
            this.Tees = Tees;
            this.Slope = Slope;
            this.Rating = Rating;
            this.Holes = Holes;
        }
        #endregion

        #region Static Functions
        public static Course LoadFromFileLine(string FileLine)
        {
            string[] data = FileLine.Split(DAC.FieldSeparator.ToCharArray());

            int ID = Int32.Parse(data[(int)CourseFileFields.ID]);
            string Name = data[(int)CourseFileFields.Name];
            string Tees = data[(int)CourseFileFields.Tees];
            string Slope = data[(int)CourseFileFields.Slope];
            string Rating = data[(int)CourseFileFields.Rating];
            string Holes = data[(int)CourseFileFields.Holes];

            // now make the holes out of the hole string.
            string[] holeData = Holes.Split(DAC.ElementSeparator.ToCharArray());
            Hole[] newHoles = new Hole[holeData.Length];
            for (int i = 0; i < holeData.Length; i++)
            {

                newHoles[i] = Hole.CreateHoleFromHoleDataString(holeData[i]);
            }

            return new Course(ID, Name, Tees, Decimal.Parse(Slope), Decimal.Parse(Rating), newHoles);
        }
        #endregion

        #region Public Methods
        public int GetTotalFairways()
        {
            int result = 0;
            for (int i = 0; i < this.Holes.Length; i++)
            {
                if (this.Holes[i].Par > 3)
                {
                    result++;
                }
            }
            return result;
        }
        public int GetTotalPar()
        {
            int result = 0;
            for (int i = 0; i < this.Holes.Length; i++)
            {
                result += this.Holes[i].Par;
            }
            return result;
        }
        internal static string[] GetHolesString(Hole[] holes)
        {
            string[] holeData = new string[holes.Length];
            for (int i = 0; i < holes.Length; i++)
            {
                holeData[i] = holes[i].ToDataString(false);
            }

            return holeData;
        }
        internal object GetTotalLength()
        {
            int result = 0;
            for (int i = 0; i < this.Holes.Length; i++)
            {
                result += this.Holes[i].Length;
            }
            return result;
        }

        #region IComparable Members
        public int CompareTo(object c)
        {
            return String.Compare(this.Name, ((Course)c).Name);
        }
        #endregion
        #endregion

        #region Private Functions
        private int GetNextCourseID()
        {
            // look up course IDs from files, get the next one on the list.
            Course[] courses = DAC.GetCourses();
            int HighestID = 0;
            for (int i = 0; i < courses.Length; i++)
            {
                if (courses[i].ID > HighestID)
                {
                    HighestID = courses[i].ID;
                }
            }

            return HighestID + 1;
        }
        #endregion
    }
}
