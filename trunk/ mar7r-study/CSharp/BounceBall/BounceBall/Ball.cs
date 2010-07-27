using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BounceBall
{
    public abstract class Ball
    {
        private double radian;
        private int velocity;

        protected PictureBox pb;
        protected const int MAX_LEFT = 600;
        protected const int MAX_TOP = 400;

        public Ball(double radian, int velocity)
        {
            this.radian = radian;
            this.velocity = velocity;

            pb = new PictureBox();
            initImage(new Point(30, 150));
        }

        public Ball(double radian, int velocity, Point initPosition)
        {
            this.radian = radian;
            this.velocity = velocity;

            pb = new PictureBox();
            initImage(initPosition);
        }

        protected abstract void initImage(Point initPosition);
        public abstract bool rightCollision();
        public abstract bool leftCollision();
        public abstract bool topCollision();
        public abstract bool bottomCollision();

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
