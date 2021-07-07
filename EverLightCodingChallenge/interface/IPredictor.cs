using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallenge
{
    public interface IPredictor
    {
        public int Predict();
        public void InitializePredictor(int infoDepth, int treeDepth, Node rootNode);
        void Check(int expected, int actual);
    }
}
