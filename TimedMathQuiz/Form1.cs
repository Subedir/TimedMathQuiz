using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {

        // create a random object called randomizer
        Random randomizer = new Random();
        int addend1;
        int addend2;
        int timeLeft;
        public Form1()
        {
            InitializeComponent();
        }


        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;
            timeLeft = 5;
            timeLabel.Text = timeLeft + " seconds";
            timer1.Start();

        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show ("you got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
                
            }
            else if(timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " Seconds";

            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
                
            }

        }

        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
                
            }
        }
    }
}
