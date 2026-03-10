using EHU.Core.Pages;
using NUnit.Framework;

namespace EHU.NUnit
{
    [TestFixture]
    [Category("Navigation")]
    public class NavigationTests : TestBase
    {
        [Test]
        [Category("Smoke")]
        public void TestCase1_NavigateToAboutEHU()
        {
            var homePage = new HomePage();
            homePage.Open();

            var aboutPage = homePage.GoToAbout();

            Assert.That(aboutPage.IsLoaded(), Is.True,
                "About page should be loaded");
            Assert.That(aboutPage.GetH1Text(), Does.Contain("About"),
                "H1 should contain 'About'");
        }

        [Test]
        [Category("Smoke")]
        public void TestCase3_LanguageChange()
        {
            var homePage = new HomePage();
            homePage.Open();
            homePage.SwitchToLithuanian();

            Thread.Sleep(2000);

            Assert.That(homePage.CurrentUrl, Does.Contain("lt.ehu"),
                $"Should redirect to Lithuanian. Actual URL: {homePage.CurrentUrl}");
            Assert.That(homePage.GetBodyText().Length, Is.GreaterThan(0));
        }
    }
}