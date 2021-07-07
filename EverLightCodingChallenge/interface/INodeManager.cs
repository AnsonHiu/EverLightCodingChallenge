using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallenge
{
    public interface INodeManager
    {
        public Node RootNode { get; }
        public int Depth { get; set; }
        public int PutBallInTree();
        public void InitializeNodeManager(int depth);
    }
}
