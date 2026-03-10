using OpenQA.Selenium;

namespace EHU.Core.Pages
{
    /// <summary>
    /// Page Object для страницы контактов.
    /// </summary>
    public class ContactPage : BasePage
    {
        private const string Url = "https://en.ehu.lt/contact/";

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public bool IsLoaded()
        {
            return CurrentUrl.Contains("contact");
        }

        public bool HasContent()
        {
            return GetBodyText().Length > 0;
        }
    }
}