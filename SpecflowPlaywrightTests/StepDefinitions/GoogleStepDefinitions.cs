namespace SpecflowPlaywrightTests.StepDefinitions
{
    [Binding]
    public sealed class GoogleStepDefinitions
    {
        private readonly Driver _driver;
        private readonly GooglePage googlePage;
        private readonly GooglePageSecond googlePageSecond;
        private string saveSearch;

       public GoogleStepDefinitions(Driver driver)
        {
            _driver = driver;
            googlePage = new GooglePage(_driver.Page);
            googlePageSecond = new GooglePageSecond(_driver.Page);
            saveSearch = "";
        }

        [Given(@"Google URL")]
        public void EnterURL()
        {
            _driver.Page.GotoAsync(TestSettings.baseGoogleURL); 
        }

        [When(@"Search (.*)")]
        public async Task WhenSearch(string search)
        {
            await googlePageSecond.selectDivByText("Accept all").ClickAsync();
            var isExists = await googlePageSecond.isInsertBoxExisting();
            isExists.Should().BeTrue(); 
            await googlePage.insertBox().FillAsync(search);
            saveSearch = search;
        }

        [When(@"Navigate")]
        public async Task WhenNavigateToChannel()
        {
            await googlePage.insertBox().PressAsync("Enter");
        }

        [Then(@"Verify")]
        public async Task ThenVerifyTitleOfThePage()
        {
            await _driver.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            string title = await _driver.Page.TitleAsync();
            Console.WriteLine("Title is: " + title + " : " + saveSearch);
            Assert.That(title, Does.Contain(saveSearch));
        }
    }
}