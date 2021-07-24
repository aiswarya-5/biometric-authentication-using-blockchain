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
    public partial class Notary_ViewData : Form
    {
        BaseConnection con = new BaseConnection();
        public static string filepath = "";
        public static string userid = "";
        public static string docid = "";
        public Notary_ViewData()
        {
            InitializeComponent();
        }
        public Notary_ViewData(string did)
        {
            InitializeComponent();
            docid = did;
            loaddata(did);
        }

        public void loaddata(string f)
        {
            string query1 = "select filepath,userid from Datatable where dataid='" + f + "'";
            SqlDataReader dr = con.ret_dr(query1);
            if (dr.Read())
            {
                filepath = dr[0].ToString();
                userid = dr[1].ToString();

            }
            if (File.Exists(Application.StartupPath + "\\" + filepath))
            {
                // Read entire text file content in one string    
                string text = File.ReadAllText(Application.StartupPath + "\\" + filepath);
                data.Text = text;
            }

        }
        private void Notary_ViewData_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "update datatable set Approved='Notary Approved' where dataid= '" + docid + "' ";
            if(con.exec1(q)>0)
            {
                MessageBox.Show("Data Approved.. Waiting for Miner to add data to Blockchain");
                this.Close();
            }
        }

        private void data_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
