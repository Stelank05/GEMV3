using System;
using System.Collections.Generic;
using System.IO;

namespace GEM_Code_V3
{
    public class RaceAdmin
    {
        CommonData CD = new CommonData();

        public List<Round> GetCalendar()
        {
            List<Round> Calendar = new List<Round>();

            string FileName = Path.Combine(CD.GetSetupPath(), "Calendar.csv");

            try
            {
                string[] iCD = File.ReadAllLines(FileName);
                int iRD = 0;

                Round TempRound;

                List<string> Racing = new List<string>();

                foreach (string RoundData in iCD)
                {
                    if (iRD == 0)
                    {
                        iRD++;
                    }

                    else
                    {
                        string[] sRD = RoundData.Split(',');

                        for (int i = 14; i < 21; i++)
                        {
                            if (sRD[i] != " " || sRD[i] != "")
                            {
                                Racing.Add(sRD[i]);

                                try
                                {
                                    if (sRD[i + 1] == " " || sRD[i + 1] == "")
                                    {
                                        break;
                                    }
                                }

                                catch
                                {
                                    break;
                                }
                            }

                            else
                            {
                                break;
                            }
                        }

                        TempRound = new Round(sRD[0], Convert.ToInt32(sRD[1]), sRD[5], Convert.ToInt32(sRD[2]), Convert.ToInt32(sRD[3]), Convert.ToInt32(sRD[7]), sRD[10], sRD[9], Convert.ToBoolean(sRD[12]), Racing, CD);

                        Racing.Clear();

                        Calendar.Add(TempRound);

                        iRD++;
                    }
                }

                return Calendar;
            }

            catch
            {
                CalendarEditor.UseMessageBox("Please Close the Calendar.csv File to Continue.", "Calendar File Open");
                return GetCalendar();
            }
        }

        public List<Car> LoadCars(string FilePath)
        {
            string[] CarData = File.ReadAllLines(FilePath);

            List<Car> CarList = new List<Car>();

            foreach (string CarDataPiece in CarData)
            {
                string[] FormattedDataPiece = CarDataPiece.Split(',');

                CarList.Add(new Car(FormattedDataPiece[0], FormattedDataPiece[1], FormattedDataPiece[2], Convert.ToInt32(FormattedDataPiece[3]), Convert.ToInt32(FormattedDataPiece[4]), Convert.ToInt32(FormattedDataPiece[6])));
            }

            return CarList;
        }

        public void LoadEntrants(List<Entrant> EntryList, string FilePathInc, Round RoundInQuestion, CommonData tCD)
        {
            List<string> Classes = RoundInQuestion.GetLongRacingClasses();

            Entrant CarEntrant;

            string FilePath;

            int CI = 0, Index = 0;

            foreach (string Class in Classes)
            {
                FilePath = Path.Combine(FilePathInc, Class + ".csv");

                string[] Cars = File.ReadAllLines(FilePath);

                int C = Convert.ToInt32(Classes[CI].Replace("Class ", "")) - 1;

                if (Cars.Length == 1)
                {
                    if (Cars[0] != "")
                    {
                        foreach (string Car in Cars)
                        {
                            string[] CarData = Car.Split(',');

                            CarEntrant = new Entrant(CarData[0], CarData[1], CarData[2], CarData[3], CarData[4], Convert.ToInt32(CarData[5]), Convert.ToInt32(CarData[7]), Convert.ToInt32(CarData[9]), Index, Convert.ToBoolean(CarData[11]), tCD.GetClasses(C), RoundInQuestion); Index++;

                            EntryList.Add(CarEntrant);
                        }
                    }
                }

                else
                {
                    foreach (string Car in Cars)
                    {
                        string[] CarData = Car.Split(',');

                        CarEntrant = new Entrant(CarData[0], CarData[1], CarData[2], CarData[3], CarData[4], Convert.ToInt32(CarData[5]), Convert.ToInt32(CarData[7]), Convert.ToInt32(CarData[9]), Index, Convert.ToBoolean(CarData[11]), tCD.GetClasses(C), RoundInQuestion); Index++;

                        EntryList.Add(CarEntrant);
                    }
                }

                CI++;
            }
        }

        public List<Entrant> LoadEntrants(string FilePath, int Index)
        {
            List<Entrant> EntryList = new List<Entrant>();
            Entrant CarEntrant;

            List<string> Classes = new List<string>() { "C1" };

            Round RoundInQuestion = new Round("PL", 1, "WEC", 1, 1, 1, "A", "N", false, Classes, CD);

            try
            {
                string[] Cars = File.ReadAllLines(FilePath);

                if (Cars.Length == 1)
                {
                    if (Cars[0] != "")
                    {
                        foreach (string Car in Cars)
                        {
                            string[] CarData = Car.Split(',');

                            CarEntrant = new Entrant(CarData[0], CarData[1], CarData[2], CarData[3], CarData[4], Convert.ToInt32(CarData[5]), Convert.ToInt32(CarData[7]), Convert.ToInt32(CarData[9]), 1, Convert.ToBoolean(CarData[11]), CD.GetClasses(Index), RoundInQuestion);

                            EntryList.Add(CarEntrant);
                        }
                    }
                }

                else
                {
                    foreach (string Car in Cars)
                    {
                        string[] CarData = Car.Split(',');

                        CarEntrant = new Entrant(CarData[0], CarData[1], CarData[2], CarData[3], CarData[4], Convert.ToInt32(CarData[5]), Convert.ToInt32(CarData[7]), Convert.ToInt32(CarData[9]), 1, Convert.ToBoolean(CarData[11]), CD.GetClasses(Index), RoundInQuestion);

                        EntryList.Add(CarEntrant);
                    }
                }

                return EntryList;
            }

            catch
            {
                CalendarEditor.UseMessageBox("The Required File is Currently Open, please Close It to Continue.", "File Already Open");
                return LoadEntrants(FilePath, Index);
            }
        }

        public bool ClassExistsInEntrants(string Item, List<Entrant> List)
        {
            bool Exists = false;

            foreach (Entrant SI in List)
            {
                if (Item == SI.GetClass())
                {
                    Exists = true;
                    break;
                }
            }

            return Exists;
        }

        public bool EntrantExistsInEntrants(Entrant ED, List<Entrant> List)
        {
            bool Exists = false;

            foreach (Entrant SI in List)
            {
                if (SI == ED)
                {
                    Exists = true;
                    break;
                }
            }

            return Exists;
        }

        public void IndexSort(List<Entrant> Entrants)
        {
            Entrant TempEntrant;

            for (int i = 0; i < Entrants.Count - 1; i++)
            {
                bool Swap = false;

                for (int j = 0; j < Entrants.Count - i - 1; j++)
                {
                    if (Entrants[j].GetClassIndex() > Entrants[j + 1].GetClassIndex())
                    {
                        Swap = true;

                        TempEntrant = Entrants[j];
                        Entrants[j] = Entrants[j + 1];
                        Entrants[j + 1] = TempEntrant;
                    }
                }

                if (!Swap)
                {
                    break;
                }
            }
        }
    }
}
