using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*************************
 * todo
 * 1. hive class 추가 - 소지한Nectar 양, Honey 양, Hive 크기(Worker+egg의 수 제한), Hive 의 내구도, egg 수
 * 2. Woker 속성추가 - Job[]
 * 3. Job class 추가 - job 명, job 별 Nectar 소모량, 경험치, 숙련도(level), 
 *          - Nectar collector : Nectar 모아서 Hive에 저장, 생산량은 X~Y + @(숙련도)
 *          - Honey manufacturing : Honey 만들어서 Hive에 저장, 생산량은 X~Y + @(숙련도)
 *          - Egg care : egg 를 부화시킴, 부화시 필요한 Shift는 모든 egg 동일, 줄어드는 양은 X+@(숙련도)
 *          - Baby bee tutoring : Baby 를 Worker로 성장시킴, 성장시 필요한 Shift는 X~Y + @(숙련도)
 *          - Hive maintenace : Hive 내구도를 올림. MAX 값 이상 시 HIVE upgrade, 내구도 오르는 양은 X~Y+@(숙련도)
 *    Job(string name, int minAmount, int maxAmount, int amountOfConsumption, int levelPerAmount)
 * 4. Bee 속성추가 - level(worker 의 job 숙련도 제한, queen의 Egg 생산량 제한)
 * 5. Egg class 추가 - ShiftLeft(egg care하지 않으면 파괴, egg care 하는 worker의 숙련에 따라 줄어드는 양이 달라짐)
 * 6. Baby : Bee 추가 - Woker 되기 전까지 bee, Nectar 소모만함, turoting 숙련에 따라 Worker 될시 능력달라짐
 * 7. 매Shift마다 Nectar소비, Honey소비, Hive 내구도 감소,
 *          - Nectar는 Queen과 Baby가 소모
 *          - Honey는 Worker가 소모
 *          - Hive 는 0~X 소모
 *************************/

namespace BeehiveManagementSystem
{
    public partial class Form1 : Form
    {
        Queen queen;
        public Form1()
        {
            InitializeComponent();
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new List<Job>() { new Job("Nectar collector", 10,100, 5, 10), 
                                                new Job("Honey manufacturing", 1000, 3000, 8, 500) }, 
                                                17);
            workers[1] = new Worker(new List<Job>() { new Job("Egg care", 1, 5, 25, 2), 
                                                new Job("Baby bee tutoring", 1,3, 30, 2) }, 
                                                114);
            workers[2] = new Worker(new List<Job>() { new Job("Hive maintenance", 30, 120, 18, 10),
                                                new Job("Baby bee tutoring", 2,5, 34, 2) }, 
                                                149);
            workers[3] = new Worker(new List<Job>() { new Job("Nectar collector", 30, 200, 32, 15),
                                                new Job("Honey manufacturing", 2000, 5000, 50, 1000), 
                                                new Job("Egg care", 1, 6, 27, 2),
                                                new Job("Baby bee tutoring", 1, 5, 33, 2),
                                                new Job("Hive maintenace", 33, 125, 20, 10) },
                                                155);
            Hive h = new Hive(txtNectar, txtHoney);
            txtNectar.Text = h.Nectar.ToString();
            txtHoney.Text = h.Honey.ToString();
            queen = new Queen(workers, 275, h);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, (int)shifts.Value))
                MessageBox.Show("The job '" + workerBeeJob.Text + "' will be done in " + (int)shifts.Value + " shifts", "The queen bee says");
            else
                MessageBox.Show("No workers are available to do this job '" + workerBeeJob.Text + "'", "The queen bee says..");
        }

        private void nextShift_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}
