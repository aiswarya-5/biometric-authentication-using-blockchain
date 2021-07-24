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
    public partial class User_AddData : Form
    {
        public User_AddData()
        {
            InitializeComponent();
            d.Text = System.DateTime.Now.ToShortDateString();
            t.Text = System.DateTime.Now.ToShortTimeString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_DataEncryption obj = new User_DataEncryption(data.Text,sha.Text);
            obj.Show();
        }

        private void data_TextChanged(object sender, EventArgs e)
        {
            if (data.Text != "")
            {
                sha.Text = Generatekey(data.Text);

            }
            else
            {
                sha.Text = "";
            }
        }
        public static string Generatekey(string inputString)
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                string str = File.ReadAllText(textBox1.Text);
                data.Text = str;

            }
        }

        private void User_AddData_Load(object sender, EventArgs e)
        {

        }
    }
}
