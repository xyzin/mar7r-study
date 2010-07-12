using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaceSimulator
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        { }

        public void ClearBet()
        { }

        public bool PlaceBet(int Amount, int Dog, RateClass Rate)
        {
            if (Amount <= Cash)
            {
                MyBet = new Bet() { Amount = Amount, Dog = Dog, Bettor = this, rate = Rate };
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Collet(int Winner)
        {
            Cash = Cash + MyBet.PayOut(Winner);
            MyRadioButton.Text = Name + " has " + Cash + " bucks";
            if (Cash < 5)
            {
                MessageBox.Show(Name + " is not enough Cash, End of GAME!");
                return false;
            }
            return true;
        }
    }
}
