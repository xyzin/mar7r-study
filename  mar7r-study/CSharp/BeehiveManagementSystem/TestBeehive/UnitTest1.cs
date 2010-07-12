using BeehiveManagementSystem;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace TestBeehive
{
    /// <summary>
    /// UnitTest1의 요약 설명
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }

        private TestContext testContextInstance;
        private Worker[] workers = new Worker[4];
        private Queen queen;

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

        [TestInitialize()]
        public void MyTestInitialize()
        {
            workers[0] = new Worker(new List<Job>() { new Job("Nectar collector"), 
                                                new Job("Honey manufacturing") },
                                                17);
            workers[1] = new Worker(new List<Job>() { new Job("Egg care"), 
                                                new Job("Baby bee tutoring") },
                                                114);
            workers[2] = new Worker(new List<Job>() { new Job("Hive maintenance"),
                                                new Job("Sting patrol") },
                                                149);
            workers[3] = new Worker(new List<Job>() { new Job("Nectar collector"),
                                                new Job("Honey manufacturing"), 
                                                new Job("Egg care"),
                                                new Job("Baby bee tutoring"),
                                                new Job("Hive maintenace"),
                                                new Job("Sting patrol") },
                                                155);
            queen = new Queen(workers, 275, new Hive(new TextBox(), new TextBox()));
        }
        [TestMethod]
        public void TestWorker()
        {
            //
            // TODO: 테스트 논리를 여기에	추가합니다.
            //

            Assert.AreEqual(workers[3].DoThisJob("Clean hive", 5), false);
            Assert.AreEqual(workers[3].DoThisJob("Nectar collector", 5), true);
            Assert.AreEqual(workers[3].ShiftLeft, 5);
            Assert.IsInstanceOfType(workers[3].WorkOneShift(), typeof(int));
            Assert.AreEqual(workers[3].ShiftLeft, 4);
            Assert.IsInstanceOfType(workers[3].WorkOneShift(), typeof(int));
            Assert.AreEqual(workers[3].ShiftLeft, 3);
            Assert.IsInstanceOfType(workers[3].WorkOneShift(), typeof(int));
            Assert.AreEqual(workers[3].ShiftLeft, 2);
            Assert.IsInstanceOfType(workers[3].WorkOneShift(), typeof(int));
            Assert.AreEqual(workers[3].ShiftLeft, 1);
            Assert.IsInstanceOfType(workers[3].WorkOneShift(), typeof(int));
            Assert.AreEqual(workers[3].ShiftLeft, 0);
            Assert.IsFalse(workers[3].CurrentJob == null);
            Assert.IsInstanceOfType(workers[3].WorkOneShift(), typeof(int));
            Assert.IsTrue(workers[3].CurrentJob == null);
        }

        [TestMethod]
        public void TestQueen()
        {

        }

        [TestMethod]
        public void TestHive()
        {
            TextBox b1 = new TextBox();
            TextBox b2 = new TextBox();
            Hive h = new Hive(b1, b2);

            h.addNectar(-10);
            Assert.AreEqual(b1.Text, (100 - 10).ToString());
            h.addHoney(-100);
            Assert.AreEqual(b2.Text, (3000 - 100).ToString());

            int nectar = 500;
            int honey = 5000;
            Hive h2 = new Hive(b1, b2, nectar, honey);

            h2.addNectar(-10);
            Assert.AreEqual(b1.Text, (nectar - 10).ToString());
            h2.addHoney(-100);
            Assert.AreEqual(b2.Text, (honey - 100).ToString());
        }
    }
}
