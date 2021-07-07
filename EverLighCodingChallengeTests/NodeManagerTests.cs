using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverLightCodingChallenge;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallengeTests
{
    [TestClass()]
    public class NodeManagerTests
    {
        [TestMethod()]
        public void NodeManagerTest()
        {
            var serviceProvider = Util.GetServiceProvider();
            INodeManager nodeManager = serviceProvider.GetService<NodeManager>();
            nodeManager.InitializeNodeManager(4);
            Node leftMostNode = GetLeftMostNode(nodeManager.RootNode);
            Assert.AreEqual(leftMostNode.HierarchyLevel, 4);
        }

        /// <summary>
        /// Tests whether the end container the ball falls into is within range
        /// </summary>
        [TestMethod()]
        public void PutBallInTreeTest()
        {
            var serviceProvider = Util.GetServiceProvider();
            INodeManager nodeManager = serviceProvider.GetService<NodeManager>();
            nodeManager.InitializeNodeManager(3);
            INodeManager nodeManager2 = serviceProvider.GetService<NodeManager>();
            nodeManager2.InitializeNodeManager(2);
            INodeManager nodeManager3 = serviceProvider.GetService<NodeManager>();
            nodeManager3.InitializeNodeManager(1);

            int endContainer = nodeManager.PutBallInTree();
            int endContainer2 = nodeManager2.PutBallInTree();
            int endContainer3 = nodeManager3.PutBallInTree();

            bool check = 0 < endContainer && endContainer <= 8;
            Assert.IsTrue(check);
            bool check2 = 0 < endContainer2 && endContainer2 <= 4;
            Assert.IsTrue(check2);
            bool check3 = 0 < endContainer3 && endContainer3 <= 2;
            Assert.IsTrue(check3);
        }

        /// <summary>
        /// Gets left most node of current tree
        /// </summary>
        /// <param name="node">root node</param>
        /// <returns>left most node</returns>
        private Node GetLeftMostNode(Node node)
        {
            if (node.LeftNode == null)
                return node;
            return GetLeftMostNode(node.LeftNode);
        }
    }
}