using OpenQA.Selenium;

namespace TestFWork.Pages
{
     static class BasePage
    {
        private static string attribute;

        public static string GetAttributeElement(this IWebElement element)
        {
            return element.GetAttribute(attribute);
        }
    }
}
