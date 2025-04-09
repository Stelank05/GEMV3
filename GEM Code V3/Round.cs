using System;
using System.Collections.Generic;

namespace GEM_Code_V3
{
    public class Round
    {
        string RoundName, LengthType, PointsSystem, QualiFormat;
        int RaceLength, IncidentRange, DNFRate, RoundNo;
        bool IsTest;

        List<string> ClassesShort = new List<string>(),
            ClassesLong = new List<string>(),
            StringClasses = new List<string>();
        List<bool> ClassesRacing = new List<bool>();

        CommonData CD;

        public Round(string RN, int RL, string LT, int IR, int DR, int RNo, string PS, string QF, bool T, List<string> RacingClasses, CommonData iCD)
        {
            RoundName = RN;
            RaceLength = RL;
            LengthType = LT;
            IncidentRange = IR;
            DNFRate = DR;
            RoundNo = RNo;
            PointsSystem = PS;
            QualiFormat = QF;
            IsTest = T;
            CD = iCD;

            LoadClasses(RacingClasses);
        }

        public void LoadClasses(List<string> RacingClasses)
        {
            ClassesShort.Clear();
            ClassesLong.Clear();
            ClassesRacing.Clear();

            for (int i = 0; i < RacingClasses.Count; i++)
            {
                if (RacingClasses[i].Contains(Convert.ToString(i + 1)))
                {
                    ClassesRacing.Add(true);
                }

                else
                {
                    ClassesRacing.Add(false);
                }

                ClassesShort.Add(RacingClasses[i]);
                ClassesLong.Add(RacingClasses[i].Replace("C", "Class "));

                StringClasses.Add(CD.GetClasses(Convert.ToInt32(RacingClasses[i].Replace("C", "")) - 1).GetClassName());
            }
        }

        public void SetRoundName(string RN)
        {
            RoundName = RN;
        }

        public string GetRoundName()
        {
            return RoundName;
        }

        public void SetLengthType(string LT)
        {
            LengthType = LT;
        }

        public string GetLengthType()
        {
            return LengthType;
        }

        public void SetRoundNo(int RN)
        {
            RoundNo = RN;
        }

        public int GetRoundNo()
        {
            return RoundNo;
        }

        public void SetRacingClasses(List<string> RC)
        {
            ClassesShort = RC;
        }

        public List<string> GetLongRacingClasses()
        {
            return ClassesLong;
        }

        public List<string> GetShortRacingClasses()
        {
            return ClassesShort;
        }

        public List<bool> GetBoolRacingClasses()
        {
            return ClassesRacing;
        }

        public void SetRaceLength(int RL)
        {
            RaceLength = RL;
        }

        public int GetRaceLength()
        {
            if (LengthType == "WEC")
            {
                return RaceLength * 2;
            }

            else
            {
                return RaceLength;
            }
        }

        public void SetIncidentRate(int IR)
        {
            IncidentRange = IR;
        }

        public int GetDefaultIncidentRate()
        {
            return IncidentRange;
        }

        public void SetDNFRate(int DR)
        {
            DNFRate = DR;
        }

        public int GetDefaultDNFRate()
        {
            return DNFRate;
        }

        public void SetPointsSystem(string PS)
        {
            PointsSystem = PS;
        }

        public string GetPointsSystem()
        {
            return PointsSystem;
        }

        public void SetQualiFormat(string QF)
        {
            QualiFormat = QF;
        }

        public string GetQualiFormat()
        {
            return QualiFormat;
        }

        public void SetIsTest(string Test)
        {
            IsTest = Convert.ToBoolean(Test);
        }

        public bool GetIsTest()
        {
            return IsTest;
        }
    }
}
