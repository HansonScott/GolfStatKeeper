using System;
using System.Collections.Generic;
using System.Text;

namespace GolfStatKeeper
{
    public class Player : IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public GolfBag Bag { get; set; }

        public Player(string Name)
        {
            this.ID = GetNextPlayerID();
            this.Name = Name;
            this.Bag = GolfBag.NewBag();
        }

        public Player(int ID, string Name, GolfBag bag)
        {
            this.ID = ID;
            this.Name = Name;
            this.Bag = bag;
        }

        public static Player LoadFromFileLine(string FileLine)
        {
            // use enum: PlayerFileFields
            string[] data = FileLine.Split(DAC.Level1Separator.ToCharArray());

            int ID = Int32.Parse(data[(int)PlayerFileFields.ID]);
            string Name = data[(int)PlayerFileFields.Name];
            string clubsData = data[(int)PlayerFileFields.Clubs];

            // now make the clubs from the clubs line.
            GolfBag bag = GolfBag.LoadFromFileLine(clubsData);
            return new Player(ID, Name, bag);
        }

        public static int GetNextPlayerID()
        {
            Player[] players = DAC.GetPlayers();
            int HighestID = 0;
            for (int i = 0; i < players.Length; i++)
            {
                HighestID = Math.Max(players[i].ID, HighestID);
            }

            return HighestID + 1;
        }

        public int CompareTo(object obj)
        {
            return ID.CompareTo(obj);
        }
    }
}
