using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFWork.Constants;
using TestFWork.Entities;
using TestFWork.Pages;
using TestFWork.Utils;

namespace TestFWork.Steps.Hooks
{
    [Binding]
    public sealed class Common
    {
        [BeforeScenario]
        public void SetUp()
        {
            WebDriverUtil.Init();
            WebDriverUtil.GetWebDriver().Url = MailRuConstants.MailRuUrl;
            WebDriverUtil.GetWebDriver().Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage();
            HomePage homePage = loginPage.Login(User.GetDefaultUser());
            Assert.IsTrue(loginPage.IsLogoutLinkDisplayed());
        }

        [AfterScenario]
        public void TearDown()
        {
            WebDriverUtil.Close();
        }
    }
}
