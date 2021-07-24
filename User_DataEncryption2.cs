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

namespace BlockchainWithFingerprint
{
    public partial class User_DataEncryption2 : Form
    {
        BaseConnection con = new BaseConnection();
        public static string did = "";
        public static string sha = "";
        public static string filepathvirtual = "";
        public static string status = "Not Approved";
        public static string hdata = "";
        public User_DataEncryption2()
        {
            InitializeComponent();
        }
        public User_DataEncryption2(string d, string key, string s)
        {
            InitializeComponent();
            hdata = d.ToString();
            data.Text = s.ToString();
            textBox1.Text = key.ToString();
            sha = s.ToString();
            dataid();
        }
        private void User_DataEncryption2_Load(object sender, EventArgs e)
        {

        }
        public void dataid()
        {
            try
            {
                string query = "select isnull(max(Dataid),0)+1 from datatable";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {

                    did = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating data Id........");
            }
        }

        public void savedata()
        {
            
            string folderpath = Application.StartupPath + "\\data\\";
            if (Directory.Exists(folderpath))
            {

                if (!File.Exists(folderpath + did + ".txt"))
                {
                    StreamWriter strm = File.CreateText(folderpath + did + ".txt");
                    strm.Flush();
                    strm.Close();
                }
                if (File.Exists(folderpath + did + ".txt"))
                {
                    using (StreamWriter sw = File.AppendText(folderpath + did + ".txt"))
                    {
                        sw.WriteLine(richTextBox1.Text);

                    }


                }
                filepathvirtual = "\\data\\" + did + ".txt";

            }
        }
        public void registryadd()
        {
            string query = "insert into datatable values(" + did + ",'" + filepathvirtual + "','" + Program.userid + "','" + status + "','" + System.DateTime.Now.ToShortDateString() + "','" + System.DateTime.Now.ToShortTimeString() + "','" + sha + "')";
            if (con.exec1(query) > 0)
            {

                MessageBox.Show("Data Added... Waiting Notary Approval..");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataid();

            savedata();
            registryadd();

            this.Close();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cipher = Crypto.EncryptStringAES(hdata, Program.kkeys);

            richTextBox1.Text = cipher;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void data_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
