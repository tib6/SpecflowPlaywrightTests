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
        //PetStore
        public static string petStoreBaseURL => settings.GetConfig().PetStore.baseURL.ToString();
        public static string getPet => settings.GetConfig().PetStore.getPet.ToString();
        public static string addPet => settings.GetConfig().PetStore.addPet.ToString();
        public static string updatePet => settings.GetConfig().PetStore.updatePet.ToString();
        public static string deletePet => settings.GetConfig().PetStore.deletePet.ToString();
    }
}
