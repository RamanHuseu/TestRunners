using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace EHU.Core.Driver
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(BrowserType browser = BrowserType.Chrome)
        {
            if (browser == BrowserType.Chrome)
                return CreateChromeDriver();

            throw new NotSupportedException($"Browser {browser} is not supported");
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new DriverOptionsBuilder()
                .WithNoSandbox()
                .WithDisabledDevShm()
                .WithWindowSize(1920, 1080)
                .WithDisabledGpu()
                .Build();

            
            var service = ChromeDriverService.CreateDefaultService();

            var driver = new ChromeDriver(service, options, TimeSpan.FromMinutes(5));

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(3);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }

    public enum BrowserType
    {
        Chrome
    }
}