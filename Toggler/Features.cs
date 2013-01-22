using System;
using System.Configuration;

namespace Toggles.Configuration
{
    public class Features
    {
        private static ISwitchFactory _switchFactory;

        public static bool IsAvailable(string featureName)
        {
            return  _switchFactory.Create().IsAvaliable(featureName);
        }

        public static void Initialize(ISwitchFactory factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");

            _switchFactory = factory;
        }
    }
}