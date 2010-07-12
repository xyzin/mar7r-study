using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceSimulator
{
    class RateClass
    {
        public int rate;
        public Random Randomizer;

        public int getDistance()
        {
            int distance = Randomizer.Next(rate) + 1;
            if (distance > 4) distance = 4;
            return distance;
        }

        public int getRate()
        {
            return 8 - rate;
        }
    }
}
