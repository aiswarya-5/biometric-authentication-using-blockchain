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
    public partial class Notary_DeleteUser : Form
    {
        BaseConnection con = new BaseConnection();
        public Notary_DeleteUser()
        {
            InitializeComponent();
            fillcombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fillcombo()
        {
            comboBox1.Items.Clear();
            string query1 = "select userid from usertable";
            SqlDataReader dr = con.ret_dr(query1);
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want to Delete","Warning Message",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                string id = comboBox1.Text;
                string q = "delete from login where userid= '" + id + "'";
                if (con.exec1(q) > 0)
                {
                    MessageBox.Show("Account Deleted");
                    
                }

            }
            else
            {
                MessageBox.Show("You clicked on no");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
