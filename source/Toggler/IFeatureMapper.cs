using System.Collections.Generic;

namespace Toggles.Configuration
{
    internal interface IFeatureMapper<T>
    {
        List<Feature> Map(T objectToMap);
    }
}