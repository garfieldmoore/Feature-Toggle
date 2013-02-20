using System.Collections.Generic;

namespace Toggles.Configuration.Interfaces
{
    internal interface IFeatureMapper<T>
    {
        List<Feature> Map(T objectToMap);
    }
}