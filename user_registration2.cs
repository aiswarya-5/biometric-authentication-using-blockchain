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
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace My_Project_Final
{
    public partial class user_registration2 : Form
    {
        BaseConnection con = new BaseConnection();
        public static string userid = "";
       
        public user_registration2()
        {
            InitializeComponent();
        }
        public user_registration2(string uid, string namep)
        {
            InitializeComponent();
            name.Text = namep;
            userid = uid;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string path = "";
          
            string folderpath = Application.StartupPath + "\\users\\" + userid.ToString();
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            path = Application.StartupPath + "\\users\\" + userid.ToString() + "\\fingerprint.tif";
            System.IO.File.Copy(Program.fingerprintpath, path);

            string softpath = "\\users\\" + userid.ToString() + "\\fingerprint.tif";
            string query = "insert into fingerprint values('" + userid + "','" + softpath + "')";
            if (con.exec1(query) > 0)
            {

                string folderpath1 = Application.StartupPath + "\\users\\" + userid.ToString();
                if (Directory.Exists(folderpath))
                {
                    string key = Generatekey(userid.ToString());
                    if (!File.Exists(folderpath1 + "\\key.txt")) ;
                    {
                        StreamWriter strm = File.CreateText(folderpath1 + "\\key.txt");
                        strm.Flush();
                        strm.Close();
                    }
                    if (File.Exists(folderpath1 + "\\key.txt"))
                    {
                        using (StreamWriter sw = File.AppendText(folderpath1 + "\\key.txt"))
                        {
                            sw.WriteLine(key);

                        }
                    }

                }
                MessageBox.Show("User registration completed...");
                this.Close();
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

        private void user_registration2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\new_fingerprints";
           
            OpenFileDialog ff = new OpenFileDialog();
            ff.Filter = "Image Files|*.tif;...";
            if (Directory.Exists(path))
            {
                ff.InitialDirectory = path;
            }
            if (ff.ShowDialog() == DialogResult.OK)
            {

                /* fingerprint.Image = Image.FromFile(ff.FileName);
                 fsearch1 = ff.FileName; //source

                 Program.fingerprintpath= ff.FileName;*/
                fingerprint.ImageLocation = ff.FileName.ToString();
                Program.fingerprintpath = ff.FileName.ToString();



            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
