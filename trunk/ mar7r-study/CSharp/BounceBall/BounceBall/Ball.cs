using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace BounceBall
{
    public abstract class Ball
    {
        private double radian;
        private int velocity;
        private int ballSize;

        public PictureBox pb;
        protected const int MAX_LEFT = 600;
        protected const int MAX_TOP = 400;

        public Ball(double radian, int velocity, int ballSize)
        {
            this.radian = radian;
            this.velocity = velocity;
            this.ballSize = ballSize;

            pb = new PictureBox();
            initImage(new Point(30, 150));
        }

        public Ball(double radian, int velocity, Point initPosition, int ballSize)
        {
            this.radian = radian;
            this.velocity = velocity;
            this.ballSize = ballSize;

            pb = new PictureBox();
            initImage(initPosition);
        }

        public bool rightCollision()
        {
            return this.pb.Left + (int)Math.Round(getXfactor()) > MAX_LEFT - ballSize;
        }
        public bool leftCollision()
        {
            return this.pb.Left + (int)Math.Round(getXfactor()) < 0;
        }
        public bool topCollision()
        {
            return this.pb.Top - (int)Math.Round(getYfactor()) < 0;
        }
        public bool bottomCollision()
        {
            return this.pb.Top - (int)Math.Round(getYfactor()) > MAX_TOP - ballSize;
        }

        protected void initImage(Point initPosition)
        {
            this.pb.BackColor = Color.Transparent;
            this.pb.Size = new Size(ballSize, ballSize);
            this.pb.Location = initPosition;
            setImage();
        }
        protected abstract void setImage();

        public PictureBox getPictureBox()
        {
            return this.pb;
        }

        public double getRadian()
        {
            return this.radian;
        }

        public int getVelocity()
        {
            return this.velocity;
        }

        public double getXfactor()
        {
            return Math.Cos(radian) * velocity;
        }

        public double getYfactor()
        {
            return Math.Sin(radian) * velocity;
        }

        public void move()
        {
            if (rightCollision())
                sideReflection();
            else if (leftCollision())
                sideReflection();
            else if (topCollision())
                topAndBottomReflection();
            else if (bottomCollision())
                topAndBottomReflection();

            int x = (int)Math.Round(getXfactor());
            int y = (int)Math.Round(getYfactor());
            this.pb.Left += x;
            this.pb.Top -= y;
        }

        private void sideReflection()
        {
            this.radian = Math.PI - this.radian;
        }

        private void topAndBottomReflection()
        {
            this.radian = 2 * Math.PI - this.radian;
        }

        public Boolean collision()
        {
            if (rightCollision())
                return true;
            else if (leftCollision())
                return true;
            else if (topCollision())
                return true;
            else if (bottomCollision())
                return true;
            return false;
        }
    }
}
