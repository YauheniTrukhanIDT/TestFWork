using NUnit.Framework;
using TestFWork.Constants;
using TestFWork.Entities;
using TestFWork.Pages;
using TestFWork.Utils;

namespace UnitTestProject1
{
    [TestFixture]
    public class Test
    {
        [SetUp]
        public void SetUpTest()
        {
            WebDriverUtil.Init();
            WebDriverUtil.GetWebDriver().Url = MailRuConstants.MailRuUrl;
            WebDriverUtil.GetWebDriver().Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage();
            HomePage homePage = loginPage.Login(User.GetDefaultUser());
            Assert.IsTrue(loginPage.IsLogoutLinkDisplayed());
        }

        [Test]
        public void WriteMessage()
        {
            SendLetterPage sendLetterPage = new SendLetterPage();
            sendLetterPage.OpenWindowWriteMessage();
            sendLetterPage.WriteAddressee(MailRuConstants.Addressee);
            sendLetterPage.WriteSubject(MailRuConstants.Theme);
            sendLetterPage.WriteMessage(MailRuConstants.Message);
            sendLetterPage.ClickSendButton();
            Assert.IsTrue(sendLetterPage.IsSendMessageDisplayed());
        }

        [Test]
        public void SendSpamLetter()
        {
            HomePage homePage = new HomePage();
            homePage.SelectLetterToSpam(MailRuConstants.NumberLetter);
            string emailSubject = homePage.GetLetterSubject();
            homePage.MoveToSpam();
            Assert.IsTrue(homePage.IsSendToSpamMessageDisplayed());
            homePage.GoToWindowSpam();
            Assert.IsTrue(homePage.CheckSpamEmailIsPresent(emailSubject));
        } 

        [Test]
        public void MarkFlagLetter()
        {
            HomePage homePage = new HomePage();
            homePage.MarkLettersByFlag();
            Assert.IsTrue(homePage.GetCountMarkedByFlags() > 0);
        }

        [Test]
        public void DropDown()
        {
            HomePage homePage = new HomePage();
            homePage.ClickDropDownList();
            homePage.ClickUnReadLetters();
            Assert.IsTrue(homePage.CountUnReadLetters() > 0);
        }

        [Test]
        public void SearchLetters()
        {
            SearchPage searchPage = new SearchPage();
            searchPage.ClickInputSearchLetter();
            searchPage.SendTextInputSearchLetter();
            searchPage.ClickButtonSearchLetter();
            Assert.IsTrue(searchPage.GetCountSearchLetters() > 0);
        }

        [TearDown]
        public void TearDownTest()
        {
            WebDriverUtil.Close();
        }
    }
}
