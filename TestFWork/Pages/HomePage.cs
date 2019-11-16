using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        private By byInboxLetter = By.XPath("//div [@class = 'nav__folder nav__folder_parent']");

        private By bySpamMessage = By.XPath("//span [@class = 'notify__message__text']");

        private By bySpamButton = By.XPath("//span [@title = 'Спам']");

        [FindsBy(How = How.XPath, Using = "//span [@title = 'Спам']")]
        private IWebElement spamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [@tabindex = '-1']")]
        private IList<IWebElement> letters { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@type = 'button']")]
        private IList<IWebElement> buttonMarkFlages { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@class = 'll-fs ll-fs_is-active']")]
        private IList<IWebElement> lettersMarkFlages { get; set; }

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
    }    
}
