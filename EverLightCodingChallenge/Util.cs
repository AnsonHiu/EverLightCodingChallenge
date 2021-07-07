using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace EverLightCodingChallenge
{
    /// <summary>
    /// Util class for general functions
    /// </summary>
    public class Util
    {
        public static IServiceProvider ServiceProvider;

        /// <summary>
        /// Captures 2 user inputs Depth and Depth info
        /// Depth is for initializing tree depth
        /// Depth info is for user to decide how blindfold the predictor is
        /// </summary>
        /// <returns>UserInput object containing depth and depth info from user input</returns>
        public static UserInput CaptureUserInputs()
        {
            int depthInt, depthInfo;
            try
            {
                //Gets depth from user
                Console.Write("Enter depth: ");
                String depthString = Console.ReadLine();
                depthInt = Int32.Parse(depthString);
                if (depthInt < 0)
                {
                    //Cannot create tree with negative depth
                    Console.WriteLine("Depth cannot be negative! Exiting application...");
                    return null;
                }
                Console.Write("Enter layers of depth the predictor can have access to: ");
                String depthInfoString = Console.ReadLine();
                depthInfo = Int32.Parse(depthInfoString);
                if (depthInfo > depthInt)
                {
                    Console.WriteLine("Layers of depth revealed to the predictor cannot be greater than max tree depth. Exiting application...");
                    return null;
                }
                else if (depthInfo < 0)
                {
                    Console.WriteLine("Layers of depth revealed to the predictor cannot be negative! Exiting application...");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid numerical value. Exiting application...");
                return null;
            }
            return new UserInput(depthInt, depthInfo);
        }

        /// <summary>
        /// Intializing logging
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .AddTransient<Game>()
                .AddTransient<NodeManager>()
                .AddTransient<Predictor>();
        }

        public static IServiceProvider GetServiceProvider()
        {
            if(ServiceProvider == null)
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                ServiceProvider = serviceCollection.BuildServiceProvider();
            }
            return ServiceProvider;
        }
    }
}
