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
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;

namespace BlockchainWithFingerprint
{
    public partial class Miner_AddBlock : Form
    {
        BaseConnection con = new BaseConnection();
        public static string blockid = "";
        public Miner_AddBlock()
        {
            InitializeComponent();
        }
        public Miner_AddBlock(string id)
        {
            InitializeComponent();
            dataid.Text = id;
            checkblocks();
            Blockid();
            nounce();
            datablock(id);
            textBox4.Text = System.DateTime.Now.ToShortDateString();

        }
        public static string Generatehash(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public void checkblocks()
        {
            try
            {
                int c = 0;
                string query = "select count(Blockid) from Blocks";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {

                    c = Convert.ToInt32(dr[0].ToString());
                }
                if (c == 0)
                {
                    textBox3.Text = Generatehash(Program.Alphadata);
                }
                else
                {
                    string query1 = "select max(Blockid) from Blocks";
                    SqlDataReader dr1 = con.ret_dr(query1);
                    if (dr1.Read())
                    {
                        string bbid = dr1[0].ToString();
                        string qu = "select hash from blocks where blockid='" + bbid + "'";
                        SqlDataReader dr11 = con.ret_dr(qu);
                        if (dr11.Read())
                        {
                            textBox3.Text = dr11[0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating block Id........");
            }
        }

        public void nounce()
        {
            Random random = new System.Random();
            int value = random.Next(10000, 99999);
            nouncetxt.Text = value.ToString();
        }

        public void ledger()
        {
            string lid = "";
            string query = "select isnull(max(LedgerID),100)+1 from Ledger";
            SqlDataReader dr = con.ret_dr(query);
            if (dr.Read())
            {

                lid = dr[0].ToString();

            }

            string q = "insert into ledger values(" + lid + ",'" + bid.Text + "','" + Program.userid + "','" + dataid.Text + "')";
            con.exec(q);


        }
        public void Blockid()
        {
            try
            {
                string query = "select isnull(max(Blockid),100)+1 from Blocks";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {

                    blockid = dr[0].ToString();
                    bid.Text = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating block Id........");
            }
        }

        public void datablock(string id)
        {
            try
            {
                string path = "";
                string hash = "";
                string query = "select * from datatable where dataid='" + id + "'";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {

                    path = dr[1].ToString();
                    hash = dr[6].ToString();
                }
                if (File.Exists(Application.StartupPath + "\\" + path))
                {
                    // Read entire text file content in one string    
                    string text = File.ReadAllText(Application.StartupPath + "\\" + path);
                    richTextBox1.Text = text;
                }
                textBox5.Text = hash;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating block Id........");
            }
        }
        private void Miner_AddBlock_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ac = "accessible";
            string query = "insert into blocks values(" + blockid + ",'" + nouncetxt.Text + "','" + dataid.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + ac + "')";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Data added to Blockchain");
               
                ledger();
                string q = "update datatable set Approved='Blockchain added' where dataid='" + dataid.Text + "'";
                con.exec1(q);
                MinerBlockChain obj = new MinerBlockChain(richTextBox1.Text);
                ActiveForm.Hide();
                obj.Show();
                
            }
        }
    }
}
