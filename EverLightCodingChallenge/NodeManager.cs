using Microsoft.Extensions.Logging;
using System;

namespace EverLightCodingChallenge
{
    /// <summary>
    /// Manages the whole tree in the game
    /// </summary>
    public class NodeManager : INodeManager
    {
        private readonly ILogger _logger;
        /// <summary>
        /// Root of all nodes
        /// </summary>
        public Node RootNode { get; set; }
        /// <summary>
        /// Depth of tree
        /// </summary>
        public int Depth { get; set; }
        private int _EndNodeCount;

        public NodeManager(ILogger<NodeManager> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Initializes Node Manager with created containers
        /// </summary>
        /// <param name="depth">The depth of the tree</param>
        public void InitializeNodeManager(int depth)
        {
            this.Depth = depth;
            _EndNodeCount = 0;
            //Root node has a hierarchy level(depth) of 0
            RootNode = new Node(0);
            //If there's no depth (only 1 node), RootNode is the end node
            if (depth == 0)
                RootNode.EndNodeNumber = _EndNodeCount + 1;
            this.Depth = depth;
            //Creates all child nodes from the root node
            CreateChildNodes(RootNode);
        }

        /// <summary>
        /// Puts a ball into the root node of the tree
        /// </summary>
        /// <returns>Number of the end node the ball falls into</returns>
        public int PutBallInTree()
        {
            return BallDrop(RootNode);
        }

        /// <summary>
        /// Imitates the ball dropping into the containers
        /// </summary>
        /// <param name="node">the next node to process</param>
        /// <returns></returns>
        private int BallDrop(Node node)
        {
            Node nextNode = node.BallPass();
            if (nextNode.HierarchyLevel == -1)
            {
                _logger.LogInformation("Ball landed in node: " + node.EndNodeNumber);
                return node.EndNodeNumber;
            }
            else
                return BallDrop(nextNode);
        }

        /// <summary>
        /// Creates child nodes recursively until node hierarchy hits depth from user input
        /// </summary>
        /// <param name="node">Node to create next layer of depth</param>
        /// <param name="depth">Depth of tree</param>
        private void CreateChildNodes(Node node)
        {
            if (node.HierarchyLevel!= Depth)
            {
                node.LeftNode = CreateChildNode(node);
                CreateChildNodes(node.LeftNode);
                node.RightNode = CreateChildNode(node);
                CreateChildNodes(node.RightNode);
            }
        }

        /// <summary>
        /// Creates a child node from the parent parameter node
        /// </summary>
        /// <param name="node">Node to create next layer of depth</param>
        /// <returns>child node</returns>
        private Node CreateChildNode(Node node)
        {
            Node newNode = new Node(node.HierarchyLevel + 1);
            if (newNode.HierarchyLevel == Depth) 
            {
                newNode.EndNodeNumber = _EndNodeCount + 1;
                _EndNodeCount++;
            }
            return newNode;
        }
    }
}
