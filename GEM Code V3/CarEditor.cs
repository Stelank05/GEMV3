using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace GEM_Code_V3
{
    public partial class CarEditor : Form
    {
        CommonData CD = new CommonData();
        RaceAdmin RA = new RaceAdmin();
        CarMaker CM = new CarMaker();

        List<Car> CarList;
        Car SelectedCar;

        string FilePath;

        public CarEditor()
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

        private void LoadCars()
        {
            lb_ChooseCar.Items.Clear();

            foreach (Car C in CarList)
            {
                lb_ChooseCar.Items.Add(C.GetCarName());
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

        private void lb_ChooseCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedIndex = lb_ChooseCar.SelectedIndex;

            if (SelectedIndex > -1 && SelectedIndex < CarList.Count)
            {
                SelectedCar = CarList[SelectedIndex];

                int ClassIndex = -1;

                for (int i = 0; i < CD.GetClassCount(); i++)
                {
                    if (SelectedCar.GetClass() == CD.GetClasses(i).GetClassName())
                    {
                        ClassIndex = i;
                    }
                }

                tb_CN.Text = SelectedCar.GetCarName();
                tb_Manufacturer.Text = SelectedCar.GetManufacturer();
                tb_OVR.Text = Convert.ToString(SelectedCar.GetOVR());
                tb_BOP.Text = Convert.ToString(SelectedCar.GetBOP());
                tb_Reliability.Text = Convert.ToString(SelectedCar.GetReliability());
                cb_Classes.SelectedIndex = ClassIndex;
            }

            else
            {
                MessageBox.Show("Selected Index outside Usable Range.", "Index Outside Range", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            lb_ChooseCar.Items.Clear();

            tb_CN.Text = null;
            tb_Manufacturer.Text = null;
            tb_OVR.Text = null;
            tb_BOP.Text = null;
            tb_Reliability.Text = null;
            cb_Classes.SelectedItem = null;
        }

        private void btn_UpdateCar_Click(object sender, EventArgs e)
        {
            if (!CM.Valid(FilePath) || tb_CN.Text == null || tb_Manufacturer.Text == null || tb_OVR.Text == null || tb_BOP.Text == null || tb_Reliability.Text == null || cb_Classes.SelectedIndex == -1)
            {
                MessageBox.Show("You have at least one null field, please rectify this before you can continue.", "Items Unselected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                bool ValidOVR = CheckOVR(tb_OVR.Text, cb_Classes.SelectedIndex);
                bool ValidBOP = CheckBOP(tb_BOP.Text);
                bool ValidRel = CheckRel(tb_Reliability.Text);

                if (!ValidOVR)
                {
                    tb_OVR.Text = "INVALID";
                }

                if (!ValidBOP)
                {
                    tb_BOP.Text = "INVALID";
                }

                if (!ValidRel)
                {
                    tb_Reliability.Text = "INVALID";
                }

                if (ValidOVR && ValidBOP && ValidRel && cb_Classes.SelectedItem.ToString() != null)
                {
                    SelectedCar.UpdateCarName(tb_CN.Text);
                    SelectedCar.UpdateManufacturer(tb_Manufacturer.Text);
                    SelectedCar.UpdateOVR(Convert.ToInt32(tb_OVR.Text));
                    SelectedCar.UpdateBOP(Convert.ToInt32(tb_BOP.Text));
                    SelectedCar.UpdateReliability(Convert.ToInt32(tb_Reliability.Text));
                    SelectedCar.UpdateClass(cb_Classes.SelectedItem.ToString());

                    LoadCars();
                }
            }
        }

        private void btn_CreateCar_Click(object sender, EventArgs e)
        {
            if (!CM.Valid(FilePath) || tb_CN.Text == null || tb_OVR.Text == null || tb_BOP.Text == null || tb_Reliability.Text == null || cb_Classes.SelectedItem.ToString() == null)
            {
                MessageBox.Show("You have at least one null field, please rectify this before you can continue.", "Items Unselected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                bool ValidNam = CheckName(tb_CN.Text);
                bool ValidOVR = CheckOVR(tb_OVR.Text, cb_Classes.SelectedIndex);
                bool ValidBOP = CheckBOP(tb_BOP.Text);
                bool ValidRel = CheckRel(tb_Reliability.Text);

                if (!ValidNam)
                {
                    tb_CN.Text = "INVALID";
                }

                if (!ValidOVR)
                {
                    tb_OVR.Text = "INVALID";
                }

                if (!ValidBOP)
                {
                    tb_BOP.Text = "INVALID";
                }

                if (!ValidRel)
                {
                    tb_Reliability.Text = "INVALID";
                }

                if (ValidNam && ValidOVR && ValidBOP && ValidRel && cb_Classes.SelectedItem.ToString() != null)
                {
                    CarList.Add(new Car(cb_Classes.SelectedItem.ToString(), tb_CN.Text, tb_Manufacturer.Text, Convert.ToInt32(tb_OVR.Text), Convert.ToInt32(tb_BOP.Text), Convert.ToInt32(tb_Reliability.Text)));
                    LoadCars();
                }
            }
        }

        private void btn_DeleteCar_Click(object sender, EventArgs e)
        {
            CarList.Remove(SelectedCar);

            LoadCars();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string WriteString = "";

            foreach (Car CL in CarList)
            {
                WriteString += CL.GetCarAsWriteString() + Environment.NewLine;
            }

            File.WriteAllText(FilePath, WriteString);
        }

        public bool CheckName(string CarName)
        {
            bool Unique = true;

            List<string> Classes = new List<string>() { "G56", "GT3", "GTE", "HC", "P1", "P2", "P3" };

            for (int FC = 0; FC < 7; FC++)
            {
                string FilePath = Path.Combine(CD.GetFilePath(), "Car Data", Classes[FC] + ".csv");

                string[] UsedNumbers = File.ReadAllLines(FilePath);

                int TotalUsed = File.ReadAllLines(FilePath).Length;

                if (TotalUsed > 1)
                {
                    for (int i = 0; i < TotalUsed; i++)
                    {
                        string[] CarNumber = UsedNumbers[i].Split(',');

                        if (CarNumber[1] == CarName)
                        {
                            Unique = false;
                            break;
                        }
                    }
                }

                else if (UsedNumbers[0].Split('0')[0] != "")
                {
                    string[] CarNumber = UsedNumbers[0].Split(',');

                    if (CarNumber[1] == CarName)
                    {
                        Unique = false;
                        break;
                    }
                }

                else
                {
                    break;
                }
            }

            return Unique;
        }

        public bool CheckOVR(string Stat, int Class)
        {
            bool bStat = int.TryParse(Stat, out int iStat);

            if (bStat)
            {
                if (iStat < CD.GetClasses(Class).GetMinOVR() || iStat > CD.GetClasses(Class).GetMaxOVR())
                {
                    bStat = false;
                }
            }

            return bStat;
        }

        public bool CheckBOP(string Stat)
        {
            bool bStat = int.TryParse(Stat, out int iStat);

            if (bStat)
            {
                if (iStat < -60 || iStat > 60)
                {
                    bStat = false;
                }
            }

            return bStat;
        }

        public bool CheckRel(string Stat)
        {
            bool bStat = int.TryParse(Stat, out int iStat);

            if (bStat)
            {
                if (iStat < 60 || iStat > 100)
                {
                    bStat = false;
                }
            }

            return bStat;
        }
    }
}
