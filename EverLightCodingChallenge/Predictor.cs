using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallenge
{
    /// <summary>
    /// Manages Predictions of the Game
    /// </summary>
    public class Predictor
    {
        /// <summary>
        /// Predicts which container the ball will fall into based on the available information on gates (depth)
        /// Each layer of info of depth increases accuracy of predictions with 100% accuracy when there is all information
        /// Method will make a random guess based on the remaining unknown Gates
        /// </summary>
        /// <param name="infoDepth">How many layers of info is being factored into the prediction</param>
        /// <param name="treeDepth">How many layers of there are in the tree</param>
        /// <param name="rootNode">The Root of the Node in a game to calculate prediction</param>
        /// <returns>Prediction of Container number where the ball will land on</returns>
        public int Predict(int infoDepth, int treeDepth, Node rootNode)
        {
            return FollowPath(rootNode, treeDepth, infoDepth);
        }

        /// <summary>
        /// Follows path of current node to the bottom node where the ball will not fall into
        /// </summary>
        /// <param name="node">the next node to process</param>
        /// <param name="treeDepth">How many layers of there are in the tree</param>
        /// <param name="infoDepth">How many layers of info is being factored into the prediction</param>
        /// <returns>node which the ball will not fall into</returns>
        public int FollowPath(Node node, int treeDepth, int infoDepth)
        {
            //Prediction is 0 if there are no balls (only 1 container)
            if (treeDepth == 0)
                return 0;
            if(node.HierarchyLevel == infoDepth)
            {
                double possibilities = NumContainersBallCanFallInto(treeDepth, infoDepth);
                int firstEndNode = LeftmostEndNodeFromCurrent(node);
                Console.WriteLine("Number of possible destination based on revealed info: {0}", possibilities);
                Console.WriteLine("Chances the prediction is correct: ~{0}%", Math.Round(100*1/(double)possibilities));
                Random random = new Random();
                return random.Next(firstEndNode, firstEndNode + (int)possibilities);
            }
            else
            {
                //If node is at bottom, return node number of bottom node. Otherwise follow the false gate path to reach destination
                if (node.LeftNode == null)
                    return node.EndNodeNumber;
                if (node.Gate)
                    return FollowPath(node.LeftNode, treeDepth, infoDepth);
                else
                    return FollowPath(node.RightNode, treeDepth, infoDepth);
            }
        }

        /// <summary>
        /// Checks whether predicted empty container and actualy empty container is the same
        /// </summary>
        /// <param name="prediction">predicted empty container</param>
        /// <param name="actual">actual empty container</param>
        /// <returns></returns>
        public bool Check(int prediction, int actual)
        {
            return prediction == actual;
        }

        /// <summary>
        /// Calculates number of unknown nodes
        /// </summary>
        /// <param name="treeDepth">How many layers of there are in the tree</param>
        /// <param name="infoDepth">How many layers of info is being factored into the prediction</param>
        /// <returns>The amount of end containers that the ball can still possibly fall into</returns>
        private double NumContainersBallCanFallInto(int treeDepth, int infoDepth)
        {
            int distance = treeDepth - infoDepth;
            return Convert.ToDouble(Math.Pow(2, distance));
        }


        /// <summary>
        /// Follows down the tree to left mode node from the current node
        /// </summary>
        /// <param name="node">Node to process</param>
        /// <returns>Container number of Left most node the current node can get to</returns>
        private int LeftmostEndNodeFromCurrent(Node node)
        {
            if (node.LeftNode != null)
            {
                return LeftmostEndNodeFromCurrent(node.LeftNode);
            }
            else
            {
                return node.EndNodeNumber;
            }
        }
    }
}
