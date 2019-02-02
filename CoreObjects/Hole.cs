using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GolfStatKeeper
{
    public class Hole
    {
        #region Class Declarations
        public int Par;
        public int Length;
        public int HoleNumber;
        public int HCP;
        #endregion

        #region Constructor
        public Hole() { }
        public Hole(int HoleNumber, int Length, int Par, int HCP)
        {
            this.Par = Par;
            this.Length = Length;
            this.HoleNumber = HoleNumber;
            this.HCP = HCP;
        }
        #endregion

        #region Static Functions
        public static Hole CreateHoleFromString(string holeData)
        {
            string[] data = holeData.Split(DAC.Level2Separator.ToCharArray());

            int num = Int32.Parse(data[(int)HoleFields.HoleNumber]);
            int par = Int32.Parse(data[(int)HoleFields.Par]);
            int len = Int32.Parse(data[(int)HoleFields.Length]);
            int hcp = Int32.Parse(data[(int)HoleFields.HCP]);

            return new Hole(num, len, par, hcp);
        }
        #endregion

        #region Public Functions
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.HoleNumber);
            sb.Append(DAC.Level2Separator);
            sb.Append(this.Par);
            sb.Append(DAC.Level2Separator);
            sb.Append(this.Length);
            sb.Append(DAC.Level2Separator);
            sb.Append(this.HCP);

            return sb.ToString();
        }
        #endregion
    }
}
