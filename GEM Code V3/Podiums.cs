using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class Podiums : Form
    {
        CommonData CD;
        RaceAdmin RA;
        Round CR;

        List<GenericPodium> ActivePodiums = new List<GenericPodium>();
        List<Top5Podium> ActivePodiumsLMS = new List<Top5Podium>();

        List<Entrant> Podium = new List<Entrant>();
        List<Entrant> PoleSitters;
        List<Entrant> Top5s;
        List<Entrant> Overall;

        string Session;
        bool LMS, EndOfQualifying;

        public Podiums(CommonData iCD, RaceAdmin iRA, Round iRound)
        {
            InitializeComponent();

            CD = iCD;
            RA = iRA;
            CR = iRound;

            LoadClasses();
        }

        private void LoadClasses()
        {
            lb_Classes.Items.Add("Overall");

            for (int C = 0; C < CD.GetClassCount(); C++)
            {
                lb_Classes.Items.Add(CD.GetClasses(C).GetClassName());
            }
        }

        public List<Entrant> GetOverallPodium(List<Entrant> Entrants)
        {
            List<Entrant> OVRP = new List<Entrant>();

            foreach (Entrant ED in Entrants)
            {
                OVRP.Add(ED);

                if (OVRP.Count == 3)
                {
                    break;
                }
            }

            return OVRP;
        }

        public List<Entrant> GetOverallTop5(List<Entrant> Entrants)
        {
            List<Entrant> OVRP = new List<Entrant>();

            foreach (Entrant ED in Entrants)
            {
                OVRP.Add(ED);

                if (OVRP.Count == 5)
                {
                    break;
                }
            }

            return OVRP;
        }

        public List<Entrant> GetPodium(List<Entrant> Entrants)
        {
            List<Entrant> P1 = new List<Entrant>();
            List<Entrant> P2 = new List<Entrant>();
            List<Entrant> P3 = new List<Entrant>();

            for (int EC = 0; EC < Entrants.Count; EC++)
            {
                if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P1))
                {
                    P1.Add(Entrants[EC]);
                }

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P2))
                {
                    P2.Add(Entrants[EC]);
                }

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P3))
                {
                    P3.Add(Entrants[EC]);
                }

                else
                {
                    continue;
                }
            }

            MergeT3(P1, P2, P3);

            RA.IndexSort(Podium);

            return Podium;
        }

        public List<Entrant> GetTop5(List<Entrant> Entrants)
        {
            List<Entrant> P1 = new List<Entrant>();
            List<Entrant> P2 = new List<Entrant>();
            List<Entrant> P3 = new List<Entrant>();
            List<Entrant> P4 = new List<Entrant>();
            List<Entrant> P5 = new List<Entrant>();

            for (int EC = 0; EC < Entrants.Count; EC++)
            {
                if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P1))
                {
                    P1.Add(Entrants[EC]);
                }

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P2))
                {
                    P2.Add(Entrants[EC]);
                }

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P3))
                {
                    P3.Add(Entrants[EC]);
                }

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P4))
                {
                    P4.Add(Entrants[EC]);
                }

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P5))
                {
                    P5.Add(Entrants[EC]);
                }

                else
                {
                    continue;
                }
            }

            MergeT5(P1, P2, P3, P4, P5);

            RA.IndexSort(Podium);

            return Podium;
        }

        public void MergeT5(List<Entrant> P1, List<Entrant> P2, List<Entrant> P3, List<Entrant> P4, List<Entrant> P5)
        {
            foreach (Entrant ED in P1)
            {
                Podium.Add(ED);
            }

            foreach (Entrant ED in P2)
            {
                Podium.Add(ED);
            }

            foreach (Entrant ED in P3)
            {
                Podium.Add(ED);
            }

            foreach (Entrant ED in P4)
            {
                Podium.Add(ED);
            }

            foreach (Entrant ED in P5)
            {
                Podium.Add(ED);
            }
        }

        public void MergeT3(List<Entrant> P1, List<Entrant> P2, List<Entrant> P3)
        {
            foreach (Entrant ED in P1)
            {
                Podium.Add(ED);
            }

            foreach (Entrant ED in P2)
            {
                Podium.Add(ED);
            }

            foreach (Entrant ED in P3)
            {
                Podium.Add(ED);
            }
        }

        public void LoadLeaders(List<Entrant> iPoleSitters, List<Entrant> iTop5s, List<Entrant> iOverall, string iSession, bool iLMS)
        {
            PoleSitters = iPoleSitters;
            Top5s = iTop5s;
            Overall = iOverall;
            Session = iSession;
            LMS = iLMS;
        }

        public void LoadLeaders(List<Entrant> iPoleSitters, List<Entrant> iTop5s, List<Entrant> iOverall, string iSession, bool iLMS, bool EOQ)
        {
            PoleSitters = iPoleSitters;
            Top5s = iTop5s;
            Overall = iOverall;
            Session = iSession;
            LMS = iLMS;
            EndOfQualifying = EOQ;
        }

        private void btn_LoadSelected_Click(object sender, EventArgs e)
        {
            string Class;

            if (Session == "Qualifying")
            {
                if (lb_Classes.SelectedItem == null)
                {
                    MessageBox.Show("You haven't Selected a Category to Display." + Environment.NewLine + "Select One, and Try Again.", "No Class Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (LMS)
                {
                    Class = lb_Classes.SelectedItem.ToString();

                    if (Class == "Overall")
                    {
                        Top5Podium GP = new Top5Podium(CD, CR);

                        GP.LoadOverall(Overall, EndOfQualifying);
                        GP.Show();

                        ActivePodiumsLMS.Add(GP);
                    }

                    else
                    {
                        if (RA.ClassExistsInEntrants(Class, Top5s))
                        {
                            Top5Podium GP = new Top5Podium(CD, CR);

                            GP.LoadResults(Podium, Class, EndOfQualifying);
                            GP.Show();

                            ActivePodiumsLMS.Add(GP);
                        }

                        else
                        {
                            MessageBox.Show("Sorry, as this Class isn't Racing, we can't Display the Podium", "Class Not Racing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                else
                {
                    Class = lb_Classes.SelectedItem.ToString();

                    if (Class == "Overall")
                    {
                        GenericPodium GP = new GenericPodium();

                        GP.LoadOverallQ(Overall);
                        GP.Show();

                        ActivePodiums.Add(GP);
                    }

                    else
                    {
                        if (RA.ClassExistsInEntrants(Class, Podium))
                        {
                            GenericPodium GP = new GenericPodium();

                            GP.LoadQualifying(Podium, Class);
                            GP.Show();

                            ActivePodiums.Add(GP);
                        }

                        else
                        {
                            MessageBox.Show("Sorry, as this Class isn't Racing, we can't Display the Podium", "Class Not Racing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            else if (Session == "Race")
            {
                if (lb_Classes.SelectedItem == null)
                {
                    MessageBox.Show("You haven't Selected a Category to Display." + Environment.NewLine + "Select One, and Try Again.", "No Class Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    Class = lb_Classes.SelectedItem.ToString();

                    if (Class == "Overall")
                    {
                        GenericPodium GP = new GenericPodium();

                        GP.LoadOverallR(Overall, PoleSitters);
                        GP.Show();

                        ActivePodiums.Add(GP);
                    }

                    else
                    {
                        if (RA.ClassExistsInEntrants(Class, Podium))
                        {
                            GenericPodium GP = new GenericPodium();

                            GP.LoadRace(Podium, PoleSitters, Class);
                            GP.Show();

                            ActivePodiums.Add(GP);
                        }

                        else
                        {
                            MessageBox.Show("Sorry, as this Class isn't Racing, we can't Display the Podium", "Class Not Racing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btn_LoadAll_Click(object sender, EventArgs e)
        {
            if (cb_Overall.Checked)
            {
                if (Session == "Qualifying")
                {
                    if (LMS)
                    {
                        Top5Podium GP = new Top5Podium(CD, CR);

                        GP.LoadOverall(Overall);
                        GP.Show();

                        ActivePodiumsLMS.Add(GP);
                    }

                    else
                    {
                        GenericPodium GP = new GenericPodium();

                        GP.LoadOverallQ(Overall);
                        GP.Show();

                        ActivePodiums.Add(GP);
                    }
                }

                else
                {
                    GenericPodium GP = new GenericPodium();

                    GP.LoadOverallR(Overall, PoleSitters);
                    GP.Show();

                    ActivePodiums.Add(GP);
                }
            }

            for (int C = 0; C < CD.GetClassCount(); C++)
            {
                string Class = CD.GetClasses(C).GetClassName();

                if (Session == "Qualifying")
                {
                    if (LMS)
                    {
                        if (RA.ClassExistsInEntrants(Class, Podium))
                        {
                            Top5Podium GP = new Top5Podium(CD, CR);

                            GP.LoadResults(Podium, Class, EndOfQualifying);
                            GP.Show();

                            ActivePodiumsLMS.Add(GP);
                        }
                    }

                    else
                    {
                        if (RA.ClassExistsInEntrants(Class, Podium))
                        {
                            GenericPodium GP = new GenericPodium();

                            GP.LoadQualifying(Podium, Class);
                            GP.Show();

                            ActivePodiums.Add(GP);
                        }
                    }
                }

                else if (Session == "Race")
                {
                    if (RA.ClassExistsInEntrants(Class, Podium))
                    {
                        GenericPodium GP = new GenericPodium();

                        GP.LoadRace(Podium, PoleSitters, Class);
                        GP.Show();

                        ActivePodiums.Add(GP);
                    }
                }
            }
        }

        private void btn_CloseAll_Click(object sender, EventArgs e)
        {
            CloseAllPodiums();
        }

        public void CloseAllPodiums()
        {
            foreach (GenericPodium Podium in ActivePodiums)
            {
                Podium.Dispose();
            }

            foreach (Top5Podium Podium in ActivePodiumsLMS)
            {
                Podium.Dispose();
            }
        }
    }
}
