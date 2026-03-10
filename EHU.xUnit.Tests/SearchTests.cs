using OpenQA.Selenium;
using Xunit;

namespace EHU.XUnit
{
    [Trait("Category", "Search")]
    public class SearchTests : TestBase
    {
        
        public static IEnumerable<object[]> SearchTerms =>
            new List<object[]>
            {
                new object[] { "study programs" },
                new object[] { "admission" },
                new object[] { "contacts" }
            };

        [Theory]
        [MemberData(nameof(SearchTerms))]
        [Trait("Category", "DataDriven")]
        public void TestCase2_SearchFunctionality(string searchTerm)
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var searchButton = wait.Until(d =>
                d.FindElement(By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div")));
            searchButton.Click();

            var searchBar = wait.Until(d =>
                d.FindElement(By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div/form/div/input")));
            searchBar.SendKeys(searchTerm);
            searchBar.SendKeys(Keys.Enter);

            wait.Until(d => d.Url.Contains("?s="));

            Assert.Contains("/?s=", driver.Url);

            var results = wait.Until(d =>
            {
                var elements = d.FindElements(By.XPath("//*[@id='page']/div[3]"));
                return elements.Count > 0 ? elements : null;
            });

            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }
    }
}