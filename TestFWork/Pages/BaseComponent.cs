using OpenQA.Selenium;

namespace TestFWork.Pages
{
    static class BaseComponent
    {

        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }

        public static void SendText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
