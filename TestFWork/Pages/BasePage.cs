using TestFWork.Utils;

namespace TestFWork.Pages
{
    public class BasePage
    {
        public string GetPageTitle()
        {
            return WebDriverUtil.GetWebDriver().Title;
        }
    }
}
