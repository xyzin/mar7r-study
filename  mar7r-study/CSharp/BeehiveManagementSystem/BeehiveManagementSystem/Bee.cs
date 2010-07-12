using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeehiveManagementSystem
{
    class Bee
    {
        private int weight;

        private const double AMOUNT_OF_CONSUMPTION_IN_NOJOB = 7.5;

        public Bee(int weight)
        {
            this.weight = weight;
        }

        public virtual int ShiftLeft { get { return 0; } }
        public virtual int JobConsumption { get { return 0; } }
        public virtual double HoneyConsumption() 
        {
            double consumption;
            if (ShiftLeft == 0)
                consumption = AMOUNT_OF_CONSUMPTION_IN_NOJOB;
            else
                consumption = AMOUNT_OF_CONSUMPTION_IN_NOJOB + (ShiftLeft * JobConsumption);

            if (weight > 150)
                consumption *= 1.35;

            return consumption;
        }
    }
}
