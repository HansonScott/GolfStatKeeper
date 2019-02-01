using System;
using System.Collections.Generic;
using System.Text;

namespace GolfStatKeeper
{
    public class Round
    {
        public enum RoundConditions
        {
            Fair = 1,
            Cold = 2,
            Rainy = 3,
            Windy = 4,
            Hot = 5,
            Extra_Wet = 6,
            Extra_Dry = 7,
        }

        #region Class Properties
        public int ID { get; set; }
        public RoundConditions Conditions { get; set; }
        public Course Course { get; set; }
        public int TotalFairwaysHit { get; set; }
        public int TotalGreensHit { get; set; }
        public Player Player { get; set; }
        public int TotalPenaltyStrokes { get; set; }
        public int TotalPutts { get; set; }
        public int TotalScore { get; set; }
        public List<HoleScore> HolesPlayed { get; set; }
        public int TotalHolesPlayed
        {
            get
            {
                if(HolesPlayed == null) { return 0; }
                else
                {
                    return HolesPlayed.Count;
                }
            }
        }
        public DateTime When { get; set; }
        #endregion

        #region Constructor
        public Round()
        {
            this.ID = -1; // default to -1 so the save function knows it is new.
            HolesPlayed = new List<HoleScore>();
        }
        #endregion

        #region File IO functions
        public override string ToString()
        {
            // use enum?
            string[] fields = new string[Enum.GetNames(typeof(RoundFileFields)).Length];
            // set the data
            fields[(int)RoundFileFields.ID] = this.ID.ToString();
            fields[(int)RoundFileFields.When] = this.When.ToString("yyyyMMdd");
            fields[(int)RoundFileFields.Conditions] = ((int)this.Conditions).ToString();
            fields[(int)RoundFileFields.Course] = this.Course.ID.ToString();
            fields[(int)RoundFileFields.FairwaysHit] = this.TotalFairwaysHit.ToString();
            fields[(int)RoundFileFields.GreensHit] = this.TotalGreensHit.ToString();
            fields[(int)RoundFileFields.Player] = this.Player.ID.ToString();
            fields[(int)RoundFileFields.TotalPenaltyStrokes] = this.TotalPenaltyStrokes.ToString();
            fields[(int)RoundFileFields.TotalPutts] = this.TotalPutts.ToString();
            fields[(int)RoundFileFields.TotalScore] = this.TotalScore.ToString();

            int hp = 0;
            for (int j = 0; j < this.HolesPlayed.Count; j++)
            {
                if (this.HolesPlayed[j] == null) { break; }
            }
            fields[(int)RoundFileFields.HolesPlayed] = hp.ToString();

            return String.Join(DAC.FieldSeparator, fields);
        }

        public static Round LoadFromFileLine(string rawSummaryLine, Boolean includeDetails)
        {
            string[] fields = rawSummaryLine.Split(DAC.FieldSeparator.ToCharArray());

            Round thisRound = new Round();

            thisRound.ID = Int32.Parse(fields[(int)RoundFileFields.ID]);
            thisRound.When = DateTime.Parse(fields[(int)RoundFileFields.When].ToString());
            thisRound.Conditions = (Round.RoundConditions)Enum.Parse(typeof(Round.RoundConditions), fields[(int)RoundFileFields.Conditions]);
            thisRound.Course.ID = Int32.Parse(fields[(int)RoundFileFields.Course]);
            thisRound.TotalFairwaysHit = Int32.Parse(fields[(int)RoundFileFields.FairwaysHit]);
            thisRound.TotalGreensHit = Int32.Parse(fields[(int)RoundFileFields.GreensHit]);
            thisRound.Player.ID = Int32.Parse(fields[(int)RoundFileFields.Player]);
            thisRound.TotalPenaltyStrokes = Int32.Parse(fields[(int)RoundFileFields.TotalPenaltyStrokes]);
            thisRound.TotalPutts = Int32.Parse(fields[(int)RoundFileFields.TotalPutts]);
            thisRound.TotalScore = Int32.Parse(fields[(int)RoundFileFields.TotalScore]);

            if (includeDetails)
            {
                thisRound.HolesPlayed = DAC.GetHolesPlayedByRoundID(thisRound.ID.ToString(), thisRound.Course);
            }

            // use enum: RoundFileFields
            return thisRound;
        }
        #endregion
    }
}
