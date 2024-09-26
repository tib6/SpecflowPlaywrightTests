namespace SpecflowPlaywrightTests.Base
{
    public class TestSettings
    {
        private static readonly Settings settings;
        static TestSettings()
        {
            settings ??= new Settings();
        }

        //Google
        public static string baseGoogleURL => settings.GetConfig().Google.baseURL.ToString();
    }
}
