using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestFWork.Constants;

namespace TestFWork.Utils
{
    public static class WebDriverWaitUtil
        {
        private static WebDriverWait wait;

        public static void WaitElementIsVisible(By locator)
        {
            new WebDriverWait(WebDriverUtil.GetWebDriver(), TimeSpan.FromSeconds(WebDriverWaitConstants.TimeOut)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitElementIsVisible(IWebElement element)
        {
            new WebDriverWait(WebDriverUtil.GetWebDriver(), TimeSpan.FromSeconds(WebDriverWaitConstants.TimeOut))
                .Until(WaitElementVisible(element));
        }

        private static Func<IWebDriver, bool> WaitElementVisible(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }
    }
}
