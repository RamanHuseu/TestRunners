using OpenQA.Selenium;
using System.Threading;

namespace EHU.Core.Pages
{
    public class HomePage : BasePage
    {
        private const string Url = "https://en.ehu.lt/";

        private static readonly By AboutLink = By.LinkText("About");
        private static readonly By SearchButton =
            By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div");
        private static readonly By SearchInput =
            By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div/form/div/input");
        private static readonly By LanguageSwitcher =
            By.XPath("//*[@id='masthead']/div[1]/div/div[4]/ul");
        private static readonly By LithuanianOption =
            By.XPath("//*[@id='masthead']/div[1]/div/div[4]/ul/li/ul/li[3]/a");

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public AboutPage GoToAbout()
        {
            Click(AboutLink);
            return new AboutPage();
        }

        public SearchResultsPage Search(string query)
        {
            Click(SearchButton);
            TypeText(SearchInput, query);
            FindElement(SearchInput).SendKeys(Keys.Enter);
            return new SearchResultsPage();
        }

        public void SwitchToLithuanian()
        {
            Click(LanguageSwitcher);

            var lithuanianLink = FindElement(LithuanianOption);
            var href = lithuanianLink.GetAttribute("href");

            if (string.IsNullOrEmpty(href))
                href = "https://lt.ehu.lt/";

            try
            {
                Driver.Navigate().GoToUrl(href);
            }
            catch (WebDriverException)
            {
                Thread.Sleep(3000);
            }
        }
    }
}