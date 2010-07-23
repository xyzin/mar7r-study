using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntQuiz;

namespace AntQuizTest
{
    /// <summary>
    /// AntQUIZtest의 요약 설명
    /// </summary>
    [TestClass]
    public class AntQUIZtest
    {
        public AntQUIZtest()
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
        public void TestIsSameWithKey()
        {
            AntString antStr = new AntString("1010");
            Assert.IsFalse(antStr.isSameWithKey(1));
            Assert.IsTrue(antStr.isSameWithKey(2));
            Assert.IsFalse(antStr.isSameWithKey(3));
            Assert.IsFalse(antStr.isSameWithKey(4));
        }

        [TestMethod]
        public void TestGetAnt()
        {
            AntString antStr = new AntString("001100");
            Assert.AreEqual("021202", antStr.getNextAnt());

            antStr = new AntString("1");
            Assert.AreEqual("11", antStr.getNextAnt());

            antStr = new AntString("11");
            Assert.AreEqual("12", antStr.getNextAnt());

            //antStr = new AntString("");
            //Assert.AreEqual("", antStr.getNextAnt());
        }

        [TestMethod]
        public void TestGetSameCount()
        {
            AntString antStr = new AntString("111100");
            Assert.AreEqual(4, antStr.getSameCount());
        }

        [TestMethod]
        public void TestNextKeyAndOverflowNextKey()
        {
            AntString antStr = new AntString("00011100");
            Assert.AreEqual("0", antStr.getKey());
            Assert.IsTrue(antStr.nextKeyPosition(3));
            Assert.AreEqual("1", antStr.getKey());
            Assert.IsTrue(antStr.nextKeyPosition(3));
            Assert.AreEqual("0", antStr.getKey());
            
            Assert.IsFalse(antStr.nextKeyPosition(2));
        }

        [TestMethod]
        public void TestGetSameCountAndNextKey()
        {
            AntString antStr = new AntString("110001110");
            Assert.AreEqual("1", antStr.getKey());

            int nextKeyPosition = antStr.getSameCount();
            antStr.nextKeyPosition(nextKeyPosition);
            Assert.AreEqual("0", antStr.getKey());

            nextKeyPosition = antStr.getSameCount();
            antStr.nextKeyPosition(nextKeyPosition);
            Assert.AreEqual("1", antStr.getKey());

            nextKeyPosition = antStr.getSameCount();
            antStr.nextKeyPosition(nextKeyPosition);
            Assert.AreEqual("0", antStr.getKey());
        }
    }
}
