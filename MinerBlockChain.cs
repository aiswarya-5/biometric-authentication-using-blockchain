using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Net;

namespace BlockchainWithFingerprint
{
    public partial class MinerBlockChain : Form
    {
        public static string data;
        public static string fc = "";
        public MinerBlockChain()
        {
            InitializeComponent();
        }
        public MinerBlockChain(string d)
        {
            InitializeComponent();
            data = d;
        }
        private void MinerBlockChain_Load(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.AppendText("Connecting to Server..........");
            richTextBox1.AppendText("\n\n");
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.AppendText("Connecting to http://localhost:8081/..........");
            richTextBox1.AppendText("\n\n");
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.AppendText("Checking Network Credentials..........");
            richTextBox1.AppendText("\n\n");
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.AppendText("Connection to Chain......");
            richTextBox1.AppendText("\n\n");
            string path = Program.ppath;
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    fc = s;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idata = Convert.ToInt32(fc);
            string str = data;
            Blockchain phillyCoin = new Blockchain();
            int count = 0;
            int chunkSize = 30;
            int stringLength = str.Length;
            for (int i = 0; i < stringLength; i += chunkSize)
            {
                count++;
                if (i + chunkSize > stringLength)
                {
                    chunkSize = stringLength - i;
                    str.Substring(i, chunkSize);

                }
                phillyCoin.AddBlock(new Block(idata, DateTime.Now, null, str.Substring(i, chunkSize)));
                idata++;
            }
            richTextBox1.SelectionColor = Color.Red;
            File.AppendAllText(Application.StartupPath + "\\bchain.json", JsonConvert.SerializeObject(phillyCoin, Formatting.Indented));
            richTextBox1.AppendText(JsonConvert.SerializeObject(phillyCoin, Formatting.Indented));
            richTextBox1.AppendText("\n\n");
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.AppendText($"Is Chain Valid: {phillyCoin.IsValid()}");


            richTextBox1.AppendText("\n\n");
            richTextBox1.SelectionColor = Color.Green;

            richTextBox1.AppendText($"Is Chain Valid: {phillyCoin.IsValid()}");
            // Console.WriteLine($"Update hash");
            richTextBox1.AppendText("\n\n");
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.AppendText($"Update hash");
            phillyCoin.Chain[1].Hash = phillyCoin.Chain[1].CalculateHash();

            // Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
            richTextBox1.AppendText($"Is Chain Valid: {phillyCoin.IsValid()}");
            // Console.WriteLine($"Update the entire chain");
            richTextBox1.AppendText("\n\n");
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.AppendText($"Update the entire chain");
            phillyCoin.Chain[2].PreviousHash = phillyCoin.Chain[1].Hash;
            phillyCoin.Chain[2].Hash = phillyCoin.Chain[2].CalculateHash();
            phillyCoin.Chain[3].PreviousHash = phillyCoin.Chain[2].Hash;
            phillyCoin.Chain[3].Hash = phillyCoin.Chain[3].CalculateHash();

            // Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
            richTextBox1.AppendText($"Is Chain Valid: {phillyCoin.IsValid()}");

            //   Console.ReadKey();
            StreamWriter sw = new StreamWriter(Program.ppath);

            sw.WriteLine(idata);

            sw.Close();

        }
    }
}
