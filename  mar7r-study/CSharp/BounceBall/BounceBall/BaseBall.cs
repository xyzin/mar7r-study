using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BounceBall
{
    public class BaseBall : Ball
    {
        private const int BALL_SIZE = 32;

        public BaseBall(double radian, int velocity)
            : base(radian, velocity, BALL_SIZE)
        {

        }

        public BaseBall(double radian, int velocity, Point initPosition)
            : base(radian, velocity, initPosition, BALL_SIZE)
        {

        }

        override protected void setImage()
        {
            this.pb.Image = Properties.Resources.baseball;
            this.pb.Name = "Baseball";
        }
    }
}
