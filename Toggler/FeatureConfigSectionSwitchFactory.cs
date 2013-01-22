namespace Toggles.Configuration
{
    public class FeatureConfigSectionSwitchFactory : ISwitchFactory
    {
        public ISwitch Create()
        {
            return new FeatureConfigSectionSwitch();
        }
    }
}