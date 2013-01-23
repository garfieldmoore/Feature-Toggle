namespace Toggles.Configuration
{
    public interface ISwitchProviderFactory
    {
        ISwitch Create();
    }
}