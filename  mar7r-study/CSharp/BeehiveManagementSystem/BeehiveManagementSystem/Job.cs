using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeehiveManagementSystem
{
    /*********************************************************
     * job 명, job 별 기본 Honey 소모량, 경험치, 숙련도(level),
     ********************************************************/
    class Job
    {
        private const int DEFAULT_EXP = 5;
        private const int DEFAULT_MUL = 1;
        private string name = "";
        public string Name 
        {
            get
            { 
                return name;
            }
        }

        private int min = 0;
        private int max = 1;
        private int amountOfConsumption = 0;
        private int exp = 0;
        private int level = 1;
        private int levelPerAmount = 1;
        private Random randomize = new Random();

        public Job(string name, int minAmount, int maxAmount, int amountOfConsumption, int levelPerAmount)
        {
            this.name = name;
            this.min = minAmount;
            this.max = maxAmount;
            this.amountOfConsumption = amountOfConsumption;
            this.levelPerAmount = levelPerAmount;
        }

        public Job(string name)
        {
            this.name = name;
        }

        public int GetConsumptionHoney()
        {
            return amountOfConsumption * level;
        }

        public int DoJob()
        {
            return DoJob(DEFAULT_EXP, DEFAULT_MUL);
        }

        public int DoJob(int exp, int multiple)
        {
            this.exp += exp;
            if (this.exp > 100)
            {
                level++;
                this.exp -= 100;
                MessageBox.Show("level UP!!!");
            }
            return GetJobAmount(multiple);
        }

        private int GetJobAmount()
        {
            return (randomize.Next(max - min) + min) + (level * levelPerAmount);
        }

        private int GetJobAmount(int multiple)
        {
            return GetJobAmount() * multiple;
        }
    }
}
