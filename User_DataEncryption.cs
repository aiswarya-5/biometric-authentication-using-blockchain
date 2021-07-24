using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace BlockchainWithFingerprint
{
    public partial class User_DataEncryption : Form
    {
        public User_DataEncryption()
        {
            InitializeComponent();
        }
        public User_DataEncryption(string d, string s)
        {
            InitializeComponent();
            data.Text = d;
            sha.Text = s;

        }
        private void User_DataEncryption_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.kkeys;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_DataEncryption2 obj = new User_DataEncryption2(data.Text, textBox1.Text, sha.Text);
            ActiveForm.Hide();
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
