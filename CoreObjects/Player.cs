using System;
using System.Collections.Generic;
using System.Text;

namespace GolfStatKeeper
{
    public class Player
    {
        public int ID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
        public GolfBag Bag
        {
            get; set;
        }

        public static Player LoadFromFileLine(string rawFileContent)
        {

            // use enum: PlayerFileFields
            return new Player();
        }
    }
}
