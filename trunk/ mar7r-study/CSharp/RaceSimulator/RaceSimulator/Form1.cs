using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaceSimulator
{
    public partial class Form1 : Form
    {
        Guy[] guys = new Guy[3];
        Greyhound[] dogs = new Greyhound[4];
        RateClass[] rates = new RateClass[4];
        Guy selGuy;

        public Form1()
        {
            InitializeComponent();
            makeRate();

            guys[0] = new Guy() { Name = "Joe", Cash = 50, MyLabel = lbJoe, MyRadioButton = rdJoe };
            guys[1] = new Guy() { Name = "Bob", Cash = 75, MyLabel = lbBob, MyRadioButton = rdBob };
            guys[2] = new Guy() { Name = "Al", Cash = 45, MyLabel = lbAl, MyRadioButton = rdAl };

            dogs[0] = new Greyhound() { MyPictureBox = picDog1, Rate = rates[0], MyLabel = lbDog1 };
            dogs[1] = new Greyhound() { MyPictureBox = picDog2, Rate = rates[1], MyLabel = lbDog2 };
            dogs[2] = new Greyhound() { MyPictureBox = picDog3, Rate = rates[2], MyLabel = lbDog3 };
            dogs[3] = new Greyhound() { MyPictureBox = picDog4, Rate = rates[3], MyLabel = lbDog4 };

            selGuy = guys[0];
        }

        private void makeRate()
        {
            Random random = new Random();
            int rate = random.Next(3) + 3;
            int i = 0;
            do
            {
                rates[i] = new RateClass() { Randomizer = random, rate = rate };
                rate = random.Next(3) + 3;
            } while (i < rates.Length);
        }

        private void rdJoe_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Joe";
            selGuy = guys[0];
            if (selGuy.MyBet != null)
            {
                numBucks.Value = selGuy.MyBet.Amount;
                numDog.Value = selGuy.MyBet.Dog;
            }
        }

        private void rdBob_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Bob";
            selGuy = guys[1];
        }

        private void rdAl_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Al";
            selGuy = guys[2];
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (!selGuy.PlaceBet((int)numBucks.Value, (int)numDog.Value, dogs[(int)numDog.Value - 1].Rate))
                MessageBox.Show(selGuy.Name + "is not enough Cash");
            else
            {
                selGuy.MyLabel.Text = selGuy.MyBet.GetDescription();
            }


        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            int Winner = 0;
            bool endRace = false;
            for (int i = 0; i < guys.Length; i++)
            {
                if (guys[i].MyBet == null)
                {
                    MessageBox.Show(guys[i].Name + " is not Bet yet.");
                    return;
                }
                if (guys[i].Cash < guys[i].MyBet.Amount)
                {
                    MessageBox.Show(guys[i].Name + " is not enough Cash.");
                    return;
                }

            }
            while (!endRace)
            {
                for (int i = 0; i < dogs.Length; i++)
                {
                    if (dogs[i].Run())
                    {
                        Winner = i+1;
                        endRace = true;
                        MessageBox.Show("Winner is #" + Winner + " dog");
                        makeRate();
                        for (int j = 0; j < dogs.Length; j++)
                        {
                            dogs[j].TakeStartingPosition();
                            dogs[j].setRate(rates[j]);
                        }
                        break;
                    }
                }
            }
            for (int i = 0; i < guys.Length; i++)
            {
                if (!guys[i].Collet(Winner))
                    btnRace.Enabled = false;
            }
        }
    }
}
