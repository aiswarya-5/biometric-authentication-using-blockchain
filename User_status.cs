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
    public partial class User_status : Form
    {
        BaseConnection con = new BaseConnection();
        public static string id = "";
        public User_status()
        {
            InitializeComponent();
            id = Program.userid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string query1 = "select Dataid,Approved,Date,Time from Datatable where approved='Notary Approved' and Userid= '" + id + "' ";

                DataSet ds = con.ret_ds(query1);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;


                
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

                string query1 = "select Dataid,Approved,Date,Time from Datatable where approved='Not Approved' and Userid= '" + id + "' ";

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

                string query1 = "select Dataid,Approved,Date,Time from Datatable where approved='Blockchain added' and Userid= '" + id + "' ";

                DataSet ds1 = con.ret_ds(query1);
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;



            }
            catch (Exception ex)
            {
                MessageBox.Show("exception occured....");
            }
        }

        private void User_status_Load(object sender, EventArgs e)
        {

        }
    }
}
