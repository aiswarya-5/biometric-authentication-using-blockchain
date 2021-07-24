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
    public partial class Miner_Base : Form
    {
        public Miner_Base()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }

        }
        private void Miner_Registration_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Miner_Home obj = new Miner_Home();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
