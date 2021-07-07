using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EverLightCodingChallenge
{
    /// <summary>
    /// Manages all components
    /// </summary>
    class GameService
    {
        private readonly IGame _game;
        private readonly INodeManager _nodeManager;
        private readonly IPredictor _predictor;
        private int _EndContainerWithoutBall;
        private int _PredictedContainerToBeWithoutBall;

        public GameService(int depth, int depthInfo)
        {
            var serviceProvider = Util.GetServiceProvider();

            //Initializing the game
            _game = serviceProvider.GetService<Game>();
            _game.InitializeGame(depth);
            //Initializing node manager
            _nodeManager = serviceProvider.GetService<NodeManager>();
            _nodeManager.InitializeNodeManager(depth);
            _game.NodeManager = _nodeManager;
            //Create Predictor to predictor which end container will have no ball
            _predictor = serviceProvider.GetService<Predictor>();
            _predictor.InitializePredictor(depthInfo, depth, _nodeManager.RootNode);
        }

        /// <summary>
        /// Start the game and drop the balls
        /// </summary>
        public void StartGame()
        {
            _EndContainerWithoutBall = _game.Start();
        }

        /// <summary>
        /// Creates Predictions for the game
        /// </summary>
        public void CreatePredictions()
        {
            //Info and prediction
            _PredictedContainerToBeWithoutBall = _predictor.Predict();
        }

        /// <summary>
        /// Check whether prediction matches the actual result
        /// </summary>
        public void CheckPrediction()
        {
            _predictor.Check(_PredictedContainerToBeWithoutBall, _EndContainerWithoutBall);
        }
    }
}
