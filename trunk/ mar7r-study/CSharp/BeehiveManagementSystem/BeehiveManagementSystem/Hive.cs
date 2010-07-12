using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeehiveManagementSystem
{
    class Hive
    {
        private int nectar = 100;   //Hive 초기 nectar 값
        public int Nectar 
        {
            get
            {
                return nectar;
            }
        }

        private int honey = 3000;   //Hive 초기 honey 값
        public int Honey 
        { 
            get { 
                return honey; 
            }
        }

        private int hiveSize = 20; //bees 와 eggs 의 최대개체수, 추후 Hive 크기를 늘릴 수 있도록 할것

        private int needsForUpgrade = 100;  //업그레이드시 필요한 bees

        private TextBox myNectar;
        private TextBox myHoney;

        public Hive(TextBox nectar, TextBox honey)
        {
            initStatBox(nectar, honey);
        }

        public Hive(TextBox nectar, TextBox honey, int initNectar, int initHoney)
        {
            initStatBox(nectar, honey);
            this.nectar = initNectar;
            this.honey = initHoney;
        }

        private void initStatBox(TextBox nectar, TextBox honey)
        {
            myNectar = nectar;
            myHoney = honey;
        }

        public void addNectar(int amount)
        {
            nectar += amount;
            updateStat(myNectar, nectar);
        }

        public void addHoney(int amount)
        {
            honey += amount;
            updateStat(myHoney, honey);
        }

        private void updateStat(TextBox t, int value)
        {
            t.Text = value.ToString();
        }

        public void upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}
