using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using TestFWork.Utils;

namespace TestFWork.Pages
{
//class HomePage : BasePage
    class HomePage
    {
        private IWebDriver driver;

        private By byInboxLetter = By.XPath("//div [@class = 'nav__folder nav__folder_parent']");

        private By bySpamMessage = By.XPath("//span [@class = 'notify__message__text']");

        private By bySpamButton = By.XPath("//span [@title = 'Спам']");

        private By byReadLetters = By.XPath("(//span [@class = 'button2__wrapper'])[2]");

        private By byDropDown = By.XPath("//span [@class = 'filters-control__filter-text']");

        private By byListDropDown = By.XPath("//div [@class = 'list list_hover-support']");

        private static int unRead = 1;

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

        [System.Obsolete]
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [System.Obsolete]
        public void SendToSpam()
        {
            WebDriverWaitUtil.DriverWait(driver, byInboxLetter);
            letters[1].ClickElement();
            WebDriverWaitUtil.DriverWait(driver, bySpamButton);
            spamButton.ClickElement();
        }

        [System.Obsolete]
        public bool IsSendToSpamMessageDisplayed()
        {
            return WebDriverWaitUtil.ElementDisplayed(driver, bySpamMessage);
        }

        [System.Obsolete]
        public void MarkLettersByFlag()
        {
            WebDriverWaitUtil.DriverWait(driver, byInboxLetter);
            foreach (IWebElement ltrs in buttonMarkFlages)
            {
                ltrs.ClickElement();
            }
        }

        public int GetCountMarkedByFlags()
        {
            return lettersMarkFlages.Count;
        }

        [System.Obsolete]
        public void DropDownList()
        {
            WebDriverWaitUtil.DriverWait(driver, byDropDown);
            dropDownLetters.ClickElement();
            WebDriverWaitUtil.DriverWait(driver, byListDropDown);
            dropDownUnReadLetters.ClickElement();
        }

        [System.Obsolete]
        public int CountUnReadLetters()
        {
            WebDriverWaitUtil.DriverWait(driver, byReadLetters);
            return unReadLetters.Count;
        }
    }    
}
