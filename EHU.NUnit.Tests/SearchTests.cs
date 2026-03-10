using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace EHU.NUnit.Tests
{
    [TestFixture]
    [Category("Search")]              
    [Parallelizable(ParallelScope.Self)] 
    public class SearchTests : BaseTest
    {
        private const string SearchButtonXPath = "//*[@id='masthead']/div[1]/div/div[4]/div";
        private const string SearchBarXPath = "//*[@id='masthead']/div[1]/div/div[4]/div/form/div/input";

        [Test]
        public void TestCase2_SearchFunctionality_Default()
        {
            RunSearch("study programs");

            wait.Until(d => d.Url.Contains("?s="));
            Assert.That(driver.Url, Does.Contain("/?s="),
                "URL should contain the search query parameter");

            var results = driver.FindElements(By.XPath("//*[@id='page']/div[3]"));
            Assert.That(results.Count, Is.GreaterThan(0), "Should have search results");
        }

        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.SearchQueries))] 
        public void TestCase2_SearchFunctionality_Parameterized(string searchTerm)
        {
            RunSearch(searchTerm);

            wait.Until(d => d.Url.Contains("?s="));
            Assert.That(driver.Url, Does.Contain("/?s="),
                $"URL should contain search query after searching for '{searchTerm}'");

            var results = driver.FindElements(By.XPath("//*[@id='page']/div[3]"));
            Assert.That(results.Count, Is.GreaterThan(0),
                $"Should have results for '{searchTerm}'");
        }

        private void RunSearch(string query)
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var searchButton = wait.Until(d => d.FindElement(By.XPath(SearchButtonXPath)));
            searchButton.Click();

            var searchBar = wait.Until(d => d.FindElement(By.XPath(SearchBarXPath)));
            searchBar.SendKeys(query);
            searchBar.SendKeys(Keys.Enter);
        }
    }
}