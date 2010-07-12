using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceSimulator
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;
        public RateClass rate;

        public string GetDescription()
        {
            return Bettor.Name + " bets " + Amount + " on dog #" + Dog; ;
        }

        public int PayOut(int Winner)
        {
            if (Winner == Dog)
                return Amount * rate.getRate();
            else
                return Amount * (-1);
        }
    }
}
