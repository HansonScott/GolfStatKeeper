using System;
using System.Collections.Generic;
using System.Text;

namespace GolfStatKeeper
{
    public class HoleScore
    {
        #region Class Members and Properties
        public Hole HolePlayed = new Hole();
        public int PenaltyStrokes = 0;
        public List<Shot> Shots = new List<Shot>();

        private int m_Score;
        public int Score
        {
            get
            {
                if (Shots != null && Shots.Count > 0)
                {
                    return Shots.Count + PenaltyStrokes;
                }
                else
                {
                    return m_Score;
                }
            }

            set
            {
                m_Score = value;
            }
        }
        private bool m_FairwayHit;
        public bool FairwayWasHit
        {
            get
            {
                if (this.HolePlayed.Par == 3) { return false; }

                if (this.Shots == null || this.Shots.Count < 1) { return m_FairwayHit; }
                else
                {
                    if (this.Shots.Count < 2) { return false; }

                    // if drive went into the hazard or OB
                    if (this.PenaltyStrokes > 0 &&
                            (this.Shots[0].ActualResult == Shot.ShotResult.Hazard ||
                            this.Shots[0].ActualResult == Shot.ShotResult.OB))
                    {
                        return false;
                    }

                    // otherwise, check the second shot was from the fairway.
                    return (this.Shots[1].Lie == Shot.BallLie.Fairway);
                }
            }
            set
            {
                m_FairwayHit = value;

            }
        }
        private bool m_GreenHit;
        public bool GreenWasHit
        {
            get
            {
                if (this.Shots == null || this.Shots.Count < 1) { return m_GreenHit; }
                else
                {
                    int putts = PuttsForHole;

                    return (this.Score > 0 &&
                            this.Score - putts <= this.HolePlayed.Par - 2);
                }
            }
            set
            {
                m_GreenHit = value;
            }
        }
        private int m_Putts;
        public int PuttsForHole
        {
            get
            {
                if (this.Shots == null || this.Shots.Count < 1) { return m_Putts; }
                else
                {
                    int putts = 0;
                    foreach (Shot s in this.Shots)
                    {
                        // Putts from green or putts with putter? - Green.
                        //if (H.Shots[i].Club == ClubType.Putter)
                        if (s.Lie == Shot.BallLie.Green)
                        {
                            putts++;
                        }
                    }
                    return putts;
                }
            }
            set
            {
                m_Putts = value;
            }
        }
        #endregion

        public HoleScore(){}
        
        public void AddShot(Shot shot)
        {
            if (shot.ShotNumber < this.Shots.Count)
            {
                // then insert
                this.Shots.Insert(shot.ShotNumber - 1, shot);
            }
            else
            {
                // just add
                this.Shots.Add(shot);
            }

            UpdateHoleSummaryFromShots();
        }
        public void DeleteShot(int ShotNumber)
        {
            if (this.Shots.Count > ShotNumber)
            {
                this.Shots.RemoveAt(ShotNumber - 1);
            }

            UpdateHoleSummaryFromShots();
        }

        private void UpdateHoleSummaryFromShots()
        {
            // uses shots if we have them, otherwise, sets the summary variable.
            this.Score = this.Score;
            this.FairwayWasHit = this.FairwayWasHit;
            this.GreenWasHit = this.GreenWasHit;
            this.PuttsForHole = this.PuttsForHole;
        }
        public Shot GetShotByShotNumber(int shotNumber)
        {
            if (this.Shots.Count > shotNumber)
            {
                return Shots[shotNumber - 1];
            }
            else
            {
                return null;
            }
        }

        public List<ShotWasted> FindWastedShots()
        {
            List<ShotWasted> results = new List<ShotWasted>();

            // go through each of the wasted shots types, and find any
            // Theory: worst to best priorities:
            // X Wiff                    = 0,
            // X Penalty_OB              = 1,
            // X Penalty_hazard          = 2,
            // X Duplicate_chip          = 3,
            // X Duplicate_sand_shot     = 4,
            // Miss_Hit                = 5,
            // X Three_putts_within_50_feet = 6,
            // X Two_putts_within_5_feet = 7,
            // X Chip_and_two_putts      = 8,
            // X Approach_missed_green   = 9,
            //   Poor_Drive              = 10,
            // X Approach_left_30_foot_putt_or_more = 11,
            // X Two_putts_from_5_to_10_feet = 12,
            // X Three_putts_from_over_50_feet = 13,
            // X Two_putts_from_10_to_15_feet = 14,

            // go through each shot and collect data.
            int putts = 0;
            int puttLength = 0;

            bool chipped = false;
            ClubType ChipClub = ClubType.Wedge_Lob;
            int ChipShotNumber = 0;

            ClubType ApproachClub = ClubType.Wedge_Lob;
            int ApproachShotNumber = 0;
            int ApproachDistance = 0;

            for (int i = 0; i < this.Shots.Count; i++)
            {
                Shot thisShot = this.Shots[i];
                if (thisShot == null) { continue; }

                Shot nextShot = null;
                if (i < this.Shots.Count - 1)
                {
                    nextShot = this.Shots[i + 1];
                }

                #region Wiff
                if (thisShot.ActualFlight == Shot.BallFlight.Wiff)
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, 0, ShotWastedType.Wiff));
                }
                #endregion
                #region OB
                else if (thisShot.ActualResult == Shot.ShotResult.OB)
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Penalty_OB));
                }
                #endregion
                #region Hazard
                else if (thisShot.ActualResult == Shot.ShotResult.Hazard)
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Penalty_hazard));
                }
                #endregion
                #region Duplicate Chip
                // if this shot was a type of chip, and so was the next
                else if (thisShot.ActualFlight == Shot.BallFlight.Chip ||
                         thisShot.ActualFlight == Shot.BallFlight.BumpAndRun ||
                         thisShot.ActualFlight == Shot.BallFlight.Flop)
                {
                    chipped = true;
                    ChipClub = thisShot.Club;
                    ChipShotNumber = thisShot.ShotNumber;

                    if (nextShot != null &&
                        (nextShot.ActualFlight == Shot.BallFlight.Chip ||
                         nextShot.ActualFlight == Shot.BallFlight.BumpAndRun ||
                         nextShot.ActualFlight == Shot.BallFlight.Flop))
                    {
                        results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Duplicate_chip));
                    }
                }
                #endregion
                #region Duplicate Sand Shot
                // if this and next were both in the sand
                else if ((thisShot.Lie == Shot.BallLie.Sand ||
                         thisShot.Lie == Shot.BallLie.Sand_Buried ||
                         thisShot.Lie == Shot.BallLie.Sand_Lip) &&
                            nextShot != null &&
                        (nextShot.Lie == Shot.BallLie.Sand ||
                         nextShot.Lie == Shot.BallLie.Sand_Buried ||
                         nextShot.Lie == Shot.BallLie.Sand_Lip))
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Duplicate_sand_shot));
                }
                #endregion
                #region Miss Hit
                // if a shot went less than half it's intended distance, it was a miss hit
                else if ((thisShot.ActualFlight == Shot.BallFlight.Topped ||
                       thisShot.ActualFlight == Shot.BallFlight.Shank ||
                       thisShot.ActualFlight == Shot.BallFlight.Fat) &&
                       (thisShot.TargetDistance > 0 &&
                        thisShot.ActualDistance < (.5 * thisShot.TargetDistance)))
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Miss_Hit));
                }

                #endregion
                #region Poor Drive
                // it's a poor drive if it was less distance, not as intended, and next shot was not 'easy'
                else if (thisShot.Lie == Shot.BallLie.Tee && this.HolePlayed.Par > 3 &&
                   thisShot.ActualResult != Shot.ShotResult.As_intended &&
                   thisShot.ActualDistance > 0 &&
                   thisShot.TargetDistance > 0 &&
                   thisShot.ActualDistance < (.9 * thisShot.TargetDistance) &&
                   nextShot.Lie != Shot.BallLie.Fairway &&
                   nextShot.Lie != Shot.BallLie.Green)
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Poor_Drive));
                }
                #endregion
                #region Set ApproachClub
                if (thisShot.Club != ClubType.Driver &&
                        !(this.HolePlayed.Par > 3 && thisShot.Lie == Shot.BallLie.Tee) &&
                        thisShot.Club != ClubType.Putter &&
                        thisShot.Lie != Shot.BallLie.Green &&
                        thisShot.Lie != Shot.BallLie.Sand &&
                        thisShot.TargetFlight != Shot.BallFlight.BumpAndRun &&
                        thisShot.TargetFlight != Shot.BallFlight.Chip &&
                        thisShot.TargetFlight != Shot.BallFlight.Flop &&
                        !(this.HolePlayed.Par == 5 && thisShot.ShotNumber == 2))
                {
                    ApproachClub = thisShot.Club;
                    ApproachShotNumber = thisShot.ShotNumber;
                    ApproachDistance = thisShot.ActualDistance;
                }
                #endregion

                #region store putts
                if (thisShot.Lie == Shot.BallLie.Green)
                {
                    putts++;
                    puttLength = Math.Max(puttLength, thisShot.TargetDistance);
                }
                #endregion

            } // end for loop - shots

            #region 3-Putts
            if (putts > 2)
            {
                if (puttLength <= 50)
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Three_putts_within_50_feet));
                }
                else
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Three_putts_from_over_50_feet));
                }
            }
            #endregion

            #region 2-Putts
            else if (putts > 1)
            {
                if (puttLength == 0)
                {
                    // if no distances were put into the system, don't assume, just leave it out.
                }
                else if (puttLength <= 5)
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_within_5_feet));
                }
                // if a chip left a putt length greater than 5 feet, it's more a chipping issue.
                else if (chipped)
                {
                    // if our chip was just close to the green, it was a chip issue.
                    if (this.GreenWasHit || this.Shots[ChipShotNumber - 1].ActualDistance < 10)
                    {
                        results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), ChipShotNumber, ChipClub, puttLength, ShotWastedType.Chip_and_two_putts));
                    }
                    // otherwise, it was the approaches fault.
                    else if (this.Shots[ChipShotNumber - 2].Lie == Shot.BallLie.Fairway ||
                            this.Shots[ChipShotNumber - 2].ActualResult != Shot.ShotResult.As_intended)
                    {
                        results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), ApproachShotNumber, ApproachClub, ApproachDistance, ShotWastedType.Approach_missed_green));
                    }
                }
                else if (puttLength <= 10)
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_from_5_to_10_feet));
                }
                else if (puttLength <= 15)
                {
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_from_10_to_15_feet));
                }

                if (this.GreenWasHit && puttLength >= 30)
                {
                    if (ApproachShotNumber == 0)
                    {
                        ApproachShotNumber = this.HolePlayed.Par - 2;
                        ApproachClub = this.Shots[ApproachShotNumber - 1].Club;
                        ApproachDistance = this.Shots[ApproachShotNumber - 1].ActualDistance;
                    }
                    results.Add(new ShotWasted(this.HolePlayed.HoleNumber, (this.Score - this.HolePlayed.Par), ApproachShotNumber, ApproachClub, puttLength, ShotWastedType.Approach_left_30_foot_putt_or_more));
                }
            }
            #endregion

            // return results
            return results;
        }

        public static HoleScore CreateHolePlayedFromString(string holePlayedLine)
        {
            HoleScore result = new HoleScore();

            string[] fields = holePlayedLine.Split(DAC.Level1Separator.ToCharArray());

            result.HolePlayed.HoleNumber = GetInt(fields, (int)HolesPlayedFileFields.HoleNumber);
            result.Score = GetInt(fields, (int)HolesPlayedFileFields.Score);
            result.FairwayWasHit = GetBool(fields,(int)HolesPlayedFileFields.FairwayHit);
            result.GreenWasHit = GetBool(fields,(int)HolesPlayedFileFields.GreenHit);
            result.PuttsForHole = GetInt(fields,(int)HolesPlayedFileFields.Putts);
            result.PenaltyStrokes = GetInt(fields, (int)HolesPlayedFileFields.PenaltyStrokes);

            if(fields.Length > (int)HolesPlayedFileFields.Shots)
            {
                string shots = fields[(int)HolesPlayedFileFields.Shots];
                result.Shots = Shot.CreateShotsFromString(shots);
            }

            return result;
        }

        private static bool GetBool(string[] fields, int col)
        {
            if (fields == null) { return false; }
            if (fields.Length <= col) { return false; }
            object o = fields[col];
            if (o == null) { return false; }
            string sval = o.ToString();
            if (sval == string.Empty) { return false; }
            return (sval.ToLower() == "y" ||
                    sval.ToLower() == "1");
        }

        private static int GetInt(string[] fields, int col)
        {
            if(fields == null) { return 0; }
            if(fields.Length <= col) { return 0; }
            object o = fields[col];
            if (o == null) { return 0; }
            string sval = o.ToString();
            if (sval == string.Empty) { return 0; }
            int iVal = 0;

            Int32.TryParse(sval, out iVal);

            return iVal;
        }

        public override string ToString()
        {
            UpdateHoleSummaryFromShots();

            StringBuilder sb = new StringBuilder();
            sb.Append(this.HolePlayed.HoleNumber);
            sb.Append(DAC.Level1Separator);
            sb.Append(this.Score);
            sb.Append(DAC.Level1Separator);
            sb.Append(this.FairwayWasHit);
            sb.Append(DAC.Level1Separator);
            sb.Append(this.GreenWasHit);
            sb.Append(DAC.Level1Separator);
            sb.Append(this.PuttsForHole);
            sb.Append(DAC.Level1Separator);
            sb.Append(this.PenaltyStrokes);
            if(this.Shots != null && this.Shots.Count > 0)
            {
                sb.Append(DAC.Level1Separator);
                sb.Append(Shot.SaveShotsToString(this.Shots));
            }

            return sb.ToString();
        }

    }
}
