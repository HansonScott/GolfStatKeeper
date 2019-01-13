namespace GolfStatKeeper
{
    public enum ShotWastedType
    {
        Wiff,
        Penalty_OB,
        Penalty_hazard,
        Duplicate_chip,
        Duplicate_sand_shot,
        Miss_Hit,
        Poor_Drive,
        Three_putts_within_50_feet,
        Three_putts_from_over_50_feet,
        Two_putts_within_5_feet,
        Chip_and_two_putts,
        Approach_missed_green,
        Two_putts_from_5_to_10_feet,
        Two_putts_from_10_to_15_feet,
        Approach_left_30_foot_putt_or_more,
    }

    public class ShotWasted
    {
        public int holeNumber { get; set; }
        public int v1 { get; set; }
        public int shotNumber { get; set; }
        public ClubType club { get; set; }
        public int v2 { get; set; }
        public ShotWastedType type {get; set;}

        public ShotWasted(int holeNumber, int v1, int shotNumber, ClubType club, int v2, ShotWastedType t)
        {
            this.holeNumber = holeNumber;
            this.v1 = v1;
            this.shotNumber = shotNumber;
            this.club = club;
            this.v2 = v2;
            this.type = t;
        }
    }
}