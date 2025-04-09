using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public class CommonData
    {
        string FilePath = @"", FolderName, SetupLocation, EntrantsLocation, PointsSystemLocation, StandingsLocation, SeasonNo, SavePath;
        int RoundNo, Rows;
        int QualiFormatBLoss, QualiFormatCR2Count, QualiFormatCR3Count, QualiFormatEGuaranteed, QualiFormatECutOff;
        bool AutoStandings;

        List<string> WECDistances = new List<string>(),
            IMSADistances = new List<string>(),
            LapDistances = new List<string>();

        List<int> WEC_LeaveGarageValues = new List<int>(), WEC_EnterGarageValues = new List<int>(),
            IMSA_LeaveGarageValues = new List<int>(), IMSA_EnterGarageValues = new List<int>(),
            Laps_LeaveGarageValues = new List<int>(), Laps_EnterGarageValues = new List<int>();

        List<Class> Classes = new List<Class>();

        public CommonData()
        {
            Setup();
            LoadQualiFormatData();
            LoadClasses();
            LoadClassGarageValues();
        }

        public void Setup()
        {
            List<string> Paths = new List<string>();

            try
            {
                string[] FPs = File.ReadAllLines("V3 Setup File.csv");

                foreach (string FP in FPs)
                {
                    Paths.Add(FP.Split(',')[1]);
                }

                FilePath = @Paths[0];
                FolderName = Paths[1];
                SetupLocation = Paths[2];
                EntrantsLocation = Paths[3];
                PointsSystemLocation = Paths[4];
                StandingsLocation = Paths[5];
                SeasonNo = Paths[6];
                AutoStandings = Convert.ToBoolean(Paths[7]);
                Rows = Convert.ToInt32(Paths[8]);
            }

            catch
            {
                MessageBox.Show("Please Close 'V3 Setup File.csv'", "File Already Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Setup();
            }
        }

        public void LoadQualiFormatData()
        {
            List<int> Paths = new List<int>();

            try
            {
                string[] FPs = File.ReadAllLines("Qualifying Format Data.csv");

                foreach (string FP in FPs)
                {
                    Paths.Add(Convert.ToInt32(FP.Split(',')[1]));
                }

                QualiFormatBLoss = Paths[0];
                QualiFormatCR2Count = Paths[1];
                QualiFormatCR3Count = Paths[2];
                QualiFormatEGuaranteed = Paths[3];
                QualiFormatECutOff = Paths[4];
            }

            catch
            {
                MessageBox.Show("Please Close 'Qualifying Format Data.csv'", "File Already Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQualiFormatData();
            }
        }

        public void LoadGarageValues()
        {
            List<string> FileNames = new List<string> { "Enter Garage Values.csv", "Exit Garage Values.csv" };
            List<string> Lengths = new List<string> { "WEC", "IMSA", "Laps" };

            foreach (string Length in Lengths)
            {
                foreach (string FN in FileNames)
                {
                    try
                    {
                        string[] Data = File.ReadAllLines(Path.Combine(GetSetupPath(), "Garage Values", Length, FN));

                        List<int> MungedData = new List<int>();

                        foreach (string DataPiece in Data)
                        {
                            MungedData.Add(Convert.ToInt32(DataPiece.Split(',')[1]));
                        }

                        if (FN.StartsWith("Enter"))
                        {
                            if (Length == "WEC")
                            {
                                WEC_EnterGarageValues = MungedData;
                            }

                            else if (Length == "IMSA")
                            {
                                IMSA_EnterGarageValues = MungedData;
                            }

                            else if (Length == "Laps")
                            {
                                Laps_EnterGarageValues = MungedData;
                            }
                        }

                        else
                        {
                            if (Length == "WEC")
                            {
                                WEC_LeaveGarageValues = MungedData;
                            }

                            else if (Length == "IMSA")
                            {
                                IMSA_LeaveGarageValues = MungedData;
                            }

                            else if (Length == "Laps")
                            {
                                Laps_LeaveGarageValues = MungedData;
                            }
                        }
                    }

                    catch
                    {
                        CalendarEditor.UseMessageBox("Please Close '" + Path.Combine("Garage Values", Length, FN) + ".csv'.", "File Open");
                    }
                }
            }
        }

        public void LoadClassGarageValues()
        {
            try
            {
                string[] Data = File.ReadAllLines(Path.Combine(GetSetupPath(), "Time Lost In Garage.csv"));

                for (int i = 1; i < 9; i++)
                {
                    string[] ClassData = Data[i].Split(',');

                    if (i <= Classes.Count)
                    {
                        Classes[i - 1].SetWECGarageValues(Convert.ToInt32(ClassData[3]), Convert.ToInt32(ClassData[4]), Convert.ToInt32(ClassData[5]));
                        Classes[i - 1].SetIMSAGarageValues(Convert.ToInt32(ClassData[7]), Convert.ToInt32(ClassData[8]), Convert.ToInt32(ClassData[9]));
                        Classes[i - 1].SetLapGarageValues(Convert.ToInt32(ClassData[11]), Convert.ToInt32(ClassData[12]), Convert.ToInt32(ClassData[13]));
                    }
                }
            }

            catch
            {
                CalendarEditor.UseMessageBox("Please Close 'Time Lost In Garage.csv' File.", "File Open");
                LoadClassGarageValues();
            }
        }

        public void LoadClasses()
        {
            Classes.Clear();

            string FileName = Path.Combine(FilePath, FolderName, SetupLocation, "Class Setup.csv");

            string[] CD = File.ReadAllLines(FileName);

            Class TempClass;

            int Index = 0;

            foreach (string RoundData in CD)
            {
                string[] CDs = RoundData.Split(',');

                if (CDs[1] == "")
                {
                    break;
                }

                else if (CDs[0] == "Arbitrary")
                {
                    continue;
                }

                else
                {
                    TempClass = new Class(CDs[1], Convert.ToInt32(CDs[2]), Convert.ToInt32(CDs[3]), Convert.ToInt32(CDs[5]), Convert.ToInt32(CDs[6]), Convert.ToInt32(CDs[7]), Index, Convert.ToInt32(CDs[9]), Convert.ToInt32(CDs[10]), Convert.ToInt32(CDs[12]), Convert.ToInt32(CDs[13]), Convert.ToInt32(CDs[14]));
                    Classes.Add(TempClass);

                    Index++;
                }
            }
        }

        public Class GetClasses(int I)
        {
            return Classes[I];
        }

        public int GetClassIndex(string ClassName)
        {
            int Index = 0;

            for (int i = 0; i < Classes.Count; i++)
            {
                if (Classes[i].GetClassName() == ClassName)
                {
                    Index = i + 1;
                    break;
                }
            }

            return Index;
        }

        public int GetClassCount()
        {
            return Classes.Count;
        }

        public void LoadDistances()
        {
            string[] sWECDistances = File.ReadAllLines(Path.Combine(FilePath, FolderName, SetupLocation, "WEC Distances.csv"));

            foreach (string sWEC in sWECDistances)
            {
                WECDistances.Add(sWEC);
            }

            string[] sIMSADistances = File.ReadAllLines(Path.Combine(FilePath, FolderName, SetupLocation, "IMSA Distances.csv"));

            foreach (string sIMSA in sIMSADistances)
            {
                IMSADistances.Add(sIMSA);
            }

            string[] sLapDistances = File.ReadAllLines(Path.Combine(FilePath, FolderName, SetupLocation, "Lap Distances.csv"));

            foreach (string sLap in sLapDistances)
            {
                LapDistances.Add(sLap);
            }
        }

        public void SetRoundNo(int RN)
        {
            RoundNo = RN;
        }

        public int GetRoundNo()
        {
            return RoundNo;
        }

        public string GetFilePath()
        {
            return Path.Combine(FilePath, FolderName);
        }

        public string SetSavePath(bool Test, string RoundName, int RN)
        {
            if (Test)
            {
                SavePath =  Path.Combine(FilePath, FolderName, "Results", SeasonNo, "Test Session - " + RoundName);
            }

            else
            {
                SavePath =  Path.Combine(FilePath, FolderName, "Results", SeasonNo, "Round " + (RN) + " - " + RoundName);
            }

            return SavePath;
        }

        public string GetSavePath()
        {
            return SavePath;
        }

        public string GetSetupPath()
        {
            return Path.Combine(FilePath, FolderName, SetupLocation);
        }

        public string GetEntrantsLocation()
        {
            return Path.Combine(GetSetupPath(), EntrantsLocation);
        }

        public string GetPointsSystemsLocation()
        {
            return Path.Combine(GetSetupPath(), PointsSystemLocation);
        }

        public string GetStandingsLocation()
        {
            return Path.Combine(FilePath, FolderName, StandingsLocation);
        }

        public string GetWECDistance(int Stint)
        {
            return WECDistances[Stint - 1];
        }

        public string GetIMSADistance(int Stint)
        {
            return IMSADistances[Stint - 1];
        }

        public string GetLapsDistance(int Stint)
        {
            return LapDistances[Stint - 1];
        }

        public bool DoAutoStandings()
        {
            return AutoStandings;
        }

        public int GetRows()
        {
            return Rows;
        }

        public int GetQualiFormatBLoss()
        {
            return QualiFormatBLoss;
        }

        public int GetQualiFormatCR2Count()
        {
            return QualiFormatCR2Count;
        }

        public int GetQualiFormatCR3Count()
        {
            return QualiFormatCR3Count;
        }

        public int GetQualiFormatEGuaranteed()
        {
            return QualiFormatEGuaranteed;
        }

        public int GetQualiFormatECutOff()
        {
            return QualiFormatECutOff;
        }

        public int GetEnterGarageValue(string LengthType, int Stint)
        {
            if (LengthType == "WEC")
            {
                return WEC_EnterGarageValues[Stint];
            }

            else if (LengthType == "IMSA")
            {
                return IMSA_EnterGarageValues[Stint];
            }

            else
            {
                return Laps_EnterGarageValues[Stint];
            }
        }

        public int GetLeaveGarageValue(string LengthType, int Stint)
        {
            if (LengthType == "WEC")
            {
                return WEC_LeaveGarageValues[Stint];
            }

            else if (LengthType == "IMSA")
            {
                return IMSA_LeaveGarageValues[Stint];
            }

            else
            {
                return Laps_LeaveGarageValues[Stint];
            }
        }
    }
}
