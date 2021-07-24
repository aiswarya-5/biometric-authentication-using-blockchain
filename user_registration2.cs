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

namespace BlockchainWithFingerprint
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
            path = Application.StartupPath + "\\users\\" + userid.ToString() + "\\fingerprint.png";
            Bitmap testbmp = CreateNonIndexedImage((Image)Image.FromFile(Program.fingerprintpath));
            // Create image.
            Bitmap finger = trainfingerprint(userid.ToString(), testbmp);
            finger.Save(path, ImageFormat.Png);
            Program.fingerprintpath = path;
            string softpath = "\\users\\" + userid.ToString() + "\\fingerprint.png";
            string query = "insert into fingerprint values('" + userid + "','" + softpath + "')";
            
            if (con.exec1(query) > 0)
            {
                user_registration3 obj = new user_registration3(userid, finger);
                ActiveForm.Hide();
                obj.Show();
            }
        }
        public enum State
        {
            Hiding,
            Filling_With_Zeros
        };
        public Bitmap CreateNonIndexedImage(Image src)
        {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(newBmp)) // create graphic object for alteration
            {
                gfx.DrawImage(src, 0, 0);
            }

            return newBmp;
        }

        public Bitmap trainfingerprint(string text, Bitmap bmp)
        {

            State state = State.Hiding;


            int charIndex = 0;


            int charValue = 0;


            long pixelElementIndex = 0;


            int zeros = 0;


            int R = 0, G = 0, B = 0;


            for (int i = 0; i < bmp.Height; i++)
            {

                for (int j = 0; j < bmp.Width; j++)
                {

                    Color pixel = bmp.GetPixel(j, i);


                    R = pixel.R - pixel.R % 2;
                    G = pixel.G - pixel.G % 2;
                    B = pixel.B - pixel.B % 2;


                    for (int n = 0; n < 3; n++)
                    {

                        if (pixelElementIndex % 8 == 0)
                        {

                            if (state == State.Filling_With_Zeros && zeros == 8)
                            {

                                if ((pixelElementIndex - 1) % 3 < 2)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }


                                return bmp;
                            }


                            if (charIndex >= text.Length)
                            {

                                state = State.Filling_With_Zeros;
                            }
                            else
                            {

                                charValue = text[charIndex++];
                            }
                        }


                        switch (pixelElementIndex % 3)
                        {
                            case 0:
                                {
                                    if (state == State.Hiding)
                                    {

                                        R += charValue % 2;


                                        charValue /= 2;
                                    }
                                }
                                break;
                            case 1:
                                {
                                    if (state == State.Hiding)
                                    {
                                        G += charValue % 2;

                                        charValue /= 2;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    if (state == State.Hiding)
                                    {
                                        B += charValue % 2;

                                        charValue /= 2;
                                    }

                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }
                                break;
                        }

                        pixelElementIndex++;

                        if (state == State.Filling_With_Zeros)
                        {

                            zeros++;
                        }
                    }
                }
            }

            return bmp;
        }

       
        private void user_registration2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\new_fingerprints";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.BMP;...";
            if (Directory.Exists(path))
            {
                openFileDialog1.InitialDirectory = path;
            }
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {

                fingerprint.ImageLocation = openFileDialog1.FileName.ToString();
                Program.fingerprintpath = openFileDialog1.FileName.ToString();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
