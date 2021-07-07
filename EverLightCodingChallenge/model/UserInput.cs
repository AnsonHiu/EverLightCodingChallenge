using System;
using System.Collections.Generic;
using System.Text;

namespace EverLightCodingChallenge
{
    public class UserInput
    {
        public int DepthInt { get; set; }
        public int DepthInfo { get; set; }

        public UserInput(int depthInt, int depthInfo)
        {
            this.DepthInt = depthInt;
            this.DepthInfo = depthInfo;
        }
    }
}
