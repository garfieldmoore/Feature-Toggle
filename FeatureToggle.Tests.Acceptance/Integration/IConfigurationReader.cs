namespace FeatureToggle.Tests.Acceptance
{
    public interface IConfigurationReader
    {
        T LoadConfiguration<T>(string configuration) where T : class;
    }
}