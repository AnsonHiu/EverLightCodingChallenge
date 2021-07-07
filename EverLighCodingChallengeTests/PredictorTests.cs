using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverLightCodingChallenge;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallengeTests
{
    [TestClass()]
    public class PredictorTests
    {
        /// <summary>
        /// Checks whether prediction is working as expected when predictor has all level of information of the tree
        /// </summary>
        [TestMethod()]
        public void PredictTest()
        {
            var serviceProvider = Util.GetServiceProvider();
            IGame game = serviceProvider.GetService<Game>();
            game.InitializeGame(4);
            INodeManager nodeManager = serviceProvider.GetService<NodeManager>();
            nodeManager.InitializeNodeManager(4);
            game.NodeManager = nodeManager;

            IPredictor predictor = serviceProvider.GetService<Predictor>();
            predictor.InitializePredictor(4, 4, nodeManager.RootNode);

            int prediction = predictor.Predict();
            int actual = game.Start();

            Assert.AreEqual(prediction, actual);
        }
    }
}