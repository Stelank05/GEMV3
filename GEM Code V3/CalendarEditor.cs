using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace GEM_Code_V3
{
    public partial class CalendarEditor : Form
    {
        CommonData CD = new CommonData();
        RaceAdmin RA = new RaceAdmin();

        List<Round> Calendar = new List<Round>();
        List<CheckBox> RacingClasses = new List<CheckBox>();
        List<string> Classes = new List<string>();

        Round CurrentRound;

        public CalendarEditor()
        {
            InitializeComponent();

            Calendar = RA.GetCalendar();

            LoadCalendar();

            cb_LengthTypes.Items.Add("WEC");
            cb_LengthTypes.Items.Add("IMSA");
            cb_LengthTypes.Items.Add("Laps");

            LoadRacingClasses();
            LoadQualiFormats();
            LoadPointsSystems();
        }

        public static void UseMessageBox(string Text, string Header)
        {
            MessageBox.Show(Text, Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadCalendar()
        {
            lb_Calendar.Items.Clear();

            foreach (Round R in Calendar)
            {
                lb_Calendar.Items.Add(R.GetRoundName());
            }
        }

        public void Sort()
        {
            for (int i = 0; i < Calendar.Count - 1; i++)
            {
                bool Swap = false;

                for (int j = 0; j < Calendar.Count - i - 1; j++)
                {
                    if (Calendar[j].GetRoundNo() > Calendar[j + 1].GetRoundNo())
                    {
                        Swap = true;

                        (Calendar[j], Calendar[j + 1]) = (Calendar[j + 1], Calendar[j]);
                    }
                }

                if (!Swap)
                {
                    break;
                }
            }

            LoadCalendar();
        }

        private bool UniqueTitle(string RoundName, Round CurrentRound)
        {
            bool Unique = true;

            for (int i = 0; i < Calendar.Count; i++)
            {
                if (Calendar[i].GetRoundName() == RoundName && RoundName != CurrentRound.GetRoundName())
                {
                    Unique = false;
                    break;
                }
            }

            return Unique;
        }

        private bool UniqueTitle(string RoundName)
        {
            bool Unique = true;

            for (int i = 0; i < Calendar.Count; i++)
            {
                if (Calendar[i].GetRoundName() == RoundName)
                {
                    Unique = false;
                    break;
                }
            }

            return Unique;
        }

        private bool RaceLength(string LengthType, decimal Length)
        {
            bool Valid = true;

            Length = Math.Round(Length);

            if (Length < 1)
            {
                Valid = false;
            }

            else
            {
                if (LengthType == "WEC")
                {
                    if (Length > 24)
                    {
                        Valid = false;
                    }
                }

                if (LengthType == "IMSA")
                {
                    if (Length > 8)
                    {
                        Valid = false;
                    }
                }
            }

            return Valid;
        }

        private bool IncidentModifier(decimal Value)
        {
            bool Valid = false;

            Value= Math.Round(Value);

            if (Value >= 0 && Value <= 60)
            {
                Valid = true;
            }

            return Valid;
        }

        private bool DNFModifier(decimal Value)
        {
            bool Valid = false;

            Value = Math.Round(Value);

            if (Value > 1 && Value < 15)
            {
                Valid = true;
            }

            return Valid;
        }

        private bool RoundNumber(decimal Value)
        {
            bool Valid = false;

            Value = Math.Round(Value);

            if (Value >= 0)
            {
                Valid = true;
            }

            return Valid;
        }

        private bool PointsSystem(bool IsTest, int PointsSystem)
        {
            bool Valid = true;

            if (IsTest && PointsSystem == -1)
            {
                Valid = false;
            }

            return Valid;
        }

        private bool ClassesRacing()
        {
            bool Valid = false;

            foreach (CheckBox CB in RacingClasses)
            {
                if (CB.Checked)
                {
                    Valid = true;
                    break;
                }
            }

            return Valid;
        }

        public List<string> LoadStringClasses()
        {
            Classes.Clear();

            for (int i = 0; i < RacingClasses.Count; i++)
            {
                if (RacingClasses[i].Checked)
                {
                    Classes.Add("C" + Convert.ToString(i + 1));
                }
            }

            return Classes;
        }

        public void LoadRacingClasses()
        {
            RacingClasses.Add(cb_C1Racing); RacingClasses.Add(cb_C2Racing); RacingClasses.Add(cb_C3Racing); RacingClasses.Add(cb_C4Racing);
            RacingClasses.Add(cb_C5Racing); RacingClasses.Add(cb_C6Racing); RacingClasses.Add(cb_C7Racing); RacingClasses.Add(cb_C8Racing);
        }

        public void LoadQualiFormats()
        {
            List<string> Formats = new List<string>() { "A", "B", "C", "D", "E" };

            foreach (string F in Formats)
            {
                cb_QualifyingFormat.Items.Add(F);
            }
        }

        public void LoadPointsSystems()
        {
            string[] FileNames = Directory.GetFiles(Path.Combine(CD.GetPointsSystemsLocation(), "Race Systems"));

            foreach (string FN in FileNames)
            {
                string PS = FN.Replace(".csv", "");
                cb_PointsSystem.Items.Add(PS.Replace(@"C:\Users\Steph\Documents\Excel Sims\Global Endurance Masters\V3 Setup Files\Points Systems\Race Systems\System ", ""));
            }
        }

        private void Clear()
        {
            tb_RoundName.Text = "";
            cb_LengthTypes.SelectedIndex = -1;
            num_RaceLength.Value = 0;
            num_IncidentModifier.Value = 0;
            num_DNFModifier.Value = 0;
            num_RoundNo.Value = 0;
            cb_QualifyingFormat.SelectedIndex = -1;
            cb_PointsSystem.SelectedIndex = -1;

            foreach (CheckBox CB in RacingClasses)
            {
                CB.Checked = false;
            }
        }

        private void lb_Calendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Calendar.SelectedIndex > Calendar.Count - 1)
            {
                lb_Calendar.SelectedIndex = Calendar.Count - 1;
            }
        }

        private void btn_Sort_Click(object sender, EventArgs e)
        {
            Sort();
        }

        private void btn_DeleteRace_Click(object sender, EventArgs e)
        {
            Calendar.RemoveAt(lb_Calendar.SelectedIndex);
            LoadCalendar();
        }

        private void btn_SaveCalendar_Click(object sender, EventArgs e)
        {
            string FilePath = Path.Combine(CD.GetSetupPath(), "Calendar.csv");
            string WriteString = "Title:,Length:,Incident:,DNF:,,Length Type:,,Round No:,,Quali:,Points:,,Is Test:,,RacingClasses:";

            int Index = 0, RL = 0;

            foreach (Round R in Calendar)
            {
                if (R.GetLengthType() == "WEC")
                {
                    RL = R.GetRaceLength() / 2;
                }

                else
                {
                    RL = R.GetRaceLength();
                }

                WriteString += Environment.NewLine + R.GetRoundName() + "," + RL + "," + R.GetDefaultIncidentRate() + "," + R.GetDefaultDNFRate() + ",," + R.GetLengthType() + ",," + R.GetRoundNo() + ",," + R.GetQualiFormat() + "," + R.GetPointsSystem() + ",," + Convert.ToString(R.GetIsTest()) + ",";
                List<string> Classes = R.GetShortRacingClasses();

                foreach (string C in Classes)
                {
                    WriteString += "," + C;
                }

                Index++;
            }

            File.WriteAllText(FilePath, WriteString);
        }

        private void btn_UpdateRace_Click(object sender, EventArgs e)
        {
            if (lb_Calendar.SelectedIndex == -1 || tb_RoundName.Text == null || cb_LengthTypes.SelectedItem.ToString() == null)
            {
                MessageBox.Show("You have at least one null field, please rectify this before you can continue.", "Items Unselected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                bool ValidRoundName = UniqueTitle(tb_RoundName.Text, CurrentRound),
                    ValidRaceLength = RaceLength(cb_LengthTypes.SelectedItem.ToString(), num_RaceLength.Value),
                    ValidIncidentModifier = IncidentModifier(num_IncidentModifier.Value),
                    ValidDNFModifier = DNFModifier(num_DNFModifier.Value),
                    ValidRoundNo = RoundNumber(num_RoundNo.Value),
                    PointsSystemProvided = PointsSystem(cb_IsTest.Checked, cb_PointsSystem.SelectedIndex),
                    RacingClassesSelected = ClassesRacing();

                if (!ValidRoundName)
                {
                    tb_RoundName.Text = "INVALID";
                }

                if (!ValidRaceLength)
                {
                    num_RaceLength.Value = 0;
                }

                if (!ValidIncidentModifier)
                {
                    num_IncidentModifier.Value = 0;
                }

                if (!ValidDNFModifier)
                {
                    num_DNFModifier.Value = 0;
                }

                if (!ValidRoundNo)
                {
                    num_RoundNo.Value = 0;
                }

                if (!PointsSystemProvided && !cb_IsTest.Checked)
                {
                    MessageBox.Show("Please Enter a Points System, or Designate Round as a Test", "No Points System Provided", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!RacingClassesSelected)
                {
                    MessageBox.Show("Please Select at least 1 Class to Compete", "No Classes Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (ValidRoundName && ValidRaceLength && ValidIncidentModifier && ValidDNFModifier && ValidRoundNo && (PointsSystemProvided || cb_IsTest.Checked) && RacingClassesSelected)
                {
                    CurrentRound.SetRoundName(tb_RoundName.Text);
                    CurrentRound.SetLengthType(cb_LengthTypes.SelectedItem.ToString());
                    CurrentRound.SetRaceLength(Convert.ToInt32(num_RaceLength.Value));
                    CurrentRound.SetIncidentRate(Convert.ToInt32(num_IncidentModifier.Value));
                    CurrentRound.SetDNFRate(Convert.ToInt32(num_DNFModifier.Value));
                    CurrentRound.SetRacingClasses(LoadStringClasses());
                    CurrentRound.SetRoundNo(Convert.ToInt32(num_RoundNo.Value));
                    CurrentRound.SetQualiFormat(cb_QualifyingFormat.SelectedItem.ToString());

                    if (!cb_IsTest.Checked)
                    {
                        CurrentRound.SetPointsSystem(cb_PointsSystem.SelectedItem.ToString());
                        CurrentRound.SetIsTest("false");
                    }

                    else
                    {
                        CurrentRound.SetPointsSystem("N");
                        CurrentRound.SetIsTest("false");
                    }
                }
            }

            LoadCalendar();
        }

        private void btn_CreateRace_Click(object sender, EventArgs e)
        {
            if (tb_RoundName.Text == null || cb_LengthTypes.SelectedItem.ToString() == null || num_RaceLength.Value == 0 || num_IncidentModifier.Value == 0 || num_DNFModifier.Value == 0)
            {
                MessageBox.Show("You have at least one null field, please rectify this before you can continue.", "Items Unselected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                bool ValidRoundName = UniqueTitle(tb_RoundName.Text),
                    ValidRaceLength = RaceLength(cb_LengthTypes.SelectedItem.ToString(), num_RaceLength.Value),
                    ValidIncidentModifier = IncidentModifier(num_IncidentModifier.Value),
                    ValidDNFModifier = DNFModifier(num_DNFModifier.Value),
                    ValidRoundNo = RoundNumber(num_RoundNo.Value),
                    PointsSystemProvided = PointsSystem(cb_IsTest.Checked, cb_PointsSystem.SelectedIndex),
                    RacingClassesSelected = ClassesRacing();

                if (!ValidRoundName)
                {
                    tb_RoundName.Text = "INVALID";
                }

                if (!ValidRaceLength)
                {
                    num_RaceLength.Value = 0;
                }

                if (!ValidIncidentModifier)
                {
                    num_IncidentModifier.Value = 0;
                }

                if (!ValidDNFModifier)
                {
                    num_DNFModifier.Value = 0;
                }

                if (!ValidRoundNo)
                {
                    num_RoundNo.Value = 0;
                }

                if (!PointsSystemProvided && !cb_IsTest.Checked)
                {
                    MessageBox.Show("Please Enter a Points System, or Designate Round as a Test", "No Points System Provided", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!RacingClassesSelected)
                {
                    MessageBox.Show("Please Select at least 1 Class to Compete", "No Classes Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (ValidRoundName && ValidRaceLength && ValidIncidentModifier && ValidDNFModifier && ValidRoundNo && (PointsSystemProvided || cb_IsTest.Checked) && RacingClassesSelected)
                {
                    string PointsSystem = "";

                    if (cb_PointsSystem.SelectedIndex != -1)
                    {
                        PointsSystem = cb_PointsSystem.SelectedItem.ToString();
                    }

                    Calendar.Add(new Round(tb_RoundName.Text, Convert.ToInt32(num_RaceLength.Value), cb_LengthTypes.SelectedItem.ToString(), Convert.ToInt32(num_IncidentModifier.Value), Convert.ToInt32(num_DNFModifier.Value), Convert.ToInt32(num_RoundNo.Value), PointsSystem, cb_QualifyingFormat.SelectedItem.ToString(), cb_IsTest.Checked, LoadStringClasses(), CD));
                    LoadCalendar();
                }
            }
        }

        private void btn_SelectAllClasses_Click(object sender, EventArgs e)
        {
            foreach (CheckBox CB in RacingClasses)
            {
                CB.Checked = true;
            }
        }

        private void btn_DeselectAll_Click(object sender, EventArgs e)
        {
            foreach (CheckBox CB in RacingClasses)
            {
                CB.Checked = false;
            }
        }

        private void btn_SelectRace_Click(object sender, EventArgs e)
        {
            Clear();

            CurrentRound = Calendar[lb_Calendar.SelectedIndex];

            int RaceLength = 0;

            if (CurrentRound.GetLengthType() == "WEC")
            {
                RaceLength = CurrentRound.GetRaceLength() / 2;
            }

            else
            {
                RaceLength = CurrentRound.GetRaceLength();
            }

            tb_RoundName.Text = CurrentRound.GetRoundName();
            cb_LengthTypes.SelectedItem = CurrentRound.GetLengthType();
            num_RaceLength.Value = RaceLength;
            num_IncidentModifier.Value = CurrentRound.GetDefaultIncidentRate();
            num_DNFModifier.Value = CurrentRound.GetDefaultDNFRate();
            num_RoundNo.Value = CurrentRound.GetRoundNo();
            cb_QualifyingFormat.SelectedItem = CurrentRound.GetQualiFormat();
            cb_PointsSystem.SelectedItem = CurrentRound.GetPointsSystem();

            if (CurrentRound.GetIsTest())
            {
                cb_IsTest.Checked = true;
            }

            List<bool> CR = CurrentRound.GetBoolRacingClasses();

            for (int i = 0; i < CR.Count; i++)
            {
                if (CR[i])
                {
                    RacingClasses[i].Checked = true;
                }
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cb_LengthTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] Lengths = new int[3] { 24, 8, 700 };

            if (cb_LengthTypes.SelectedIndex != -1 && cb_LengthTypes.SelectedIndex < 3)
            {
                num_RaceLength.Maximum = Lengths[cb_LengthTypes.SelectedIndex];
            }
        }
    }
}
