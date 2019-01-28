using System;
using System.Collections.Generic;

namespace GolfStatKeeper
{
    public class Shot
    {
        public enum BallLie
        {
            Tee = 1,
            Fairway = 2,
            Rough_Light = 3,
            Rough_Heavy = 4,
            Green = 5,
            Sand = 6,
            Sand_Buried = 7,
            Sand_Lip = 8,
        }
        public enum BallFlight
        {
            Wiff = 1,
            Chip = 2,
            BumpAndRun = 3,
            Flop = 4,
            Topped = 5,
            Shank = 6,
            Fat = 7,
            Skied = 8,
            Pull = 9,
            Hook = 10,
            Draw = 11,
            Straight = 12,
            Fade = 13,
            Slice = 14,
            Push = 15,
        }
        public enum ShotResult
        {
            As_intended = 1,
            Different_Ball_Impact = 2,
            Different_Ball_Flight = 3,
            Different_Length = 4,
            Different_Direction = 5,
            Hazard = 6,
            OB = 7,
        }

        public int ShotNumber { get; set; }
        public BallLie Lie { get; set; }
        public ClubType Club { get; set; }

        public BallFlight TargetFlight { get; set; }
        public ShotResult TargetResult { get; set; }
        public int TargetDistance { get; set; }

        public BallFlight ActualFlight { get; set; }
        public ShotResult ActualResult { get; set; }
        public int ActualDistance { get; set; }

        public static string SaveShotsToString(List<Shot> shots)
        {
            throw new NotImplementedException();
        }

        public static List<Shot> CreateShotsFromStringLine(string shots)
        {
            throw new NotImplementedException();
        }
    }
}