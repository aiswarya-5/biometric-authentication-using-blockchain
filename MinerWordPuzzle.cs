using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainWithFingerprint
{
    public partial class MinerWordPuzzle : Form
    {
        Random r = new Random();
        Random r2 = new Random();
        private string strStoreWord;
        int intRandom = 0;
        string[] strWord = { "engineer", "toenails", "penguins", "asterisk", "appetite", "backstab", "junkyard", "werewolf", "princess", "trespass", "accessible", "calculator", "complaints", "marvellous", "neighbours", "precaution", "refundable", "revolution", "unbeatable", "vocational" };
        int timeLeft = 100;
        int count = 1;
        public static string dataid1 = "";
        public MinerWordPuzzle()
        {
            InitializeComponent();
        }
        public MinerWordPuzzle(string id)
        {
            InitializeComponent();
            dataid1 = id;
        }
        private void MinerWordPuzzle_Load(object sender, EventArgs e)
        {
            label8.Text = timeLeft.ToString();
            wordScramble();
        }
        private void wordScramble()
        {
            string strAnagram = null;
            intRandom = r.Next(20);
            strAnagram = strWord[intRandom];
            strStoreWord = strAnagram;
            for (int i = 0; i < 20; i++)
            {
                string strAnagram2;

                int intRandom2 = r2.Next(strAnagram.Length);
                strAnagram2 = strAnagram.Substring(intRandom2, 1);

                strAnagram = strAnagram.Remove(intRandom2, 1);

                strAnagram = strAnagram.Insert(strAnagram.Length, strAnagram2);
            }
            dataid.Text = strAnagram;

            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (count > 3)
            {
                MessageBox.Show("Thank you Bester Luck Next Time");
                this.Close();
            }
            string strGuess;
            strGuess = textBox1.Text.ToString();

            if (strGuess.ToLower() == strStoreWord)
            {

                if (count == 3)
                {
                    
                    Miner_AddBlock obj = new Miner_AddBlock(dataid1);
                    ActiveForm.Hide();
                    obj.Show();

                }
                else
                {
                    lblResult.Text = "You are CORRECT!";

                    textBox1.Clear();
                    wordScramble();


                }
            }
            else

            {
                lblResult.Text = "Wrong! Please try again!";
                textBox1.Clear();
            }
            count++;
            textBox1.Focus();
        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            label8.Text = timeLeft.ToString();
            timeLeft -= 1;

            if (timeLeft < 0)
            {

                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }
}
