using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFWork.Constants;
using TestFWork.Pages;

namespace TestFWork.Steps
{
    [Binding]
    public class SendLetterPageSteps
    {
        private SendLetterPage sendLetterPage;

        [Given(@"I open writing window")]
        public void GivenIOpenWritingWindow()
        {
            sendLetterPage.OpenWindowWriteMessage();
        }
        
        [When(@"I write addressee")]
        public void WhenIWriteAddressee()
        {
            sendLetterPage.WriteAddressee(MailRuConstants.Addressee);
        }
        
        [When(@"I write subject")]
        public void WhenIWriteSubject()
        {
            sendLetterPage.WriteSubject(MailRuConstants.Theme);
        }
        
        [When(@"I write message")]
        public void WhenIWriteMessage()
        {
            sendLetterPage.WriteMessage(MailRuConstants.Message);
        }
        
        [When(@"I click to on send letter button")]
        public void WhenIClickToOnSendLetterButton()
        {
            sendLetterPage.ClickSendButton();
        }
        
        [Then(@"I see a message sending a letter successfully")]
        public void ThenISeeAMessageSendingALetterSuccessfully()
        {
            Assert.IsTrue(sendLetterPage.IsSendMessageDisplayed());
        }
    }
}
