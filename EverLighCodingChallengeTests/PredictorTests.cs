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
            Game game = new Game(4);
            Predictor predictor = new Predictor();

            int prediction = predictor.Predict(4, 4, game.NodeManager.RootNode);
            int actual = game.Start();

            Assert.AreEqual(prediction, actual);
        }
    }
}