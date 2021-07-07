using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallenge
{
    public interface IGame
    {
        INodeManager NodeManager { get; set; }
        public int Start();
        public void InitializeGame(int depth);
    }
}
