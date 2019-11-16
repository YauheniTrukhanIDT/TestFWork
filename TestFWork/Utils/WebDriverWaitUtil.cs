using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFWork.Utils
{
    class WebDriverWaitUtil
    {
        private static int timeOut = 10;

        private WebDriverWaitUtil() 
        {
        }

        [System.Obsolete]
        public static IWebElement DriverWait(IWebDriver driver, By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        [Obsolete]
        public static bool ElementDisplayed(IWebDriver driver, By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).Until(condition: ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            return driver.FindElement(locator).Displayed;
        }
    }
}
