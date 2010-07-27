using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BounceBall;
using System.Drawing;

namespace TestBounceBall
{
    /// <summary>
    /// TestBall의 요약 설명
    /// </summary>
    [TestClass]
    public class TestBall
    {
        public TestBall()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///현재 테스트 실행에 대한 정보 및 기능을
        ///제공하는 테스트 컨텍스트를 가져오거나 설정합니다.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 추가 테스트 특성
        //
        // 테스트를 작성할 때 다음 추가 특성을 사용할 수 있습니다.
        //
        // ClassInitialize를 사용하여 클래스의 첫 번째 테스트를 실행하기 전에 코드를 실행합니다.
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup을 사용하여 클래스의 테스트를 모두 실행한 후에 코드를 실행합니다.
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 테스트를 작성할 때 다음 추가 특성을 사용할 수 있습니다. 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestInitialize를 사용하여 각 테스트를 실행하기 전에 코드를 실행합니다.
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMakeBasketBall()
        {
            Ball ball = new BasketBall(1, 1);
            Assert.AreEqual(1, ball.getRadian(), "ball radian is 1");
            Assert.AreEqual(1, ball.getVelocity(), "ball velocity is 1");
        }

        [TestMethod]
        public void TestGetXfactor()
        {
            Ball ball = new BasketBall(1, 20);

            double expected = Math.Cos(1) * 20;
            Assert.AreEqual(expected, ball.getXfactor());
        }

        [TestMethod]
        public void TestGetYfactor()
        {
            Ball ball = new BasketBall(1, 20);

            double exptected = Math.Sin(1) * 20;
            Assert.AreEqual(exptected, ball.getYfactor());
        }

        [TestMethod]
        public void TestRightSideCollision()
        {
            Ball ball = new BasketBall(0, 20, new Point(513, 0));
            Assert.IsFalse(ball.rightCollision(), "이동 전");
            ball.move();
            Assert.IsTrue(ball.rightCollision(), "이동 후");
        }

        [TestMethod]
        public void TestLeftSideCollision()
        {
            Ball ball = new BasketBall(Math.PI, 20, new Point(30, 0));
            Assert.IsFalse(ball.leftCollision(), "이동 전");
            ball.move();
            Assert.IsTrue(ball.leftCollision(), "이동 후");
        }

        [TestMethod]
        public void TestTopSideCollision()
        {
            Ball ball = new BasketBall(Math.PI / 2, 20, new Point(0, 20));
            Assert.IsFalse(ball.topCollision(), "이동 전");
            ball.move();
            Assert.IsTrue(ball.topCollision(), "이동 후");
        }

        [TestMethod]
        public void TestBottomSideCollision()
        {
            Ball ball = new BasketBall(Math.PI * 3 / 2, 20, new Point(0, 300));
            Assert.IsFalse(ball.bottomCollision(), "이동 전");
            ball.move();
            Assert.IsTrue(ball.bottomCollision(), "이동 후");
        }

        [TestMethod]
        public void TestLeftReflect()
        {
            Ball ball = new BasketBall(Math.PI, 20, new Point(30, 0));
            Assert.IsFalse(ball.collision(), "이동 전");
            ball.move();
            Assert.IsTrue(ball.collision(), "충돌 전");
            ball.move();
            Assert.IsFalse(ball.collision(), "충돌 후");

            ball = new BasketBall(Math.PI * 3 / 4, 40, new Point(30, 150));
            Assert.IsFalse(ball.collision(), "이동 전2");
            ball.move();
            Assert.IsTrue(ball.collision(), "충돌 전2");
            ball.move();
            Assert.IsFalse(ball.collision(), "충돌 후2");

            ball = new BasketBall(Math.PI * 5 / 4, 40, new Point(30, 150));
            Assert.IsFalse(ball.collision(), "이동 전3");
            ball.move();
            Assert.IsTrue(ball.collision(), "충돌 전3");
            ball.move();
            Assert.IsFalse(ball.collision(), "충돌 후3");
        }

        [TestMethod]
        public void TestRightReflect()
        {
            Ball ball = new BasketBall(0, 20, new Point(513, 0));
            Assert.IsFalse(ball.collision(), "이동 전");
            ball.move();
            Assert.IsTrue(ball.collision(), "충돌 전");
            ball.move();
            Assert.IsFalse(ball.collision(), "충돌 후");

            ball = new BasketBall(Math.PI / 4, 20, new Point(513, 150));
            Assert.IsFalse(ball.collision(), "이동 전2");
            ball.move();
            Assert.IsTrue(ball.collision(), "충돌 전2");
            ball.move();
            Assert.IsFalse(ball.collision(), "충돌 후2");

            ball = new BasketBall(Math.PI * 7 / 4, 20, new Point(513, 150));
            Assert.IsFalse(ball.collision(), "이동 전3");
            ball.move();
            Assert.IsTrue(ball.collision(), "충돌 전3");
            ball.move();
            Assert.IsFalse(ball.collision(), "충돌 후3");
        }

        //[TestMethod]
        //public void TestGetCurrentPosition()
        //{
        //    Ball ball = new BasketBall(2, 10);
        //    Point exptected = new Point(0, 0);
        //    Assert.AreEqual(exptected, ball.getCurrentPosition());
        //}

        //[TestMethod]
        //public void TestMoveBall()
        //{
        //    Ball ball = new BasketBall(0, 20);
        //    Point exptected = new Point(0, 0);
        //    Assert.AreEqual(exptected, ball.getCurrentPosition());

        //    Point newPosition = new Point(0, 20);
        //    ball.move();
        //    Assert.AreEqual(newPosition, ball.getCurrentPosition());

        //    newPosition.Y += 20;
        //    ball.move();
        //    Assert.AreEqual(newPosition, ball.getCurrentPosition());
        //}
    }
}
