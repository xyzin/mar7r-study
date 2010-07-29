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
        private volatile bool isMoving = false;
        private Thread thread;
        private Random random;

        delegate void ballMoveCallback();

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

            if (isMoving)
            {
                thread = new Thread(ballMove);
                thread.Start();
                while (!thread.IsAlive) ;
            }
            else
            {
                thread.Join();
            }
        }

        private void ballMove()
        {
            while (isMoving)
            {
                Ball[] ballArray;
                Monitor.Enter(this);
                ballArray = new Ball[balls.Count];
                balls.CopyTo(ballArray);
                Monitor.Exit(this);
                foreach (Ball ball in ballArray)
                {
                    if (ball.pb.InvokeRequired)
                    {
                        ballMoveCallback m = new ballMoveCallback(ball.move);
                        this.Invoke(m);
                    }
                    else
                    {

                        ball.move();
                    }
                }
                
                Thread.Sleep(50);
//                Refresh();
            }
        }

        private void btnBasket_Click(object sender, EventArgs e)
        {
            Ball ball = new BasketBall(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            AddBall(ball);
        }

        private void AddBall(Ball ball)
        {
            if (Monitor.TryEnter(this) == false)
            {
                Console.WriteLine("임계 영역에 들어가는데 실패");
            }
            else
            {
                balls.Add(ball);
                Monitor.Exit(this);
            }
        }

        private void btnSoccer_Click(object sender, EventArgs e)
        {
            Ball ball = new Soccer(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            AddBall(ball);
        }

        private void btnBaseball_Click(object sender, EventArgs e)
        {
            Ball ball = new BaseBall(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            AddBall(ball);
        }

        private void btnGolf_Click(object sender, EventArgs e)
        {
            Ball ball = new Golf(random.Next(600) / 100, random.Next(20) + 1,
                new Point(random.Next(500), random.Next(300)));
            this.panel1.Controls.Add(ball.getPictureBox());
            AddBall(ball);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isMoving)
                isMoving = false;
            thread.Abort();
            while (thread.IsAlive)
                System.Threading.Thread.Sleep(500);
        }
    }
}
