using System;
using Microsoft.Extensions.Logging;

namespace EverLightCodingChallenge
{
    /// <summary>
    /// Manages the state of the Game
    /// </summary>
    public class Game : IGame
    {
        private readonly ILogger _logger;
        public INodeManager NodeManager { get; set; }
        /// <summary>
        /// Keeps a count of all the end nodes that has balls in them
        /// </summary>
        private int[] _ContainersWithBall;
        /// <summary>
        /// Count of how many balls are left to put into the tree nodes
        /// </summary>
        private int _BallCount;
        /// <summary>
        /// Count of how many end containers have a ball in them
        /// </summary>
        public int EndContainerCount { get; set; }
        public int Depth { get; set; }

        public Game(ILogger<Game> logger)
        {
            _logger = logger;
        }

        public void InitializeGame(int depth)
        {
            _logger.LogInformation("Initializing Game...");
            //Initializing game variables
            this.EndContainerCount = 0;
            //Calculate amount of end containers based on depth and initialize array to hold all end containers that has a ball
            int amountOfEndContainers = Convert.ToInt32(Math.Pow(2, depth));
            //1 End Container won't have a ball, so ball count is end node size - 1
            _BallCount = amountOfEndContainers - 1;
            //Console.WriteLine("Ball Count: {0}", _BallCount);
            _logger.LogInformation("Ball Count: {0}", _BallCount);
            this._ContainersWithBall = new int[amountOfEndContainers - 1];
        }

        /// <summary>
        /// Entry point of the game
        /// Initializes all nodes, then add balls in 1 by 1
        /// Finally sorts array and find missing number in array to find the empty slot
        /// </summary>
        /// <returns>End Container that remained empty after all the balls were dropped</returns>
        public int Start()
        {
            int sumOfEndNode = 0;
            while (_BallCount != 0)
            {
                int endContainerNo = NodeManager.PutBallInTree();
                sumOfEndNode += endContainerNo;
                AddBallContainerIntoArray(endContainerNo);
                _BallCount--;
            }
            //Calculate total sum of all end containers
            int totalSum = (EndContainerCount + 2) * (EndContainerCount + 1) / 2;
            //There's only 1 container, which means there aren't any balls
            if (totalSum == 1)
                return 0;
            int containerWithMissingBall = totalSum - sumOfEndNode;
            return containerWithMissingBall;
            //Console.WriteLine("Ball is missing from: Node {0}", containerWithMissingBall);

        }

        /// <summary>
        /// Once a ball reaches an end container, this function is called to add the node into the ContainersWithBall array.
        /// </summary>
        /// <param name="endContainerNo"></param>
        private void AddBallContainerIntoArray(int endContainerNo)
        {
            _ContainersWithBall[EndContainerCount] = endContainerNo;
            EndContainerCount++;
        }
    }
}
