using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeehiveManagementSystem
{
    class Queen : Bee
    {
        private Hive hive;
        private Worker[] workers;
        private int shiftNumber;
                

        public Queen(Worker[] workers, int weight, Hive hive) : base(weight)
        {
            this.workers = workers;
            this.hive = hive;
        }

        public bool AssignWork(String job, int shift)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DoThisJob(job, shift))
                    return true;
            }
            return false;
        }

        public string WorkTheNextShift()
        {
            int totalConsumption = 0;
            int nectarConsumption = 0;

            int makeHoney = 0;
            int makeNectar = 0;
            for (int i = 0; i < workers.Length; i++)
            {
                totalConsumption += (int)workers[i].HoneyConsumption();
            }
            totalConsumption += (int)HoneyConsumption();
            nectarConsumption = (int)(totalConsumption * 0.05);

            shiftNumber++;
            string report = "Report for shift #" + shiftNumber + "\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                int amount = workers[i].WorkOneShift();
                if (amount == -1)
                    report += "Worker #" + (i + 1) + " is not working\r\n";
                if (workers[i].CurrentJob == null)
                    report += "Worker #" + (i + 1) + " finished the job\r\n";
                else {
                    if (workers[i].ShiftLeft > 0)
                        report += "Worker #" + (i + 1) + " is doing '" + workers[i].CurrentJob.Name + "' for " + workers[i].ShiftLeft + " more shifts. : " + amount + "\r\n";
                    else
                        report += "Worker #" + (i + 1) + " will be done with '" + workers[i].CurrentJob.Name + "' after this shift. : " + amount + "\r\n";
                    if (workers[i].CurrentJob.Name == "Nectar collector")
                        makeNectar += amount;
                    if (workers[i].CurrentJob.Name == "Honey manufacturing")
                        makeHoney += amount;
                    }
            }

            report += "Total honey consumption: " + totalConsumption + " units. Nectar consumption: " + nectarConsumption + "\r\n";
            hive.addHoney(makeHoney - totalConsumption);
            hive.addNectar(makeNectar - nectarConsumption);
            return report;
        }

        private Baby[] babies;
        private Egg[] eggs;

        public double HoneyConsumption()
        {
            throw new System.NotImplementedException();
        }

        public void DefendTheHive(IStingPatrol patroller)
        {
            throw new System.NotImplementedException();
        }
    }
}
