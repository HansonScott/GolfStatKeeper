using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Windows.Forms;

namespace GolfStatKeeper
{

    #region Enums
    #region Top level files
    public enum PlayerFileFields
        {
            ID = 0,
            Name = 1,
            Clubs = 2,
        }
    public enum CourseFileFields
        {
            ID = 0,
            Name = 1,
            Tees = 2,
            Slope = 3,
            Rating = 4,
            Holes = 5,
        }
    public enum RoundFileFields
    {
        ID = 0,
        Course = 1,
        Player = 2,
        When = 3,
        Conditions = 4,
        HolesPlayed = 5,
        FairwaysHit = 6,
        GreensHit = 7,
        TotalPutts = 8,
        TotalPenaltyStrokes = 9,
        TotalScore = 10,

    }
    public enum HolesPlayedFileFields // ID of file is the round ID
    {
        HoleNumber = 0,
        Score = 1,
        FairwayHit = 2,
        GreenHit = 3,
        Putts = 4,
        PenaltyStrokes = 5,
        Shots = 6,
    }
    #endregion

    #region Detail Object Fields
    public enum ClubFields // fields within the player file
    {
        ClubType = 0,
        ClubName = 1,
    }
    public enum HoleFields // fields within a course file
    {
        HoleNumber = 0,
        Par = 1,
        Length = 2,
        HCP = 3,
    }
    public enum ShotsFields // within the holesPlayed file
    {
        ShotNumber = 0,
        ClubType = 1,
        Lie = 2,
        TargetDistance = 3,
        TargetFlight = 4,
        ActualDistance = 5,
        ActualFlight = 6,
        ActualResult = 7,
    }
    #endregion
    #endregion

    public class DAC // Data Access Code
    {
        #region Separators and Extensions
        public static string Level1Separator = "|";
        public static string Level2Separator = ",";
        public static string Level3Separator = ":";
        //public static string Level4Separator = "~"; 
        public static string NotesExtension = ".note";
        public static string HelpExtension = ".help";
        #endregion

        #region FileLocations from App Settings
        //public static string LocalDirectory = ConfigurationManager.AppSettings["LocalDirectory"] + Path.DirectorySeparatorChar;
        public static string DATA_PATH
        {
            get; set;
        }
        public static string LocalDirectory
        {
            get { return System.AppDomain.CurrentDomain.BaseDirectory; }
        }
        public static string ContentsFolder
        {
            get
            {
                if (DATA_PATH != null && 
                    DATA_PATH != String.Empty)
                {
                    return Path.Combine(DATA_PATH, ConfigurationManager.AppSettings["ContentsFolder"]);
                }
                else
                {
                    return Path.Combine(LocalDirectory, ConfigurationManager.AppSettings["ContentsFolder"]);
                }
            }
        }
        public static string RoundDetailsFolder
        {
            get { return Path.Combine(ContentsFolder, ConfigurationManager.AppSettings["RoundsDetailsFolder"]); }
        }
        public static string NotesFolder
        {
            get { return Path.Combine(ContentsFolder, ConfigurationManager.AppSettings["NotesFolder"]); }
        }
        public static string HelpFolder
        {
            get { return Path.Combine(ContentsFolder, ConfigurationManager.AppSettings["HelpFolder"]); }
        }

        public static string PlayersFile
        {
            get { return Path.Combine(ContentsFolder, ConfigurationManager.AppSettings["PlayersFile"]); }
        }

        public static string CoursesFile
        {
            get { return Path.Combine(ContentsFolder, ConfigurationManager.AppSettings["CoursesFile"]); }
        }
        public static string RoundsFile
        {
            get { return Path.Combine(ContentsFolder, ConfigurationManager.AppSettings["RoundsFile"]); }
        }
        #endregion

        #region Direct File Access Methods
        public static bool CheckInstalled()
        {
            // if installed directory does not exist, then install
            if (!Directory.Exists(ContentsFolder))
            {
                DialogResult dr = MessageBox.Show("Golf Stat Keeper has not been installed on this machine.  Install now?", "Contents Directory not found.", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) { return false; }

                #region Create Directories
                // then create the Local Directory
                try
                {
                    Directory.CreateDirectory(LocalDirectory);

                    // create all sub-directories
                    Directory.CreateDirectory(ContentsFolder);
                    Directory.CreateDirectory(RoundDetailsFolder);
                    Directory.CreateDirectory(NotesFolder);
                    Directory.CreateDirectory(HelpFolder);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not create directories for program files." + Environment.NewLine + 
                                    "Exception: " + e.Message, "Error installing program files.", MessageBoxButtons.OK);
                    return false;
                }
                #endregion

                // copy content files to their various Directories
                #region Copy Help Files
                // get all help files.
                //string[] files = Directory.GetFiles(HelpFolder);

                //// copy all help files to new directory
                //for (int i = 0; i < files.Length; i++)
                //{
                //    File.Copy(files[i], LocalDirectory + Path.DirectorySeparatorChar + files[i]);
                //}
                #endregion

                // others?

                return true;
            }

            return true;
        }

        private static string ReadText(string FileName)
        {
            if (File.Exists(FileName))
            {
                return File.ReadAllText(FileName);
            }
            else
            {
                return string.Empty;
            }
        }
        private static string[] ReadAllLines(string FileName)
        {
            if (File.Exists(FileName))
            {
                return File.ReadAllLines(FileName);
            }
            else
            {
                return new string[0];
            }
        }
        private static void WriteFile(string FileName, string fileContents)
        {
            WriteFile(FileName, fileContents, false);
        }
        private static void WriteFile(string FileName, string fileContents, bool Append)
        {
            if (Append && File.Exists(FileName))
            {
                File.AppendAllText(FileName, Environment.NewLine + fileContents);
            }
            else
            {
                File.WriteAllText(FileName, fileContents);
            }
        }
        private static void WriteLines(string FileName, string[] fileContentLines)
        {
            File.WriteAllLines(FileName, fileContentLines);
        }
        private static void DeleteRoundDetailFile(int rID)
        {
            // Can't delete if the folders not there.
            if (!Directory.Exists(RoundDetailsFolder))
            {
                return;
            }

            string file = rID + ".txt";
            string path = Path.Combine(RoundDetailsFolder, file);

            DeleteFile(path);
        }
        private static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        #endregion

        #region Player (File)
        public static string[] GetPlayerFileLines()
        {
            return ReadAllLines(PlayersFile);
        }
        public static string[] GetPlayerNames()
        {
            string[] lines = GetPlayerFileLines();
            string[] names = new string[lines.Length];

            for(int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(Level1Separator.ToCharArray());
                names[i] = parts[(int)PlayerFileFields.Name];
            }
            return names;
        }
        public static Player[] GetPlayers()
        {
            string[] players = GetPlayerFileLines();
            Player[] results = new Player[players.Length];

            for (int i = 0; i < players.Length; i++)
            {
                results[i] = Player.LoadFromFileLine(players[i]);
            }

            return results;
        }
        public static Player GetPlayerByID(string pID)
        {
            string[] players = GetPlayerFileLines();

            for (int i = 0; i < players.Length; i++)
            {
                string[] fields = players[i].Split(Level1Separator.ToCharArray());
                if (fields[(int)PlayerFileFields.ID] == pID)
                {
                    return Player.LoadFromFileLine(players[i]);
                }
            }

            return null;
        }
        public static void AddNewPlayer(int pID, string Name, string clubs)
        {
            string[] players = GetPlayerFileLines();

            string[] playersUpdated = new string[players.Length + 1];

            for (int i = 0; i < playersUpdated.Length; i++)
            {
                if (i == players.Length) // if last record.
                {
                    // use enum?
                    string[] newFields = new string[Enum.GetNames(typeof(PlayerFileFields)).Length];
                    newFields[(int)PlayerFileFields.ID] = pID.ToString();
                    newFields[(int)PlayerFileFields.Name] = Name;
                    newFields[(int)PlayerFileFields.Clubs] = clubs;
                    string newLine = String.Join(Level1Separator, newFields);
                    playersUpdated[i] = newLine;
                }
                else
                {
                    playersUpdated[i] = players[i];
                }
            }
            WriteLines(PlayersFile, playersUpdated);
        }
        public static void SavePlayer(int ID, string Name, string clubs)
        {
            string[] players = GetPlayerFileLines();

            for (int i = 0; i < players.Length; i++)
            {
                // find the matching ID
                string[] fields = players[i].Split(Level1Separator.ToCharArray());

                if (fields[(int)PlayerFileFields.ID] == ID.ToString())
                {
                    // change the data
                    fields[(int)PlayerFileFields.Name] = Name;
                    fields[(int)PlayerFileFields.Clubs] = clubs;

                    // set back to list of players
                    players[i] = String.Join(Level1Separator, fields);
                    break;
                }
            }

            // write over the file
            WriteLines(PlayersFile,players);
        }
        public static void DeletePlayerID(string ID)
        {
            string[] players = ReadAllLines(PlayersFile);
            string[] newPlayers = new string[players.Length - 1];
            int nextID = 0;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].StartsWith(ID))
                {
                    players[i] = null;
                    break;
                }
                else
                {
                    newPlayers[nextID] = players[i];
                    nextID++;
                }
            }

            WriteLines(PlayersFile, newPlayers);

            // now delete all data relating to this player ID !
            DeleteRoundsByPlayerID(ID);
        }

        public static string GetCurrentPlayer()
        {
            string p = ConfigurationManager.AppSettings["CurrentPlayer"];
            return p;
        }
        public static void SetCurrentPlayer(Player p)
        {
            // store the value back to the running memory config
            ConfigurationManager.AppSettings["CurrentPlayer"] = p.ID.ToString();

            // Future: store the value back to the config file.
            //string configPath = Application.StartupPath + Path.DirectorySeparatorChar 
            //                        + "golfstatkeeper.exe.config";
            //Configuration c = ConfigurationManager.OpenExeConfiguration(configPath);
            //c.AppSettings["CurrentPlayer"] = p.ID.ToString();
            //c.Save();
        }
        #endregion

        #region Clubs - sub object within player
        public static Club[] GetClubsForCurrentPlayer()
        {
            // get the current players bag
            Player p = FormMain.thisForm.CurrentPlayer;
            return p.Bag.Clubs;
        }
        #endregion

        #region Course (File)
        public static void PopulateCoursesToComboBox(ComboBox c)
        {
            // get all the courses
            Course[] courses = GetCourses();
            c.DisplayMember = "Name";
            c.ValueMember = "ID";

            // clear old stuff, if there is any
            c.Items.Clear();
            c.Text = String.Empty;

            for (int i = 0; i < courses.Length; i++)
            {
                c.Items.Add(new CBItem(courses[i].ID.ToString(), courses[i].CourseAndTee));
            }
        }
        public static string[] GetCoursesFileLines()
        {
            if (!File.Exists(CoursesFile))
            {
                WriteFile(CoursesFile, String.Empty);
            }
            return ReadAllLines(CoursesFile);
        }
        public static Course[] GetCourses()
        {
            string[] courses = GetCoursesFileLines();
            Course[] results = new Course[courses.Length];

            for (int i = 0; i < courses.Length; i++)
            {
                results[i] = Course.LoadFromFileLine(courses[i]);
            }
            Array.Sort(results);
            return results;
        }
        public static Course GetCourseByID(string cID)
        {
            string[] courses = GetCoursesFileLines();

            for (int i = 0; i < courses.Length; i++)
            {
                string[] fields = courses[i].Split(Level1Separator.ToCharArray());
                if (fields[(int)CourseFileFields.ID] == cID)
                {
                    return Course.LoadFromFileLine(courses[i]);
                }
            }

            return null;
        }
        public static Course GetCourseByNameAndTee(string CourseNameAndTee)
        {
            //"name - tee"
            string[] parts = CourseNameAndTee.Split('-');

            string[] courseLines = GetCoursesFileLines();
            for (int i = 0; i < courseLines.Length; i++)
            {
                string[] data = courseLines[i].Split(Level1Separator.ToCharArray());
                if (data[(int)CourseFileFields.Name] == parts[0].Trim() &&
                    data[(int)CourseFileFields.Tees] == parts[1].Trim())
                {
                    return Course.LoadFromFileLine(courseLines[i]);
                }
            }
            return null;
        }
        public static Course[] GetCoursesByCourseAndTeeNames(string[] SelectedCourses)
        {
            Course[] Results = new Course[SelectedCourses.Length];
            string[] courseLines = GetCoursesFileLines();

            for( int i = 0; i < SelectedCourses.Length; i++)
            {
                //"name - tee"
                string[] parts = SelectedCourses[i].Split('-');
                for (int j = 0; j < courseLines.Length; j++)
                {
                    string[] data = courseLines[j].Split(Level1Separator.ToCharArray());
                    if (data[(int)CourseFileFields.Name] == parts[0].Trim() &&
                        data[(int)CourseFileFields.Tees] == parts[1].Trim())
                    {
                        Results[i] = Course.LoadFromFileLine(courseLines[j]);
                    }
                }
            }
            Array.Sort(Results);
            return Results;
        }
        public static string[] GetCourseAndTeeNames()
        {
            string[] lines = GetCoursesFileLines();
            string[] names = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(Level1Separator.ToCharArray());
                string temp1 = parts[(int)CourseFileFields.Name];
                string temp2 = parts[(int)CourseFileFields.Tees];
                names[i] = temp1 + " - " + temp2;
            }

            Array.Sort(names);
            return names;
        }
        public static string[] GetTeesForCourse(string cID)
        {
            List<string> tees = new List<string>();

            string[] courses = GetCoursesFileLines();

            for (int i = 0; i < courses.Length; i++)
            {
                string[] fields = courses[i].Split(Level1Separator.ToCharArray());
                if (fields[(int)CourseFileFields.ID] == cID)
                {
                    tees.Add(fields[(int)CourseFileFields.Tees]);
                }
            }

            return tees.ToArray();
        }
        public static void SaveCourse(string cID, string cName, string cTees, string cSlope, string cRating, string[] cHoles)
        {
            string[] courses = GetCoursesFileLines();

            for (int i = 0; i < courses.Length; i++)
            {
                // find the matching ID
                string[] fields = courses[i].Split(Level1Separator.ToCharArray());

                if (fields[(int)CourseFileFields.ID] == cID.ToString())
                {
                    // change the data
                    fields[(int)CourseFileFields.Name] = cName;
                    fields[(int)CourseFileFields.Tees] = cTees;
                    fields[(int)CourseFileFields.Slope] = cSlope;
                    fields[(int)CourseFileFields.Rating] = cRating;

                    string sHoles = String.Join(Level2Separator, cHoles);
                    fields[(int)CourseFileFields.Holes] = sHoles;

                    // set back to list of players
                    courses[i] = String.Join(Level1Separator, fields);
                    break;
                }
            }

            // write over the file
            WriteLines(CoursesFile, courses);
        }
        public static int AddCourse(string cName, string cTees, string cSlope, string cRating, string[] cHoles)
        {
            int newID = 0;
            string[] courses = GetCoursesFileLines();

            string[] coursesUpdated = new string[courses.Length + 1];

            int maxID = 0;
            for (int i = 0; i < coursesUpdated.Length; i++)
            {
                if (i < courses.Length)
                {
                    // to get the right ID, we need to calculate the max ID and add one.
                    Course thisCourse = Course.LoadFromFileLine(courses[i]);
                    maxID = Math.Max(maxID, thisCourse.ID);
                    coursesUpdated[i] = courses[i];
                }
                else if (i == courses.Length) // if last record.
                {
                    // use enum?
                    string[] newFields = new string[Enum.GetNames(typeof(CourseFileFields)).Length];
                    newFields[(int)CourseFileFields.Name] = cName;
                    newFields[(int)CourseFileFields.Tees] = cTees;
                    newFields[(int)CourseFileFields.Slope] = cSlope;
                    newFields[(int)CourseFileFields.Rating] = cRating;

                    newFields[(int)CourseFileFields.ID] = (maxID + 1).ToString();
                    newID = maxID + 1;

                    string holes = String.Join(Level2Separator, cHoles);
                    newFields[(int)CourseFileFields.Holes] = holes;

                    string newLine = String.Join(Level1Separator, newFields);
                    coursesUpdated[i] = newLine;
                }
            }

            WriteLines(CoursesFile, coursesUpdated);
            return newID;
        }
        public static void DeleteCourseByID(string cID)
        {
            string[] courses = GetCoursesFileLines();
            string[] newCourses = new string[courses.Length - 1];
            int currentIndex = 0;

            for (int i = 0; i < courses.Length; i++)
            {
                // find the matching ID
                string[] fields = courses[i].Split(Level1Separator.ToCharArray());

                if (fields[(int)CourseFileFields.ID] == cID.ToString())
                {
                    // don't copy to new array
                    continue;
                }
                else
                {
                    newCourses[currentIndex++] = courses[i];
                }
            }

            // write over the file
            WriteLines(CoursesFile, newCourses);
        }
        #endregion

        #region Round (File w/ summary)
        private static string[] GetRoundsFileLines()
        {
            if (!File.Exists(RoundsFile))
            {
                WriteFile(RoundsFile, "");
            }
            return ReadAllLines(RoundsFile);
        }
        public static void SaveRound(Round thisRound)
        {
            // add new round
            if (thisRound.ID < 0)
            {
                AddRound(thisRound);                
            }
            else
            {
                // update existing round.
                UpdateRound(thisRound);
            }

            SaveHolesPlayedByRoundID(thisRound.ID.ToString(), thisRound.HolesPlayed);
        }
        public static void UpdateRound(Round thisRound)
        {
            string[] rounds = GetRoundsFileLines();

            for (int i = 0; i < rounds.Length; i++)
            {
                // find the matching ID
                string[] fields = rounds[i].Split(Level1Separator.ToCharArray());

                if (fields[(int)RoundFileFields.ID] == thisRound.ID.ToString())
                {
                    rounds[i] = thisRound.ToString();
                    break;
                }
            }

            // write over the file
            WriteLines(RoundsFile, rounds);
        }
        public static void AddRound(Round thisRound)
        {
            string[] rounds = GetRoundsFileLines();

            string[] roundsUpdated = new string[rounds.Length + 1];

            int maxID = 0;
            for (int i = 0; i < roundsUpdated.Length; i++)
            {
                if (i == rounds.Length) // if last record.
                {
                    // assign the new ID
                    thisRound.ID = maxID + 1;

                    string newLine = thisRound.ToString();
                    
                    roundsUpdated[i] = newLine;
                }
                else
                {
                    Round r = Round.LoadFromFileLine(rounds[i], false);
                    maxID = Math.Max(r.ID, maxID);

                    roundsUpdated[i] = rounds[i];
                }
            }

            WriteLines(RoundsFile, roundsUpdated);

            SaveHolesPlayedByRoundID(thisRound.ID.ToString(), thisRound.HolesPlayed);
        }
        public static Round[] GetRoundsSummaryOnly()
        {
            return GetRounds(false);
        }
        public static Round[] GetRounds()
        {
            return GetRounds(true);
        }
        public static Round[] GetRounds(bool IncludeHoleDetails)
        {
            string[] rounds = GetRoundsFileLines();
            ArrayList temp = new ArrayList();

            for (int i = 0; i < rounds.Length; i++)
            {
                if (rounds[i] == string.Empty){ continue; }

                Round r = Round.LoadFromFileLine(rounds[i], IncludeHoleDetails);
                if (r.Player.ID == FormMain.thisForm.CurrentPlayer.ID)
                {
                    temp.Add(r);
                }
            }

            Round[] results = (Round[])temp.ToArray(typeof(Round));
            return results;
        }
        public static void SortRoundsByDate(Round[] results, bool ascending)
        {
            if (ascending)
            {
                Array.Sort(results,
                        delegate (Round r1, Round r2)
                        {
                            return r1.When.CompareTo(r2.When);
                        }
                    );

            }
            else
            {
                Array.Sort(results,
                        delegate (Round r1, Round r2)
                        {
                            return r2.When.CompareTo(r1.When);
                        }
                    );
            }
        }
        public static Round[] GetRoundsByCoursesAndDates(Course[] Courses, 
                                DateTime dateTime_From, 
                                DateTime dateTime_To, 
                                bool IncludeDetails)
        {
            if (Courses == null || Courses.Length < 1) { return new Round[0]; }
            ArrayList ResultRounds = new ArrayList();

            // get pre-made rounds (maybe do manually to make faster?)
            Round[] AllRounds = GetRoundsSummaryOnly();
            SortRoundsByDate(AllRounds, true);

            for (int i = 0; i < AllRounds.Length; i++)
            {
                // make sure round fits criteria, then add to arrayList.
                if(RoundAtOneOfTheseCourses(AllRounds[i], Courses))
                {
                    if(AllRounds[i].When >= dateTime_From.AddDays(-1) && 
                        AllRounds[i].When <= dateTime_To)
                    {
                        ResultRounds.Add(AllRounds[i]);
                    }
                }
            }

            Round[] Rounds = (Round[])ResultRounds.ToArray(typeof(Round));

            // now check for includeDetails
            if(IncludeDetails)
            {
                for(int i = 0; i < Rounds.Length; i++)
                {
                    // fill Rounds[i] with hole details
                    Rounds[i].HolesPlayed = GetHolesPlayedByRoundID(Rounds[i].ID.ToString(), Rounds[i].Course);
                }
            }
            return Rounds;
        }
        public static Round[] GetRoundsByDates(DateTime dFrom, DateTime dTo)
        {
            return GetRoundsByDates(dFrom, dTo, false);
        }
        public static Round[] GetRoundsByDates(DateTime dFrom, DateTime dTo, bool IncludeDetails)
        {
            ArrayList ResultRounds = new ArrayList();

            // get pre-made rounds (maybe do manually to make faster?)
            Round[] AllRounds = GetRoundsSummaryOnly();

            for (int i = 0; i < AllRounds.Length; i++)
            {
                if (AllRounds[i].When >= dFrom &&
                    AllRounds[i].When <= dTo)
                {
                    ResultRounds.Add(AllRounds[i]);
                }
            }

            Round[] Rounds = (Round[])ResultRounds.ToArray(typeof(Round));

            // now check for includeDetails
            if (IncludeDetails)
            {
                for (int i = 0; i < Rounds.Length; i++)
                {
                    // fill Rounds[i] with hole details
                    Rounds[i].HolesPlayed = GetHolesPlayedByRoundID(Rounds[i].ID.ToString(), Rounds[i].Course);
                }
            }
            return Rounds;
        }
        private static bool RoundAtOneOfTheseCourses(Round round, Course[] Courses)
        {
            for (int i = 0; i < Courses.Length; i++)
            {
                if (round.Course.ID == Courses[i].ID)
                {
                    return true;
                }
            }
            return false;
        }
        public static Round GetRoundByID(int rID)
        {
            string[] rounds = GetRoundsFileLines();
            for (int i = 0; i < rounds.Length; i++)
            {
                if (rounds[i] == string.Empty){ continue; }

                string[] fields = rounds[i].Split(DAC.Level1Separator.ToCharArray());
                int ID = Int32.Parse(fields[(int)RoundFileFields.ID]);
                if (ID == rID)
                {
                    Round result = Round.LoadFromFileLine(rounds[i], true);
                    result.HolesPlayed = GetHolesPlayedByRoundID(rID.ToString(), result.Course);
                    if(result.HolesPlayed == null) { result.HolesPlayed = new List<HoleScore>(); }
                    return result;
                }
            }

            return null;
        }
        public static void DeleteRoundByID(int rID)
        {
            string[] rounds = GetRoundsFileLines();
            string[] newRounds = new string[rounds.Length - 1];
            int currentIndex = 0;

            for (int i = 0; i < rounds.Length; i++)
            {
                // find the matching ID
                string[] fields = rounds[i].Split(Level1Separator.ToCharArray());

                if (fields[(int)RoundFileFields.ID] == rID.ToString())
                {
                    // don't copy to new array
                    continue;
                }
                else
                {
                    newRounds[currentIndex++] = rounds[i];
                }
            }

            // write over the file
            WriteLines(RoundsFile, newRounds);

            // now see if the details file exists, if so, delete it.
            DeleteRoundDetailFile(rID);
        }
        private static void DeleteRoundsByPlayerID(string ID)
        {
            // get all the rounds
            string[] rounds = GetRoundsFileLines();

            // go through all the rounds
            for (int i = 0; i < rounds.Length; i++)
            {
                // find the player ID of the round
                string[] fields = rounds[i].Split(Level1Separator.ToCharArray());

                // if this round was for the player ID passed in
                if (fields[(int)RoundFileFields.Player] == ID)
                {
                    // then capture the round ID
                    int RoundID = 0;
                    Int32.TryParse(fields[(int)RoundFileFields.ID], out RoundID);

                    // then delete the round
                    DeleteRoundByID(RoundID);
                }
            }
        }
        #endregion

        #region Hole Played (File by RoundID)
        public static string[] GetHolePlayedFileLines(string RoundID)
        {
            string folder = RoundDetailsFolder;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string file = RoundID + ".txt";
            string path = Path.Combine(folder,file);

            return ReadAllLines(path);
        }
        public static List<HoleScore> GetHolesPlayedByRoundID(string RoundID, Course c)
        {
            // look up the file with the RoundID.txt
            string[] holeLines = GetHolePlayedFileLines(RoundID);
            if (holeLines == null || holeLines.Length == 0) { return null; }

            List<HoleScore> results = new List<HoleScore>(holeLines.Length);

            for (int i = 0; i < holeLines.Length; i++)
            {
                HoleScore s = HoleScore.CreateHolePlayedFromString(holeLines[i]);

                // and fill in course data too
                s.HolePlayed.Par = c.Holes[i].Par;
                s.HolePlayed.HCP = c.Holes[i].HCP;
                s.HolePlayed.Length = c.Holes[i].Length;

                results.Add(s);
            }

            return results;
        }
        public static void SaveHolesPlayedByRoundID(string RoundID, List<HoleScore> holes)
        {
            string folder = RoundDetailsFolder;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string file = RoundID + ".txt";
            string path = Path.Combine(folder,file);

            string[] holeData = new string[holes.Count];
            for (int i = 0; i < holes.Count; i++)
            {
                holeData[i] = holes[i].ToString();
            }

            // will either overwrite or create file as necessary.
            WriteLines(path, holeData);
        }
        #endregion

        #region Notes
        public static string[] GetNotesFiles()
        {
            if (!Directory.Exists(NotesFolder))
            {
                Directory.CreateDirectory(NotesFolder);
            }

            string[] notesFiles = Directory.GetFiles(NotesFolder);

            ArrayList temp = new ArrayList();

            for (int i = 0; i < notesFiles.Length; i++)
            {
                string thisFileName = Path.GetFileName(notesFiles[i]);
                if (thisFileName.StartsWith(FormMain.thisForm.CurrentPlayer.ID.ToString()))
                {
                    temp.Add(thisFileName);
                }
            }

            string[] results = (string[])temp.ToArray(typeof(string));
            return results;
        }
        public static string GetNotesForTag(string thisTag)
        {
            string file = GetFileForThisPlayersNotes(thisTag);
            string path = Path.Combine(NotesFolder, file);
            return ReadText(path);
        }
        public static void WriteNote(string thisTag, string content, bool Append)
        {
            string file = GetFileForThisPlayersNotes(thisTag);
            string path = Path.Combine(NotesFolder,file);
            WriteFile(path, content, Append);
        }
        public static void DeleteTagAndNotes(string thisTag)
        {
            string file = GetFileForThisPlayersNotes(thisTag);
            string path = Path.Combine(NotesFolder, file);
            DeleteFile(path);
        }
        private static string GetFileForThisPlayersNotes(string thisTag)
        {
            return FormMain.thisForm.CurrentPlayer.ID.ToString() + "." + thisTag + NotesExtension;
        }
        #endregion

        #region Help
        public static string GetHelpDocForItemID(string ID)
        {
            string file = ID + HelpExtension;
            return ReadText(Path.Combine(HelpFolder, file));
        }
        #endregion

        internal static string SafeString(string raw)
        {
            raw = raw.Replace(DAC.Level1Separator, String.Empty);
            raw = raw.Replace(DAC.Level2Separator, String.Empty);
            raw = raw.Replace(DAC.Level3Separator, String.Empty);
            return raw;
        }
    }
}
