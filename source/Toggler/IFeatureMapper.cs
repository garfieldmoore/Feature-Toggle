namespace Toggles.Configuration
{
    public interface IFeatureMapper<T>
    {
        Feature Map(T objectToMap);
    }
}