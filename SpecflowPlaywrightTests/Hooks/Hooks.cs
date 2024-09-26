namespace SpecflowPlaywrightTests.Hooks
{
    namespace SpecflowPlaywrightTests.Hooks
    {
        [Binding]
        public sealed class Hooks : ExtentReport
        {
            private readonly IObjectContainer _container;
            private Driver _driver;

            public Hooks(IObjectContainer container)
            {
                _container = container;
                _driver = new Driver();
            }

            [BeforeTestRun]
            public static void BeforeTestRun()
            {
                // Initialize the Extent Report
                ExtentReportInit();
            }

            [AfterTestRun]
            public static void AfterTestRun()
            {
                // Flush and close the Extent Report
                ExtentReportTearDown();
            }

            [BeforeFeature]
            public static void BeforeFeature(FeatureContext featureContext)
            {
                // Create a new feature in the Extent Report
                CreateFeature(featureContext.FeatureInfo.Title);
            }

            [BeforeScenario(Order = 1)]
            public void FirstBeforeScenario(ScenarioContext scenarioContext)
            {
                // Initialize Playwright Driver
                //_driver = new Driver();

                // Register the driver for dependency injection
                _container.RegisterInstanceAs(_driver);

                // Create a scenario node in the Extent Report
                CreateScenario(scenarioContext.ScenarioInfo.Title);
            }

            [AfterScenario]
            public async Task AfterScenario()
            {
                var driver = _container.Resolve<Driver>();

                if (driver != null)
                {
                    await driver.Page.CloseAsync();
                }
            }

            [AfterStep]
            public async Task AfterStep(ScenarioContext scenarioContext)
            {
                string stepName = scenarioContext.StepContext.StepInfo.Text;

                var driver = _container.Resolve<Driver>();

                if (scenarioContext.TestError == null)
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else
                {
                    // Log failure with screenshot
                    string screenshotPath = await CaptureScreenshot(driver, scenarioContext);
                    var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, mediaEntity);
                }
            }

            private async Task<string> CaptureScreenshot(Driver driver, ScenarioContext scenarioContext)
            {
                // Ensure the test result directory exists
                if (!Directory.Exists(testResultPath))
                {
                    Directory.CreateDirectory(testResultPath);
                }
                var screenshotFolderPath = Path.Combine(testResultPath, "Captures");

            // Capture a screenshot using Playwright and save it to a file
            string screenshotFileName = $"{scenarioContext.ScenarioInfo.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.png"; // Unique filename
                string screenshotPath = Path.Combine(screenshotFolderPath, screenshotFileName);
                await driver.Page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });
                return screenshotPath;
            }
        }
    }
}