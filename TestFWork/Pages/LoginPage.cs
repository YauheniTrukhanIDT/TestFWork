using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class LoginPage
    {

        IWebDriver driver;

        private By byLogoutLink = By.Id("PH_logoutLink");

        private By byStartMail = By.XPath("//a [@class = 'logo__img']");

        private By byInputPassword = By.Id("mailbox:password");

        [FindsBy(How = How.Id, Using = "mailbox:login")]
        private IWebElement loginField { get; set; }

        [FindsBy(How = How.Id, Using = "mailbox:password")]
        private IWebElement passwordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@type = 'submit']")]
        private IWebElement buttonMail { get; set; }

        [Obsolete]
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [Obsolete]
        public HomePage Login(string login, string password)
        {
            WebDriverWaitUtil.DriverWait(driver, byStartMail);
            loginField.SendText(login);
            buttonMail.ClickElement();
            WebDriverWaitUtil.DriverWait(driver, byInputPassword);
            passwordField.SendText(password);
            buttonMail.ClickElement();
            WebDriverWaitUtil.DriverWait(driver, byLogoutLink);
            return new HomePage(driver);
        }

        [Obsolete]
        public bool IsLogoutLinkDisplayed()        
        {
            return WebDriverWaitUtil.ElementDisplayed(driver, byLogoutLink);
        }
    }
}
