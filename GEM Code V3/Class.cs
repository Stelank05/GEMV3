namespace GEM_Code_V3
{
    public class Class
    {
        string ClassName;
        int IncidentRangeModifier, DNFRateModifier;
        int SRHigh, SRLow, SRInc;
        int ClassIndex;
        int MinOVR, MaxOVR;
        int WECDTP, IMSADTP, LapDTP;
        int WECMin, WECMax, WECGarage;
        int IMSAMin, IMSAMax, IMSAGarage;
        int LapMin, LapMax, LapGarage;

        public Class(string CN, int IRM, int DNF, int SRH, int SRL, int SRI, int CI, int Min, int Max, int WEC, int IMSA, int Lap)
        {
            ClassName = CN;
            IncidentRangeModifier = IRM;
            DNFRateModifier = DNF;
            SRHigh = SRH;
            SRLow = SRL;
            SRInc = SRI;
            ClassIndex = CI;
            MinOVR = Min;
            MaxOVR = Max;
            WECDTP = WEC;
            IMSADTP = IMSA;
            LapDTP = Lap;
        }

        public void SetClassName(string CN)
        {
            ClassName = CN;
        }

        public string GetClassName()
        {
            return ClassName;
        }

        public void SetIRM(int IRM)
        {
            IncidentRangeModifier = IRM;
        }

        public int GetIRM()
        {
            return IncidentRangeModifier;
        }

        public void SetDNFRM(int DNFRM)
        {
            DNFRateModifier = DNFRM;
        }

        public int GetDNFRM()
        {
            return DNFRateModifier;
        }

        public void SetClassIndex(int CI)
        {
            ClassIndex = CI;
        }

        public int GetClassIndex()
        {
            return ClassIndex;
        }

        public void SetSRLow(int SRL)
        {
            SRLow = SRL;
        }

        public int GetSRLow()
        {
            return SRLow;
        }

        public void SetSRHigh(int SRH)
        {
            SRHigh = SRH;
        }

        public int GetSRHigh()
        {
            return SRHigh;
        }

        public void SetSRInc(int SRI)
        {
            SRInc = SRI;
        }

        public int GetSRInc()
        {
            return SRInc;
        }

        public void SetMinOVR(int OVR)
        {
            MinOVR = OVR;
        }

        public int GetMinOVR()
        {
            return MinOVR;
        }

        public void SetMaxOVR(int OVR)
        {
            MaxOVR = OVR;
        }

        public int GetMaxOVR()
        {
            return MaxOVR;
        }

        public void SetWECDTP(int DTP)
        {
            WECDTP = DTP;
        }

        public int GetWECDTP()
        {
            return WECDTP;
        }

        public void SetIMSADTP(int DTP)
        {
            IMSADTP = DTP;
        }

        public int GetIMSADTP()
        {
            return IMSADTP;
        }

        public void SetLapDTP(int DTP)
        {
            LapDTP = DTP;
        }

        public int GetLapDTP()
        {
            return LapDTP;
        }

        public void SetWECGarageValues(int V1, int V2, int V3)
        {
            WECMin = V1;
            WECMax = V2;
            WECGarage = V3;
        }

        public (int, int, int) GetWECGarageValues()
        {
            return (WECMin, WECMax, WECGarage);
        }

        public void SetIMSAGarageValues(int V1, int V2, int V3)
        {
            IMSAMin = V1;
            IMSAMax = V2;
            IMSAGarage = V3;
        }

        public (int, int, int) GetIMSAGarageValues()
        {
            return (IMSAMin, IMSAMax, IMSAGarage);
        }

        public void SetLapGarageValues(int V1, int V2, int V3)
        {
            LapMin = V1;
            LapMax = V2;
            LapGarage = V3;
        }

        public (int, int, int) GetLapGarageValues()
        {
            return (LapMin, LapMax, LapGarage);
        }
    }
}
