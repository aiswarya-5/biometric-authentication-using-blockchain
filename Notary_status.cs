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
    public partial class Notary_status : Form
    {
        BaseConnection con = new BaseConnection();
        public Notary_status()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string query1 = "select Dataid,Userid,Date,Time from Datatable where approved='Notary Approved'";

                DataSet ds1 = con.ret_ds(query1);
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;



            }
            catch (Exception ex)
            {
                MessageBox.Show("exception occured....");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string query1 = "select Dataid,Userid,Date,Time from Datatable where approved='Not Approved'";

                DataSet ds1 = con.ret_ds(query1);
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;



            }
            catch (Exception ex)
            {
                MessageBox.Show("exception occured....");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string query1 = "select Dataid,Userid,Date,Time from Datatable where approved='Blockchain added'";

                DataSet ds1 = con.ret_ds(query1);
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;



            }
            catch (Exception ex)
            {
                MessageBox.Show("exception occured....");
            }
        }
    }
}
