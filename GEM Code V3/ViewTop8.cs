using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class ViewTop8 : Form
    {
        RaceAdmin RA = new RaceAdmin();

        List<Entrant> Podium = new List<Entrant>();
        List<Entrant> Top8 = new List<Entrant>();

        List<TextBox> TBS = new List<TextBox>();

        string Class;

        public ViewTop8()
        {
            InitializeComponent();
        }

        public void LoadCars(List<Entrant> Entrants, string iClass)
        {
            Class = iClass;
            GetPodium(Entrants, Class);

            this.Text = Class + " Top 8";
            GenericPodium.SetWindowIcon(this, Class, new CommonData());
            tb_ClassTop8.Text = "Top 8 - " + Class;
        }

        public void LoadCarsOverall(List<Entrant> Entrants)
        {
            Class = "Overall";

            GetPodiumOverall(Entrants);

            this.Text = "Overall Top 8";
            tb_ClassTop8.Text = "Top 8 - Overall";
        }

        private void GetPodium(List<Entrant> Entrants, string Class)
        {
            foreach (Entrant EntrantData in Entrants)
            {
                if (EntrantData.GetClass() == Class)
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
                }

                if (Podium.Count == 8)
                {
                    break;
                }
            }
        }

        public void GetPodiumOverall(List<Entrant> Entrants)
        {
            foreach (Entrant ED in Entrants)
            {
                Top8.Add(ED);

                if (Top8.Count == 8)
                {
                    break;
                }
            }
        }

        private void btn_ShowPodium_Click(object sender, EventArgs e)
        {
            LoadTBS();

            btn_ShowPodium.Visible = false;

            if (Class == "Overall")
            {
                int I = 0;

                foreach (Entrant ED in Top8)
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

            TBS.Add(tb_TeamP6);
            TBS.Add(tb_CarP6);

            TBS.Add(tb_TeamP7);
            TBS.Add(tb_CarP7);

            TBS.Add(tb_TeamP8);
            TBS.Add(tb_CarP8);
        }
    }
}
