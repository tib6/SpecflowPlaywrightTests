namespace SpecflowPlaywrightTests.Hooks
{
    public class ExtentReport
    {
        protected static ExtentReports _extentReports;
        protected static ExtentTest _feature;
        protected static ExtentTest _scenario;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInit()
        {
            // Ensure the test result directory exists
            if (!Directory.Exists(testResultPath))
            {
                Directory.CreateDirectory(testResultPath);
            }

            // Specify the custom path for the Extent report HTML file
            var sparkReporter = new ExtentSparkReporter(Path.Combine(testResultPath, "ExtentReport.html"));
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(sparkReporter);

            // Configuring the reporter
            sparkReporter.Config.DocumentTitle = "Test Report";
            sparkReporter.Config.ReportName = "Automated Test Results";
            sparkReporter.Config.Theme = Theme.Dark;

            // Start the reporting
            _extentReports.AddSystemInfo("Environment", "Development");
            _extentReports.AddSystemInfo("User", "Your Name"); // Update this with your name or the user running the tests
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush(); // Ensures the report is saved
        }

        public static void CreateFeature(string featureName)
        {
            _feature = _extentReports.CreateTest<Feature>(featureName);
        }

        public static void CreateScenario(string scenarioName)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioName);
        }

/*        public static void LogStep(string stepName, string status = "pass")
        {
            if (status.ToLower() == "pass")
                _scenario.CreateNode<Given>(stepName);
            else

                _scenario.CreateNode<Given>(stepName).Fail("Test Failed");
        }*/
    }
}
