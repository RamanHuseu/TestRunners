using NUnit.Framework;
using OpenQA.Selenium;

namespace EHU.NUnit.Tests
{
    [TestFixture]
    [Category("Navigation")]          
    [Parallelizable(ParallelScope.Self)] 
    public class NavigationTests : BaseTest
    {
        [Test]
        public void TestCase1_NavigateToAboutEHU()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            IWebElement aboutLink = wait.Until(d => d.FindElement(By.LinkText("About")));
            aboutLink.Click();

            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Does.Contain("/about/"),
                    "URL should contain /about/");
                Assert.That(driver.Title, Does.Contain("About"),
                    "Page title should contain 'About'");
            });

            IWebElement header = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.That(header.Text, Does.Contain("About"),
                "H1 header should contain 'About'");
        }

        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.NavigationLinks))]
        public void TestCase_NavigateToPage(string linkText, string urlPart, string titlePart)
        {
            driver.Navigate().GoToUrl(BaseUrl);

            IWebElement link = wait.Until(d => d.FindElement(By.LinkText(linkText)));
            link.Click();

            Assert.That(driver.Url, Does.Contain(urlPart),
                $"URL should contain {urlPart}");
        }

        [Test]
        public void TestCase3_LanguageChange()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var languageSwitcher = wait.Until(d => d.FindElement(
                By.XPath("//*[@id='masthead']/div[1]/div/div[4]/ul")));
            languageSwitcher.Click();

            var lithuanianOption = wait.Until(d => d.FindElement(
                By.XPath("//*[@id='masthead']/div[1]/div/div[4]/ul/li/ul/li[3]/a")));
            lithuanianOption.Click();

            wait.Until(d => d.Url.Contains("lt.ehu"));

            Assert.That(driver.Url, Does.Contain("lt.ehu"),
                "Should redirect to Lithuanian version");
        }
    }
}