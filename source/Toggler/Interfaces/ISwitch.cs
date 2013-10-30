namespace Toggles.Configuration.Interfaces
{
    using System.Collections.Generic;

    public interface IProvideSwitches
    {
        bool IsAvailable(string switchName);
        void ReadConfiguration();
    }
}