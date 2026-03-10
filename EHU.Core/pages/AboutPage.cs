using OpenQA.Selenium;

namespace EHU.Core.Pages
{
    /// <summary>
    /// Page Object для страницы About.
    /// </summary>
    public class AboutPage : BasePage
    {
        private static readonly By H1Header = By.TagName("h1");

        public string GetH1Text()
        {
            return FindElement(H1Header).Text;
        }

        public bool IsLoaded()
        {
            return CurrentUrl.Contains("/about/") && Title.Contains("About");
        }
    }
}