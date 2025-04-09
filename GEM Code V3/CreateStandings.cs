using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace GEM_Code_V3
{
    public partial class CreateStandings : Form
    {
        CommonData CD = new CommonData();
        RaceAdmin RA = new RaceAdmin();

        List<Entrant> Entrants = new List<Entrant>();

        int ClassIndex;
        string EntrantsFilePath, StandingsFilePathCrew, StandingsFilePathTeams, StandingsFilePathManufacturers;

        public CreateStandings()
        {
            InitializeComponent();

            LoadClasses();
        }

        public void LoadClasses()
        {
            for (int i = 0; i < CD.GetClassCount(); i++)
            {
                lb_Classes.Items.Add(CD.GetClasses(i).GetClassName());
            }
        }

        private void btn_SelectClass_Click(object sender, EventArgs e)
        {
            ClassIndex = lb_Classes.SelectedIndex;

            EntrantsFilePath = Path.Combine(CD.GetSetupPath(), "Entrants", "Class " + Convert.ToString(ClassIndex + 1) + ".csv");
            StandingsFilePathCrew = Path.Combine(CD.GetStandingsLocation(), "Crew", "Class " + Convert.ToString(ClassIndex + 1) + ".csv");
            StandingsFilePathTeams = Path.Combine(CD.GetStandingsLocation(), "Teams", "Class " + Convert.ToString(ClassIndex + 1) + ".csv");
            StandingsFilePathManufacturers = Path.Combine(CD.GetStandingsLocation(), "Manufacturers", "Class " + Convert.ToString(ClassIndex + 1) + ".csv");

            tb_DisplayClass.Text = CD.GetClasses(ClassIndex).GetClassName();

            Entrants.Clear();
            Entrants = RA.LoadEntrants(EntrantsFilePath, lb_Classes.SelectedIndex);
        }

        private void btn_CreateCrewStandings_Click(object sender, EventArgs e)
        {
            string WriteString = "";

            foreach (Entrant E in Entrants)
            {
                WriteString += E.GetClass() + "," + E.GetCarNo() + "," + E.GetTeamName() + "," + E.GetCar() + ",0" + Environment.NewLine;
            }

            WriteFile(StandingsFilePathCrew, WriteString);
        }

        private void btn_CreateTeamsStandings_Click(object sender, EventArgs e)
        {
            string WriteString = "";

            List<string> Teams = new List<string>();

            foreach (Entrant E in Entrants)
            {
                if (!ExistsInList(Teams, E.GetTeamName()))
                {
                    Teams.Add(E.GetTeamName());

                    WriteString += E.GetClass() + "," + E.GetTeamName() + ",0" + Environment.NewLine;
                }
            }

            WriteFile(StandingsFilePathTeams, WriteString);
        }

        private void lb_Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Classes.SelectedIndex >= CD.GetClassCount())
            {
                lb_Classes.SelectedIndex = CD.GetClassCount() - 1;
            }
        }

        private void btn_CreateManufacturersStandings_Click(object sender, EventArgs e)
        {
            string WriteString = "";

            List<string> Manufacturers = new List<string>();

            foreach (Entrant E in Entrants)
            {
                if (!ExistsInList(Manufacturers, E.GetManufacturer()))
                {
                    Manufacturers.Add(E.GetManufacturer());

                    WriteString += E.GetClass() + "," + E.GetManufacturer() + ",0" + Environment.NewLine;
                }
            }

            WriteFile(StandingsFilePathManufacturers, WriteString);
        }

        private bool ExistsInList(List<string> CheckList, string CheckItem)
        {
            bool Exists = false;

            foreach (string Item in CheckList)
            {
                if (Item == CheckItem)
                {
                    Exists = true;
                    break;
                }
            }

            return Exists;
        }

        private void WriteFile(string FilePath, string WriteString)
        {
            if (FilePath != null)
            {
                try
                {
                    File.WriteAllText(FilePath, WriteString);
                }

                catch
                {
                    CalendarEditor.UseMessageBox("Please Close File '" + FilePath + "'", "Open File");
                    WriteFile(FilePath, WriteString);
                }
            }

            else
            {
                CalendarEditor.UseMessageBox("Please Select a Class", "No Class Selected");
            }
        }
    }
}
