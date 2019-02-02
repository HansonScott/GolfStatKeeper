using System;
using System.Collections.Generic;
using System.Text;

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

        public static Shot FromString(string data)
        {
            Shot s = new Shot();
            string[] fields = data.Split(DAC.Level3Separator.ToCharArray());
            int sn = 0;
            if(fields != null && fields.Length > 0 &&
                Int32.TryParse(fields[0], out sn))
            {
                s.ShotNumber = sn;
            }

            if(fields != null && fields.Length > 1)
            {
                s.Lie = (BallLie)(Enum.Parse(typeof(BallLie), fields[1]));
            }

            if (fields != null && fields.Length > 2)
            {
                s.Club = (ClubType)(Enum.Parse(typeof(ClubType), fields[2]));
            }

            if (fields != null && fields.Length > 3)
            {
                s.TargetFlight = (BallFlight)(Enum.Parse(typeof(BallFlight), fields[3]));
            }

            if (fields != null && fields.Length > 4)
            {
                s.TargetResult = (ShotResult)(Enum.Parse(typeof(ShotResult), fields[4]));
            }

            int td = 0;
            if (fields != null && fields.Length > 5 &&
                Int32.TryParse(fields[5], out td))
            {
                s.TargetDistance = td;
            }

            if (fields != null && fields.Length > 6)
            {
                s.ActualFlight = (BallFlight)(Enum.Parse(typeof(BallFlight), fields[6]));
            }

            if (fields != null && fields.Length > 7)
            {
                s.ActualResult = (ShotResult)(Enum.Parse(typeof(ShotResult), fields[7]));
            }

            int ad = 0;
            if (fields != null && fields.Length > 5 &&
                Int32.TryParse(fields[6], out ad))
            {
                s.ActualDistance = ad;
            }

            return s;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.ShotNumber);
            sb.Append(DAC.Level3Separator);
            sb.Append((int)this.Lie);
            sb.Append(DAC.Level3Separator);
            sb.Append((int)this.Club);
            sb.Append(DAC.Level3Separator);
            sb.Append((int)this.TargetFlight);
            sb.Append(DAC.Level3Separator);
            sb.Append((int)this.TargetResult);
            sb.Append(DAC.Level3Separator);
            sb.Append((int)this.TargetDistance);
            sb.Append(DAC.Level3Separator);
            sb.Append((int)this.ActualFlight);
            sb.Append(DAC.Level3Separator);
            sb.Append((int)this.ActualResult);
            sb.Append(DAC.Level3Separator);
            sb.Append((int)this.ActualDistance);

            return sb.ToString();
        }
        public static string SaveShotsToString(List<Shot> shots)
        {
            StringBuilder sb = new StringBuilder();

            bool n = true;
            foreach(Shot s in shots)
            {
                if(n)
                {
                    sb.Append(DAC.Level2Separator);
                }

                sb.Append(s.ToString());
            }

            return sb.ToString();
        }

        public static List<Shot> CreateShotsFromString(string shots)
        {
            string[] shotData = shots.Split(DAC.Level2Separator.ToCharArray());
            List<Shot> lshots = new List<Shot>();

            foreach(string s in shotData)
            {
                lshots.Add(Shot.FromString(s));
            }

            return lshots;
        }
    }
}