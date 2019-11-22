using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestFWork.Pages;

namespace TestFWork
{
    [Binding]
    public class SearchPageSteps
    {
        private SearchPage searchPage;

        [Given(@"I click on the search input")]
        public void GivenIClickOnTheSearchInput()
        {
            searchPage.ClickInputSearchLetter();
        }
        
        [When(@"I enter addressee")]
        public void WhenIEnterAddressee()
        {
            searchPage.SendTextInputSearchLetter();
        }
        
        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            searchPage.ClickButtonSearchLetter();
        }
        
        [Then(@"I see successfully addressee letters")]
        public void ThenISeeSuccessfullyAddresseeLetters()
        {
            Assert.IsTrue(searchPage.GetCountSearchLetters() > 0);
        }
    }
}
