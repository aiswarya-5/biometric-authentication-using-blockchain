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

namespace My_Project_Final
{
    public partial class User_Edit : Form
    {
        BaseConnection con = new BaseConnection();
        public static string uid = "";
        public User_Edit()
        {
            InitializeComponent();
            uid = Program.userid;
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void e_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q1 = "update usertable set name='" + n.Text + "',country='" + comboBox1.Text + "',mobile='" + no.Text + "',mailid='" + em.Text + "'  where userid='" + uid + "'";
            con.exec(q1);

              if (con.exec1(q1) > 0)
                {
                string path = "";


                path = Application.StartupPath + "\\users\\" + uid.ToString() + "\\fingerprint.tif";

                File.SetAttributes(path, FileAttributes.Normal);
                System.IO.File.Delete(path);
                //MessageBox.Show(path);
                System.IO.File.Copy(Program.fingerprintpath, path, true);
                File.SetAttributes(path, FileAttributes.Normal);

                MessageBox.Show("Data is succesfully updated.");
                this.Close();
                
                }
             else
                {
                MessageBox.Show("Sorry !! an errr occured in Update");
                }
            
        }

        private void User_Edit_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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


                fingerprint.ImageLocation = ff.FileName.ToString();
                Program.fingerprintpath = ff.FileName.ToString();
                //MessageBox.Show(Program.fingerprintpath);



            }
        }
    }
}
