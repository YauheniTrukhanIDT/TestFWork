using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFWork.Constants;
using TestFWork.Pages;

namespace TestFWork.Steps
{
    [Binding]
    public class HomePageSteps               
        {

        private HomePage homePage;

        [Given(@"I click on dropdown list")]
        public void GivenIClickOnDropdownList()
        {
            homePage.ClickDropDownList();
        }
        
        [Given(@"I flag letters")]
        public void GivenIFlagLetters()
        {
            homePage.MarkLettersByFlag();
        }
        
        [Given(@"I take the number letter")]
        public void GivenIWriteTheNumberLetter()
        {
            homePage.SelectLetterToSpam(MailRuConstants.NumberLetter);
        }

        [When(@"I take the subject of the letter")]
        public void WhenITakeTheSubjectLetter()
        {
            homePage.GetLetterSubject();
        }

        [When(@"I click on unread letters")]
        public void WhenIClickOnUnreadLetters()
        {
            homePage.ClickUnReadLetters();
        }
        
        [When(@"I move the the letter to spam")]
        public void WhenIMoveTheTheLetterToSpam()
        {
            homePage.MoveToSpam();
        }
        
        [When(@"I get a confirmation letter")]
        public void WhenIGetAConfirmationLetter()
        {
            Assert.IsTrue(homePage.IsSendToSpamMessageDisplayed());
        }
        
        [When(@"I go to the spam window")]
        public void WhenIGoToTheSpamWindow()
        {
            homePage.GoToWindowSpam();
        }
        
        [Then(@"I successfully receive a list of unread letters")]
        public void ThenISuccessfullyReceiveAListOfUnreadLetters()
        {
            Assert.IsTrue(homePage.CountUnReadLetters() > 0);
        }
        
        [Then(@"I see letters a flagged")]
        public void ThenISeeLettersAFlagged()
        {
            Assert.IsTrue(homePage.GetCountMarkedByFlags() > 0);
        }
        
        [Then(@"I see a successfully moved letter")]
        public void ThenISeeASuccessfullyMovedLetter()
        {
            Assert.IsTrue(homePage.CheckSpamEmailIsPresent(homePage.GetLetterSubject()));
        }
    }
}
