using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestFWork.Entities;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "mailbox:login")]
        private IWebElement loginField { get; set; }

        [FindsBy(How = How.Id, Using = "mailbox:password")]
        private IWebElement passwordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@type = 'submit']")]
        private IWebElement buttonMail { get; set; }

        [FindsBy(How = How.Id, Using = "PH_logoutLink")]
        private IWebElement logoutLink { get; set; }

        public LoginPage()
        {
            PageFactory.InitElements(WebDriverUtil.GetWebDriver(), this);
        }

        public HomePage Login(User user)
        {
            WebDriverWaitUtil.WaitElementIsVisible(loginField);
            loginField.SendText(user.ToString());
            buttonMail.ClickElement();
            WebDriverWaitUtil.WaitElementIsVisible(passwordField);
            passwordField.SendText(user.ToString());
            buttonMail.ClickElement();
            WebDriverWaitUtil.WaitElementIsVisible(logoutLink);
            return new HomePage();
        }

        public bool IsLogoutLinkDisplayed()        
        {
            return logoutLink.Displayed;                                     
        }
    }
}
