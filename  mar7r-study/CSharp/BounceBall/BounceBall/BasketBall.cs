using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BounceBall
{
    public class BasketBall : Ball
    {
        private const int BALL_SIZE = 64;

        public BasketBall(double radian, int velocity)
            : base(radian, velocity, BALL_SIZE)
        {

        }

        public BasketBall(double radian, int velocity, Point initPosition)
            : base(radian, velocity, initPosition, BALL_SIZE)
        {

        }

        override protected void setImage()
        {
            this.pb.Name = "Baskball";
            this.pb.Image = Properties.Resources.basketball;
        }
    }
}
