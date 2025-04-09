using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class ViewClassOrder : Form
    {
        CommonData CD;
        RaceAdmin RA;

        List<ViewTop8> ActiveWindows = new List<ViewTop8>();

        List<Entrant> EntryList = new List<Entrant>();
        List<Entrant> Podium = new List<Entrant>();
        List<Entrant> Overall = new List<Entrant>();
        List<Entrant> Top8;

        public ViewClassOrder(CommonData iCD, RaceAdmin iRA)
        {
            InitializeComponent();

            CD = iCD;
            RA = iRA;

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

        public List<Entrant> GetTop8(List<Entrant> Entrants)
        {
            List<Entrant> P1 = new List<Entrant>(),
                P2 = new List<Entrant>(),
                P3 = new List<Entrant>(),
                P4 = new List<Entrant>(),
                P5 = new List<Entrant>(),
                P6 = new List<Entrant>(),
                P7 = new List<Entrant>(),
                P8 = new List<Entrant>();

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

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P6))
                {
                    P6.Add(Entrants[EC]);
                }

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P7))
                {
                    P7.Add(Entrants[EC]);
                }

                else if (!RA.ClassExistsInEntrants(Entrants[EC].GetClass(), P8))
                {
                    P8.Add(Entrants[EC]);
                }

                else
                {
                    continue;
                }
            }

            Merge(P1, P2, P3, P4, P5, P6, P7, P8);

            RA.IndexSort(Podium);

            return Podium;
        }

        private void Merge(List<Entrant> P1, List<Entrant> P2, List<Entrant> P3, List<Entrant> P4, List<Entrant> P5, List<Entrant> P6, List<Entrant> P7, List<Entrant> P8)
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

            foreach (Entrant ED in P6)
            {
                Podium.Add(ED);
            }

            foreach (Entrant ED in P7)
            {
                Podium.Add(ED);
            }

            foreach (Entrant ED in P8)
            {
                Podium.Add(ED);
            }
        }

        public List<Entrant> GetTop8Overall(List<Entrant> Entrants)
        {
            foreach (Entrant ED in Entrants)
            {
                Podium.Add(ED);

                if (Podium.Count == 8)
                {
                    break;
                }
            }

            return Podium;
        }

        public void LoadLeaders(List<Entrant> iTop8, List<Entrant> iOverall, List<Entrant> Entrants)
        {
            Top8 = iTop8;
            Overall = iOverall;
            EntryList = Entrants;
        }

        private void btn_LoadSelected_Click(object sender, EventArgs e)
        {
            if (lb_Classes.SelectedItem == null)
            {
                MessageBox.Show("You haven't Selected a Category to Display." + Environment.NewLine + "Select One, and Try Again.", "No Class Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string Class = lb_Classes.SelectedItem.ToString();

            if (Class == "Overall")
            {
                ViewTop8 GP = new ViewTop8();

                GP.LoadCarsOverall(EntryList);
                GP.Show();

                ActiveWindows.Add(GP);
            }

            else
            {
                if (RA.ClassExistsInEntrants(Class, Podium))
                {
                    ViewTop8 GP = new ViewTop8();

                    GP.LoadCars(Podium, Class);
                    GP.Show();

                    ActiveWindows.Add(GP);
                }

                else
                {
                    MessageBox.Show("Sorry, as this Class isn't Racing, we can't Display the Podium", "Class Not Racing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_LoadAll_Click(object sender, EventArgs e)
        {
            ViewTop8 GP;

            if (cb_Overall.Checked)
            {
                GP = new ViewTop8();

                GP.LoadCarsOverall(EntryList);
                GP.Show();

                ActiveWindows.Add(GP);
            }

            for (int C = 0; C < CD.GetClassCount(); C++)
            {
                string Class = CD.GetClasses(C).GetClassName();

                if (RA.ClassExistsInEntrants(Class, Podium))
                {
                    GP = new ViewTop8();

                    GP.LoadCars(Podium, Class);
                    GP.Show();

                    ActiveWindows.Add(GP);
                }
            }
        }

        private void btn_CloseAll_Click(object sender, EventArgs e)
        {
            CloseAllPodiums();
        }

        private void CloseAllPodiums()
        {
            foreach (ViewTop8 VT8 in ActiveWindows)
            {
                VT8.Dispose();
            }
        }
    }
}
