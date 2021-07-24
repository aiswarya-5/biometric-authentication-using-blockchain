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
    public partial class Notary_approve : Form
    {
        BaseConnection con = new BaseConnection();
        public Notary_approve()
        {
            InitializeComponent();
            fillgrid();
            fillcombo();
        }
        public void fillgrid()
        {
            try
            {

                string query1 = "select Dataid,SHA,Userid,Date,Time from Datatable where approved='Not Approved'";

                DataSet ds1 = con.ret_ds(query1);
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;



            }
            catch (Exception ex)
            {
                MessageBox.Show("exception occured....");
            }
        }
        public void fillcombo()
        {
            comboBox1.Items.Clear();
            string query1 = "select Dataid from Datatable where approved='Not Approved'";
            SqlDataReader dr = con.ret_dr(query1);
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Notary_ViewData obj = new Notary_ViewData(comboBox1.Text);
            this.Close();
            obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Notary_approve_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
