using System.Collections.Generic;

namespace Toggles.Configuration
{
    public interface IProvideConfiguration
    {
        IDictionary<string, Feature> ReadConfiguration();
    }
}