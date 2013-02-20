namespace Toggles.Configuration.Interfaces
{
    public interface ISwitch
    {
        bool IsAvailable(string switchName);
    }
}