using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace GEM_Code_V3
{
    public partial class ClassEditor : Form
    {
        CommonData CD = new CommonData();
        RaceAdmin RA = new RaceAdmin();

        List<Class> Classes = new List<Class>();

        Class CurrentClass;
        int ClassLocation;

        public ClassEditor()
        {
            InitializeComponent();

            LoadClasses();
        }

        private void LoadClasses()
        {
            lb_Classes.Items.Clear();

            ClassSort();

            for (int i = 0; i < CD.GetClassCount(); i++)
            {
                Classes.Add(CD.GetClasses(i));
                lb_Classes.Items.Add(Classes[i].GetClassName());
            }
        }

        private void ClassSort()
        {
            for (int i = 0; i < Classes.Count - 1; i++)
            {
                bool Swap = false;
                
                for (int j = 0; j < Classes.Count - i - 1; j++)
                {
                    if (Classes[j].GetClassIndex() > Classes[j + 1].GetClassIndex())
                    {
                        Swap = true;

                        (Classes[j], Classes[j + 1]) = (Classes[j + 1], Classes[j]);
                    }
                }

                if (!Swap)
                {
                    break;
                }
            }
        }

        private bool UniqueName(string ClassName, Class CurrentClass)
        {
            bool Unique = true;

            for (int i = 0; i < Classes.Count; i++)
            {
                if (Classes[i].GetClassName() == ClassName && CurrentClass.GetClassName() != ClassName)
                {
                    Unique = false;
                    break;
                }
            }

            return Unique;
        }

        private bool UniqueName(string ClassName)
        {
            bool Unique = true;

            for (int i = 0; i < Classes.Count; i++)
            {
                if (Classes[i].GetClassName() == ClassName)
                {
                    Unique = false;
                    break;
                }
            }

            return Unique;
        }

        private bool IncidentModifier(decimal Value)
        {
            bool Valid = false;

            Value = Math.Round(Value);

            if (Value >= -10 && Value <= 60)
            {
                Valid = true;
            }

            return Valid;
        }

        private bool DNFModifier(decimal Value)
        {
            bool Valid = false;

            Value = Math.Round(Value);

            if (Value >= -5 && Value <= 15)
            {
                Valid = true;
            }

            return Valid;
        }

        private bool ValidOVRs(decimal MinOVR, decimal MaxOVR)
        {
            bool Valid = false;

            MinOVR = Math.Round(MinOVR);
            MaxOVR = Math.Round(MaxOVR);

            if (MinOVR >= 0 && MaxOVR >= 1 && MinOVR < MaxOVR)
            {
                Valid = true;
            }

            return Valid;
        }

        private bool ValidRanges(decimal MinStint, decimal MaxStint, decimal Incident)
        {
            bool Valid = false;

            MinStint = Math.Round(MinStint);
            MaxStint = Math.Round(MaxStint);
            Incident = Math.Round(Incident);

            if (MinStint >= 5 && MaxStint >= 7 && MinStint < MaxStint && MinStint > Incident)
            {
                Valid = true;
            }

            return Valid;
        }

        private bool ValidDTPs(decimal WEC, decimal IMSA, decimal Lap)
        {
            bool Valid = false;

            WEC = Math.Round(WEC);
            IMSA = Math.Round(IMSA);
            Lap = Math.Round(Lap);

            if (WEC > 0 && WEC < 25 && IMSA > 0 && IMSA < 9 && Lap > 0)
            {
                Valid = true;
            }

            return Valid;
        }

        private bool ValidCI(decimal CI)
        {
            bool Valid = false;

            CI = Math.Round(CI);

            if (CI > 0 || CI < Classes.Count + 1)
            {
                Valid = true;
            }

            return Valid;
        }

        private void btn_SelectClass_Click(object sender, EventArgs e)
        {
            CurrentClass = CD.GetClasses(lb_Classes.SelectedIndex);
            ClassLocation = lb_Classes.SelectedIndex;

            tb_ClassName.Text = CurrentClass.GetClassName();
            num_IncidentModifier.Value = CurrentClass.GetIRM();
            num_DNFModifier.Value = CurrentClass.GetDNFRM();
            num_MinOVR.Value = CurrentClass.GetMinOVR();
            num_MaxOVR.Value = CurrentClass.GetMaxOVR();
            num_StintRangeLow.Value = CurrentClass.GetSRLow();
            num_StintRangeHigh.Value = CurrentClass.GetSRHigh();
            num_StintRangeIncident.Value = CurrentClass.GetSRInc();
            num_WECDTP.Value = CurrentClass.GetWECDTP();
            num_IMSADTP.Value = CurrentClass.GetIMSADTP();
            num_LapDTP.Value = CurrentClass.GetLapDTP();
            num_ClassIndex.Value = CurrentClass.GetClassIndex();
        }

        private void btn_UpdateClass_Click(object sender, EventArgs e)
        {
            if (lb_Classes.SelectedIndex == -1 || tb_ClassName.Text == null)
            {
                MessageBox.Show("You have at least one null field, please rectify this before you can continue.", "Items Unselected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                bool ValidClassName = UniqueName(tb_ClassName.Text, CurrentClass),
                    ValidIncidentModifier = IncidentModifier(num_IncidentModifier.Value),
                    ValidDNFModifier = DNFModifier(num_DNFModifier.Value),
                    ValidOVRValues = ValidOVRs(num_MinOVR.Value, num_MaxOVR.Value),
                    ValidStintRanges = ValidRanges(num_StintRangeLow.Value, num_StintRangeHigh.Value, num_StintRangeIncident.Value),
                    ValidDistanceToPit = ValidDTPs(num_WECDTP.Value, num_IMSADTP.Value, num_LapDTP.Value),
                    ValidClassIndex = ValidCI(num_ClassIndex.Value);

                if (!ValidClassName)
                {
                    tb_ClassName.Text = "INVALID";
                }

                if (!ValidIncidentModifier)
                {
                    num_IncidentModifier.Value = 0;
                }

                if (!ValidDNFModifier)
                {
                    num_DNFModifier.Value = 0;
                }

                if (!ValidOVRValues)
                {
                    num_MinOVR.Value = 0;
                    num_MaxOVR.Value = 0;
                }

                if (!ValidStintRanges)
                {
                    num_StintRangeLow.Value = 0;
                    num_StintRangeHigh.Value = 0;
                    num_StintRangeIncident.Value = 0;
                }

                if (!ValidDistanceToPit)
                {
                    num_WECDTP.Value = 0;
                    num_IMSADTP.Value = 0;
                    num_LapDTP.Value = 0;
                }

                if (!ValidClassIndex)
                {
                    num_ClassIndex.Value = 0;
                }

                if (ValidClassName && ValidIncidentModifier && ValidDNFModifier && ValidOVRValues && ValidStintRanges && ValidDistanceToPit)
                {
                    CurrentClass.SetClassName(tb_ClassName.Text);
                    CurrentClass.SetIRM(Convert.ToInt32(Math.Round(num_IncidentModifier.Value)));
                    CurrentClass.SetDNFRM(Convert.ToInt32(Math.Round(num_DNFModifier.Value)));
                    CurrentClass.SetMinOVR(Convert.ToInt32(Math.Round(num_MinOVR.Value)));
                    CurrentClass.SetMaxOVR(Convert.ToInt32(Math.Round(num_MaxOVR.Value)));
                    CurrentClass.SetSRLow(Convert.ToInt32(Math.Round(num_StintRangeLow.Value)));
                    CurrentClass.SetSRHigh(Convert.ToInt32(Math.Round(num_StintRangeHigh.Value)));
                    CurrentClass.SetSRInc(Convert.ToInt32(Math.Round(num_StintRangeIncident.Value)));
                    CurrentClass.SetWECDTP(Convert.ToInt32(Math.Round(num_WECDTP.Value)));
                    CurrentClass.SetIMSADTP(Convert.ToInt32(Math.Round(num_IMSADTP.Value)));
                    CurrentClass.SetLapDTP(Convert.ToInt32(Math.Round(num_LapDTP.Value)));
                    CurrentClass.SetClassIndex(Convert.ToInt32(Math.Round(num_ClassIndex.Value)));

                    //LoadClasses();
                }
            }
        }

        private void btn_DeleteClass_Click(object sender, EventArgs e)
        {
            Classes.RemoveAt(ClassLocation);

            LoadClasses();
        }

        private void btn_CreateClass_Click(object sender, EventArgs e)
        {
            if (lb_Classes.SelectedIndex == -1 || tb_ClassName.Text == null)
            {
                MessageBox.Show("You have at least one null field, please rectify this before you can continue.", "Items Unselected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                bool ValidClassName = UniqueName(tb_ClassName.Text),
                    ValidIncidentModifier = IncidentModifier(num_IncidentModifier.Value),
                    ValidDNFModifier = DNFModifier(num_DNFModifier.Value),
                    ValidOVRValues = ValidOVRs(num_MinOVR.Value, num_MaxOVR.Value),
                    ValidStintRanges = ValidRanges(num_StintRangeLow.Value, num_StintRangeHigh.Value, num_StintRangeIncident.Value),
                    ValidDistanceToPit = ValidDTPs(num_WECDTP.Value, num_IMSADTP.Value, num_LapDTP.Value),
                    ValidClassIndex = ValidCI(num_ClassIndex.Value);

                if (Classes.Count == 8)
                {
                    MessageBox.Show("You cannot have more than 8 Classes.", "Class Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!ValidClassName)
                {
                    tb_ClassName.Text = "INVALID";
                }

                if (!ValidIncidentModifier)
                {
                    num_IncidentModifier.Value = 0;
                }

                if (!ValidDNFModifier)
                {
                    num_DNFModifier.Value = 0;
                }

                if (!ValidOVRValues)
                {
                    num_MinOVR.Value = 0;
                    num_MaxOVR.Value = 0;
                }

                if (!ValidStintRanges)
                {
                    num_StintRangeLow.Value = 0;
                    num_StintRangeHigh.Value = 0;
                    num_StintRangeIncident.Value = 0;
                }

                if (!ValidDistanceToPit)
                {
                    num_WECDTP.Value = 0;
                    num_IMSADTP.Value = 0;
                    num_LapDTP.Value = 0;
                }

                if (!ValidClassIndex)
                {
                    num_ClassIndex.Value = 0;
                }

                if (Classes.Count < 8 && ValidClassName && ValidIncidentModifier && ValidDNFModifier && ValidOVRValues && ValidStintRanges && ValidDistanceToPit)
                {
                    Classes.Add(new Class(tb_ClassName.Text, Convert.ToInt32(Math.Round(num_IncidentModifier.Value)), Convert.ToInt32(Math.Round(num_DNFModifier.Value)), Convert.ToInt32(Math.Round(num_StintRangeLow.Value)), Convert.ToInt32(Math.Round(num_StintRangeHigh.Value)), Convert.ToInt32(Math.Round(num_StintRangeIncident.Value)), Convert.ToInt32(Math.Round(num_ClassIndex.Value)), Convert.ToInt32(Math.Round(num_MinOVR.Value)), Convert.ToInt32(Math.Round(num_MaxOVR.Value)), Convert.ToInt32(Math.Round(num_WECDTP.Value)), Convert.ToInt32(Math.Round(num_IMSADTP.Value)), Convert.ToInt32(Math.Round(num_LapDTP.Value))));
                    
                    LoadClasses();
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string FilePath = Path.Combine(CD.GetSetupPath(), "Class Setup.csv");
            string WriteString = "Arbitrary,Name,I Range,DNF Rate,,SR - High,SR - Low,SR - Inc,,Min OVR,Max OVR,,STS - WEC,STS - IMSA,STS - Laps";

            ClassSort();

            for (int i = 0; i < Classes.Count; i++)
            {
                Class CC = Classes[i];
                WriteString += Environment.NewLine + "C" + Convert.ToString(i + 1) + ":," + CC.GetClassName() + "," + CC.GetIRM() + "," + CC.GetDNFRM() + ",," + CC.GetSRHigh() + "," + CC.GetSRLow () + "," + CC.GetSRInc() + ",," + CC.GetMinOVR() + "," + CC.GetMaxOVR() + ",," + CC.GetWECDTP() + "," + CC.GetIMSADTP() + "," + CC.GetLapDTP();
            }

            for (int i = Classes.Count; i < 8; i++)
            {
                WriteString += Environment.NewLine + "C" + Convert.ToString(i + 1) + ":";
            }

            File.WriteAllText(FilePath, WriteString);
        }
    }
}
