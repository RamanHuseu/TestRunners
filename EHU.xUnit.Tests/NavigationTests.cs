using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace EHU.XUnit
{
    [Trait("Category", "Navigation")]
    public class NavigationTests : TestBase
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void TestCase1_NavigateToAboutEHU()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            IWebElement aboutLink = wait.Until(d => d.FindElement(By.LinkText("About")));
            aboutLink.Click();

            Assert.Contains("/about/", driver.Url);
            Assert.Contains("About", driver.Title);

            IWebElement header = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.Contains("About", header.Text);
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void TestCase3_LanguageChange()
        {
            
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

            driver.Navigate().GoToUrl(BaseUrl);

            var languageSwitcher = wait.Until(d =>
                d.FindElement(By.XPath("//*[@id='masthead']/div[1]/div/div[4]/ul")));
            languageSwitcher.Click();

            var lithuanianOption = wait.Until(d =>
                d.FindElement(By.XPath("//*[@id='masthead']/div[1]/div/div[4]/ul/li/ul/li[3]/a")));

            
            var href = lithuanianOption.GetAttribute("href");

            try
            {
                driver.Navigate().GoToUrl(href);
            }
            catch (WebDriverException)
            {
                
                Thread.Sleep(3000);
            }

            
            var longWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            bool urlChanged = false;
            try
            {
                urlChanged = longWait.Until(d => d.Url.Contains("lt.ehu") || d.Url.Contains("lt."));
            }
            catch
            {
                urlChanged = driver.Url.Contains("lt.ehu") || driver.Url.Contains("lt.");
            }

            Assert.True(urlChanged, $"Should redirect to Lithuanian version. Current URL: {driver.Url}");

            var bodyText = driver.FindElement(By.TagName("body")).Text;
            Assert.True(bodyText.Length > 0, "Lithuanian page should have content");
        }
    }
}