using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace RaceSimulator
{
    class Greyhound
    {
        public int StartingPostion;
        private int RaceTrackLength;
        
        public PictureBox MyPictureBox;
        public Label MyLabel;
        public int Location = 0;
        private RateClass rate;
        public RateClass Rate 
        {
            set {
                setRate(value);
            }

            get
            {
                return rate;
            }
        }

        
        public Greyhound()
        {
            Location = 20;
            StartingPostion = 20;
            RaceTrackLength = 450;
        }

        public bool Run()
        {
            int distance = rate.getDistance();

            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;

            Location += distance;

            if (Location > RaceTrackLength)
                return true;
            else
                return false;
        }

        public void TakeStartingPosition()
        {
            Location = 20;
            Point p = MyPictureBox.Location;
            p.X = Location;
            MyPictureBox.Location = p;
        }

        public void setRate(RateClass r)
        {
            rate = r;
            MyLabel.Text = "rate is 1:" + rate.getRate();
        }
    }
}
