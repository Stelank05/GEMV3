using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GEM_Code_V3
{
    public class CarMaker
    {
        CommonData CD = new CommonData();

        List<string> ClassNames;

        public CarMaker()
        {
            ClassNames = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                ClassNames.Add("Class " + (i + 1));
            }
        }

        public void WriteCar(string CarData, int ClassNumber)
        {
            string FilePath = Path.Combine(CD.GetSetupPath(), "Entrants", "Class " + ClassNumber + ".csv");

            int UsedLines = File.ReadAllLines(FilePath).Length;
            string[] Data = File.ReadAllLines(FilePath);

            if (UsedLines == 1)
            {
                if (Data[0] == "")
                {
                    File.WriteAllText(FilePath, CarData);
                }

                else
                {
                    File.AppendAllText(FilePath, CarData);
                }
            }

            else
            {
                File.AppendAllText(FilePath, CarData);
            }
        }

        public bool Valid(string FilePath)
        {
            bool IsValid = true;

            try
            {
                File.ReadAllLines(FilePath);
            }
            catch
            {
                IsValid = false;
            }

            return IsValid;
        }

        public bool CheckNumber(string Number)
        {
            bool Unique = true;

            bool bN = int.TryParse(Number, out int iN);

            if (bN)
            {
                string checkNumber = "#" + Number;

                for (int FC = 0; FC < ClassNames.Count(); FC++)
                {
                    string FilePath = Path.Combine(CD.GetSetupPath(), "Entrants", ClassNames[FC] + ".csv");

                    string[] UsedNumbers = File.ReadAllLines(FilePath);

                    int TotalUsed = File.ReadAllLines(FilePath).Length;

                    if (TotalUsed > 0)
                    {
                        for (int i = 0; i < TotalUsed; i++)
                        {
                            if (UsedNumbers[i] != "")
                            {
                                string[] CarNumber = UsedNumbers[i].Split(',');

                                if (CarNumber[1] == checkNumber)
                                {
                                    Unique = false;
                                    break;
                                }
                            }
                        }
                    }

                    else
                    {
                        break;
                    }
                }
            }

            else
            {
                Unique = false;
            }

            return Unique;
        }

        public bool CheckStat(string Stat)
        {
            bool bStat = int.TryParse(Stat, out int iStat);

            if (bStat)
            {
                if (iStat < 1 || iStat > 100)
                {
                    bStat = false;
                }
            }

            return bStat;
        }

        public bool CheckSRM(string Stat)
        {
            bool bStat = int.TryParse(Stat, out int iStat);

            if (bStat)
            {
                if (iStat < -5 || iStat > 5)
                {
                    bStat = false;
                }
            }

            return bStat;
        }

        public bool CheckCrewReliability(string Stat)
        {
            bool bStat = int.TryParse(Stat, out int iStat);

            if (bStat)
            {
                if (iStat < 20 || iStat > 30)
                {
                    bStat = false;
                }
            }

            return bStat;
        }
    }
}
