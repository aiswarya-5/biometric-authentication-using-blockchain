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
    public partial class FingerMatching : Form
    {
        public FingerMatching()
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
        private void FingerMatching_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "E:\\";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.png;...";
            if (Directory.Exists(path))
            {
                openFileDialog1.InitialDirectory = path;
            }
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {

                fingerprint.ImageLocation = openFileDialog1.FileName;
                Program.keyImage1 = (Bitmap)Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kmatch = extractkey(Program.keyImage1);
            if (kmatch == Program.userid)
            {
                string kstruct = Managekey(kmatch);
                Program.kkeys = kstruct;
                MessageBox.Show("Success Full Match FingerPrint");
               // MessageBox.Show(" Success Full Match FingerPrint: Your Key Structure: " + kstruct);
                User_Home obj = new User_Home();
                ActiveForm.Hide();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid FingerPrint");
            }
        }

        public static int reverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }
        public string extractkey(Bitmap bmp)
        {
            int colorUnitIndex = 0;
            int charValue = 0;


            string extractedText = String.Empty;


            for (int i = 0; i < bmp.Height; i++)
            {

                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);


                    for (int n = 0; n < 3; n++)
                    {
                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {

                                    charValue = charValue * 2 + pixel.R % 2;
                                }
                                break;
                            case 1:
                                {
                                    charValue = charValue * 2 + pixel.G % 2;
                                }
                                break;
                            case 2:
                                {
                                    charValue = charValue * 2 + pixel.B % 2;
                                }
                                break;
                        }

                        colorUnitIndex++;


                        if (colorUnitIndex % 8 == 0)
                        {

                            charValue = reverseBits(charValue);


                            if (charValue == 0)
                            {
                                return extractedText;
                            }


                            char c = (char)charValue;


                            extractedText += c.ToString();
                        }
                    }
                }
            }

            return extractedText;
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
    }
}
