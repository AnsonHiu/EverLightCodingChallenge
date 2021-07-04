using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallenge
{
    /// <summary>
    /// Each point within the tree structure
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Left Child Node
        /// </summary>
        public Node LeftNode { get; set; }
        /// <summary>
        /// Right Child Node
        /// </summary>
        public Node RightNode { get; set; }
        /// <summary>
        /// 0 (false) to left, 1(true) to right, determines where the ball falls into
        /// </summary>
        public Boolean Gate { get; set; }
        /// <summary>
        /// the hierarchical level (depth) the current Node is in
        /// </summary>
        public int HierarchyLevel { get; set; }
        public bool Ball { get; set; }
        /// <summary>
        /// if current node is an end node (bottom most node in the tree), assign it a number
        /// </summary>
        public int EndNodeNumber { get; set; }

        public Node(int hierarchy)
        {
            this.HierarchyLevel = hierarchy;
            this.Gate = GetRandomizedGateValue();
            this.Ball = false;
        }

        /// <summary>
        /// Pass a ball through this node, switches gate from left to right in the process
        /// </summary>
        /// <returns>If it is an end node, returns node with hierarchy -1 and End Node Number, otherwise returns the node the ball falls into</returns>
        public Node BallPass()
        {
            Node returnNode;
            if (EndNodeNumber != 0)
            {
                //Ball has landed in this node
                Ball = true;
                returnNode = new Node(-1)
                {
                    EndNodeNumber = this.EndNodeNumber
                };
                return returnNode;
            }
            //True moves the ball to the right, false moves the ball to the left
            returnNode = Gate ? RightNode : LeftNode;
            this.Gate = !this.Gate;
            return returnNode;
        }

        /// <summary>
        /// returns a randomized value of true or false for gates.
        /// </summary>
        /// <returns>false(left) and true(right)</returns>
        private bool GetRandomizedGateValue()
        {
            Random gateRandomizer = new Random();
            return gateRandomizer.Next(0, 2) != 0;
        }
    }
}
