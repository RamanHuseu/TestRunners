using EHU.Core.Pages;
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
            var homePage = new HomePage();
            homePage.Open();

            var aboutPage = homePage.GoToAbout();

            Assert.True(aboutPage.IsLoaded(), "About page should be loaded");
            Assert.Contains("About", aboutPage.GetH1Text());
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void TestCase3_LanguageChange()
        {
            var homePage = new HomePage();
            homePage.Open();
            homePage.SwitchToLithuanian();

            Thread.Sleep(2000);

            Assert.Contains("lt.ehu", homePage.CurrentUrl);
            Assert.True(homePage.GetBodyText().Length > 0);
        }
    }
}