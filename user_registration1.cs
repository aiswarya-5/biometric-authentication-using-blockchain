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
    public partial class user_registration1 : Form
    {
        BaseConnection con = new BaseConnection();
        public static string uid = "";
        public user_registration1()
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
        private void button1_Click(object sender, EventArgs e)
        {
            string usertype = "User";
            string query = "insert into login values(" + uid + ",'" + user.Text + "','" + pwd.Text + "','" + usertype + "')";
            if (con.exec1(query) > 0)
            {
                string query1 = "insert into UserTable values('" + uid + "','" + name.Text + "','" + country.Text + "','" + mob.Text + "','" + mail.Text + "')";
                if (con.exec1(query1) > 0)
                {
                    user_registration2 obj = new user_registration2(uid, name.Text.ToString());
                    ActiveForm.Hide();
                    obj.Show();
                }

            }
        }
        private void user_registration1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
