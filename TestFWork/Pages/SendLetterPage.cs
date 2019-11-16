using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class SendLetterPage
    {
        private IWebDriver driver;

        private By byLetterSent = By.XPath("(//a [@class = 'layer__link'])[1]");

        private By byWindowWriteMessage = By.XPath("(//input [@class = 'container--H9L5q size_s--3_M-_'])[1]");

        private By byWriteMessage = By.XPath("//span [@class = 'compose-button__wrapper']");

        [FindsBy(How = How.XPath, Using = "//span [@class = 'compose-button__wrapper']")]
        private IWebElement buttonWriteLetter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input [@class = 'container--H9L5q size_s--3_M-_'])[1]")]
        private IWebElement recipient { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input [@class = 'container--H9L5q size_s--3_M-_'])[2]")]
        private IWebElement subject { get; set; }

        [FindsBy(How = How.XPath, Using = "//div [@role = 'textbox']")]
        private IWebElement textMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//span [text() = 'Отправить']")]
        private IWebElement sendButton { get; set; }

        [Obsolete]
        public SendLetterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [Obsolete]
        public void WriteMessage(string addressee, string theme, string message)
        {
            WebDriverWaitUtil.DriverWait(driver, byWriteMessage);
            buttonWriteLetter.ClickElement();
            WebDriverWaitUtil.DriverWait(driver, byWindowWriteMessage);
            recipient.SendText(addressee);
            subject.SendText(theme);
            textMessage.ClickElement();
            textMessage.SendText(message);
            sendButton.ClickElement();
        }

        [Obsolete]
        public bool IsSendMessageDisplayed()
        {
            return WebDriverWaitUtil.ElementDisplayed(driver, byLetterSent);
        }
    }
}
