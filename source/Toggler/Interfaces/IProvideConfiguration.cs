using System.Collections.Generic;

namespace Toggles.Configuration.Interfaces
{
    internal interface IProvideConfiguration
    {
        // TODO: make return type void
        IDictionary<string, Feature> ReadConfiguration();
    }
}