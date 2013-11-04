using System.Configuration;

namespace Toggles.Configuration
{
    public class Feature 
    {
        public string Name { get; set; }
    
        public bool State { get; set; }

//        public Feature DependsOn { get; set; }
    }
}