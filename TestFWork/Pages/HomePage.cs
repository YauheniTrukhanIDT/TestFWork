﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using TestFWork.Utils;

namespace TestFWork.Pages
{
    class HomePage : BasePage
    {   
        [FindsBy(How = How.XPath, Using = "//div [@class = 'nav__folder nav__folder_parent']")]
        private IWebElement inboxLetter { get; set; } 

        [FindsBy(How = How.XPath, Using = "//span [@class = 'notify__message__text']")]
        private IWebElement spamMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span [@class = 'button2__wrapper'])[2]")]
        private IWebElement readLetters { get; set; }

        [FindsBy(How = How.XPath, Using = "//span [@class = 'filters-control__filter-text']")]
        private IWebElement dropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div [@class = 'list list_hover-support']")]
        private IWebElement listDropDown { get; set; }
                
        [FindsBy(How = How.XPath, Using = "//span [@title = 'Спам']")]
        private IWebElement spamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [@tabindex = '-1']")]
        private IList<IWebElement> letters { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@type = 'button']")]
        private IList<IWebElement> buttonMarkFlages { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@class = 'll-fs ll-fs_is-active']")]
        private IList<IWebElement> lettersMarkFlages { get; set; }

        [FindsBy(How = How.XPath, Using = "//div [@class = 'filters-control__arrow-down-icon']")]
        private IWebElement dropDownLetters { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div [@class = 'list-item list-item_hover-support list-item_markable'])[2]")]
        private IWebElement dropDownUnReadLetters { get; set; }

        [FindsBy(How = How.XPath, Using = "//span [@class = 'll-rs ll-rs_is-active']")]
        private IList<IWebElement> unReadLetters { get; set; }

        [FindsBy(How = How.XPath, Using = "//span [@class = 'll-sj__normal']")]
        private IList<IWebElement> spamLetters { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [@href = '/spam/']")]
        private IWebElement windowSpam { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span [@class = 'button2__wrapper'])[1]")]
        private IWebElement imageSpam { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2 [@class = 'thread__subject']")]
        private IWebElement subjectLetter { get; set; }

        List<String> listEmailSubject = new List<string>();

        public HomePage()
        {
            PageFactory.InitElements(WebDriverUtil.GetWebDriver(), this);
        }

        public void SelectLetterToSpam(int i)
        {
            WebDriverWaitUtil.WaitElementIsVisible(inboxLetter);
            letters[i].ClickElement();
        }

        public string GetLetterSubject()
        {
            WebDriverWaitUtil.WaitElementIsVisible(subjectLetter);
            string emailSubject = subjectLetter.GetElementText();
            return emailSubject;
        }

        public void MoveToSpam()
        {
            WebDriverWaitUtil.WaitElementIsVisible(spamButton);
            spamButton.ClickElement();
        }

        public bool IsSendToSpamMessageDisplayed()
        {
            WebDriverWaitUtil.WaitElementIsVisible(spamMessage);
            return spamMessage.Displayed;
        }

        public void GoToWindowSpam()
        {
            WebDriverWaitUtil.WaitElementIsVisible(windowSpam);
            windowSpam.ClickElement();
        }

        public bool CheckSpamEmailIsPresent(string emailSubject)
        {
            WebDriverWaitUtil.WaitElementIsVisible(imageSpam);
            foreach (IWebElement ltrs in spamLetters)
            {
                if (ltrs.Text.Contains(emailSubject))
                {
                    listEmailSubject.Add(ltrs.Text);
                    return true;
                }
            }
            return false;
        }

        public void MarkLettersByFlag()
        {
            WebDriverWaitUtil.WaitElementIsVisible(inboxLetter);
            foreach (IWebElement ltrs in buttonMarkFlages)
            {
                ltrs.ClickElement();
            }
        }

        public int GetCountMarkedByFlags()
        {
            return lettersMarkFlages.Count;
        }

        public void ClickDropDownList()
        {
            WebDriverWaitUtil.WaitElementIsVisible(dropDown);
            dropDownLetters.ClickElement();
        }

        public void ClickUnReadLetters()
        {
            WebDriverWaitUtil.WaitElementIsVisible(listDropDown);
            dropDownUnReadLetters.ClickElement();
        }

        public int CountUnReadLetters()
        {
            WebDriverWaitUtil.WaitElementIsVisible(readLetters);
            return unReadLetters.Count;
        }
    }    
}
