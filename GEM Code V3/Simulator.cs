using System;
using System.Collections.Generic;

namespace GEM_Code_V3
{
    public class Simulator
    {
        CommonData CD;
        Random Rand;
        Round CurrentRound;

        public Simulator(CommonData iCD, Random iRand, Round iRound)
        {
            CD = iCD;
            Rand = iRand;
            CurrentRound = iRound;
        }

        public void Qualifying(List<Entrant> EntryList, int ECount)
        {
            int StintScore;

            for (int E = 0; E < ECount; E++)
            {
                StintScore = QualiStint(EntryList[E]);

                if (EntryList[E].GetBaseOVR() + StintScore > EntryList[E].GetOVR())
                {
                    EntryList[E].UpdateOVR(EntryList[E].GetBaseOVR() + StintScore);
                    EntryList[E].SetLastStint(StintScore);
                }
            }

            Sort(EntryList, ECount);
        }

        public void Qualifying(List<Entrant> EntryList, int Start, int End)
        {
            int StintScore;

            for (int E = Start; E < End; E++)
            {
                StintScore = QualiStint(EntryList[E]);

                if (EntryList[E].GetBaseOVR() + StintScore > EntryList[E].GetOVR())
                {
                    EntryList[E].UpdateOVR(EntryList[E].GetBaseOVR() + StintScore);
                    EntryList[E].SetLastStint(StintScore);
                }
            }

            Sort(EntryList, 0, End);
        }

        public List<HyperPole> HyperPole(List<HyperPole> HPE)
        {
            foreach (HyperPole THP in HPE)
            {
                int StintScore;

                for (int i = 0; i < THP.GetLength(); i++)
                {
                    StintScore = QualiStint(THP.GetEntrant(i));

                    if (THP.GetEntrant(i).GetBaseOVR() + StintScore > THP.GetEntrant(i).GetOVR())
                    {
                        THP.GetEntrant(i).UpdateOVR(THP.GetEntrant(i).GetBaseOVR() + StintScore);
                        THP.GetEntrant(i).SetLastStint(StintScore);
                    }
                }

                THP.Sort();
            }

            return HPE;
        }

        public int QualiStint(Entrant EntrantData)
        {
            int StintScore, Incident;
            int IL = 1, DNF = EntrantData.GetDNF();

            StintScore = Rand.Next(CD.GetClasses(EntrantData.GetClassIndex()).GetSRLow(), CD.GetClasses(EntrantData.GetClassIndex()).GetSRHigh() + EntrantData.GetSRM());
            Incident = Rand.Next(IL, EntrantData.GetReliability());

            if (Incident < DNF)
            {
                if (Incident == 1)
                {
                    StintScore = 5;
                }

                else
                {
                    StintScore -= CD.GetClasses(EntrantData.GetClassIndex()).GetSRInc();
                }
            }

            return StintScore;
        }

        public void Race(List<Entrant> EntryList, int StintNo)
        {
            int StintScore, PitScore = 0;

            foreach (Entrant E in EntryList)
            {
                if (E.GetOVR() == 1)
                {
                    break;
                }

                else if (E.GetInGarage())
                {
                    if (ShouldRetire(E, StintNo))
                    {
                        E.UpdateOVR(1);
                    }

                    else
                    {
                        bool LeaveGarage = ShouldLeaveGarage(E, StintNo);
                        StintScore = RaceStint(E, StintNo, LeaveGarage);

                        if (StintScore == 1)
                        {
                            E.UpdateOVR(1);
                        }

                        else if (LeaveGarage)
                        {
                            E.LeaveGarage();
                            E.AddToOVR(StintScore);
                        }

                        else
                        {
                            E.StintInGarage();
                            E.AddToOVR(StintScore);
                        }
                    }
                }

                else
                {
                    StintScore = RaceStint(E, StintNo, false);

                    if (StintScore == 1)
                    {
                        E.UpdateOVR(1);
                    }

                    else if (StintScore <= 10)
                    {
                        E.AddToOVR(StintScore);

                        E.EnterGarage(Rand);
                        E.Pit();
                    }

                    else
                    {
                        if (ShouldPit(E))
                        {
                            PitScore = Rand.Next(5, 21);
                            E.Pit();
                        }

                        else
                        {
                            E.NotPit();
                        }

                        E.AddToOVR(StintScore - PitScore);
                    }
                }
            }

            Sort(EntryList, EntryList.Count);
        }

        public int RaceStint(Entrant EntrantData, int Stint, bool LeaveGarage)
        {
            int StintScore, Incident;
            int IL = 1, DNF = EntrantData.GetDNF();

            StintScore = Rand.Next(CD.GetClasses(EntrantData.GetClassIndex()).GetSRLow(), CD.GetClasses(EntrantData.GetClassIndex()).GetSRHigh() + EntrantData.GetSRM());
            Incident = Rand.Next(IL, EntrantData.GetReliability());

            if (Incident < DNF)
            {
                if (Incident == 1)
                {
                    StintScore = 1;
                }

                else
                {
                    StintScore -= CD.GetClasses(EntrantData.GetClassIndex()).GetSRInc();
                }
            }

            else if (LeaveGarage || Incident < CD.GetEnterGarageValue(CurrentRound.GetLengthType(), Stint - 1) + EntrantData.GetDNF())
            {
                StintScore = TimeLostInGarage(EntrantData, LeaveGarage);
            }

            return StintScore;
        }

        public bool ShouldLeaveGarage(Entrant E, int Stint)
        {
            bool LeaveGarage = false;
            string LengthType = CurrentRound.GetLengthType();
            int EMax, MinStints = 1;
            EMax = CD.GetLeaveGarageValue(LengthType, Stint - 1);
            double Chance = (EMax) * 0.65;

            if (Chance < 1)
            {
                Chance = 1;
            }

            if (E.GetExtendedGarageStay())
            {
                if (LengthType == "WEC")
                {
                    MinStints = CurrentRound.GetRaceLength() / 6;
                }

                else if (LengthType == "IMSA")
                {
                    MinStints = 2;
                }

                else
                {
                    MinStints = CurrentRound.GetRaceLength() / 10;
                }
            }

            if (LengthType == "WEC")
            {
                if (E.GetStintsInGarage() <= Rand.Next(MinStints, 11))
                {
                    if (Rand.Next(1, EMax) <= Chance)
                    {
                        LeaveGarage = true;
                    }
                }
            }

            else if (LengthType == "IMSA")
            {
                if (E.GetStintsInGarage() <= Rand.Next(MinStints, 5))
                {
                    if (Rand.Next(1, EMax) <= Chance)
                    {
                        LeaveGarage = true;
                    }
                }
            }

            else
            {
                if (E.GetStintsInGarage() <= Rand.Next(MinStints, 25))
                {
                    if (Rand.Next(1, EMax) <= Chance)
                    {
                        LeaveGarage = true;
                    }
                }
            }

            return LeaveGarage;
        }

        public bool ShouldRetire(Entrant E, int Stint)
        {
            bool Retire = false;

            if (CurrentRound.GetLengthType() == "WEC")
            {
                if (Stint > 12)
                {
                    if (E.GetTotalStaysInGarage() > 2 && E.GetTotalStintsInGarage() > 10)
                    {
                        if (Rand.Next(1, 6) <= 2)
                        {
                            Retire = true;
                        }
                    }

                    else
                    {
                        if (E.GetTotalStintsInGarage() > 8)
                        {
                            if (Rand.Next(1, 4) == 1)
                            {
                                Retire = true;
                            }
                        }

                        else if (E.GetTotalStintsInGarage() > 4)
                        {
                            if (Rand.Next(1, 9) == 1)
                            {
                                Retire = true;
                            }
                        }
                    }
                }

                else
                {
                    if (E.GetTotalStaysInGarage() > 2 && E.GetTotalStintsInGarage() > 10)
                    {
                        if (Rand.Next(1, 6) < 2)
                        {
                            Retire = true;
                        }
                    }

                    else
                    {
                        if (E.GetTotalStintsInGarage() > 8)
                        {
                            if (Rand.Next(1, 6) == 1)
                            {
                                Retire = true;
                            }
                        }

                        else if (E.GetTotalStintsInGarage() > 4)
                        {
                            if (Rand.Next(1, 11) == 1)
                            {
                                Retire = true;
                            }
                        }
                    }
                }
            }

            else if (CurrentRound.GetLengthType() == "IMSA")
            {
                if (E.GetStintsInGarage() >= 6)
                {
                    Retire = true;
                }
            }

            else
            {
                if (E.GetStintsInGarage() > Rand.Next(8, 15))
                {
                    Retire = true;
                }
            }

            return Retire;
        }

        public bool ShouldPit(Entrant E)
        {
            bool Pit = false;
            Class EntrantClass = CD.GetClasses(E.GetClassIndex());

            if (CurrentRound.GetLengthType() == "WEC")
            {
                if (E.GetStintsSincePit() >= EntrantClass.GetWECDTP() + Rand.Next(-1, 2))
                {
                    Pit = true;
                }
            }

            else if (CurrentRound.GetLengthType() == "IMSA")
            {
                if (E.GetStintsSincePit() >= EntrantClass.GetIMSADTP() + Rand.Next(-1, 2))
                {
                    Pit = true;
                }
            }

            else
            {
                if (E.GetStintsSincePit() >= EntrantClass.GetLapDTP() + Rand.Next(-5, 6))
                {
                    Pit = true;
                }
            }

            return Pit;
        }

        public int TimeLostInGarage(Entrant E, bool LeaveGarage)
        {
            int TimeLost = 0, MinValue, MaxValue, FullStint;

            if (CurrentRound.GetLengthType() == "WEC")
            {
                (MinValue, MaxValue, FullStint) = CD.GetClasses(E.GetClassIndex()).GetWECGarageValues();

                if (LeaveGarage || E.GetStintsInGarage() <= 1)
                {
                    TimeLost = Rand.Next(MinValue, MaxValue) - (2 * CD.GetClasses(E.GetClassIndex()).GetSRInc());
                }

                else
                {
                    TimeLost = FullStint; // -150;
                }
            }
            
            else if (CurrentRound.GetLengthType() == "IMSA")
            {
                (MinValue, MaxValue, FullStint) = CD.GetClasses(E.GetClassIndex()).GetIMSAGarageValues();

                if (LeaveGarage || E.GetStintsInGarage() == 1)
                {
                    TimeLost = Rand.Next(MinValue, MaxValue) - (2 * CD.GetClasses(E.GetClassIndex()).GetSRInc());
                }

                else
                {
                    TimeLost = FullStint; // -150;
                }
            }

            else if (CurrentRound.GetLengthType() == "Laps")
            {
                (MinValue, MaxValue, FullStint) = CD.GetClasses(E.GetClassIndex()).GetLapGarageValues();

                if (LeaveGarage || E.GetStintsInGarage() == 1)
                {
                    TimeLost = Rand.Next(MinValue, MaxValue) - (2 * CD.GetClasses(E.GetClassIndex()).GetSRInc());
                }

                else
                {
                    TimeLost = FullStint; // -150;
                }
            }

            return TimeLost;
        }

        public void SetGrid(List<Entrant> EntryList, int Spacing)
        {
            int ED = EntryList.Count;

            foreach (Entrant EntrantData in EntryList)
            {
                EntrantData.SetGridOVR(ED * Spacing);
                ED--;
            }
        }

        public void Sort(List<Entrant> Entrants, int EC)
        {
            for (int i = 0; i < EC - 1; i++)
            {
                bool Swap = false;

                for (int j = 0; j < EC - i - 1; j++)
                {
                    if (Entrants[j].GetOVR() < Entrants[j + 1].GetOVR())
                    {
                        Swap = true;

                        (Entrants[j], Entrants[j + 1]) = (Entrants[j + 1], Entrants[j]);
                    }

                    else if (Entrants[j].GetOVR() == Entrants[j + 1].GetOVR())
                    {
                        if (Entrants[j].GetOVR() == 1)
                        {
                            continue;
                        }

                        else if (Entrants[j].GetLastStint() < Entrants[j + 1].GetLastStint())
                        {
                            Swap = true;

                            (Entrants[j], Entrants[j + 1]) = (Entrants[j + 1], Entrants[j]);
                        }
                    }
                }

                if (!Swap)
                {
                    break;
                }
            }
        }

        public void Sort(List<Entrant> Entrants, int Start, int EC)
        {
            for (int i = 0; i < EC - 1; i++)
            {
                bool Swap = false;

                for (int j = Start; j < EC - i - 1; j++)
                {
                    if (Entrants[j].GetOVR() < Entrants[j + 1].GetOVR())
                    {
                        Swap = true;

                        (Entrants[j], Entrants[j + 1]) = (Entrants[j + 1], Entrants[j]);
                    }

                    else if (Entrants[j].GetOVR() == Entrants[j + 1].GetOVR())
                    {
                        if (Entrants[j].GetOVR() == 1)
                        {
                            continue;
                        }

                        else if (Entrants[j].GetLastStint() < Entrants[j + 1].GetLastStint())
                        {
                            Swap = true;

                            (Entrants[j], Entrants[j + 1]) = (Entrants[j + 1], Entrants[j]);
                        }
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
