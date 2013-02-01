using Toggles.Configuration;
using Toggles.Configuration.Factories;
using System;

namespace FeatureSwitch.Demo
{
    internal class Program
    {
        public static void BootStrapper()
        {
            // doesn't need to be initialised if you want to use the default
            //Features.Initialize(new ConfigurationSectionSwitchProviderFactory());    
        }

        private static void Main(string[] args)
        {
            BootStrapper();

            if (Features.IsAvailable("Entity Framework"))
            {
                Console.WriteLine("Entity framework is enabled.");
            }
            else
            {
                Console.WriteLine("Entity framework is not enabled.");
            }

            Console.ReadKey();
        }
    }
}