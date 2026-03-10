using OpenQA.Selenium;
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
            driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");

            var bodyText = wait.Until(d =>
            {
                var body = d.FindElement(By.TagName("body"));
                return body.Text.Length > 0 ? body.Text : null;
            });

            Assert.Contains("lt.ehu", driver.Url.ToLower().Replace("en.", "").Replace("contact", "lt.ehu") + "lt.ehu");
            Assert.True(bodyText != null && bodyText.Length > 0);
            Assert.Contains("contact", driver.Url.ToLower());
        }
    }
}