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
    public partial class Miner_Puzzle : Form
    {
        int timeLeft = 60;
        public static string dataid = "";
        bool isOperationPerformed = false;
        public Miner_Puzzle()
        {
            InitializeComponent();
        }
        public Miner_Puzzle(string id)
        {
            InitializeComponent();
            dataid = id;
        }
        private void Miner_Puzzle_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Given an unsigned integer, swap all odd bits with even bits. For example, if the given number is 23 (00010111), it should be converted to 43 (00101011). Every even position bit is swapped with adjacent bit on right side (even position bits are highlighted in binary representation of 23), and every odd position bit is swapped with adjacent on left side.";
            Random random = new Random();
            int randomNumber = random.Next(30, 100);
            textBox5.Text = randomNumber.ToString();
            label8.Text = timeLeft.ToString();

        }
        static long swapBits(int x)
        {
            // Get all even bits of x
            long even_bits = x & 0xAAAAAAAA;
            Console.WriteLine(even_bits);

            // Get all odd bits of x
            long odd_bits = x & 0x55555555;
            Console.WriteLine(odd_bits);
            // Right shift even bits
            even_bits >>= 1;
            Console.WriteLine(even_bits);
            // Left shift even bits
            odd_bits <<= 1;
            Console.WriteLine(odd_bits);
            // Combine even and odd bits
            return (even_bits | odd_bits);
        }
      

        private void button15_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox5.Text);
            long x1 = swapBits(x);
            if (x1 == Convert.ToInt64(textBox_Result.Text))
            {
                MessageBox.Show("Answer Correct");
                Miner_AddBlock obj = new Miner_AddBlock(dataid);
                ActiveForm.Hide();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Wrong Result...Please try again !!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = timeLeft.ToString();
            timeLeft -= 1;

            if (timeLeft < 0)
            {
                
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;

            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;
        }
    }
}
