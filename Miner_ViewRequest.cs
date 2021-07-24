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
    public partial class Miner_ViewRequest : Form
    {
        BaseConnection con = new BaseConnection();
        public Miner_ViewRequest()
        {
            InitializeComponent();
            fillcombo();
            fillgrid();
        }
        public void fillcombo()
        {
            comboBox1.Items.Clear();
            string query1 = "select Dataid from Datatable where approved='Notary Approved'";
            SqlDataReader dr = con.ret_dr(query1);
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }


        }

        public void fillgrid()
        {
            try
            {


                string query1 = "select Dataid,SHA,Userid,Date,Time from Datatable where approved='Notary Approved'";

                DataSet ds1 = con.ret_ds(query1);
                dataGridView2.DataSource = ds1.Tables[0].DefaultView;



            }
            catch (Exception ex)
            {
                MessageBox.Show("exception occured....");
            }
        }
        private void Miner_ViewRequest_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please Select Puzzle Type");
            }
            else
            {
                if (comboBox2.SelectedItem.ToString() == "Word Puzzle")
                {
                     MinerWordPuzzle obj = new MinerWordPuzzle(comboBox1.Text);
                     ActiveForm.Hide();
                     obj.Show();
                }
                else if (comboBox2.SelectedItem.ToString() == "Binary Puzzle")
                {
                     Miner_Puzzle obj = new Miner_Puzzle(comboBox1.Text); 
                     ActiveForm.Hide();
                     obj.Show();

                }
                else
                {
                    MessageBox.Show("Please Choose Puzzle Type");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
