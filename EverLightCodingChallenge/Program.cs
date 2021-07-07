using System;
using System.Threading;

namespace EverLightCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Capture User Input for depth of tree and how much info is allowed for the prediction
            UserInput depths = Util.CaptureUserInputs();
            //If user input errors out, stops program
            if (depths == null)
                return;

            //Start Game, initialize tree with gates
            GameService gameService = new GameService(depths.DepthInt, depths.DepthInfo);
            Thread.Sleep(100);
            gameService.CreatePredictions();
            Thread.Sleep(100);
            gameService.StartGame();
            Thread.Sleep(100);
            gameService.CheckPrediction();            
        }
    }
}
