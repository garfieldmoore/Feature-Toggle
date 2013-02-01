namespace Rainbow.Wrappers.Configuration
{
    public interface IConfigurationReader
    {
        T LoadConfiguration<T>(string configuration) where T : class;
    }
}