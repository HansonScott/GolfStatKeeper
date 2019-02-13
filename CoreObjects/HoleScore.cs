﻿using System;
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
                    sval.ToLower() == "1" ||
                    sval.ToLower() == "true" ||
                    sval.ToLower() == "t");
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
            sb.Append((this.FairwayWasHit ? 1: 0));
            sb.Append(DAC.Level1Separator);
            sb.Append((this.GreenWasHit ? 1: 0));
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
