namespace SpecflowPlaywrightTests.StepDefinitions
{
    [Binding]
    public sealed class GoogleTwoStepDefinitions
    {
        private readonly Driver _driver;
        private readonly GooglePage googlePage;
        private readonly GooglePageSecond googlePageSecond;
        private string saveSearch;

        public GoogleTwoStepDefinitions(Driver driver)
        {
            _driver = driver;
            googlePage = new GooglePage(_driver.Page);
            googlePageSecond = new GooglePageSecond(_driver.Page);
            saveSearch = "";
        }

        [Given(@"Enter the google URL Google Two")]
        public void EnterURL()
        {
            _driver.Page.GotoAsync(TestSettings.baseGoogleURL);
        }

        [When(@"Google Search (.*) and (.*)")]
        public async Task WhenGoogleSearchFish(string searchTwo, string var)
        {
            Console.WriteLine(searchTwo + "  " + var);
            await googlePageSecond.selectDivByText("Accept all").ClickAsync();
            await googlePageSecond.insertBox().FillAsync(searchTwo + "  " + var);
            saveSearch = searchTwo + " " + var;
        }

        [When(@"Navigate Google Two")]
        public void WhenNavigateToChannel()
        {
            googlePageSecond.insertBox().PressAsync("Enter");
        }

        [Then(@"Verify Google Two")]
        public async Task ThenVerifyTitleOfThePage()
        {
            await _driver.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            string title = await _driver.Page.TitleAsync();
            Console.WriteLine("Title is: " + title + " : " + saveSearch);
            Assert.That(title.Contains(saveSearch));
        }
    }
}