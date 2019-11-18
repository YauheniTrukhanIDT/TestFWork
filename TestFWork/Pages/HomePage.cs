using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class HomePage : BasePage
    {        
        private By byInboxLetter = By.XPath("//div [@class = 'nav__folder nav__folder_parent']");

        private By bySpamMessage = By.XPath("//span [@class = 'notify__message__text']");

        private By bySpamButton = By.XPath("//span [@title = 'Спам']");

        private By byReadLetters = By.XPath("(//span [@class = 'button2__wrapper'])[2]");

        private By byDropDown = By.XPath("//span [@class = 'filters-control__filter-text']");

        private By byListDropDown = By.XPath("//div [@class = 'list list_hover-support']");
                
        [FindsBy(How = How.XPath, Using = "//span [@title = 'Спам']")]
        private IWebElement spamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [@tabindex = '-1']")]
        private IList<IWebElement> letters { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@type = 'button']")]
        private IList<IWebElement> buttonMarkFlages { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@class = 'll-fs ll-fs_is-active']")]
        private IList<IWebElement> lettersMarkFlages { get; set; }

        [FindsBy(How = How.XPath, Using = "//div [@class = 'filters-control filters-control_short filters-control_pure']")]
        private IWebElement dropDownLetters { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div [@class = 'list-item list-item_hover-support list-item_markable'])[2]")]
        private IWebElement dropDownUnReadLetters { get; set; }

        [FindsBy(How = How.XPath, Using = "//span [@class = 'll-rs ll-rs_is-active']")]
        private IList<IWebElement> unReadLetters { get; set; }

        public HomePage()
        {
            PageFactory.InitElements(WebDriverUtil.GetWebDriver(), this);
        }

        public void SendToSpam()
        {
            WebDriverWaitUtil.WaitElementIsVisible(byInboxLetter);
            letters[1].ClickElement();
            WebDriverWaitUtil.WaitElementIsVisible(bySpamButton);
            spamButton.ClickElement();
        }

        public bool IsSendToSpamMessageDisplayed()
        {
            return WebDriverWaitUtil.ElementDisplayed(bySpamMessage);
        }

        public void MarkLettersByFlag()
        {
            WebDriverWaitUtil.WaitElementIsVisible(byInboxLetter);
            foreach (IWebElement ltrs in buttonMarkFlages)
            {
                ltrs.ClickElement();
            }
        }

        public int GetCountMarkedByFlags()
        {
            return lettersMarkFlages.Count;
        }

        public void DropDownList()
        {
            WebDriverWaitUtil.WaitElementIsVisible(byDropDown);
            dropDownLetters.ClickElement();
            WebDriverWaitUtil.WaitElementIsVisible(byListDropDown);
            dropDownUnReadLetters.ClickElement();
        }

        public int CountUnReadLetters()
        {
            WebDriverWaitUtil.WaitElementIsVisible(byReadLetters);
            return unReadLetters.Count;
        }
    }    
}
