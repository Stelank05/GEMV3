using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class Top5Podium : Form
    {
        string Class;

        CommonData CD;
        RaceAdmin RA = new RaceAdmin();
        Round CurrentRound;

        List<Entrant> Overall = new List<Entrant>();
        List<Entrant> Podium = new List<Entrant>();

        List<TextBox> TBS = new List<TextBox>(),
            PointsTBS = new List<TextBox>();

        public Top5Podium(CommonData iCD, Round iRound)
        {
            CD = iCD;
            CurrentRound = iRound;

            InitializeComponent();
            LoadPoints();
        }

        public void LoadPoints()
        {
            List<int> PointsSystem = AutoStandings.LoadPointsSystem("Qualifying", CD, CurrentRound);

            int RunLength = 0, Index = 0;

            if (PointsSystem.Count > PointsTBS.Count)
            {
                RunLength = PointsTBS.Count;
            }

            else
            {
                RunLength = PointsSystem.Count;
            }

            for (int i = 0; i < RunLength; i++)
            {
                if (PointsSystem[i] == 1)
                {
                    PointsTBS[i].Text = Convert.ToString(PointsSystem[i]) + " Pt";
                }

                else
                {
                    PointsTBS[i].Text = Convert.ToString(PointsSystem[i]) + " Pts";
                }
                
                Index = i;
            }

            for (int i = Index; i < PointsTBS.Count; i++)
            {
                PointsTBS[i].Text = "0 Pts";
            }
        }

        public void LoadResults(List<Entrant> Entrants, string Class)
        {
            GetPodium(Entrants, Class);

            this.Text = Class + " Top 5";
            GenericPodium.SetWindowIcon(this, Class, CD);
            tb_ClassTop5.Text = "Class Podium - " + Class;
        }

        public void LoadResults(List<Entrant> Entrants, string Class, bool EOQ)
        {
            GetPodium(Entrants, Class);

            this.Text = Class + " Top 5";
            GenericPodium.SetWindowIcon(this, Class, CD);
            tb_ClassTop5.Text = "Class Podium - " + Class;

            if (!EOQ)
            {
                tb_Pts.Visible = false;
                tb_Pts_P1.Visible = false;
                tb_Pts_P2.Visible = false;
                tb_Pts_P3.Visible = false;
                tb_Pts_P4.Visible = false;
                tb_Pts_P5.Visible = false;
            }
        }

        public void LoadOverall(List<Entrant> Entrants)
        {
            Class = "Overall";

            GetPodiumOverall(Entrants);

            this.Text = "Overall Top 5";
            tb_ClassTop5.Text = "Overall Top 5";
        }

        public void LoadOverall(List<Entrant> Entrants, bool EndOfQualifying)
        {
            Class = "Overall";

            GetPodiumOverall(Entrants);

            this.Text = "Overall Top 5";
            tb_ClassTop5.Text = "Overall Top 5";

            if (!EndOfQualifying)
            {
                tb_Pts.Visible = false;
                tb_Pts_P1.Visible = false;
                tb_Pts_P2.Visible = false;
                tb_Pts_P3.Visible = false;
                tb_Pts_P4.Visible = false;
                tb_Pts_P5.Visible = false;
            }
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

                if (Podium.Count == 5)
                {
                    break;
                }
            }
        }

        private void GetPodiumOverall(List<Entrant> Entrants)
        {
            foreach (Entrant ED in Entrants)
            {
                Overall.Add(ED);

                if (Overall.Count == 5)
                {
                    break;
                }
            }
        }

        private void btn_ShowPodium_Click(object sender, EventArgs e)
        {
            btn_ShowPodium.Visible = false;

            LoadTBS();

            if (Class == "Overall")
            {
                int I = 0;

                foreach (Entrant ED in Overall)
                {
                    TBS[I].Text = ED.GetCrew();
                    TBS[I + 1].Text = ED.GetCar();

                    I += 2;
                }
            }

            else
            {
                int I = 0;

                foreach (Entrant ED in Podium)
                {
                    TBS[I].Text = ED.GetCrew();
                    TBS[I + 1].Text = ED.GetCar();

                    I += 2;
                }
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

            TBS.Add(tb_TeamP4);
            TBS.Add(tb_CarP4);

            TBS.Add(tb_TeamP5);
            TBS.Add(tb_CarP5);

            PointsTBS.Add(tb_Pts_P1);
            PointsTBS.Add(tb_Pts_P2);
            PointsTBS.Add(tb_Pts_P3);
            PointsTBS.Add(tb_Pts_P4);
            PointsTBS.Add(tb_Pts_P5);
        }
    }
}
