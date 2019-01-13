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
            this.Clubs = Clubs;
        }
        public GolfBag(string clubs)
        {
            string[] fields = clubs.Split(DAC.ElementSeparator.ToCharArray());
            Club[] theseClubs = new Club[fields.Length];

            for (int i = 0; i < fields.Length; i++)
            {
                string[] temp  = fields[i].Split(DAC.SubElementSeparator.ToCharArray());;
                string thisClub = temp[0];
                string thisClubName = thisClub;
                if (temp.Length > 1)
                {
                    thisClubName = temp[1];
                }
                ClubType t = (ClubType)Enum.Parse(typeof(ClubType), thisClub);
                theseClubs[i] = new Club(t, thisClubName);
            }

            this.Clubs = theseClubs;
        }
        public GolfBag NewBag()
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
            newClubs[10] = new Club(ClubType.PW);
            newClubs[11] = new Club(ClubType.SW);
            newClubs[12] = new Club(ClubType.LW);
            newClubs[13] = new Club(ClubType.Putter);

            return new GolfBag(newClubs);
        }
    }
}
