using System;
using System.Collections.Generic;
using System.Text;

namespace GolfStatKeeper
{
    public class GolfBag
    {
        public static int MaxClubs = 14;
        public Club[] Clubs;

        public GolfBag(Club[] Clubs)
        {
            if(Clubs != null) // they want existing clubs in the bag
            {
                this.Clubs = Clubs;
            }
            else // they want an 'empty' bag
            {
                this.Clubs = new Club[GolfBag.MaxClubs];
            }
        }

        // creates a new bag with default clubs
        public static GolfBag NewBag()
        {
            Club [] newClubs = new Club[GolfBag.MaxClubs];

            newClubs[0] = new Club(ClubType.Driver);
            newClubs[1] = new Club(ClubType.Wood_3);
            newClubs[2] = new Club(ClubType.Wood_5);
            newClubs[3] = new Club(ClubType.Iron_3);
            newClubs[4] = new Club(ClubType.Iron_4);
            newClubs[5] = new Club(ClubType.Iron_5);
            newClubs[6] = new Club(ClubType.Iron_6);
            newClubs[7] = new Club(ClubType.Iron_7);
            newClubs[8] = new Club(ClubType.Iron_8);
            newClubs[9] = new Club(ClubType.Iron_9);
            newClubs[10] = new Club(ClubType.Wedge_Pitching);
            newClubs[11] = new Club(ClubType.Wedge_Sand);
            newClubs[12] = new Club(ClubType.Wedge_Lob);
            newClubs[13] = new Club(ClubType.Putter);

            return new GolfBag(newClubs);
        }

        internal static GolfBag LoadFromFileLine(string clubsData)
        {
            string[] clubs = clubsData.Split(DAC.ElementSeparator.ToCharArray());
            Club[] theseClubs = new Club[clubs.Length];

            // foreach club
            for (int i = 0; i < clubs.Length; i++)
            {
                string[] clubFields = clubs[i].Split(DAC.SubElementSeparator.ToCharArray()); ;
                ClubType t = (ClubType)Enum.Parse(typeof(ClubType), clubFields[0]);
                string thisClubName = clubFields[1];
                theseClubs[i] = new Club(t, thisClubName);
            }

            GolfBag results = new GolfBag(theseClubs);

            return results;
        }

        internal string SaveToFileLine()
        {
            StringBuilder result = new StringBuilder();

            foreach(Club c in this.Clubs)
            {
                if(result.Length > 0)
                {
                    result.Append(DAC.ElementSeparator);
                }

                result.Append((int)c.ClubType);
                result.Append(DAC.SubElementSeparator);
                result.Append(DAC.SafeString(c.Name));
            }

            return result.ToString();
        }
    }
}
