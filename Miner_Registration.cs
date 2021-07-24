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
    public partial class Miner_Registration : Form
    {
        BaseConnection con = new BaseConnection();
        public static string uid = "";
        public Miner_Registration()
        {
            InitializeComponent();
            userid();
        }
        public void userid()
        {
            try
            {
                string query = "select isnull(max(Userid),100)+1 from Login";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {
                    Program.userid = dr[0].ToString();
                    uid = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating user Id........");
            }
        }

        private void Miner_home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usertype = "Miner";
            string query = "insert into login values(" + uid + ",'" + user.Text + "','" + pwd.Text + "','" + usertype + "')";
            if (con.exec1(query) > 0)
            {
                string query1 = "insert into MinerTable values('" + uid + "','" + name.Text + "','" + country.Text + "','" + mob.Text + "','" + mail.Text + "')";
                if (con.exec1(query1) > 0)
                {
                   
                    MessageBox.Show("Miner Registered Successfully....");
                    this.Close();


                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string usertype = "Miner";
            string query = "insert into login values(" + uid + ",'" + user.Text + "','" + pwd.Text + "','" + usertype + "')";
            if (con.exec1(query) > 0)
            {
                string query1 = "insert into MinerTable values('" + uid + "','" + name.Text + "','" + country.Text + "','" + mob.Text + "','" + mail.Text + "')";
                if (con.exec1(query1) > 0)
                {

                    MessageBox.Show("Miner Registered Successfully....");
                    this.Close();


                }

            }
        }
    }
}
