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
        int addnum1;
        int addnum2;
        int subtractnum1;
        int subtractnum2;
        int multiplynum1;
        int multiplynum2;
        int dividenum1;
        int dividenum2;

        int totalTime;
        int timeLeft; 
        public Form1()
        {
            InitializeComponent();
        }


        public void StartTheQuiz()
        {

            // create random numbers for the 2 numbers to add
            addnum1 = randomizer.Next(51);
            addnum2 = randomizer.Next(51);
            // set the labels text to the two numbers defined 
            plusLeftLabel.Text = addnum1.ToString();
            plusRightLabel.Text = addnum2.ToString();
            sum.Value = 0;

            //*******************************************************//
            subtractnum1 = randomizer.Next(0, 101);
            subtractnum2 = randomizer.Next(0, subtractnum1);

            minusLeftLabel.Text = subtractnum1.ToString();
            minusRightLabel.Text = subtractnum2.ToString();

            difference.Value = 0;


            //*******************************************************//

            multiplynum1 = randomizer.Next(2,11);
            multiplynum2 = randomizer.Next(2, 11);

            timesLeftLabel.Text = multiplynum1.ToString();
            timesRightLabel.Text = multiplynum2.ToString();

            product.Value = 0;

            //*******************************************************//

            dividenum2 = randomizer.Next(2, 11);
            int tempNumber = randomizer.Next(2, 11);
            dividenum1 = dividenum2 * tempNumber;

            dividedLeftLabel.Text = dividenum1.ToString();
            dividedRightLabel.Text = dividenum2.ToString();
            quotient.Value = 0;
            //*******************************************************//
            timeLeft = setTime();
            totalTime = timeLeft; // this sets a marker called totalTime which will keep the original time entered
            timeLabel.Text = timeLeft + " seconds";
            timer1.Start();

        }


        private int setTime()
        {
            int tempTime = 0;

            tempTime = int.Parse(timeEnterBox.Text);
            timeLabel.Visible = true; // this makes the label box which displays the time visable
            timeEnterBox.Visible = false; // this hides the text box which serves as an input for the time

            return tempTime;
        }
        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int tempValue;
            if (timeEnterBox.Text != null && (int.TryParse(timeEnterBox.Text, out tempValue)) && tempValue >= 1)
            {
                StartTheQuiz();
                startButton.Enabled = false;
            }

            else
            {
                MessageBox.Show("Please Enter a time to count down to.");

            }
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

                if (( 100 * timeLeft / totalTime) > 60) // this checks to see if the time has reached less than 50% of the original time.
                {
                    timeLabel.BackColor = Color.Green;
                }

                else if ((100 * timeLeft / totalTime) > 30) // this checks to see if the time has reached less than 10% of the original time.
                {
                    timeLabel.BackColor = Color.Yellow;
                }

                else if ((100 * timeLeft / totalTime) > 10) // this checks to see if the time has reached less than 10% of the original time.
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addnum1 + addnum2;
                difference.Value = subtractnum1 - subtractnum2;
                product.Value = multiplynum1 * multiplynum2;
                quotient.Value = dividenum1 / dividenum2;
                startButton.Enabled = true;
                
            }

        }

        private bool CheckTheAnswer()
        {
            if ( ((addnum1 + addnum2) == sum.Value) 
                && ((subtractnum1 - subtractnum2) == difference.Value) 
                && ((multiplynum1*multiplynum2) == product.Value) 
                && ((dividenum1/dividenum2) == quotient.Value))
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
