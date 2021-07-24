using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BlockchainWithFingerprint
{
    public partial class Miner_edit : Form
    {
        BaseConnection con = new BaseConnection();
        public static string uid = "";
        public Miner_edit()
        {
            InitializeComponent();
            uid = Program.userid;
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Miner_edit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string q1 = "update minertable set name='" + n.Text + "',country='" + comboBox1.Text + "',mobile='" + no.Text + "',mailid='" + em.Text + "'  where userid='" + uid + "'";
            con.exec(q1);

            if (con.exec1(q1) > 0)
            {
                MessageBox.Show("Your Data is Succesfully Updated");
            }
            else
            {
                MessageBox.Show("Sorry !! an errr occured in Update");
            }

        }
    }
}
