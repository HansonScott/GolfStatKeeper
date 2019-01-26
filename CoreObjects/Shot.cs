using System;
using System.Collections.Generic;

namespace GolfStatKeeper
{
    public class Shot
    {
        public enum BallLie
        {
            Fairway,
            Green,
            Sand,
            Sand_Buried,
            Sand_Lip,
            Tee,

        }
        public enum BallFlight
        {
            Wiff,
            Chip,
            BumpAndRun,
            Flop,
            Topped,
            Shank,
            Fat,
            Skied,
            Pull,
            Hook,
            Draw,
            Straight,
            Fade,
            Slice,
            Push,
        }
        public enum ShotResult
        {
            As_intended,
            Different_Ball_Impact,
            Different_Ball_Flight,
            Different_Location,
            Hazard,
            OB,
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