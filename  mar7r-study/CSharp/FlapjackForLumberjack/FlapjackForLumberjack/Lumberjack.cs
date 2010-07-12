using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlapjackForLumberjack
{
    class Lumberjack
    {
        private string name;
        private Stack<Flapjack> meal;

        public Lumberjack(string name)
        {
            this.name = name;
            meak = new Stack<Flapjack>();
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int FlapjackCount
        {
            get
            {
                return meal.Count;
            }
        }

        public void TakeFlapjacks(Flapjack Food, int HowMany)
        {
            for (int i = 0; i < HowMany; i++)
            {
                meal.Push(Food);
            }
        }

        public void EatFlapjacs()
        {
            Console.WriteLine(name + "'s eating flapjacks.";
            for (int i = 0; i < meal.Count; i++)
            {
                Console.WriteLine(name + " ate a " + meal.Pop().ToString() + " flapjack.";
            }
        }
    }
}
