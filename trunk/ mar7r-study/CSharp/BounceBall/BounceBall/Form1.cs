using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BounceBall
{
    public partial class Form1 : Form
    {

        List<Ball> balls = new List<Ball>();
        private bool isMoving = false;
        private Random random;
        public Form1()
        {
            InitializeComponent();

            random = new Random();

            Ball ball = new BasketBall(random.Next(600) / 100, random.Next(20) + 1, 
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            balls.Add(ball);

            ball = new BaseBall(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            balls.Add(ball);
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            isMoving = isMoving ? false : true ;
            this.btnDo.Text = isMoving ? "Stop" : "Start";
            while (isMoving)
            {
                foreach (Ball ball in balls)
                {
                    ball.move();
                    Refresh();
                }
                Thread.Sleep(50);
            }
        }

        private void btnBasket_Click(object sender, EventArgs e)
        {
            Ball ball = new BasketBall(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            balls.Add(ball);
        }

        private void btnSoccer_Click(object sender, EventArgs e)
        {
            Ball ball = new Soccer(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            balls.Add(ball);
        }

        private void btnBaseball_Click(object sender, EventArgs e)
        {
            Ball ball = new BaseBall(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            balls.Add(ball);
        }

        private void btnGolf_Click(object sender, EventArgs e)
        {
            Ball ball = new Golf(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            balls.Add(ball);
        }
    }
}
