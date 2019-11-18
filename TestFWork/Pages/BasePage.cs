using OpenQA.Selenium;

namespace TestFWork.Pages
{
    public class BasePage
    {
          //delete
        //private static string attribute;
          //move to BaseComponent
        public string GetAttributeElement(this IWebElement element, string attribute)
        {
            return element.GetAttribute(attribute);
        }
          
        //public string GetPageTitle(){ return WDUtils.GetWD().Title;
    }
}
