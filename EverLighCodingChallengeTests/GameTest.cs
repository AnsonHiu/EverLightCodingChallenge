using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverLightCodingChallenge;
using System;

namespace EverLightCodingChallengeTests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void Test0DepthGame()
        {
            Game game1 = new Game(0);
            int endContainer = game1.Start();

            //Expect there wouldn't be any ball if there is only 1 container (no. of balls is number of end container - 1)
            int expected = 0;
            Assert.AreEqual(expected, endContainer);
        }

        [TestMethod]
        public void TestEndContainer()
        {
            //After game finishes, the number of containers with balls should be max number of containers - 1
            Game game1 = new Game(1);
            game1.Start();
            int expected = Convert.ToInt32(Math.Pow(2, 1) - 1);
            Assert.AreEqual(expected, game1.EndContainerCount);

            Game game2 = new Game(2);
            game2.Start();
            int expected2 = Convert.ToInt32(Math.Pow(2, 2) - 1);
            Assert.AreEqual(expected2, game2.EndContainerCount);

            Game game3 = new Game(3);
            game3.Start();
            int expected3 = Convert.ToInt32(Math.Pow(2, 3) - 1);
            Assert.AreEqual(expected3, game3.EndContainerCount);
        }
    }
}
