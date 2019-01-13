using System;

namespace GolfStatKeeper
{
    public enum Lie
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
        wiff,
        Chip,
        BumpAndRun,
        Flop,
        Topped,
        Shank,
        Fat,
        Sand_Greenside,
    }
    public enum ShotResult
    {
        Hazard,
        OB,
        As_intended,
    }

    public class Shot
    {
        public int ShotNumber { get; set; }
        public Lie Lie { get; set; }
        public ClubType Club { get; set; }

        public BallFlight TargetFlight { get; set; }
        public ShotResult TargetResult { get; set; }
        public int TargetDistance { get; set; }

        public BallFlight ActualFlight { get; set; }
        public ShotResult ActualResult { get; set; }
        public int ActualDistance { get; set; }

        public static string SaveShotsToString(Shot[] shots)
        {
            throw new NotImplementedException();
        }

        public static Shot[] CreateShotsFromStringLine(string shots)
        {
            throw new NotImplementedException();
        }
    }
}