using System.Collections.Generic;

namespace Toggles.Configuration.Interfaces
{
    public interface IProvideConfiguration
    {
        IDictionary<string, Feature> ReadConfiguration();
    }
}