using Toggles.Configuration;

namespace Ef.CodeFirstConfig
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        private static void Main(string[] args)
        {
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