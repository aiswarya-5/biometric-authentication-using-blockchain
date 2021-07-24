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
    public partial class Hyperledger : Form
    {
        BaseConnection con = new BaseConnection();

        public Hyperledger()
        {
            InitializeComponent();
            fillgrid();
        }

        private void Hyperledger_Load(object sender, EventArgs e)
        {

        }
        public void fillgrid()
        {
            try
            {
                string query1 = "select Ledgerid,blockid,miner from ledger";
                DataSet ds1 = con.ret_ds(query1);
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;

            }
            catch(Exception e)
            {
                MessageBox.Show("An Exception Occured");
            }
        }
    }
}
