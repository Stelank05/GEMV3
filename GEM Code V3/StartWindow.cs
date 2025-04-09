using System;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void btn_SelectRace_Click(object sender, EventArgs e)
        {
            SelectRace SR = new SelectRace();
            SR.Show();
        }

        private void btn_EditCalendar_Click(object sender, EventArgs e)
        {
            CalendarEditor CE = new CalendarEditor();
            CE.Show();
        }

        private void btn_CreateCrew_Click(object sender, EventArgs e)
        {
            CrewMaker MC = new CrewMaker();
            MC.Show();
        }

        private void btn_DeleteCrew_Click(object sender, EventArgs e)
        {
            DeleteCrews CD = new DeleteCrews();
            CD.Show();
        }

        private void btn_EditCars_Click(object sender, EventArgs e)
        {
            CarEditor CE = new CarEditor();
            CE.Show();
        }

        private void btn_ClassEditor_Click(object sender, EventArgs e)
        {
            ClassEditor CE = new ClassEditor();
            CE.Show();
        }

        private void btn_CreateStandings_Click(object sender, EventArgs e)
        {
            CreateStandings CD = new CreateStandings();
            CD.Show();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            UserSure US = new UserSure();
            US.Show();
        }
    }
}
