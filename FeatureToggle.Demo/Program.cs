using Toggles.Configuration;
using Toggles.Configuration.Factories;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace Ef.CodeFirstConfig
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        public static void BootStrapper()
        {
            Features.Initialize(new ConfigurationSectionSwitchProviderFactory());    
        }

        private static void Main(string[] args)
        {
            BootStrapper();

            if (Features.IsAvailable("Feature001"))
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