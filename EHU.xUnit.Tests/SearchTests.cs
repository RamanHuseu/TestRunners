using EHU.Core.Pages;
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
            var homePage = new HomePage();
            homePage.Open();

            var resultsPage = homePage.Search(searchTerm);

            Assert.True(resultsPage.IsLoaded(),
                $"Search results page should load for: {searchTerm}");
            Assert.True(resultsPage.HasResults(),
                $"Should have results for: {searchTerm}");
        }
    }
}