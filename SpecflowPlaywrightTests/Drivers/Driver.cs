﻿namespace SpecflowPlaywrightTests.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = InitializePlaywright();
        }
        public void Dispose() => _browser?.CloseAsync();
        public IPage Page => _page.Result;

        private async Task<IPage> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            return await _browser.NewPageAsync();
        }
    }
}
