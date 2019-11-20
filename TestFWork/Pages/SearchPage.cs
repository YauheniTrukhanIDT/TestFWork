using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using TestFWork.Constants;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class SearchPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//span [@class = '_1Sq-e9MVzbKWUgdGRPfVlE']")]
        private IWebElement buttonSearchLetter { get; set; }

        [FindsBy(How = How.XPath, Using = "//span [@class = 'search-panel-button__text']")]
        private IWebElement inputSearchLetter { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@class = '_1BEp2b6vqOez8I6Rw9SpK6 _3pRLYQt59tmiwn0Ugfy9W5']")]
        private IWebElement inputSendSearchLetter { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [@tabindex = '-1']")]
        private IList<IWebElement> listSearchLetters { get; set; }

        public SearchPage()
        {
            PageFactory.InitElements(WebDriverUtil.GetWebDriver(), this);
        }

        public void ClickInputSearchLetter()
        {
            WebDriverWaitUtil.WaitElementIsVisible(inputSearchLetter);
            inputSearchLetter.ClickElement();
        }

        public void SendTextInputSearchLetter()
        {
            WebDriverWaitUtil.WaitElementIsVisible(inputSendSearchLetter);
            inputSendSearchLetter.SendText(MailRuConstants.SearchLetters);
        }

        public void ClickButtonSearchLetter()
        {
            WebDriverWaitUtil.WaitElementIsVisible(buttonSearchLetter);
            buttonSearchLetter.ClickElement();
            WebDriverWaitUtil.WaitElementIsVisible(listSearchLetters[0]);
        }

        public int GetCountSearchLetters()
        {
            return listSearchLetters.Count;
        }
    }
}
