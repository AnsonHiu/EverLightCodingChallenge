using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
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
            var serviceProvider = Util.GetServiceProvider();

            //Initializing the game
            Game game1 = serviceProvider.GetService<Game>();
            game1.InitializeGame(0);
            INodeManager nodeManager1 = serviceProvider.GetService<NodeManager>();
            nodeManager1.InitializeNodeManager(0);
            game1.NodeManager = nodeManager1;
            int endContainer = game1.Start();

            //Expect there wouldn't be any ball if there is only 1 container (no. of balls is number of end container - 1)
            int expected = 0;
            Assert.AreEqual(expected, endContainer);
        }

        [TestMethod]
        public void TestEndContainer()
        {
            var serviceProvider = Util.GetServiceProvider();

            //After game finishes, the number of containers with balls should be max number of containers - 1
            Game game1 = serviceProvider.GetService<Game>();
            INodeManager nodeManager1 = serviceProvider.GetService<NodeManager>();
            nodeManager1.InitializeNodeManager(1);
            game1.NodeManager = nodeManager1;
            game1.InitializeGame(1);
            game1.Start();
            int expected = Convert.ToInt32(Math.Pow(2, 1) - 1);
            Assert.AreEqual(expected, game1.EndContainerCount);

            Game game2 = serviceProvider.GetService<Game>();
            INodeManager nodeManager2 = serviceProvider.GetService<NodeManager>();
            nodeManager2.InitializeNodeManager(2);
            game2.NodeManager = nodeManager2;
            game2.InitializeGame(2);
            game2.Start();
            int expected2 = Convert.ToInt32(Math.Pow(2, 2) - 1);
            Assert.AreEqual(expected2, game2.EndContainerCount);

            Game game3 = serviceProvider.GetService<Game>();
            INodeManager nodeManager3 = serviceProvider.GetService<NodeManager>();
            nodeManager3.InitializeNodeManager(3);
            game3.NodeManager = nodeManager3;
            game3.InitializeGame(3);
            game3.Start();
            int expected3 = Convert.ToInt32(Math.Pow(2, 3) - 1);
            Assert.AreEqual(expected3, game3.EndContainerCount);
        }
    }
}
