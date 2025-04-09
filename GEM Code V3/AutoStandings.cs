using System;
using System.Collections.Generic;
using System.IO;

namespace GEM_Code_V3
{
    public class AutoStandings
    {
        CommonData CD;

        Round CurrentRound;

        List<Class> RacingClasses = new List<Class>();
        List<string> strRacingClasses;
        List<int> PointsSystem = new List<int>();

        string PointsSystemFilePath, StandingsFilePath, FilePath;

        public AutoStandings(CommonData iCD, Round iRound)
        {
            CD = iCD;
            CurrentRound = iRound;

            PointsSystemFilePath = CD.GetPointsSystemsLocation();
            StandingsFilePath = CD.GetStandingsLocation();

            strRacingClasses = CurrentRound.GetShortRacingClasses();

            foreach (string RC in strRacingClasses)
            {
                RacingClasses.Add(CD.GetClasses(Convert.ToInt32(RC.Replace("C","")) - 1));
            }
        }

        public void DoAllStandings(List<Entrant> EntryList, string Session)
        {
            CrewStandings(EntryList, Session);
            TeamsStandings(EntryList, Session);
            ManufacturersStandings(EntryList, Session);
        }

        public void CrewStandings(List<Entrant> EntryList, string Session)
        {
            int IndexOfNextClass = 0;
            List<Entrant> Entrants;

            for (int i = 0; i < RacingClasses.Count; i++)
            {
                ClassIndexSort(EntryList);

                (Entrants, IndexOfNextClass) = SplitToList(RacingClasses, i, EntryList, IndexOfNextClass);

                int ClassIndex = CD.GetClassIndex(RacingClasses[i].GetClassName());

                LoadPointsSystem(Session);

                for (int j = 0; j < Entrants.Count; j++)
                {
                    if (j < PointsSystem.Count)
                    {
                        if (Entrants[j].GetOVR () != 1 && !Entrants[j].GetInGarage())
                        {
                            Entrants[j].SetPoints(PointsSystem[j]);
                        }
                    }
                }

                IndexSort(Entrants);

                StandingsFilePath = Path.Combine(CD.GetStandingsLocation(), "Crew", "Class " + ClassIndex + ".csv");

                WriteCrewStandings(Entrants, StandingsFilePath);
            }
        }

        public void TeamsStandings(List<Entrant> EntryList, string Session)
        {
            int IndexOfNextClass = 0;
            List<Entrant> Entrants;

            for (int i = 0; i < RacingClasses.Count; i++)
            {
                (Entrants, IndexOfNextClass) = SplitToList(RacingClasses, i, EntryList, IndexOfNextClass);

                int ClassIndex = CD.GetClassIndex(RacingClasses[i].GetClassName());

                LoadPointsSystem(Session);

                for (int j = 0; j < Entrants.Count; j++)
                {
                    if (j < PointsSystem.Count)
                    {
                        if (Entrants[j].GetOVR() != 1 && !Entrants[j].GetInGarage())
                        {
                            Entrants[j].SetPoints(PointsSystem[j]);
                        }
                    }
                }

                IndexSort(Entrants);

                List<Entrant> Teams = new List<Entrant>(), CurrentTeam = new List<Entrant>();
                List<string> TeamNames = GetTeamNames(ClassIndex);
                int IndexOfNextTeam = 0;
                bool NextTeamFound = false;

                for (int t = 0; t < TeamNames.Count; t++)
                {
                    CurrentTeam.Clear();

                    for (int j = IndexOfNextTeam; j < Entrants.Count; j++)
                    {
                        if (Entrants[j].GetTeamName() == TeamNames[t])
                        {
                            CurrentTeam.Add(Entrants[j]);
                        }

                        if (t != TeamNames.Count - 1)
                        {
                            if (Entrants[j].GetTeamName() == TeamNames[t + 1] && !NextTeamFound)
                            {
                                IndexOfNextTeam = j;
                                break;
                            }
                        }
                    }

                    PointSort(CurrentTeam);

                    if (CurrentTeam.Count > 0)
                    {
                        Teams.Add(CurrentTeam[0]);
                    }
                }

                StandingsFilePath = Path.Combine(CD.GetStandingsLocation(), "Teams", "Class " + ClassIndex + ".csv");

                WriteTeamsStandings(Teams, StandingsFilePath);
            }
        }

        public void ManufacturersStandings(List<Entrant> EntryList, string Session)
        {
            int IndexOfNextClass = 0;
            List<Entrant> Entrants;

            for (int i = 0; i < RacingClasses.Count; i++)
            {
                (Entrants, IndexOfNextClass) = SplitToList(RacingClasses, i, EntryList, IndexOfNextClass);

                int ClassIndex = CD.GetClassIndex(RacingClasses[i].GetClassName());

                LoadPointsSystem(Session);

                for (int j = 0; j < Entrants.Count; j++)
                {
                    if (Entrants[j].GetOVR() != 1 && !Entrants[j].GetInGarage() && j < PointsSystem.Count)
                    {
                        Entrants[j].SetPoints(PointsSystem[j]);
                    }
                }

                IndexSort(Entrants);

                List<Entrant> Teams = new List<Entrant>(), CurrentTeam = new List<Entrant>();
                List<string> TeamNames = GetManufacturers(ClassIndex);
                int IndexOfNextTeam = 0;
                bool NextTeamFound = false;

                for (int t = 0; t < TeamNames.Count; t++)
                {
                    CurrentTeam.Clear();

                    for (int j = IndexOfNextTeam; j < Entrants.Count; j++)
                    {
                        if (Entrants[j].GetManufacturer() == TeamNames[t] && Entrants[j].GetIsFullTime())
                        {
                            CurrentTeam.Add(Entrants[j]);
                        }

                        if (t != TeamNames.Count - 1)
                        {
                            if (Entrants[j].GetManufacturer() == TeamNames[t + 1] && !NextTeamFound)
                            {
                                IndexOfNextTeam = j;
                                break;
                            }
                        }
                    }

                    PointSort(CurrentTeam);

                    if (CurrentTeam.Count > 1)
                    {
                        CurrentTeam[0].SetPoints(CurrentTeam[0].GetPoints() + CurrentTeam[1].GetPoints());
                    }

                    Teams.Add(CurrentTeam[0]);
                }

                StandingsFilePath = Path.Combine(CD.GetStandingsLocation(), "Manufacturers", "Class " + ClassIndex + ".csv");

                WriteManufacturersStandings(Teams, StandingsFilePath);
            }
        }

        public void LoadPointsSystem(string Session)
        {
            if (Session == "Qualifying")
            {
                FilePath = Path.Combine(PointsSystemFilePath, "Qualifying Systems", "System " + CurrentRound.GetPointsSystem() + ".csv");
            }

            else
            {
                FilePath = Path.Combine(PointsSystemFilePath, "Race Systems", "System " + CurrentRound.GetPointsSystem() + ".csv");
            }

            string[] Data = File.ReadAllLines(FilePath);

            PointsSystem.Clear();

            foreach (string DP in Data)
            {
                PointsSystem.Add(Convert.ToInt32(DP));
            }
        }

        public static List<int> LoadPointsSystem(string Session, CommonData CD, Round CurrentRound)
        {
            List<int> PointsSystem = new List<int>();
            string FilePath = "";

            if (Session == "Qualifying")
            {
                FilePath = Path.Combine(CD.GetPointsSystemsLocation(), "Qualifying Systems", "System " + CurrentRound.GetPointsSystem() + ".csv");
            }

            else
            {
                FilePath = Path.Combine(CD.GetPointsSystemsLocation(), "Race Systems", "System " + CurrentRound.GetPointsSystem() + ".csv");
            }

            string[] Data = ReadFile(FilePath, CD);

            PointsSystem.Clear();

            foreach (string DP in Data)
            {
                PointsSystem.Add(Convert.ToInt32(DP));
            }

            return PointsSystem;
        }

        public (List<Entrant>, int) SplitToList(List<Class> Classes, int Index, List<Entrant> EntryList, int IndexOfNextClass)
        {
            List<Entrant> Entrants = new List<Entrant>();
            bool NextClassFound = false, FindNextClass = true;

            if (Index + 1 >= Classes.Count)
            {
                FindNextClass = false;
            }

            for (int j = IndexOfNextClass; j < EntryList.Count; j++)
            {
                if (EntryList[j].GetClass() == Classes[Index].GetClassName())
                {
                    Entrants.Add(EntryList[j]);
                }

                else if (FindNextClass)
                {
                    if (EntryList[j].GetClass() == Classes[Index + 1].GetClassName() && !NextClassFound)
                    {
                        IndexOfNextClass = j;
                        NextClassFound = true;
                        FindNextClass = false;
                    }
                }
            }

            return (Entrants, IndexOfNextClass);
        }

        public void IndexSort(List<Entrant> Entrants)
        {
            for (int i = 0; i < Entrants.Count - 1; i++)
            {
                bool Swap = false;

                for (int j = 0; j < Entrants.Count - i - 1; j++)
                {
                    if (Entrants[j].GetIndex() > Entrants[j + 1].GetIndex())
                    {
                        Swap = true;

                        (Entrants[j], Entrants[j + 1]) = (Entrants[j + 1], Entrants[j]);
                    }
                }

                if (!Swap)
                {
                    break;
                }
            }
        }

        private void ClassIndexSort(List<Entrant> EntryList)
        {
            for (int i = 0; i < EntryList.Count - 1; i++)
            {
                bool Swap = false;

                for (int j = 0; j < EntryList.Count - i - 1; j++)
                {
                    if (EntryList[j].GetClassIndex() > EntryList[j + 1].GetClassIndex())
                    {
                        Swap = true;

                        (EntryList[j], EntryList[j + 1]) = (EntryList[j + 1], EntryList[j]);
                    }
                }

                if (!Swap)
                {
                    break;
                }
            }
        }

        public void PointSort(List<Entrant> Entrants)
        {
            for (int i = 0; i < Entrants.Count - 1; i++)
            {
                bool Swap = false;

                for (int j = 0; j < Entrants.Count - i - 1; j++)
                {
                    if (Entrants[j].GetPoints() < Entrants[j + 1].GetPoints())
                    {
                        Swap = true;

                        (Entrants[j], Entrants[j + 1]) = (Entrants[j + 1], Entrants[j]);
                    }
                }

                if (!Swap)
                {
                    break;
                }
            }
        }

        public void WriteCrewStandings(List<Entrant> Entrants, string FilePath)
        {
            string[] Data = ReadFile(FilePath, CD);

            string WriteString = "";

            for (int j = 0; j < Data.Length; j++)
            {
                if (EntrantExistsInEntrants(Data[j].Split(',')[1], Entrants))
                {
                    if (j != 0)
                    {
                        WriteString += Environment.NewLine;
                    }

                    WriteString += Entrants[j].GetClass() + "," + Entrants[j].GetCarNo() + "," + Entrants[j].GetTeamName() + "," + Entrants[j].GetCar() + "," + (Entrants[j].GetPoints() + Convert.ToInt32(Data[j].Split(',')[4]));
                }

                else
                {
                    if (j != 0)
                    {
                        WriteString += Environment.NewLine;
                    }

                    WriteString += Data[j];
                }
            }

            Save.WriteFile(FilePath, WriteString);
        }

        public void WriteTeamsStandings(List<Entrant> Entrants, string FilePath)
        {
            string[] Data = ReadFile(FilePath, CD);

            string WriteString = "";

            for (int j = 0; j < Data.Length; j++)
            {
                if (TeamExistsInEntrants(Data[j].Split(',')[1], Entrants))
                {
                    if (j != 0)
                    {
                        WriteString += Environment.NewLine;
                    }

                    WriteString += Entrants[j].GetClass() + "," + Entrants[j].GetTeamName() + "," + (Entrants[j].GetPoints() + Convert.ToInt32(Data[j].Split(',')[2]));
                }

                else
                {
                    if (j != 0)
                    {
                        WriteString += Environment.NewLine;
                    }

                    WriteString += Data[j];
                }
            }

            Save.WriteFile(FilePath, WriteString);
        }

        public void WriteManufacturersStandings(List<Entrant> Entrants, string FilePath)
        {
            string[] Data = ReadFile(FilePath, CD);

            string WriteString = "";

            for (int j = 0; j < Data.Length; j++)
            {
                if (ManufacturerExistsInEntrants(Data[j].Split(',')[1], Entrants))
                {
                    if (j != 0)
                    {
                        WriteString += Environment.NewLine;
                    }

                    WriteString += Entrants[j].GetClass() + "," + Entrants[j].GetManufacturer() + "," + (Entrants[j].GetPoints() + Convert.ToInt32(Data[j].Split(',')[2]));
                }

                else
                {
                    if (j != 0)
                    {
                        WriteString += Environment.NewLine;
                    }

                    WriteString += Data[j];
                }
            }

            Save.WriteFile(FilePath, WriteString);
        }

        public bool EntrantExistsInEntrants(string Crew, List<Entrant> Entrants)
        {
            bool Exists = false;

            foreach (Entrant E in Entrants)
            {
                if (E.GetCarNo() == Crew)
                {
                    Exists = true;
                    break;
                }
            }

            return Exists;
        }

        public bool TeamExistsInEntrants(string Crew, List<Entrant> Entrants)
        {
            bool Exists = false;

            foreach (Entrant E in Entrants)
            {
                if (E.GetTeamName() == Crew)
                {
                    Exists = true;
                    break;
                }
            }

            return Exists;
        }

        public bool ManufacturerExistsInEntrants(string Crew, List<Entrant> Entrants)
        {
            bool Exists = false;

            foreach (Entrant E in Entrants)
            {
                if (E.GetManufacturer() == Crew)
                {
                    Exists = true;
                    break;
                }
            }

            return Exists;
        }

        public List<string> GetTeamNames(int ClassIndex)
        {
            string FP = Path.Combine(CD.GetStandingsLocation(), "Teams", "Class " + ClassIndex + ".csv");

            string[] Data = ReadFile(FP, CD);

            List<string> Names = new List<string>();

            foreach (string DP in Data)
            {
                Names.Add(DP.Split(',')[1]);
            }

            return Names;
        }

        public List<string> GetManufacturers(int ClassIndex)
        {
            string FP = Path.Combine(CD.GetStandingsLocation(), "Manufacturers", "Class " + ClassIndex + ".csv");

            string[] Data = ReadFile(FP, CD);

            List<string> Names = new List<string>();

            foreach (string DP in Data)
            {
                Names.Add(DP.Split(',')[1]);
            }

            return Names;
        }

        public bool CanDoAutoStandings(string Session, string PointsSystem)
        {
            string CheckFile = Path.Combine(PointsSystemFilePath, Session + " Systems", "System " + PointsSystem + ".csv");

            if (File.Exists(CheckFile))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static string[] ReadFile(string FP, CommonData CD)
        {
            try
            {
                return File.ReadAllLines(FP);
            }

            catch
            {
                CalendarEditor.UseMessageBox("Please Close File '" + FP.Replace(CD.GetStandingsLocation(), "") + "'.!", "File Open");
                return ReadFile(FP, CD);
            }
        }
    }
}
