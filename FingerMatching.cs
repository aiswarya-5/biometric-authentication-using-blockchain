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
using PatternRecognition.FingerprintRecognition.Core;
using PatternRecognition.FingerprintRecognition.FeatureExtractors;
using PatternRecognition.FingerprintRecognition.Matchers;

namespace My_Project_Final
{
    public partial class FingerMatching : Form
    {
        public FingerMatching()
        {
            InitializeComponent();
            
        }

        public string score;
        public string qry;
        public string temp;


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }

        }
        private void FingerMatching_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\new_fingerprints";
           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.tif;...";
            if (Directory.Exists(path))
            {
                openFileDialog1.InitialDirectory = path;
            }
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string fileName;
                fileName = openFileDialog1.FileName;
                temp = fileName;
                fingerprint.ImageLocation = temp;

                //fingerprint.ImageLocation = openFileDialog1.FileName;
                //Program.keyImage1 = (Bitmap)Image.FromFile(openFileDialog1.FileName);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            qry = Application.StartupPath + "\\users\\" + Program.userid + "\\fingerprint.tif";
           // MessageBox.Show(Program.userid);
            
            if (fingerprint.Image != null)
            {
               
                match(qry, temp);
            }
            else
            {
                MessageBox.Show("Please choose two fingerprints!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Bitmap Change_Resolution(string file)
        {
            using (Bitmap bitmap = (Bitmap)Image.FromFile(file))
            {
                using (Bitmap newBitmap = new Bitmap(bitmap))
                {
                    newBitmap.SetResolution(500, 500);
                    return newBitmap;
                }
            }
        }
        private void match(string query, string template)
        {
            Change_Resolution(query);
            Change_Resolution(template);

            var fingerprintImg1 = ImageLoader.LoadImage(query);
            var fingerprintImg2 = ImageLoader.LoadImage(template);

            var featExtractor = new PNFeatureExtractor() { MtiaExtractor = new Ratha1995MinutiaeExtractor() };
            var features1 = featExtractor.ExtractFeatures(fingerprintImg1);
            var features2 = featExtractor.ExtractFeatures(fingerprintImg2);

            var matcher = new PN();
            double similarity = matcher.Match(features1, features2);


            score = similarity.ToString("0.000");
           // MessageBox.Show("Similarity " + similarity.ToString("0.000"), "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (similarity >= 70)
            {
                MessageBox.Show("Success Full Match FingerPrint");
                string kstruct = Managekey(Program.userid);
                Program.kkeys = kstruct;
                //MessageBox.Show(kstruct);
                User_Home obj = new User_Home();
                ActiveForm.Hide();
                obj.Show();

            }
            else
            {
                MessageBox.Show("No Matching Person found");
                Login obj = new Login();
                ActiveForm.Hide();
                obj.Show();
            }

        }
        
        public static string Managekey(string inputString)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
        }
    }
}
