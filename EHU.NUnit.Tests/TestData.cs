using EHU.Core.Pages;
using NUnit.Framework;

namespace EHU.NUnit
{
    [TestFixture]
    [Category("Contact")]
    public class ContactTests : TestBase
    {
        [Test]
        [Category("Smoke")]
        public void TestCase4_VerifyContactInfo()
        {
            var contactPage = new ContactPage();
            contactPage.Open();

            Assert.That(contactPage.IsLoaded(), Is.True,
                "Contact page should be loaded");
            Assert.That(contactPage.HasContent(), Is.True,
                "Contact page should have content");
        }
    }
}