using System;
using System.Collections.Generic;
using System.Text;

namespace GolfStatKeeper
{
    public class Round
    {
        public enum RoundConditions
        {
            Cold = 1,
            Rainy = 2,
            Fair = 3,
            Windy = 4,
            Hot = 5,
            Extra_Wet = 6,
            Extra_Dry = 7,
        }

        public int ID { get; set; }
        public RoundConditions Conditions { get; set; }
        public Course Course { get; set; }
        public int TotalFairwaysHit { get; set; }
        public int TotalGreensHit { get; set; }
        public Player Player { get; set; }
        public int TotalPenaltyStrokes { get; set; }
        public int TotalPutts { get; set; }
        public int TotalScore { get; set; }
        public HoleScore[] HolesPlayed { get; set; }
        public int TotalHolesPlayed
        {
            get
            {
                if(HolesPlayed == null) { return 0; }
                else
                {
                    return HolesPlayed.Length;
                }
            }
        }
        public DateTime When { get; set; }

        public static Round LoadFromFileLine(string rawSummaryLine, Boolean includeDetails)
        {
            // use enum: RoundFileFields
            return new Round();
        }
    }
}
