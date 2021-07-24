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
    public partial class Miner_Home : Form
    {
        public Miner_Home()
        {
            InitializeComponent();
        }

        private void Miner_Home_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            ActiveForm.Hide();
            obj.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
            Miner_ViewRequest obj = new Miner_ViewRequest();
            obj.Show();

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            Hyperledger obj = new Hyperledger();
            obj.Show();

        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            Miner_Profile obj = new Miner_Profile();
            obj.Show();
        }

       
    }
}
