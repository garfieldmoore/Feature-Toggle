using System.Collections.Generic;

namespace Toggles.Configuration
{
    public interface IFeatureMapper<T>
    {
        List<Feature> Map(T objectToMap);
    }
}