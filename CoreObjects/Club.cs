using System;
using System.Collections.Generic;
using System.Text;

namespace GolfStatKeeper
{
    public enum ClubType
    {
        Driver = 0,
        Wood_2 = 19,
        Wood_3 = 1,
        Wood_4 = 2,
        Wood_5 = 3,
        Wood_7 = 4,
        Iron_1 = 5,
        Iron_2 = 6,
        Iron_3 = 7,
        Iron_4 = 8,
        Iron_5 = 9,
        Iron_6 = 10,
        Iron_7 = 11,
        Iron_8 = 12,
        Iron_9 = 13,
        PW = 14,
        SW = 15,
        LW = 16,
        XW = 17,
        Putter = 18,
    }

    public class Club
    {
        #region Member Declarations
        private ClubType m_type;
        private string m_name;
        #endregion

        #region Public Properties
        public ClubType ClubType
        {
            get { return m_type; }
            set { m_type = value; }
        }
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        #endregion

        #region Constructors
        public Club(ClubType C)
        {
            this.ClubType = C;
            this.Name = Enum.GetName(typeof(ClubType), C);
        }
        public Club(ClubType C, string Name)
        {
            this.ClubType = C;
            this.Name = Name;
        }
        #endregion
    }
}
