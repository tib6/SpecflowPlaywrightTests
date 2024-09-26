namespace SpecflowPlaywrightTests.Pages
{
    public class GooglePageSecond
    {
        private IPage page;

        public GooglePageSecond(IPage page)
        {
            this.page = page;
        }
        public ILocator selectDivByText(string value) => page.Locator($"//div[text() = '{value}']");
        public ILocator insertBox() => page.Locator("//textarea[@class = 'gLFyf']");
        public ILocator searchButton(string value) => page.Locator($"//div[contains(@class, 'FPdoLc')]//input[@value='{value}']");
        public ILocator CautaGoogle(string value) => page.Locator("//input[@value = 'Google Search']");

        public async Task<bool> isInsertBoxExisting() => await insertBox().IsVisibleAsync();
    }
}
