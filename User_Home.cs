using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainWithFingerprint
{
    public partial class User_Home : Form
    {
        public User_Home()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            User_AddData obj = new User_AddData();
            obj.Show();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            ActiveForm.Hide();
            obj.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            Hyperledger obj = new Hyperledger();
            obj.Show();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            User_status obj = new User_status();
            obj.Show();
        }

        private void User_Home_Load(object sender, EventArgs e)
        {
           
            
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            User_viewData obj = new User_viewData();
            obj.Show();
        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {
            User_Profile obj = new User_Profile();
            obj.Show();
        }
    }
}
