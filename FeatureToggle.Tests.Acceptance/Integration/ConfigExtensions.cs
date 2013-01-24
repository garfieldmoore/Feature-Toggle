using System.Collections.Generic;
using System.Linq;
using Toggles.Configuration;

namespace FeatureToggle.Tests.Acceptance
{
    public static class ConfigExtensions
    {
        public static List<T> ToList<T>(this FeatureConfiguration config) where T:class 
        {
            return config.Features.Cast<T>().ToList();
        }
    }
}