using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class SendLetterPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "(//a [@class = 'layer__link'])[1]")]
        private IWebElement smsLetterSent { get; set; }

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

        public SendLetterPage()
        {
            PageFactory.InitElements(WebDriverUtil.GetWebDriver(), this);
        }

        public void OpenWindowWriteMessage()
        {
            WebDriverWaitUtil.WaitElementIsVisible(buttonWriteLetter);
            buttonWriteLetter.ClickElement();
        }

        public void WriteAddressee(string addressee)
        {
            WebDriverWaitUtil.WaitElementIsVisible(recipient);
            recipient.SendText(addressee);
        }

        public void WriteSubject(string theme)
        {
            subject.SendText(theme);
        }

        public void WriteMessage(string text)
        {
            textMessage.ClickElement();
            textMessage.SendText(text);
        }

        public void ClickSendButton()
        {
            sendButton.ClickElement();
        }

        public bool IsSendMessageDisplayed()
        {
            WebDriverWaitUtil.WaitElementIsVisible(smsLetterSent);
            return smsLetterSent.Displayed;
        }
    }
}
