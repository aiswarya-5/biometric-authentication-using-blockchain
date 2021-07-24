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
    public partial class User_Profile : Form
    {
        BaseConnection con = new BaseConnection();
        public static string id = "";
        public User_Profile()
        {
            InitializeComponent();
            id = Program.userid;
            filld();
        }
        public void filld()
        {
            try
            {
                string name = "";
                string add = "";
                string no = " ";
                string email = " ";
                string query = "select * from usertable where userid='" + id + "'";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {

                    name = dr[1].ToString();
                    add = dr[2].ToString();
                    no = dr[3].ToString();
                    email = dr[4].ToString();
                }

                a.Text = add;
                e.Text = email;
                n.Text = no;
                u.Text = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating block Id........");
            }
        }
        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            User_Edit obj = new User_Edit();
            obj.Show();
        }
    }
}
