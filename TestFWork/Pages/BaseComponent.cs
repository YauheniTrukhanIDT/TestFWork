using OpenQA.Selenium;

namespace TestFWork.Pages
{
    public static class BaseComponent
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

        public static string GetAttributeElement(this IWebElement element, string attribute)
        {
            return element.GetAttribute(attribute);
        }
    }
}
