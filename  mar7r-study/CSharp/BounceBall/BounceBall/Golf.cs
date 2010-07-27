using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BounceBall
{
    public class Golf : Ball
    {
        private const int BALL_SIZE = 64;

        public Golf(double radian, int velocity)
            : base(radian, velocity)
        {

        }

        public Golf(double radian, int velocity, Point initPosition)
            : base(radian, velocity, initPosition)
        {

        }

        override protected void initImage(Point initPosition)
        {
            this.pb.Image = global::BounceBall.Properties.Resources.golf;
            this.pb.Location = initPosition;
            this.pb.Name = "Baskball";
            this.pb.Size = new Size(BALL_SIZE, BALL_SIZE);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        }

        override public bool rightCollision()
        {
            return this.pb.Left + (int)Math.Round(getXfactor()) > MAX_LEFT - BALL_SIZE;
        }
        override public bool leftCollision()
        {
            return this.pb.Left + (int)Math.Round(getXfactor()) < 0;
        }
        override public bool topCollision()
        {
            return this.pb.Top - (int)Math.Round(getYfactor()) < 0;
        }
        override public bool bottomCollision()
        {
            return this.pb.Top - (int)Math.Round(getYfactor()) > MAX_TOP - BALL_SIZE;
        }
    }
}
