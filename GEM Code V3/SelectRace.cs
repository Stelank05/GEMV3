using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class SelectRace : Form
    {
        RaceAdmin RA = new RaceAdmin();
        CommonData CD = new CommonData();
        Random Rand = new Random();

        List<Round> Calendar = new List<Round>();

        public SelectRace()
        {
            InitializeComponent();

            Calendar = RA.GetCalendar();
            LoadCalendar(Calendar);

            SetSizes();
        }

        private void LoadCalendar(List<Round> Calendar)
        {
            for (int R = 0; R < Calendar.Count; R++)
            {
                lb_Calendar.Items.Add(Calendar[R].GetRoundName());
            }
        }

        private void SetSizes()
        {
            lb_Calendar.Height = 4 + (Calendar.Count * 16);

            int Location = 25 + lb_Calendar.Height; Location += 5 - (Location % 5);
            btn_ChooseRnd.Location = new System.Drawing.Point(20, Location);

            ClientSize = new System.Drawing.Size(195, (Location + 25 + 40 + 25) - 40);
        }

        private void btn_ChooseRnd_Click(object sender, EventArgs e)
        {
            if (lb_Calendar.SelectedItem == null)
            {
                MessageBox.Show("You haven't Selected a Race!" + Environment.NewLine + "Select One to be able to Race!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                int TestCount = 0;

                for (int i = 0; i < lb_Calendar.SelectedIndex; i++)
                {
                    if (Calendar[i].GetIsTest())
                    {
                        TestCount++;
                    }
                }

                CD.SetRoundNo(Calendar[lb_Calendar.SelectedIndex].GetRoundNo() - 1 + TestCount);

                SimRace SR = new SimRace(Calendar, CD, Rand);
                SR.Show();
            }
        }
    }
}
