using TestFWork.Utils;

namespace TestFWork.Pages
{
    public class BasePage : BaseComponent
    {
        public string GetPageTitle()
        {
            return WebDriverUtil.GetWebDriver().Title;
        }
    }
}
