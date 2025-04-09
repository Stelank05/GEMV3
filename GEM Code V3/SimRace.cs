using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace GEM_Code_V3
{
    public partial class SimRace : Form
    {
        RaceAdmin RA = new RaceAdmin();

        CommonData CD;
        Random Rand;

        Simulator Sim;
        AutoStandings AS;

        string RoundName, QualiFormat, PointsSystem;
        int RoundNo, PassInRoundNo = 0, TestCount = 0;
        bool LMS, Test, EndOfQualifying = false;

        int RStint = 1, IC = 1;
        int QualiFormatBLoss,
            QualiFormatCR2Count, QualiFormatCR3Count,
            QualiFormatEGuaranteed, QualiFormatECutOff;

        List<Round> Calendar;

        List<Entrant> EntryList = new List<Entrant>();
        List<Entrant> ELA = new List<Entrant>(), ELB = new List<Entrant>(), ELC = new List<Entrant>(), ELD = new List<Entrant>();
        List<Entrant> PoleSitters = new List<Entrant>();
        List<Entrant> Leaders = new List<Entrant>();
        List<HyperPole> HyperPoleEntrants = new List<HyperPole>();

        List<TextBox> ClassTBs;

        List<Podiums> ActivePodiums = new List<Podiums>();
        List<ViewClassOrder> ActiveVCOs = new List<ViewClassOrder>();

        string Session;

        public SimRace(List<Round> iCalendar, CommonData iCD, Random iRand)
        {
            InitializeComponent();

            Calendar = iCalendar;
            CD = iCD;
            Rand = iRand;

            CD.LoadDistances();
            CD.LoadGarageValues();
            CD.LoadClassGarageValues();

            if (CD.GetRoundNo() + 1 <= Calendar.Count)
            {
                if (Calendar[0].GetIsTest())
                {
                    //MessageBox.Show(Convert.ToString(CD.GetRoundNo()) + " , " + Convert.ToString(CD.GetRoundNo() + 1), "Round Number", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int RN = 0;

                    if (CD.GetRoundNo() == -1)
                    {
                        RN = 0;
                    }

                    else
                    {
                        RN = CD.GetRoundNo();
                    }

                    //MessageBox.Show(Convert.ToString(CD.GetRoundNo()) + " , " + Convert.ToString(CD.GetRoundNo() + 1) + " , " + RN, "Round Number", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (Calendar[RN].GetIsTest())
                    {
                        RoundNo = CD.GetRoundNo() + 2;
                        RoundName = Calendar[RoundNo - 1].GetRoundName();
                        Test = Calendar[RoundNo - 1].GetIsTest();
                        GetTestCount();
                    }

                    else
                    {
                        RoundNo = CD.GetRoundNo() + 1;
                        RoundName = Calendar[RoundNo - 1].GetRoundName();
                        Test = Calendar[RoundNo - 1].GetIsTest();
                        GetTestCount();
                    }
                }

                else
                {
                    RoundNo = CD.GetRoundNo() + 1;
                    RoundName = Calendar[RoundNo - 1].GetRoundName();
                    Test = Calendar[RoundNo - 1].GetIsTest();
                    GetTestCount();
                }
            }

            Text = RoundName + " - GEM V3";

            Sim = new Simulator(CD, Rand, Calendar[RoundNo - 1]);
            AS = new AutoStandings(CD, Calendar[RoundNo - 1]);

            Directory.CreateDirectory(CD.SetSavePath(Test, RoundName, Calendar[RoundNo - 1].GetRoundNo()));

            RA.LoadEntrants(EntryList, CD.GetEntrantsLocation(), Calendar[RoundNo - 1], CD);

            if (Test)
            {
                if (RoundNo - 1 == 0)
                {
                    tb_RoundNo.Text = "Test";
                }

                else
                {
                    tb_RoundNo.Text = "Round " + (RoundNo - 1);
                }
            }

            else
            {
                tb_RoundNo.Text = "Round " + Calendar[RoundNo - 1].GetRoundNo();
            }

            tb_RoundName.Text = RoundName;

            if (Calendar[RoundNo - 1].GetLengthType() == "Laps")
            {
                tb_RaceLength.Text = Convert.ToString(Calendar[RoundNo - 1].GetRaceLength()) + " Laps";
            }

            else if (Calendar[RoundNo - 1].GetLengthType() == "WEC")
            {
                tb_RaceLength.Text = Convert.ToString(Calendar[RoundNo - 1].GetRaceLength() / 2) + " Hours";
            }

            else if (Calendar[RoundNo - 1].GetLengthType() == "IMSA")
            {
                tb_RaceLength.Text = CD.GetIMSADistance(Calendar[RoundNo - 1].GetRaceLength());
            }

            ClassTBs = new List<TextBox>();
            LoadBoxes(ClassTBs);

            LoadClassColumn();
            SetSizes();

            QualiFormat = Calendar[RoundNo - 1].GetQualiFormat();
            PointsSystem = Calendar[RoundNo - 1].GetPointsSystem();

            if (QualiFormat == "A" && PointsSystem == "A")
            {
                LMS = true;
            }

            else
            {
                LMS = false;
            }

            Session = "Qualifying";

            SetQualiFormatValues();

            btn_ViewPodium.Text = "View Top 8";
        }

        private void SetQualiFormatValues()
        {
            QualiFormatBLoss = CD.GetQualiFormatBLoss();
            QualiFormatCR2Count = CD.GetQualiFormatCR2Count();
            QualiFormatCR3Count = CD.GetQualiFormatCR3Count();
            QualiFormatEGuaranteed = CD.GetQualiFormatEGuaranteed();
            QualiFormatECutOff = CD.GetQualiFormatECutOff();
        }

        private List<Entrant> GetLeaders(List<Entrant> Entrants)
        {
            List<Entrant> ClassLeaders = new List<Entrant>();

            for (int CC = 0; CC < CD.GetClassCount(); CC++)
            {
                for (int EC = 0; EC < Entrants.Count; EC++)
                {
                    if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), ClassLeaders))
                    {
                        ClassLeaders.Add(Entrants[EC]);
                    }
                }
            }

            RA.IndexSort(ClassLeaders);

            return ClassLeaders;
        }

        private List<Entrant> GetLeaders(List<HyperPole> Entrants)
        {
            List<Entrant> ClassLeaders = new List<Entrant>();

            foreach (HyperPole THP in Entrants)
            {
                ClassLeaders.Add(THP.GetEntrant(0));
            }

            return ClassLeaders;
        }

        private void SetLeaders(List<Entrant> Leaders)
        {
            int TBI = 0;

            for (int LI = 0; LI < Leaders.Count; LI++)
            {
                ClassTBs[TBI + 1].Text = Leaders[LI].GetCrew();
                ClassTBs[TBI + 2].Text = Leaders[LI].GetCar();

                TBI += 3;
            }
        }

        private void LoadBoxes(List<TextBox> ClassTBs)
        {
            ClassTBs.Add(tb_C1_Class);
            ClassTBs.Add(tb_C1_Team);
            ClassTBs.Add(tb_C1_Car);

            ClassTBs.Add(tb_C2_Class);
            ClassTBs.Add(tb_C2_Team);
            ClassTBs.Add(tb_C2_Car);

            ClassTBs.Add(tb_C3_Class);
            ClassTBs.Add(tb_C3_Team);
            ClassTBs.Add(tb_C3_Car);

            ClassTBs.Add(tb_C4_Class);
            ClassTBs.Add(tb_C4_Team);
            ClassTBs.Add(tb_C4_Car);

            ClassTBs.Add(tb_C5_Class);
            ClassTBs.Add(tb_C5_Team);
            ClassTBs.Add(tb_C5_Car);

            ClassTBs.Add(tb_C6_Class);
            ClassTBs.Add(tb_C6_Team);
            ClassTBs.Add(tb_C6_Car);

            ClassTBs.Add(tb_C7_Class);
            ClassTBs.Add(tb_C7_Team);
            ClassTBs.Add(tb_C7_Car);

            ClassTBs.Add(tb_C8_Class);
            ClassTBs.Add(tb_C8_Team);
            ClassTBs.Add(tb_C8_Car);
        }

        private void LoadClassColumn()
        {
            int TBI = 0;

            List<string> Classes = Calendar[RoundNo - 1].GetShortRacingClasses();

            for (int CI = 0; CI < Classes.Count(); CI++)
            {
                int CN = Convert.ToInt32(Classes[CI].Replace('C', ' ')) - 1;

                ClassTBs[TBI].Text = CD.GetClasses(CN).GetClassName();
                TBI += 3;
            }

            for (int TI = TBI; TI < ClassTBs.Count; TI++)
            {
                ClassTBs[TI].Visible = false;
            }
        }

        private void SetSizes()
        {
            if (CD.GetClassCount() < 8)
            {
                int Reduce = (8 - CD.GetClassCount()) * 30;

                if (Reduce > 60)
                {
                    Reduce = 60;
                }

                ClientSize = new System.Drawing.Size(520, 363 - Reduce - 55);
            }
        }

        private void HyperPoleSplit()
        {
            int IndexOfNextClass = 0;
            bool NextClassFound;

            for (int i = 0; i < CD.GetClassCount(); i++)
            {
                HyperPole THP = new HyperPole();
                NextClassFound = false;

                for (int j = IndexOfNextClass; j < EntryList.Count; j++)
                {
                    if (EntryList[j].GetClass() == CD.GetClasses(i).GetClassName())
                    {
                        EntryList[j].SetBaseOVR();
                        THP.AddCar(EntryList[j]);
                    }

                    if (i + 1 != CD.GetClassCount())
                    {
                        if (EntryList[j].GetClass() == CD.GetClasses(i + 1).GetClassName() && !NextClassFound)
                        {
                            IndexOfNextClass = j;
                            NextClassFound = true;
                        }
                    }

                    if (THP.GetLength() == 5)
                    {
                        break;
                    }
                }

                if (THP.GetLength() == 0)
                {
                    break;
                }

                else
                {
                    HyperPoleEntrants.Add(THP);
                }
            }
        }

        private void ClassIndexSort()
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

        public List<Entrant> Merge()
        {
            List<Entrant> NewEntryList = new List<Entrant>();

            int IndexOfNextClass = 5;
            bool NextClassFound;

            for (int i = 0; i < HyperPoleEntrants.Count; i++)
            {
                HyperPole THP = HyperPoleEntrants[i];
                NextClassFound = false;

                for (int j = 0; j < THP.GetLength(); j++)
                {
                    NewEntryList.Add(THP.GetEntrant(j));
                }

                for (int j = IndexOfNextClass; j < EntryList.Count; j++)
                {
                    if (EntryList[j].GetClass() == THP.GetEntrant(0).GetClass())
                    {
                        NewEntryList.Add(EntryList[j]);
                    }

                    if (i != HyperPoleEntrants.Count - 1)
                    {
                        if (EntryList[j].GetClass() == HyperPoleEntrants[i + 1].GetEntrant(0).GetClass() && !NextClassFound)
                        {
                            IndexOfNextClass = j + 5;
                            NextClassFound = true;
                        }
                    }
                }
            }

            return NewEntryList;
        }

        private void GetTestCount()
        {
            foreach (Round Race in Calendar)
            {
                if (Race.GetIsTest())
                {
                    TestCount++;
                }
            }
        }

        private void btn_Advance_Click(object sender, EventArgs e)
        {
            if (btn_Advance.Text == "Start Qualifying")
            {
                if (QualiFormat == "A")
                {
                    tb_RaceLength.Text = "3 Sessions";
                    tb_CurrentStint.Text = "Qualifying 1";

                    Sim.Qualifying(EntryList, EntryList.Count);

                    Leaders = GetLeaders(EntryList);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);
                }

                else if (QualiFormat == "B")
                {
                    tb_RaceLength.Text = "3 Sessions";
                    tb_CurrentStint.Text = "Qualifying 1";

                    Sim.Qualifying(EntryList, EntryList.Count);

                    Leaders = GetLeaders(EntryList);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                    for (int i = 0; i < EntryList.Count - QualiFormatBLoss; i++)
                    {
                        EntryList[i].SetBaseOVR();
                        ELA.Add(EntryList[i]);
                    }
                }

                else if (QualiFormat == "C")
                {
                    tb_RaceLength.Text = "3 Rounds";
                    tb_CurrentStint.Text = "R1 - Group 1";

                    for (int i = 0; i < EntryList.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            ELA.Add(EntryList[i]);
                        }

                        else
                        {
                            ELB.Add(EntryList[i]);
                        }
                    }

                    Sim.Qualifying(ELA, ELA.Count); IC++;

                    Leaders = GetLeaders(ELA);

                    Save.SaveStint(ELA, CD, tb_CurrentStint.Text, RoundName, Test);
                }

                else if (QualiFormat == "D")
                {
                    tb_RaceLength.Text = "Qualifying";
                    tb_CurrentStint.Text = "Qualifying 1";

                    int EndIndex = EntryList.Count / 3;

                    Sim.Qualifying(EntryList, 0, EndIndex);

                    Leaders = GetLeaders(EntryList);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);
                }

                else if (QualiFormat == "E")
                {
                    tb_RaceLength.Text = "Qualifying";
                    tb_CurrentStint.Text = "Quali - Cars 1-" + (EntryList.Count / 4);

                    int EndIndex = EntryList.Count / 4;

                    Sim.Qualifying(EntryList, 0, EndIndex);

                    Leaders = GetLeaders(EntryList);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);
                }

                btn_Advance.Text = "Continue Qualifying";

                SetLeaders(Leaders);
            }

            else if (btn_Advance.Text == "Continue Qualifying")
            {
                if (QualiFormat == "A")
                {
                    tb_CurrentStint.Text = "Qualifying 2";

                    Sim.Qualifying(EntryList, EntryList.Count);

                    Leaders = GetLeaders(EntryList);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                    btn_Advance.Text = "Finish Qualifying";
                }

                else if (QualiFormat == "B")
                {
                    tb_CurrentStint.Text = "Qualifying 2";

                    Sim.Qualifying(ELA, ELA.Count);

                    Leaders = GetLeaders(ELA);

                    Save.SaveStint(ELA, CD, tb_CurrentStint.Text, RoundName, Test);

                    for (int i = 0; i < ELA.Count - QualiFormatBLoss; i++)
                    {
                        ELA[i].SetBaseOVR();
                        ELB.Add(ELA[i]);
                    }

                    btn_Advance.Text = "Finish Qualifying";
                }

                else if (QualiFormat == "C")
                {
                    if (IC == 2)
                    {
                        tb_CurrentStint.Text = "R1 - Group 2";

                        Sim.Qualifying(ELB, ELB.Count); IC++;

                        Leaders = GetLeaders(ELB);

                        Save.SaveStint(ELB, CD, tb_CurrentStint.Text, RoundName, Test);
                    }
                    
                    else if (IC == 3)
                    {
                        tb_CurrentStint.Text = "R2 - Fast " + QualiFormatCR2Count;

                        for (int i = 0; i < QualiFormatCR2Count / 2; i++)
                        {
                            ELC.Add(ELA[i]);
                            ELC.Add(ELB[i]);
                        }

                        Sim.Qualifying(ELC, ELC.Count); IC++;

                        Leaders = GetLeaders(ELC);

                        Save.SaveStint(ELC, CD, tb_CurrentStint.Text, RoundName, Test);

                        for (int i = 0; i < QualiFormatCR3Count; i++)
                        {
                            ELD.Add(ELC[i]);
                        }

                        btn_Advance.Text = "Finish Qualifying";
                    }
                }

                else if (QualiFormat == "D")
                {
                    tb_CurrentStint.Text = "Qualifying 2";

                    int StartIndex = EntryList.Count / 3;
                    int EndIndex = 2 * (EntryList.Count / 3);

                    Sim.Qualifying(EntryList, StartIndex, EndIndex);

                    Leaders = GetLeaders(EntryList);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                    btn_Advance.Text = "Finish Qualifying";
                }

                else if (QualiFormat == "E")
                {
                    if (tb_CurrentStint.Text == "Quali - Cars 1-" + (EntryList.Count / 4))
                    {
                        tb_CurrentStint.Text = "Quali - Cars " + ((EntryList.Count / 4) + 1) + "-" + (2 * (EntryList.Count / 4));

                        int StartIndex = EntryList.Count / 4;
                        int EndIndex = 2 * (EntryList.Count / 4);

                        Sim.Qualifying(EntryList, StartIndex, EndIndex);

                        Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);
                    }

                    else if (tb_CurrentStint.Text == "Quali - Cars " + ((EntryList.Count / 4) + 1) + "-" + (2 * (EntryList.Count / 4)))
                    {
                        tb_CurrentStint.Text = "Quali - Cars " + (2 * (EntryList.Count / 4) + 1) + "-" + (3 * (EntryList.Count / 4));

                        int StartIndex = 2 * (EntryList.Count / 4);
                        int EndIndex = 3 * (EntryList.Count / 4);

                        Sim.Qualifying(EntryList, StartIndex, EndIndex);

                        Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);
                    }

                    else if (tb_CurrentStint.Text == "Quali - Cars " + (2 * (EntryList.Count / 4) + 1) + "-" + (3 * (EntryList.Count / 4)))
                    {
                        tb_CurrentStint.Text = "Quali - Cars " + (3 * (EntryList.Count / 4) + 1) + "-" + EntryList.Count;

                        int StartIndex = 3 * (EntryList.Count / 4);
                        int EndIndex = EntryList.Count;

                        Sim.Qualifying(EntryList, StartIndex, EndIndex);

                        Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                        foreach (Entrant E in EntryList)
                        {
                            E.SetBaseOVR();
                        }
                    }

                    else if (tb_CurrentStint.Text == "Quali - Cars " + (3 * (EntryList.Count / 4) + 1) + "-" + EntryList.Count)
                    {
                        if (EntryList.Count > QualiFormatECutOff)
                        {
                            tb_CurrentStint.Text = "Quali - Bump Day";

                            Sim.Qualifying(EntryList, QualiFormatEGuaranteed, EntryList.Count);

                            Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                            while (EntryList.Count > QualiFormatECutOff)
                            {
                                EntryList.RemoveAt(EntryList.Count - 1);
                            }
                        }

                        else
                        {
                            tb_CurrentStint.Text = "Quali - Fast 12";

                            Sim.Qualifying(EntryList, 0, 12);

                            Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                            btn_Advance.Text = "Finish Qualifying";
                        }
                    }

                    else if (tb_CurrentStint.Text == "Quali - Bump Day")
                    {
                        tb_CurrentStint.Text = "Quali - Fast 12";

                        Sim.Qualifying(EntryList, 0, 12);

                        Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                        foreach (Entrant E in EntryList)
                        {
                            E.SetBaseOVR();
                        }

                        btn_Advance.Text = "Finish Qualifying";
                    }

                    Leaders = GetLeaders(EntryList);
                }

                SetLeaders(Leaders);
            }

            else if (btn_Advance.Text == "Finish Qualifying")
            {
                if (QualiFormat == "A")
                {
                    tb_CurrentStint.Text = "Qualifying 3";

                    Sim.Qualifying(EntryList, EntryList.Count);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                    Leaders = GetLeaders(EntryList);

                    if (LMS)
                    {
                        btn_Advance.Text = "Start Hyper Pole";
                    }

                    else
                    {
                        PoleSitters = Leaders;
                        btn_Advance.Text = "Start Race";
                    }
                }
                
                else if (QualiFormat == "B")
                {
                    tb_CurrentStint.Text = "Qualifying 3";

                    Sim.Qualifying(ELB, ELB.Count);

                    Leaders = GetLeaders(ELB);

                    Save.SaveStint(ELB, CD, tb_CurrentStint.Text, RoundName, Test);

                    btn_Advance.Text = "Start Race";
                }

                else if (QualiFormat == "C")
                {
                    tb_CurrentStint.Text = "R3 - Fast " + QualiFormatCR3Count;

                    Sim.Qualifying(ELD, ELD.Count); IC++;

                    Leaders = GetLeaders(ELB);

                    Save.SaveStint(ELD, CD, tb_CurrentStint.Text, RoundName, Test);

                    btn_Advance.Text = "Start Race";
                }

                else if (QualiFormat == "D")
                {
                    tb_CurrentStint.Text = "Qualifying 3";

                    int StartIndex = 2 * (EntryList.Count / 3);

                    Sim.Qualifying(EntryList, StartIndex, EntryList.Count);

                    Sim.Sort(EntryList, EntryList.Count);

                    Leaders = GetLeaders(ELB);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                    btn_Advance.Text = "Start Race";
                }

                else if (QualiFormat == "E")
                {
                    tb_CurrentStint.Text = "Quali - Fast 6";

                    Sim.Qualifying(EntryList, 0, 6);

                    Leaders = GetLeaders(ELB);

                    Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                    btn_Advance.Text = "Start Race";
                }

                SetLeaders(Leaders);
                btn_ViewPodium.Text = "View Podium";

                if (!Test && CD.DoAutoStandings() && AS.CanDoAutoStandings("Qualifying", PointsSystem) && QualiFormat != "A")
                {
                    AS.DoAllStandings(EntryList, Session);
                }
            }

            else if (btn_Advance.Text == "Start Hyper Pole")
            {
                tb_CurrentStint.Text = "Hyper Pole Part 1";
                tb_RaceLength.Text = "Hyper Pole";

                HyperPoleSplit();

                HyperPoleEntrants = Sim.HyperPole(HyperPoleEntrants);

                Leaders = GetLeaders(HyperPoleEntrants);
                SetLeaders(Leaders);

                Save.SaveStint(Merge(), CD, tb_CurrentStint.Text, RoundName, Test);

                btn_Advance.Text = "Finish Hyper Pole";
            }

            else if (btn_Advance.Text == "Finish Hyper Pole")
            {
                tb_CurrentStint.Text = "Hyper Pole Part 2";

                HyperPoleEntrants = Sim.HyperPole(HyperPoleEntrants);

                Leaders = GetLeaders(HyperPoleEntrants);
                SetLeaders(Leaders);

                ClassIndexSort();
                EntryList = Merge();

                PoleSitters = Leaders;

                Save.SaveStint(EntryList, CD, tb_CurrentStint.Text, RoundName, Test);

                btn_Advance.Text = "Start Race";
                btn_ViewPodium.Text = "View Podium";

                EndOfQualifying = true;

                if (!Test && CD.DoAutoStandings() && AS.CanDoAutoStandings("Qualifying", PointsSystem))
                {
                    AS.DoAllStandings(EntryList, "Qualifying");
                }
            }

            else if (btn_Advance.Text == "Start Race")
            {
                btn_ViewPodium.Text = "View Top 8";

                ClosePodiums();

                Session = "Race";

                if (Calendar[RoundNo - 1].GetLengthType() == "WEC")
                {
                    tb_CurrentStint.Text = CD.GetWECDistance(RStint);
                    tb_RaceLength.Text = CD.GetWECDistance(Calendar[RoundNo - 1].GetRaceLength());
                }

                else if (Calendar[RoundNo - 1].GetLengthType() == "IMSA")
                {
                    tb_CurrentStint.Text = CD.GetIMSADistance(RStint);
                    tb_RaceLength.Text = CD.GetIMSADistance(Calendar[RoundNo - 1].GetRaceLength());
                }

                else if (Calendar[RoundNo - 1].GetLengthType() == "Laps")
                {
                    tb_CurrentStint.Text = CD.GetLapsDistance(RStint);
                    tb_RaceLength.Text = CD.GetLapsDistance(Calendar[RoundNo - 1].GetRaceLength()) + " Laps";
                }

                Sim.SetGrid(EntryList, 10);

                Sim.Race(EntryList, RStint);

                Leaders = GetLeaders(EntryList);
                SetLeaders(Leaders);

                Save.SaveStint(EntryList, CD, "Stint 1", RoundName, Test); RStint++;

                btn_Advance.Text = "Simulate Stint " + RStint;
            }

            else if (btn_Advance.Text.StartsWith("Simulate Stint"))
            {
                if (Calendar[RoundNo - 1].GetLengthType() == "WEC")
                {
                    tb_CurrentStint.Text = CD.GetWECDistance(RStint);
                }

                else if (Calendar[RoundNo - 1].GetLengthType() == "IMSA")
                {
                    tb_CurrentStint.Text = CD.GetIMSADistance(RStint);
                }

                else if (Calendar[RoundNo - 1].GetLengthType() == "Laps")
                {
                    tb_CurrentStint.Text = CD.GetLapsDistance(RStint);
                }

                Sim.Race(EntryList, RStint);

                Leaders = GetLeaders(EntryList);
                SetLeaders(Leaders);

                Save.SaveStint(EntryList, CD, "Stint " + RStint, RoundName, Test); RStint++;

                if (RStint == Calendar[RoundNo - 1].GetRaceLength())
                {
                    btn_Advance.Text = "Finish Race";
                }

                else
                {
                    btn_Advance.Text = "Simulate Stint " + RStint;
                }
            }

            else if (btn_Advance.Text == "Finish Race")
            {
                if (Calendar[RoundNo - 1].GetLengthType() == "WEC")
                {
                    tb_CurrentStint.Text = CD.GetWECDistance(RStint);
                }

                else if (Calendar[RoundNo - 1].GetLengthType() == "IMSA")
                {
                    tb_CurrentStint.Text = CD.GetIMSADistance(RStint);
                }

                else if (Calendar[RoundNo - 1].GetLengthType() == "Laps")
                {
                    tb_CurrentStint.Text = CD.GetLapsDistance(RStint);
                }

                Sim.Race(EntryList, RStint);

                foreach (Entrant E in EntryList)
                {
                    if (E.GetInGarage() && E.GetOVR() != 1)
                    {
                        E.UpdateOVR(100);
                    }
                }

                Sim.Sort(EntryList, EntryList.Count);

                Leaders = GetLeaders(EntryList);
                SetLeaders(Leaders);

                Save.SaveStint(EntryList, CD, "Race Results", RoundName, Test);

                btn_Advance.Visible = false;
                btn_ViewPodium.Text = "View Podium";
                btn_NextRace.Visible = true;

                if (!Test && CD.DoAutoStandings() && AS.CanDoAutoStandings("Race", PointsSystem))
                {
                    AS.DoAllStandings(EntryList, "Race");
                }
            }
        }

        private void btn_ViewPodium_Click(object sender, EventArgs e)
        {
            if (btn_ViewPodium.Text == "View Top 8")
            {
                ViewClassOrder VCO = new ViewClassOrder(CD, RA);

                ActiveVCOs.Add(VCO);

                List<Entrant> Top8 = VCO.GetTop8(EntryList);
                List<Entrant> Overall = VCO.GetTop8Overall(EntryList);

                VCO.LoadLeaders(Top8, Overall, EntryList);
                VCO.Show();
            }

            else
            {
                if (Session == "Qualifying")
                {
                    if (!LMS)
                    {
                        Podiums QualiR = new Podiums(CD, RA, Calendar[RoundNo - 1]);

                        ActivePodiums.Add(QualiR);

                        List<Entrant> Podiums = QualiR.GetPodium(EntryList);
                        List<Entrant> Overall = QualiR.GetOverallPodium(EntryList);

                        QualiR.LoadLeaders(PoleSitters, Podiums, Overall, Session, LMS);
                        QualiR.Show();
                    }

                    else
                    {
                        Podiums QualiR = new Podiums(CD, RA, Calendar[RoundNo - 1]);

                        ActivePodiums.Add(QualiR);

                        List<Entrant> Top5s = QualiR.GetTop5(EntryList);
                        List<Entrant> Overall = QualiR.GetOverallTop5(EntryList);

                        QualiR.LoadLeaders(PoleSitters, Top5s, Overall, Session, LMS, EndOfQualifying);
                        QualiR.Show();
                    }
                }

                else if (Session == "Race")
                {
                    Podiums Podium = new Podiums(CD, RA, Calendar[RoundNo - 1]);

                    ActivePodiums.Add(Podium);

                    List<Entrant> Podiums = Podium.GetPodium(EntryList);
                    List<Entrant> Overall = Podium.GetOverallPodium(EntryList);

                    Podium.LoadLeaders(PoleSitters, Podiums, Overall, Session, LMS);
                    Podium.Show();
                }
            }
        }

        private void btn_NextRace_Click(object sender, EventArgs e)
        {
            if (RoundNo + TestCount > Calendar.Count || CD.GetRoundNo() + TestCount + 1 > Calendar.Count || RoundNo + 1 > Calendar.Count)
            {
                MessageBox.Show("That's It!" + Environment.NewLine +
                    "The Calendar is now Complete, the Season's over!" + Environment.NewLine + Environment.NewLine +
                    "Press Enter, or Click OK, to Exit the Program.", "Season Over!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
            }

            else
            {
                CD.SetRoundNo(CD.GetRoundNo() + 1);
            }

            SimRace NextRound = new SimRace(Calendar, CD, Rand);

            this.Close();
            ClosePodiums();
            NextRound.Show();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            UserSure US = new UserSure();
            US.Show();
        }

        private void ClosePodiums()
        {
            foreach (Podiums P in ActivePodiums)
            {
                P.CloseAllPodiums();
                P.Hide();
            }

            foreach (ViewClassOrder VCO in ActiveVCOs)
            {
                VCO.Hide();
            }
        }
    }
}
