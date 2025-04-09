using System;

namespace GEM_Code_V3
{
    public class Entrant
    {
        string Class, CarNo, TeamName, Car, Manufacturer;
        int OVR, OVRa, Reliability, DNF, SRModifier, ClassIndex, LastStint, StintsInGarage, TotalStintsInGarage, TotalStaysInGarage, Points, Index, StintsSincePit = 0, TotalStops;
        bool InGarage = false, FullTimeEntry, ExtendedGarageStay = false;

        public Entrant(string C, string CN, string TN, string Ca, string M, int OVRi, int SRM, int R, int I, bool FTE, Class EntrantClass, Round RoundData)
        {
            Class = C;
            CarNo = CN;
            TeamName = TN;
            Car = Ca;
            Manufacturer = M;
            OVR = OVRi;
            OVRa = OVRi;
            SRModifier = SRM;
            FullTimeEntry = FTE;
            Reliability = R + EntrantClass.GetIRM() - RoundData.GetDefaultIncidentRate();
            DNF = RoundData.GetDefaultDNFRate() + EntrantClass.GetDNFRM();
            ClassIndex = EntrantClass.GetClassIndex();
            Index = I;
        }

        public string GetClass()
        {
            return Class;
        }

        public string GetCarNo()
        {
            return CarNo;
        }

        public string GetTeamName()
        {
            return TeamName;
        }

        public string GetCrew()
        {
            return CarNo + " " + TeamName;
        }

        public string GetCar()
        {
            return Car;
        }

        public string GetManufacturer()
        {
            return Manufacturer;
        }

        public string GetCarAsWriteString()
        {
            return CarNo + " " + TeamName + "," + Car + ",," + OVR;
        }

        public void AddToOVR(int AddValue)
        {
            OVR += AddValue;
        }

        public void SetGridOVR(int GridSpacing)
        {
            OVR = OVRa + GridSpacing;
        }

        public void UpdateOVR(int NewOVR)
        {
            OVR = NewOVR;
        }

        public void SetBaseOVR()
        {
            OVR = OVRa;
        }

        public int GetOVR()
        {
            return OVR;
        }

        public int GetBaseOVR()
        {
            return OVRa;
        }

        public int GetSRM()
        {
            return SRModifier;
        }

        public int GetReliability()
        {
            return Reliability;
        }

        public int GetDNF()
        {
            return DNF;
        }

        public int GetClassIndex()
        {
            return ClassIndex;
        }

        public void SetLastStint(int Stint)
        {
            LastStint = Stint;
        }

        public int GetLastStint()
        {
            return LastStint;
        }

        public bool GetInGarage()
        {
            return InGarage;
        }

        public void EnterGarage(Random Rand)
        {
            InGarage = true;

            StintsInGarage++;
            TotalStintsInGarage++;
            StintsSincePit = 0;
            TotalStaysInGarage++;

            Pit();

            if (Rand.Next(1, 11) == 1)
            {
                ExtendedGarageStay = true;
            }
        }

        public void LeaveGarage()
        {
            InGarage = false;
            StintsInGarage = 0;
        }

        public void StintInGarage()
        {
            StintsInGarage++;
            TotalStintsInGarage++;
        }

        public int GetStintsInGarage()
        {
            return StintsInGarage;
        }

        public int GetTotalStintsInGarage()
        {
            return TotalStintsInGarage;
        }

        public void SetPoints(int PTS)
        {
            Points = PTS;
        }

        public int GetPoints()
        {
            return Points;
        }

        public int GetIndex()
        {
            return Index;
        }

        public bool GetIsFullTime()
        {
            return FullTimeEntry;
        }

        public void Pit()
        {
            StintsSincePit = 0;
            TotalStops++;
        }

        public void NotPit()
        {
            StintsSincePit++;
        }

        public int GetStintsSincePit()
        {
            return StintsSincePit;
        }

        public int GetTotalStops()
        {
            return TotalStops;
        }

        public bool GetExtendedGarageStay()
        {
            return ExtendedGarageStay;
        }

        public int GetTotalStaysInGarage()
        {
            return TotalStaysInGarage;
        }
    }
}
