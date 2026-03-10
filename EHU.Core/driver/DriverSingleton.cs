using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EHU.Core.Driver
{
    public sealed class DriverSingleton
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        private static WebDriverWait _wait;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = DriverFactory.CreateDriver();
            }
            return _driver;
        }

        public static WebDriverWait GetWait()
        {
            if (_wait == null)
            {
                _wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
            }
            return _wait;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
                _wait = null;
            }
        }
    }
}