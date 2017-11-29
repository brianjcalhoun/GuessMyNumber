using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessMyNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int number = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Generates random number on applicaiton load
            Random generator = new Random();
            number = generator.Next(1, 201);
            MessageBox.Show("I'm Thinking of a number from 1-200.  Bet you can't guess it!", "Guess My Number");

        }

        //Runs button guess click event
        private void btnGuess_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {


                int guess = Convert.ToInt32(txtNumberEntry.Text);

                if (guess > number)
                {
                    txtResult.Text = "Your last guess of" + " " + guess + " " + "was to high.";
                    txtNumberEntry.Text = "";
                    MessageBox.Show("Your guess is too high!", "Guess Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (guess < number)
                {
                    txtResult.Text = "Your last guess of" + " " + guess + " " + "was to low.";
                    txtNumberEntry.Text = "";
                    MessageBox.Show("Your guess is too low!", "Guess Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else if (guess == number)
                {
                    txtResult.Text = "Your guess of" + " " + guess + " " + "was correct!";
                    txtNumberEntry.Text = "";
                    btnGuess.Enabled = false;
                    MessageBox.Show("Congratualtion, Your guess is correct!", "Guess Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        //Validation Code
        public bool IsValidData()
        {
            return
                // Validate the guess entry text box
                IsPresent(txtNumberEntry, "Your guess") &&
                IsInt32(txtNumberEntry, "Your guess") &&
                IsWithinRange(txtNumberEntry, "Your Guess", 1, 200);

        }

        //Validates that entry is keyed into the guess textbox
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        //Validates that the entry keyed into the guess box is an integer only
        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        //Validates that the entry keyed into guess box is withing the set game range of numbers
        public bool IsWithinRange(TextBox textBox, string name,
            decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min
                    + " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        //Generates a new random number
        private void btnNewNumber_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            number = generator.Next(1, 201);
            MessageBox.Show("A New number has been randomly generated between 1-200. Thank you for playing again!",
                            "Wizards Have Conjured A New Number");

            btnGuess.Enabled = true;
            txtResult.Text = "";
            txtNumberEntry.Focus();
        }
        //Closes the application
        private void btnQuit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for playing!");
            this.Close();
        }
    }
}
