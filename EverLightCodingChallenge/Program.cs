using System;

namespace EverLightCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Capture User Input for depth of tree and how much info is allowed for the prediction
            int depthInt;
            int depthInfo;
            try
            {
                Console.Write("Enter depth: ");
                String depthString = Console.ReadLine();
                depthInt = Int32.Parse(depthString);
                if(depthInt < 0)
                {
                    Console.WriteLine("Depth cannot be negative! Exiting application...");
                    return;
                }
                Console.Write("Enter layers of depth the predictor can have access to: ");
                String depthInfoString = Console.ReadLine();
                depthInfo = Int32.Parse(depthInfoString);
                if (depthInfo > depthInt)
                {
                    Console.WriteLine("Layers of depth revealed to the predictor cannot be greater than max tree depth. Exiting application...");
                    return;
                } 
                else if (depthInfo < 0)
                {
                    Console.WriteLine("Layers of depth revealed to the predictor cannot be negative! Exiting application...");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid numerical value. Exiting application...");
                return;
            }

            //Start Game, initialize tree with gates
            Game Game1 = new Game(depthInt);
            //Create Predictor to predictor which end container will have no ball
            Predictor predictor = new Predictor();

            //Info and prediction
            Console.WriteLine("Layers of Containers factored into prediction calculation: {0}", depthInfo);
            int containerPredictedWithNoBall = predictor.Predict(depthInfo, depthInt, Game1.NodeManager.RootNode);
            Console.WriteLine("Container predicted to be empty: {0}", containerPredictedWithNoBall);

            //Start the game and drop the balls
            int containerWithMissingBall = Game1.Start();

            //Check whether prediction matches the actual result
            bool prediction = predictor.Check(containerPredictedWithNoBall, containerWithMissingBall);
            if (prediction)
                Console.WriteLine("Prediction ({0}) matches with Actual ({1})", containerPredictedWithNoBall, containerWithMissingBall);
            else
                Console.WriteLine("Prediction ({0}) did not match with Actual ({1})", containerPredictedWithNoBall, containerWithMissingBall);

        }
    }
}
