using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class CrewMaker : Form
    {
        CommonData CD = new CommonData();
        RaceAdmin RA = new RaceAdmin();
        CarMaker CM = new CarMaker();

        List<Car> CarList;

        string FilePath = "";

        public CrewMaker()
        {
            InitializeComponent();

            LoadClasses();
        }

        private void LoadClasses()
        {
            for (int C = 0; C < CD.GetClassCount(); C++)
            {
                cb_Classes.Items.Add(CD.GetClasses(C).GetClassName());
            }
        }

        private void btnLocateFile_Click(object sender, EventArgs e)
        {
            if (FileLocator.ShowDialog() == DialogResult.OK)
            {
                FilePath = FileLocator.FileName;

                CarList = RA.LoadCars(FilePath);

                LoadCars();
            }
        }

        private void LoadCars()
        {
            lb_ChooseCar.Items.Clear();

            foreach (Car C in CarList)
            {
                lb_ChooseCar.Items.Add(C.GetCarName());
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            lb_ChooseCar.Items.Clear();
        }

        private void btn_MakeCar_Click(object sender, EventArgs e)
        {
            if (!CM.Valid(FilePath) || lb_ChooseCar.SelectedItem == null || tb_TN == null || tb_CN == null || tb_CS == null || tb_TS == null || tb_SRM == null || cb_Classes.SelectedItem == null)
            {
                MessageBox.Show("You have at least one null field, please rectify this before you can continue.", "Items Unselected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                bool CarNo = CM.CheckNumber(tb_CN.Text);
                bool CStat = CM.CheckStat(tb_CS.Text);
                bool TStat = CM.CheckStat(tb_TS.Text);
                bool CrewR = CM.CheckCrewReliability(tb_CR.Text);
                bool SRM = CM.CheckSRM(tb_SRM.Text);

                bool Match = false, Happy = true;

                if (CarList[lb_ChooseCar.SelectedIndex].GetClass() == Convert.ToString(cb_Classes.SelectedItem))
                {
                    Match = true;
                }

                if (!CarNo)
                {
                    tb_CN.Text = "INVALID";
                }

                if (!CStat)
                {
                    tb_CS.Text = "INVALID";
                }

                if (!TStat)
                {
                    tb_TS.Text = "INVALID";
                }

                if (!CrewR)
                {
                    tb_CR.Text = "INVALID";
                }

                if (!SRM)
                {
                    tb_SRM.Text = "INVALID";
                }

                if (!Match)
                {
                    Happy = false;

                    UserConfirm UC = new UserConfirm();
                    UC.Show();

                    Happy = UC.GetUserSure();
                }

                if (CarNo && CStat && TStat && CrewR && SRM && Happy)
                {
                    string Class = cb_Classes.SelectedItem.ToString();
                    int ArbitraryClass = cb_Classes.SelectedIndex;

                    int CarIndex = lb_ChooseCar.SelectedIndex;

                    int OVR = CarList[CarIndex].GetOVR() + CarList[CarIndex].GetBOP() + Convert.ToInt32(tb_CS.Text) + Convert.ToInt32(tb_TS.Text);
                    int Reliability = CarList[CarIndex].GetReliability() + Convert.ToInt32(tb_CR.Text);

                    string EntrantString = Class + ",#" + tb_CN.Text + "," + tb_TN.Text + "," + CarList[CarIndex].GetCarName() + "," + CarList[CarIndex].GetManufacturer() + "," + OVR + ",," + tb_SRM.Text + ",," + Reliability + ",," + Convert.ToString(cb_FullTimeEntry.Checked) + Environment.NewLine;

                    CM.WriteCar(EntrantString, ArbitraryClass + 1);
                }
            }
        }
    }
}
