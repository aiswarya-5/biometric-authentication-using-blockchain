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
    public partial class Login : Form
    {
        BaseConnection con = new BaseConnection();
        public Login()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "n" && pwd.Text == "n")
            {
                Notary_Base obj = new Notary_Base();
                ActiveForm.Hide();
                obj.Show();
            }
            else
            {
                string q = "select *from login where username='" + user.Text + "' and password='" + pwd.Text + "'";
                SqlDataReader dr = con.ret_dr(q);
                if (dr.Read())
                {
                    if (dr[3].ToString() == "User")
                    {
                        FingerMatching obj = new FingerMatching();
                        ActiveForm.Hide();
                        Program.userid = dr[0].ToString();

                        obj.Show();
                    }
                    else
                    {
                        Miner_Base obj = new Miner_Base();
                        ActiveForm.Hide();
                        Program.userid = dr[0].ToString();

                        obj.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password..");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            user_registration1 obj = new user_registration1();
            obj.Show();
        }

        private void pwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Miner_Registration obj = new Miner_Registration();
            obj.Show();
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            user.Text = "";
            pwd.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Instructions obj = new Instructions();
            obj.Show();
        }
    }
}
