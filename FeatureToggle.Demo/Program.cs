using Toggles.Configuration;

namespace Ef.CodeFirstConfig
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        public static void BootStrapper()
        {
            Features.Initialize(new FeatureConfigSectionSwitchFactory());    
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