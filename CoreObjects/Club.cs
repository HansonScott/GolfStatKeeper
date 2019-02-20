using System;
using System.Collections.Generic;
using System.Text;

namespace GolfStatKeeper
{
    public enum ClubType
    {
        Driver = 1,
        Wood_2 = 10,
        Wood_3 = 11,
        Wood_4 = 12,
        Wood_5 = 13,
        Wood_6 = 13,
        Wood_7 = 15,
        Wood_8 = 16,
        Wood_9 = 17,
        Iron_1 = 20,
        Iron_2 = 21,
        Iron_3 = 22,
        Iron_4 = 23,
        Iron_5 = 24,
        Iron_6 = 25,
        Iron_7 = 26,
        Iron_8 = 27,
        Iron_9 = 28,
        Iron_10 = 29,
        Wedge_Pitching = 30,
        Wedge_Sand = 31,
        Wedge_Lob = 32,
        Wedge_X = 33,
        Putter = 40,
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

        public static string GetClubNameFromClubType(ClubType club)
        {
            // comes in as a custom name, needs to map back to the generic type
            foreach (Club c in FormMain.thisForm.CurrentPlayer.Bag.Clubs)
            {
                if (c.ClubType == club) { return c.Name; }
            }

                return null;
            }
        public static ClubType? GetClubTypeFromClubName(string clubName)
        {
            // comes in as a custom name, needs to map back to the generic type
            foreach (Club c in FormMain.thisForm.CurrentPlayer.Bag.Clubs)
            {
                if (c.Name == clubName) { return c.ClubType; }
            }

            return null;
        }
    }
}
