using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GolfStatKeeper
{
    public class Hole
    {
        #region Class Declarations
        public int Par;
        public int Length;
        public int HoleNumber;
        public int HCP;
        public int PenaltyStrokes = 0;
        public Shot[] Shots;
        #endregion

        #region Properties
        public int Score
        {
            get
            {
                int shots = 0;
                for(int i = 0; i < Shots.Length; i++)
                {
                    if(Shots[i] != null){shots++;}
                }
                return shots + PenaltyStrokes;
            }
        }
        #endregion

        #region Constructor
        public Hole() { }
        public Hole(int HoleNumber, int Length, int Par, int HCP)
        {
            this.Par = Par;
            this.Length = Length;
            this.HoleNumber = HoleNumber;
            this.HCP = HCP;
            Shots = new Shot[10];
        }
        #endregion

        public bool AddShot(Shot shot)
        {
            #region Add at end
            if (shot.ShotNumber == 0)
            {
                // then add at first opening.
                bool Added = false;
                for (int i = 0; i < this.Shots.Length; i++)
                {
                    if (!Added &&
                        Shots[i] == null)
                    {
                        shot.ShotNumber = i + 1;
                        Shots[i] = shot;
                        Added = true;
                    }
                    else if (Added &&
                        Shots[i] != null &&
                        Shots[i].ShotNumber >= shot.ShotNumber)
                    {
                        // push everyone else down one.
                        Shots[i].ShotNumber++;
                    }
                }
                // shot exeeds max limit!
                return false;
            }
            #endregion
            else // add at specific location.            
            {
                if (Shots[shot.ShotNumber - 1] == null)
                {
                    // then this shot number is open, just add it.
                    Shots[shot.ShotNumber - 1] = shot;

                    // and move everyone else up one.
                    int temp = shot.ShotNumber - 1;
                    for (int i = Shots.Length - 1; i > temp; i--)
                    {
                        // if there is room to move this shot up one
                        if (Shots[i] != null &&
                            i + 1 < Shots.Length)
                        {
                            // up the shot number
                            Shots[i].ShotNumber += 1;
                            // store the shot up one slot
                            Shots[i + 1] = Shots[i];
                            Shots[i] = null;
                        }
                    }
                }
                else
                {
                    // we want to put it at a specific location, 
                    // but that location is full.

                    // we need to move everyone else down.
                    int temp = shot.ShotNumber - 1;
                    for (int i = Shots.Length - 1; i >= temp; i--)
                    {
                        if (Shots[i] != null)
                        {
                            // if there is room to move this shot up one
                            if (i + 1 < Shots.Length)
                            {
                                // up the shot number
                                Shots[i].ShotNumber += 1;
                                // store the shot up one slot
                                Shots[i + 1] = Shots[i];
                            }
                            Shots[i] = null;

                            if (i == temp)
                            {
                                // then we want to put our new shot here.
                                Shots[i] = shot;
                                return true;
                            }
                        }
                    }
                }
                return true;
            }
        }
        public void DeleteShot(int ShotNumber)
        {
            for (int i = 0; i < Shots.Length; i++)
            {
                if (Shots[i] != null &&
                    Shots[i].ShotNumber == ShotNumber)
                {
                    Shots[i] = null;
                }
                else if (Shots[i] != null &&
                    Shots[i].ShotNumber > ShotNumber)
                {
                    Shots[i].ShotNumber--;
                }
            }

            // clean up null slots
            for (int i = 0; i < Shots.Length; i++)
            {
                if (i > 0 &&
                    Shots[i - 1] == null &&
                    Shots[i] != null)
                {
                    Shots[i - 1] = Shots[i];
                    Shots[i] = null;
                }
            }
        }

        public static Hole CreateHoleFromHoleDataString(string holeData)
        {
            string[] data = holeData.Split(DAC.SubElementSeparator.ToCharArray());

            int num = Int32.Parse(data[(int)HoleFileFields.HoleNumber]);
            int par = Int32.Parse(data[(int)HoleFileFields.Par]);
            int len = Int32.Parse(data[(int)HoleFileFields.Length]);
            int hcp = Int32.Parse(data[(int)HoleFileFields.HCP]);

            return new Hole(num, len, par, hcp);
        }
        public static Hole CreateHoleFromHolePlayedLine(string holePlayedLine)
        {
            Hole result = new Hole();

            string[] fields = holePlayedLine.Split(DAC.FieldSeparator.ToCharArray());

            result.HoleNumber = Int32.Parse(fields[(int)HolesPlayedFileFields.HoleNumber]);
            result.PenaltyStrokes = Int32.Parse(fields[(int)HolesPlayedFileFields.PenaltyStrokes]);

            string shots = fields[(int)HolesPlayedFileFields.Shots];
            result.Shots = Shot.CreateShotsFromStringLine(shots);

            return result;
        }

        public Shot GetShotByShotNumber(int shotNumber)
        {
            for (int i = 0; i < this.Shots.Length; i++)
            {
                if (this.Shots[i] != null &&
                    this.Shots[i].ShotNumber == shotNumber)
                { return this.Shots[i]; }
            }
            return null;
        }

        public bool FairwayWasHit()
        {
            if (this.Par == 3) { return false; }

            if (this.Shots[0] == null) { return false; }

            // if drive went into the hazard or OB
            if (this.PenaltyStrokes > 0 &&
                    (this.Shots[0].ActualResult == ShotResult.Hazard ||
                    this.Shots[0].ActualResult == ShotResult.OB))
            {
                return false;
            }

            // otherwise, check the second shot was from the fairway.
            for (int i = 0; i < this.Shots.Length; i++)
            {
                Shot thisShot = this.Shots[i];

                if (thisShot != null &&
                    thisShot.ShotNumber == 2)
                {
                    return (thisShot.Lie == Lie.Fairway);
                }
            }

            return false;
        }
        public bool GreenWasHit()
        {
            int putts = GetPuttsForHole();

            if (this.Shots[0] == null) { return false; }

            return (this.Score > 0 &&
                    this.Score - putts <= this.Par - 2);
        }
        public int GetPuttsForHole()
        {
            int putts = 0;
            for (int i = 0; i < this.Shots.Length; i++)
            {
                if (this.Shots[i] == null) { continue; }

                // Putts from green or putts with putter?
                //if (H.Shots[i].Club == ClubType.Putter)
                if (this.Shots[i].Lie == Lie.Green)
                {
                    putts++;
                }
            }
            return putts;
        }

        public ArrayList FindWastedShots()
        {
            ArrayList results = new ArrayList();

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
            ClubType ChipClub = ClubType.LW;
            int ChipShotNumber = 0;

            ClubType ApproachClub = ClubType.LW;
            int ApproachShotNumber = 0;
            int ApproachDistance = 0;

            for (int i = 0; i < this.Shots.Length; i++)
            {
                Shot thisShot = this.Shots[i];
                if (thisShot == null) { continue; }

                Shot nextShot = null;
                if(i < this.Shots.Length - 1)
                {
                    nextShot = this.Shots[i + 1];
                }

                #region Wiff
                if (thisShot.ActualFlight == BallFlight.wiff)
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), thisShot.ShotNumber, thisShot.Club, 0, ShotWastedType.Wiff));
                }
                #endregion
                #region OB
                else if (thisShot.ActualResult == ShotResult.OB)
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Penalty_OB));
                }
                #endregion
                #region Hazard
                else if (thisShot.ActualResult == ShotResult.Hazard)
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Penalty_hazard));
                }
                #endregion
                #region Duplicate Chip
                // if this shot was a type of chip, and so was the next
                else if (thisShot.ActualFlight == BallFlight.Chip ||
                         thisShot.ActualFlight == BallFlight.BumpAndRun ||
                         thisShot.ActualFlight == BallFlight.Flop)
                {
                    chipped = true;
                    ChipClub = thisShot.Club;
                    ChipShotNumber = thisShot.ShotNumber;

                    if (nextShot != null &&
                        (nextShot.ActualFlight == BallFlight.Chip ||
                         nextShot.ActualFlight == BallFlight.BumpAndRun ||
                         nextShot.ActualFlight == BallFlight.Flop))
                    {
                        results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Duplicate_chip));
                    }
                }
                #endregion
                #region Duplicate Sand Shot
                // if this and next were both in the sand
                else if ((thisShot.Lie == Lie.Sand ||
                         thisShot.Lie == Lie.Sand_Buried ||
                         thisShot.Lie == Lie.Sand_Lip) &&
                            nextShot != null &&
                        (nextShot.Lie == Lie.Sand ||
                         nextShot.Lie == Lie.Sand_Buried ||
                         nextShot.Lie == Lie.Sand_Lip))
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Duplicate_sand_shot));
                }
                #endregion
                #region Miss Hit
                    // if a shot went less than half it's intended distance, it was a miss hit
                else if ((thisShot.ActualFlight == BallFlight.Topped ||
                       thisShot.ActualFlight == BallFlight.Shank ||
                       thisShot.ActualFlight == BallFlight.Fat) &&
                       (thisShot.TargetDistance > 0 &&
                        thisShot.ActualDistance < (.5 * thisShot.TargetDistance)))
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Miss_Hit));
                }
                        
                #endregion
                #region Poor Drive
                // it's a poor drive if it was less distance, not as intended, and next shot was not 'easy'
                else if (thisShot.Lie == Lie.Tee && this.Par > 3 &&
                   thisShot.ActualResult != ShotResult.As_intended &&
                   thisShot.ActualDistance > 0 &&
                   thisShot.TargetDistance > 0 &&
                   thisShot.ActualDistance < (.9 * thisShot.TargetDistance) &&
                   nextShot.Lie != Lie.Fairway &&
                   nextShot.Lie != Lie.Green)
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), thisShot.ShotNumber, thisShot.Club, thisShot.ActualDistance, ShotWastedType.Poor_Drive));
                }
                #endregion
                #region Set ApproachClub
                if (thisShot.Club != ClubType.Driver &&
                        !(this.Par > 3 && thisShot.Lie == Lie.Tee) &&
                        thisShot.Club != ClubType.Putter &&
                        thisShot.Lie != Lie.Green &&
                        thisShot.ActualFlight != BallFlight.Sand_Greenside &&
                        thisShot.TargetFlight != BallFlight.BumpAndRun &&
                        thisShot.TargetFlight != BallFlight.Chip &&
                        thisShot.TargetFlight != BallFlight.Flop &&
                        !(this.Par == 5 && thisShot.ShotNumber == 2))
                    {
                        ApproachClub = thisShot.Club;
                        ApproachShotNumber = thisShot.ShotNumber;
                        ApproachDistance = thisShot.ActualDistance;
                    }                
                #endregion

                #region store putts
                if (thisShot.Lie == Lie.Green)
                {
                    putts++;
                    puttLength = Math.Max(puttLength, thisShot.TargetDistance);
                }
                #endregion

            } // end for loop - shots

            #region 3-Putts
            if (putts > 2)
            {
                if(puttLength <= 50)
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Three_putts_within_50_feet));
                }
                else
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Three_putts_from_over_50_feet));
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
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_within_5_feet));
                }
                // if a chip left a putt length greater than 5 feet, it's more a chipping issue.
                else if (chipped)
                {
                    // if our chip was just close to the green, it was a chip issue.
                    if (GreenWasHit() || this.Shots[ChipShotNumber - 1].ActualDistance < 10)
                    {
                        results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), ChipShotNumber, ChipClub, puttLength, ShotWastedType.Chip_and_two_putts));
                    }
                    // otherwise, it was the approaches fault.
                    else if (this.Shots[ChipShotNumber - 2].Lie == Lie.Fairway ||
                            this.Shots[ChipShotNumber - 2].ActualResult != ShotResult.As_intended)
                    {
                        results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), ApproachShotNumber, ApproachClub, ApproachDistance, ShotWastedType.Approach_missed_green));
                    }
                }
                else if (puttLength <= 10)
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_from_5_to_10_feet));
                }
                else if (puttLength <= 15)
                {
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), this.Score, ClubType.Putter, puttLength, ShotWastedType.Two_putts_from_10_to_15_feet));
                }

                if (GreenWasHit() && puttLength >= 30)
                {
                    if (ApproachShotNumber == 0)
                    {
                        ApproachShotNumber = this.Par - 2;
                        ApproachClub = this.Shots[ApproachShotNumber - 1].Club;
                        ApproachDistance = this.Shots[ApproachShotNumber - 1].ActualDistance;
                    }
                    results.Add(new ShotWasted(this.HoleNumber, (this.Score - this.Par), ApproachShotNumber, ApproachClub, puttLength, ShotWastedType.Approach_left_30_foot_putt_or_more));
                }
            }
            #endregion

            // return results
            return results;
        }
    }
}
