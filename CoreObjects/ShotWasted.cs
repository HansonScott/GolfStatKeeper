using System;
using System.Collections.Generic;

namespace GolfStatKeeper
{
    public enum ShotWastedType
    {
        Wiff = 1,
        Penalty_OB = 2,
        Penalty_hazard = 3,
        Duplicate_chip = 4,
        Duplicate_sand_shot = 5,
        Miss_Hit = 6,
        Three_putts_within_50_feet = 7,
        Chip_and_two_putts = 8,
        Two_putts_within_5_feet = 9,
        Three_putts_from_over_50_feet = 10,
        Poor_Drive = 11,
        Approach_missed_green = 12,
        Two_putts_from_5_to_10_feet = 13,
        Two_putts_from_10_to_15_feet = 14,
        Approach_left_30_foot_putt_or_more = 15,
    }

    public class ShotWasted
    {
        public int holeNumber { get; set; }
        public int OverPar { get; set; }
        public int shotNumber { get; set; }
        public ClubType club { get; set; }
        public int PuttDistance { get; set; }
        public ShotWastedType type {get; set;}

        public ShotWasted(int holeNumber, int OverPar, int shotNumber, ClubType club, int PuttDistance, ShotWastedType t)
        {
            this.holeNumber = holeNumber;
            this.OverPar = OverPar;
            this.shotNumber = shotNumber;
            this.club = club;
            this.PuttDistance = PuttDistance;
            this.type = t;
        }

        public static List<ShotWasted> FindWastedShots(HoleScore score)
        {
            List<ShotWasted> results = new List<ShotWasted>();

            // go through each shot and collect data.
            int putts = 0;
            int puttLength = 0;

            bool chipped = false;
            ClubType ChipClub = ClubType.Wedge_Lob;
            int ChipShotNumber = 0;

            ClubType ApproachClub = ClubType.Wedge_Lob;
            int ApproachShotNumber = 0;
            int ApproachDistance = 0;

            // for each shot, find any wasted ones
            for (int i = 0; i < score.Shots.Count; i++)
            {
                Shot thisShot = score.Shots[i];
                if (thisShot == null) { continue; }

                Shot nextShot = null;
                if (i < score.Shots.Count - 1)
                {
                    nextShot = score.Shots[i + 1];
                }

                #region Wiff
                if (thisShot.ActualFlight == Shot.BallFlight.Wiff)
                {
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, 0, ShotWastedType.Wiff));
                }
                #endregion
                #region OB
                else if (thisShot.ActualResult == Shot.ShotResult.OB)
                {
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Penalty_OB));
                }
                #endregion
                #region Hazard
                else if (thisShot.ActualResult == Shot.ShotResult.Hazard)
                {
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Penalty_hazard));
                }
                #endregion
                #region Set Chip and catch Duplicate Chip
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
                        results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Duplicate_chip));
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
                    // also, make sure the hole wasn't drive to fairway sand, approach to greenside sand,
                    if (thisShot.Club == ClubType.Wedge_Sand &&
                        nextShot.Club == ClubType.Wedge_Sand)
                    {
                        results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Duplicate_sand_shot));
                    }
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
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Miss_Hit));
                }

                #endregion
                #region Poor Drive
                // it's a poor drive if it was less distance, not as intended, and next shot was not 'easy'
                else if (thisShot.Lie == Shot.BallLie.Tee && score.HolePlayed.Par > 3 &&
                   thisShot.ActualResult != Shot.ShotResult.As_intended &&
                   thisShot.ActualDistance > 0 &&
                   thisShot.TargetDistance > 0 &&
                   thisShot.ActualDistance < (.9 * thisShot.TargetDistance) &&
                   nextShot.Lie != Shot.BallLie.Fairway &&
                   nextShot.Lie != Shot.BallLie.Green &&
                   !score.GreenWasHit)
                {
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Poor_Drive));
                }
                else
                {
                    // this shot was not an obvious error
                }
                #endregion

                #region Set ApproachClub
                if (thisShot.Club != ClubType.Driver &&
                        !(score.HolePlayed.Par > 3 && thisShot.Lie == Shot.BallLie.Tee) &&
                        thisShot.Club != ClubType.Putter &&
                        thisShot.Lie != Shot.BallLie.Green &&
                        thisShot.Lie != Shot.BallLie.Sand &&
                        thisShot.TargetFlight != Shot.BallFlight.BumpAndRun &&
                        thisShot.TargetFlight != Shot.BallFlight.Chip &&
                        thisShot.TargetFlight != Shot.BallFlight.Flop &&
                        !(score.HolePlayed.Par == 5 && thisShot.ShotNumber == 2))
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
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), score.Score, ClubType.Putter, puttLength, ShotWastedType.Three_putts_within_50_feet));
                }
                else
                {
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), score.Score, ClubType.Putter, puttLength, ShotWastedType.Three_putts_from_over_50_feet));
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
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), score.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_within_5_feet));
                }
                // if a chip left a putt length greater than 5 feet, it's more a chipping issue.
                else if (chipped)
                {
                    // if our chip was just close to the green, it was a chip issue.
                    if (score.GreenWasHit || score.Shots[ChipShotNumber - 1].ActualDistance < 10)
                    {
                        results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), ChipShotNumber, ChipClub, puttLength, ShotWastedType.Chip_and_two_putts));
                    }
                    // otherwise, it was the approaches fault.
                    else if (score.Shots[ChipShotNumber - 2].Lie == Shot.BallLie.Fairway ||
                            score.Shots[ChipShotNumber - 2].ActualResult != Shot.ShotResult.As_intended)
                    {
                        results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), ApproachShotNumber, ApproachClub, ApproachDistance, ShotWastedType.Approach_missed_green));
                    }
                }
                else if (puttLength <= 10)
                {
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), score.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_from_5_to_10_feet));
                }
                else if (puttLength <= 15)
                {
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), score.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_from_10_to_15_feet));
                }

                if (score.GreenWasHit && puttLength >= 30)
                {
                    if (ApproachShotNumber == 0)
                    {
                        ApproachShotNumber = score.HolePlayed.Par - 2;
                        ApproachClub = score.Shots[ApproachShotNumber - 1].Club;
                        ApproachDistance = score.Shots[ApproachShotNumber - 1].ActualDistance;
                    }
                    results.Add(new ShotWasted(score.HolePlayed.HoleNumber, (score.Score - score.HolePlayed.Par), ApproachShotNumber, ApproachClub, puttLength, ShotWastedType.Approach_left_30_foot_putt_or_more));
                }
            }
            #endregion

            // return results
            return results;
        }

        public static void SortList(ref List<ShotWasted> shots)
        {
            // thoery: sort based on most obvious / worst shots as defined by type and situation
            shots.Sort(delegate (ShotWasted w1, ShotWasted w2)
            {
                // first, compare the type as that is the most important
                int result = ((int)w1.type).CompareTo((int)w2.type);

                // if different, we're done.
                if (result != 0) { return result; }

                // if the type is the same, then check for the highest hole score (worse hole score is more obvious)
                // note, the objects are switched because a higher over par is prioritized
                result = ((int)w2.OverPar).CompareTo((int)w1.OverPar);

                return result;
            });
        }
    }
}