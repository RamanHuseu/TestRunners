using EHU.Core.Pages;
using NUnit.Framework;

namespace EHU.NUnit
{
    [TestFixture]
    [Category("Search")]
    public class SearchTests : TestBase
    {
        private static IEnumerable<TestCaseData> SearchTerms()
        {
            yield return new TestCaseData("study programs").SetName("Search_StudyPrograms");
            yield return new TestCaseData("admission").SetName("Search_Admission");
            yield return new TestCaseData("contacts").SetName("Search_Contacts");
        }

        [Test]
        [Category("DataDriven")]
        [TestCaseSource(nameof(SearchTerms))]
        public void TestCase2_SearchFunctionality(string searchTerm)
        {
            var homePage = new HomePage();
            homePage.Open();

            var resultsPage = homePage.Search(searchTerm);

            Assert.That(resultsPage.IsLoaded(), Is.True,
                $"Search results page should load for term: {searchTerm}");
            Assert.That(resultsPage.HasResults(), Is.True,
                $"Should have results for: {searchTerm}");
        }
    }
}