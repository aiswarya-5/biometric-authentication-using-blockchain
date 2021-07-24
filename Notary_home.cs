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
    public partial class Notary_home : Form
    {
        public Notary_home()
        {
            InitializeComponent();
        }

        private void Notary_home_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            ActiveForm.Hide();
            obj.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Notary_approve obj = new Notary_approve();
            obj.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            Hyperledger obj = new Hyperledger();
            obj.Show();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            Notary_ViewBlock obj = new Notary_ViewBlock();
            obj.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Notary_status obj = new Notary_status();
            obj.Show();
        }

        private void toolStripLabel9_Click(object sender, EventArgs e)
        {
            Notary_DeleteUser obj = new Notary_DeleteUser();
            obj.Show();
        }
    }
}
