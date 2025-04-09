using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class GenericPodium : Form
    {
        CommonData CD = new CommonData();
        RaceAdmin RA = new RaceAdmin();

        List<Entrant> Podium = new List<Entrant>();
        Entrant PoleSitter;

        List<TextBox> TBS = new List<TextBox>();

        bool ShowPole;

        public GenericPodium()
        {
            InitializeComponent();
        }

        public void LoadQualifying(List<Entrant> Entrants, string Class)
        {
            GetPodium(Entrants, Class);

            ShowPole = false;

            this.Text = Class + " Top 3";
            SetWindowIcon(this, Class, CD);
            tb_ClassPodium.Text = "Class Top 3 - " + Class;

            tb_PosP1.Text = "Pole";
        }

        public void LoadRace(List<Entrant> Entrants, List<Entrant> PoleSitters, string Class)
        {
            GetPodium(Entrants, Class);
            GetPole(PoleSitters, Class);

            ShowPole = true;

            this.Text = Class + " Podium";
            SetWindowIcon(this, Class, CD);
            tb_ClassPodium.Text = "Class Podium - " + Class;
        }

        public void LoadOverallQ(List<Entrant> Entrants)
        {
            GetPodiumOverall(Entrants);

            ShowPole = false;

            this.Text = "Overall Top 3";
            tb_ClassPodium.Text = "Top 3 - Overall";
        }

        public void LoadOverallR(List<Entrant> Entrants, List<Entrant> Pole)
        {
            GetPodiumOverall(Entrants);
            PoleSitter = Pole[0];

            ShowPole = true;

            this.Text = "Overall Podium";
            tb_ClassPodium.Text = "Podium - Overall";
        }

        private void GetPodium(List<Entrant> Entrants, string Class)
        {
            foreach (Entrant EntrantData in Entrants)
            {
                if (RA.EntrantExistsInEntrants(EntrantData, Podium))
                {
                    break;
                }

                else
                {
                    if (EntrantData.GetClass() == Class)
                    {
                        Podium.Add(EntrantData);
                    }
                }

                if (Podium.Count == 3)
                {
                    break;
                }
            }
        }

        private void GetPodiumOverall(List<Entrant> Entrants)
        {
            foreach (Entrant EntrantData in Entrants)
            {
                Podium.Add(EntrantData);

                if (Podium.Count == 3)
                {
                    break;
                }
            }
        }

        private void GetPole(List<Entrant> Entrants, string Class)
        {
            foreach (Entrant EntrantData in Entrants)
            {
                if (EntrantData.GetClass() == Class)
                {
                    PoleSitter = EntrantData;
                    break;
                }
            }
        }

        private void btn_ShowPodium_Click(object sender, EventArgs e)
        {
            LoadTBS();

            btn_ShowPodium.Visible = false;

            int I = 0;

            foreach (Entrant ED in Podium)
            {
                TBS[I].Text = ED.GetCrew();
                TBS[I + 1].Text = ED.GetCar();

                I += 2;
            }

            if (ShowPole)
            {
                tb_TeamPole.Text = PoleSitter.GetCrew();
                tb_CarPole.Text = PoleSitter.GetCar();
            }

            else
            {
                tb_PosPole.Visible = false;
                tb_TeamPole.Visible = false;
                tb_CarPole.Visible = false;
            }
        }

        private void LoadTBS()
        {
            TBS.Add(tb_TeamP1);
            TBS.Add(tb_CarP1);

            TBS.Add(tb_TeamP2);
            TBS.Add(tb_CarP2);

            TBS.Add(tb_TeamP3);
            TBS.Add(tb_CarP3);
        }

        public static void SetWindowIcon(Form ThisForm, string Class, CommonData CD)
        {
            int ClassIndex = CD.GetClassIndex(Class);

            if (ClassIndex == 1)
            {
                ThisForm.Icon = Properties.Resources.Class1;
            }

            else if (ClassIndex == 2)
            {
                ThisForm.Icon = Properties.Resources.Class2;
            }

            else if (ClassIndex == 3)
            {
                ThisForm.Icon = Properties.Resources.Class3;
            }

            else if (ClassIndex == 4)
            {
                ThisForm.Icon = Properties.Resources.Class4;
            }

            else if (ClassIndex == 5)
            {
                ThisForm.Icon = Properties.Resources.Class5;
            }

            else if (ClassIndex == 6)
            {
                ThisForm.Icon = Properties.Resources.Class6;
            }

            else if (ClassIndex == 7)
            {
                ThisForm.Icon = Properties.Resources.Class7;
            }

            else if (ClassIndex == 8)
            {
                ThisForm.Icon = Properties.Resources.Class8;
            }
        }
    }
}
