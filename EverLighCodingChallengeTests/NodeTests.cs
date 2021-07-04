using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverLightCodingChallenge;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallengeTests
{
    [TestClass()]
    public class NodeTests
    {
        [TestMethod()]
        public void NodeTest()
        {
            //Checks whether hierarchy levels are initialized properly
            Node node = new Node(0);
            Assert.AreEqual(0, node.HierarchyLevel);
        }

        /// <summary>
        /// Whether the return value is correct when a ball falls into an end container
        /// </summary>
        [TestMethod()]
        public void BallPassTestForEndNode()
        {
            Node node = new Node(4);
            node.EndNodeNumber = 5;
            bool currentGate = node.Gate;
            Node returnNode = node.BallPass();

            Assert.AreEqual(returnNode.HierarchyLevel, -1);
            //Gate isn't changed when it's the end node
            Assert.AreEqual(node.Gate, currentGate);
        }

        /// <summary>
        /// Tests whether the return value is correct when a ball passes through a gate
        /// Tests whether the gate switch direction when a ball passes through
        /// </summary>
        [TestMethod()]
        public void BallPassTestForMiddleNodes()
        {
            Node node = new Node(3);
            node.LeftNode = new Node(4);
            node.LeftNode.EndNodeNumber = 1;
            node.RightNode = new Node(4);
            node.RightNode.EndNodeNumber = 2;
            node.Gate = false;

            Node returnNode = node.BallPass();
            //Return node should be 1 level deeper
            Assert.AreEqual(returnNode.HierarchyLevel, node.HierarchyLevel + 1);
            //Gate is false so should be returning left node (end node number 1)
            Assert.AreEqual(1, returnNode.EndNodeNumber);
            //Gate should be flipped
            Assert.AreEqual(true, node.Gate);
        }
    }
}