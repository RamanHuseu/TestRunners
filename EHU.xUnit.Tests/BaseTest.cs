using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace EHU.XUnit
{
  
    public class TestBase : IDisposable
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected const string BaseUrl = "https://en.ehu.lt/";

        public TestBase()
        {
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");

            driver = new ChromeDriver(options);

          
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
           
            driver?.Quit();
            driver?.Dispose();
        }
    }
}