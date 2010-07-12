using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeehiveManagementSystem
{
    class Worker : Bee
    {
        private List<Job> jobs;
        private int shiftsToWork;
        private int shiftsWorked;

        private Job currentJob = null;
        public Job CurrentJob { 
            get {
                return currentJob;
            }    
        }

        public override int ShiftLeft {
            get {
                return shiftsToWork - shiftsWorked;
            }
        }

        public override int JobConsumption { 
            get{
                return currentJob.GetConsumptionHoney();
            } 
        }

        public int isBusy
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Worker(List<Job> jobs, int weight) : base(weight)
        {
            this.jobs = jobs;
        }

        public bool DoThisJob(string jobName, int numberOfShifts)
        {
            if (currentJob != null)
                return false;
            foreach (Job job in jobs)
            {
                if (job.Name == jobName)
                {
                    currentJob = job;
                    this.shiftsToWork = numberOfShifts;
                    this.shiftsWorked = 0;
                    return true;
                }
            }
            return false;
        }

        public int WorkOneShift()
        {
            int amountPerShift = 0;
            if (currentJob == null)
                return -1;
            shiftsWorked++;
            currentJob.GetConsumptionHoney();
            amountPerShift = currentJob.DoJob();
            
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = null;
            }
            return amountPerShift;
        }
    }
}
