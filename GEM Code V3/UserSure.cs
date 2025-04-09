using System;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class UserSure : Form
    {
        public UserSure()
        {
            InitializeComponent();
        }

        private void btn_ChooseYes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ChooseNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
