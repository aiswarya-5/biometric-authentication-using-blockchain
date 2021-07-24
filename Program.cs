using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BlockchainWithFingerprint
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///  
        public static int transactioncharge = 5;
        public static int minercharge = 3;
        public static string Alphadata = "Alpha";
        public static string userid = "";
        public static string keys = "";
        public static string kkeys = "";
        public static string fingerprintpath = "";
        public static Bitmap blackImage;
        public static Bitmap keyImage;
        public static Bitmap keyImage1;
        public static string ppath = Application.StartupPath + "\\Test.txt";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
