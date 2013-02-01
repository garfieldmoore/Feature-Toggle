using System.Collections.Generic;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration
{
    public interface IProvideConfiguration
    {
        IDictionary<string, Feature> ReadConfiguration();
    }
}