using EHU.Core.Pages;
using Xunit;

namespace EHU.XUnit
{
    [Trait("Category", "Contact")]
    public class ContactTests : TestBase
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void TestCase4_VerifyContactInfo()
        {
            var contactPage = new ContactPage();
            contactPage.Open();

            Assert.True(contactPage.IsLoaded(), "Contact page should be loaded");
            Assert.True(contactPage.HasContent(), "Contact page should have content");
        }
    }
}