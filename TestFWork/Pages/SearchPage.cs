using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using TestFWork.Constants;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class SearchPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//span [@class = 'search-panel-button__icon']")]
        private IWebElement buttonSearchLetter { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@class = '_1BEp2b6vqOez8I6Rw9SpK6 _3pRLYQt59tmiwn0Ugfy9W5']")]
        private IWebElement inputSearchLetter { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [@tabindex = '-1']")]
        private IList<IWebElement> listSearchLetters { get; set; }

        public SearchPage()
        {
            PageFactory.InitElements(WebDriverUtil.GetWebDriver(), this);
        }

        public void SearchLetter()
        {
            WebDriverWaitUtil.WaitElementIsVisible(buttonSearchLetter);
            inputSearchLetter.ClickElement();
            inputSearchLetter.SendText(MailRuConstants.SearchLetters);
            WebDriverWaitUtil.WaitElementIsVisible(listSearchLetters[1]);
        }     
        
        public int GetCountSearchLetters()
        {
            return listSearchLetters.Count;
        }
    }
}
