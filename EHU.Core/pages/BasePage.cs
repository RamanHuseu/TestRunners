using EHU.Core.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EHU.Core.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage()
        {
            Driver = DriverSingleton.GetDriver();
            Wait = DriverSingleton.GetWait();
        }

        public string CurrentUrl => Driver.Url;
        public string Title => Driver.Title;

        protected IWebElement FindElement(By locator)
        {
            return Wait.Until(d => d.FindElement(locator));
        }

        protected IList<IWebElement> FindElements(By locator)
        {
            try
            {
                return Wait.Until(d =>
                {
                    var elements = d.FindElements(locator);
                    return elements.Count > 0 ? elements : null;
                });
            }
            catch
            {
                return new List<IWebElement>();
            }
        }

        protected void Click(By locator)
        {
            FindElement(locator).Click();
        }

        protected void TypeText(By locator, string text)
        {
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public string GetBodyText()
        {
            return Driver.FindElement(By.TagName("body")).Text;
        }
    }
}