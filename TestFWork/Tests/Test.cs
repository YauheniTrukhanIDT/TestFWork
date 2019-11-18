using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TestFWork.Pages;
using TestFWork.Utils;

namespace UnitTestProject1
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;

        private LoginPage loginPage;

        private HomePage homePage;

        private SendLetterPage sendLetterPage;

        private static string mailRu = "https://mail.ru/";

        private static string login = "jora.pog";

        private static string password = "korol_eva";

        private static string addressee = "truhanzhenya@mail.ru";

        private static string theme = "Test";

        private static string message = "Hi!";

        [Obsolete]
        [SetUp]
        public void SetUpTest()
        {
            driver = WebDriverUtil.Init();
            driver.Url = mailRu;
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            sendLetterPage = new SendLetterPage(driver);
        }

        [Test]
        [Obsolete]
        public void EnterMailRu()
        {
            loginPage.Login(login, password);
            Assert.IsTrue(loginPage.IsLogoutLinkDisplayed());
        }

        [Test]
        [Obsolete]
        public void WriteMessage()
        {
            loginPage.Login(login, password);
            sendLetterPage.WriteMessage(addressee, theme, message);
            Assert.IsTrue(sendLetterPage.IsSendMessageDisplayed());
        }

        [Test]
        [Obsolete]
        public void SendSpamLetter()
        {
            loginPage.Login(login, password);
            homePage.SendToSpam();
            Assert.IsTrue(homePage.IsSendToSpamMessageDisplayed());
        } 

        [Test]
        [Obsolete]
        public void MarkFlagLetter()
        {
            loginPage.Login(login, password);
            homePage.MarkLettersByFlag();
            Assert.IsTrue(homePage.GetCountMarkedByFlags() > 0);
        }

        [Test]
        [Obsolete]
        public void DropDown()
        {
            loginPage.Login(login, password);
            homePage.DropDownList();
            Assert.IsTrue(homePage.CountUnReadLetters() > 0);
        }

        [TearDown]
        public void TearDownTest()
        {
            WebDriverUtil.Close();
        }
    }
}
