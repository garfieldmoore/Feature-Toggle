namespace Toggles.Configuration
{
    public interface ISwitch
    {
        bool IsAvailable(string switchName);
    }
}