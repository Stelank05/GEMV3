using System;
using System.Windows.Forms;

namespace GEM_Code_V3
{
    public partial class UserConfirm : Form
    {
        bool UserSure = false;
        public UserConfirm()
        {
            InitializeComponent();
        }

        private void btn_ChooseYes_Click(object sender, EventArgs e)
        {
            UserSure = true;
            Close();
        }

        private void btn_ChooseNo_Click(object sender, EventArgs e)
        {
            UserSure = false;
            Close();
        }

        public bool GetUserSure()
        {
            return UserSure;
        }
    }
}
