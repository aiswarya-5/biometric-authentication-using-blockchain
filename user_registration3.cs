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
using System.Drawing.Imaging;

namespace BlockchainWithFingerprint
{
   public partial class user_registration3 : Form
   {
       public static string uid = "";
       private byte threshold = 128;
       public static int windowsize = 8; 
       public static Bitmap bmp1;
       public user_registration3()
       {
           InitializeComponent();
       }

       public user_registration3(string userid, Bitmap bmp)
       {
           InitializeComponent();
           bmp1 = bmp;
           uid = userid;
           pictureBox1.Image = (Image)bmp;
           pictureBox2.Image = (Image)Image.FromFile(Program.fingerprintpath);
           Bitmap newImage = bmp;
           Program.blackImage = new Bitmap(newImage.Width, newImage.Height);
           imageToByteArray((Image)bmp);
       }
       public void imageToByteArray(System.Drawing.Image imageIn)
       {
           MemoryStream ms = new MemoryStream();
           imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
           OrientationImage newImg = FromByteArray(ms.ToArray());
           byte[] finalarray = ToByteArray(newImg);
           MemoryStream ms1 = new MemoryStream(finalarray);

           System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms1);
           // hogcanny.Image = returnImage;
           //Show(newImg, Graphics.FromImage(hogcanny.Image));
           newimage(newImg);


       }
       public void newimage(OrientationImage orImg)
       {

           Graphics g = Graphics.FromImage(pictureBox1.Image);

           int lineLength = windowsize / 2;
           Pen greenPen = new Pen(Brushes.Green) { Width = 2 };
           Pen redPen = new Pen(Brushes.Red) { Width = 2 };
           Pen currentPen;

           for (int i = 0; i < orImg.Height; i++)
               for (int j = 0; j < orImg.Width; j++)
               {
                   double angle;
                   if (orImg.IsNullBlock(i, j))
                   {
                       currentPen = redPen;
                       angle = 0;
                   }
                   else
                   {
                       currentPen = greenPen;
                       angle = orImg.AngleInRadians(i, j);
                   }
                   //double angle = orImg.IsNullBlock(i, j) ? 0 : orImg.AngleInRadians(i, j);
                   int x = j * windowsize + windowsize / 2;
                   int y = i * windowsize + windowsize / 2;

                   Point p0 = new Point
                   {
                       X = Convert.ToInt32(x - lineLength * Math.Cos(angle)),
                       Y = Convert.ToInt32(y - lineLength * Math.Sin(angle))
                   };

                   Point p1 = new Point
                   {
                       X = Convert.ToInt32(x + lineLength * Math.Cos(angle)),
                       Y = Convert.ToInt32(y + lineLength * Math.Sin(angle))
                   };

                   g.DrawLine(currentPen, p0, p1);
               }
           //hogpattern.Image = Program.blackImage;


       }
       public void Show(OrientationImage orImg, Graphics g)
       {

           // int lineLength = orImg.WindowSize / 2;
           int lineLength = windowsize / 2;
           Pen greenPen = new Pen(Brushes.Green) { Width = 2 };
           Pen redPen = new Pen(Brushes.Red) { Width = 2 };
           Pen currentPen;

           for (int i = 0; i < orImg.Height; i++)
               for (int j = 0; j < orImg.Width; j++)
               {
                   double angle;
                   if (orImg.IsNullBlock(i, j))
                   {
                       currentPen = redPen;
                       angle = 0;
                   }
                   else
                   {
                       currentPen = greenPen;
                       angle = orImg.AngleInRadians(i, j);
                   }
                   //double angle = orImg.IsNullBlock(i, j) ? 0 : orImg.AngleInRadians(i, j);
                   int x = j * windowsize + windowsize / 2;
                   int y = i * windowsize + windowsize / 2;

                   Point p0 = new Point
                   {
                       X = Convert.ToInt32(x - lineLength * Math.Cos(angle)),
                       Y = Convert.ToInt32(y - lineLength * Math.Sin(angle))
                   };

                   Point p1 = new Point
                   {
                       X = Convert.ToInt32(x + lineLength * Math.Cos(angle)),
                       Y = Convert.ToInt32(y + lineLength * Math.Sin(angle))
                   };

                   g.DrawLine(currentPen, p0, p1);
                   // showgridlines(orImg, g);
               }
       }
       public static byte[] ToByteArray(OrientationImage orImg)
       {
           byte[] bytes = new byte[orImg.Width * orImg.Height + 3];
           bytes[0] = orImg.WindowSize;
           bytes[1] = orImg.Height;
           bytes[2] = orImg.Width;
           int k = 3;
           for (int i = 0; i < orImg.Height; i++)
               for (int j = 0; j < orImg.Width; j++)
                   if (orImg.IsNullBlock(i, j))
                       bytes[k++] = 255;
                   else
                       bytes[k++] = Convert.ToByte(Math.Round(orImg.AngleInRadians(i, j) * 180 / Math.PI));
           return bytes;
       }

       public static OrientationImage FromByteArray(byte[] bytes)
       {
           byte height = bytes[1];
           byte width = bytes[2];
           byte[,] orientations = new byte[height, width];
           for (int i = 0; i < height; i++)
           {
               for (int j = 0; j < width; j++)
               {
                   if (i * width + j + 3 < bytes.Length)
                   {
                       orientations[i, j] = Convert.ToByte(bytes[i * width + j + 3]);
                   }
               }
           }

           OrientationImage orImg = new OrientationImage(width, height, orientations, bytes[0]);
           return orImg;
       }

       private void button2_Click(object sender, EventArgs e)
       {
           string path = "";
           string folderpath = Application.StartupPath + "\\users\\" + uid.ToString();
           if (Directory.Exists(folderpath))
           {
               string key = Generatekey(uid.ToString());
               if (!File.Exists(folderpath + "\\key.txt")) ;
               {
                   StreamWriter strm = File.CreateText(folderpath + "\\key.txt");
                   strm.Flush();
                   strm.Close();
               }
               if (File.Exists(folderpath + "\\key.txt"))
               {
                   using (StreamWriter sw = File.AppendText(folderpath + "\\key.txt"))
                   {
                       sw.WriteLine(key);

                   }
               }

           }

           string npath = "";
           string nfolderpath = Application.StartupPath + "\\notary\\";
           if (Directory.Exists(nfolderpath))
           {
               string key = Generatekey(uid.ToString());
               if (!File.Exists(nfolderpath + "\\" + uid.ToString() + "_key.txt"))
               {
                   StreamWriter strm = File.CreateText(nfolderpath + "\\" + uid.ToString() + "_key.txt");
                   strm.Flush();
                   strm.Close();
               }
               if (File.Exists(nfolderpath + "\\" + uid.ToString() + "_key.txt"))
               {
                   using (StreamWriter sw = File.AppendText(nfolderpath + "\\" + uid.ToString() + "_key.txt"))
                   {
                       sw.WriteLine(key);

                   }
               }

           }
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           saveFileDialog1.InitialDirectory = "E:\\";
           saveFileDialog1.Title = "Save Image Files";

           if (saveFileDialog1.ShowDialog() == DialogResult.OK)
           {
               pictureBox2.Image.Save(saveFileDialog1.FileName + ".png", ImageFormat.Png);
               MessageBox.Show("File Saved in :" + saveFileDialog1.FileName + ".png");
           }
           MessageBox.Show("User registration completed...");
           this.Close();
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

       
        private void user_registration3_Load(object sender, EventArgs e)
        {

        }
    }
}
