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
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace BlockchainWithFingerprint
{
    public partial class User_viewData : Form
    {
        BaseConnection con = new BaseConnection();
        public User_viewData()
        {
            InitializeComponent();
            fillcombo();
        }

        private void User_viewData_Load(object sender, EventArgs e)
        {

        }
        public void fillcombo()
        {
            comboBox1.Items.Clear();
            string query1 = "select Dataid from Datatable where approved='Blockchain added' and userid='" + Program.userid + "'";
            SqlDataReader dr = con.ret_dr(query1);
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string raw = Crypto.DecryptStringAES(data.Text, Program.kkeys);
            textBox2.Text = raw;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            datablock(comboBox1.Text);
        }
        public void datablock(string id)
        {
            try
            {
                string path = "";
                string hash = "";
                string date = " ";
                string time = " ";
                string query = "select * from datatable where dataid='" + id + "'";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {

                    path = dr[1].ToString();
                    date = dr[4].ToString();
                    time = dr[5].ToString();
                    hash = dr[6].ToString();
                }
                if (File.Exists(Application.StartupPath + "\\" + path))
                {
                    // Read entire text file content in one string    
                    string text = File.ReadAllText(Application.StartupPath + "\\" + path);
                    data.Text = text;
                }
                sha.Text = hash;
                d.Text = date;
                t.Text = time;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating block Id........");
            }
        }
    }
}
