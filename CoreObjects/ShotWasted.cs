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
        Three_putts_from_over_50_feet = 8,
        Two_putts_within_5_feet = 9,
        Chip_and_two_putts = 10,
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
    }
}