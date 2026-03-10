using OpenQA.Selenium;
using System;

namespace EHU.Core.Pages
{
    public class SearchResultsPage : BasePage
    {
        private static readonly By ResultsContainer =
            By.XPath("//*[@id='page']/div[3]");

        public bool IsLoaded()
        {
            return CurrentUrl.Contains("?s=");
        }

        public bool HasResults()
        {
            var results = FindElements(ResultsContainer);
            return results.Count > 0;
        }

        public bool ResultsContainText(string text)
        {
            var results = FindElements(ResultsContainer);
            foreach (var result in results)
            {
                if (result.Text.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }
            return false;
        }

        public string GetCurrentUrl() => CurrentUrl;
    }
}