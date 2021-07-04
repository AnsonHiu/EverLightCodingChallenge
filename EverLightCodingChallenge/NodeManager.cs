using System;

namespace EverLightCodingChallenge
{
    /// <summary>
    /// Manages the whole tree in the game
    /// </summary>
    public class NodeManager
    {
        /// <summary>
        /// Root of all nodes
        /// </summary>
        public Node RootNode { get; }
        /// <summary>
        /// Depth of tree
        /// </summary>
        private readonly int _Depth;
        private int _EndNodeCount;

        /// <summary>
        /// Initializes Node Manager with created containers
        /// </summary>
        /// <param name="depth">The depth of the tree</param>
        public NodeManager(int depth)
        {
            _EndNodeCount = 0;
            //Root node has a hierarchy level(depth) of 0
            RootNode = new Node(0);
            //If there's no depth (only 1 node), RootNode is the end node
            if (depth == 0)
                RootNode.EndNodeNumber = _EndNodeCount+1;
            this._Depth = depth;
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
                Console.WriteLine("Ball landed in node: " + node.EndNodeNumber);
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
            if (node.HierarchyLevel!= _Depth)
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
            if (newNode.HierarchyLevel == _Depth) 
            {
                newNode.EndNodeNumber = _EndNodeCount + 1;
                _EndNodeCount++;
            }
            return newNode;
        }
    }
}
