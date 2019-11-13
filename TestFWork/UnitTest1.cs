using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2000));
        }

        [Test]
        [Obsolete]
        public void EnterMailRu()
        {
            driver.Url = "https://mail.ru/";
            driver.Manage().Window.Maximize();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a [@class = 'logo__img']")));
            driver.FindElement(By.Id("mailbox:login")).SendKeys("jora.pog");
            driver.FindElement(By.XPath("//input [@type = 'submit']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input [@name = 'password']")));
            driver.FindElement(By.XPath("//input [@name = 'password']")).SendKeys("korol_eva");
            driver.FindElement(By.XPath("//input [@type = 'submit']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("PH_logoutLink")));
        }

        [Test]
        [Obsolete]
        public void SpamLetter()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img [@src = 'https://img.imgsmail.ru/static.promo/logo/logo.svg']")));
            driver.FindElements(By.XPath("//a [@tabindex = '-1']"))[0].Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span [@class = 'avatar__img avatar__img_with-border']")));
            driver.FindElement(By.XPath("//span [@title = 'Спам']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span [@class = 'notify__message__text']")));
        }

        [Test]
        [Obsolete]
        public void WriteLetter()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span [@class = 'notify__message__text']")));
            driver.FindElement(By.XPath("//span [@title = 'Написать письмо']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div [@class = 'container--2a9I2 container_full--2INh1']")));
            driver.FindElement(By.XPath("(//input [@class = 'container--H9L5q size_s--3_M-_'])[1]")).SendKeys("truhanzhenya@mail.ru");
            driver.FindElement(By.XPath("(//input [@class = 'container--H9L5q size_s--3_M-_'])[2]")).SendKeys("Test");                      
            driver.FindElement(By.XPath("//div [@role = 'textbox']")).Click();
            driver.FindElement(By.XPath("//div [@role = 'textbox']")).Clear();
            driver.FindElement(By.XPath("//div [@role = 'textbox']")).SendKeys("Hi");
            driver.FindElement(By.XPath("//span [text() = 'Отправить']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a [@class = 'layer__link'])[1]")));           
        }

        [Test]
        [Obsolete]
        public void XFlagLetter()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a [@title = 'Входящие']")));
            driver.FindElement(By.XPath("//a [@title = 'Входящие']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span [@class = 'filters-control__filter-text']")));
            ReadOnlyCollection<IWebElement> letters = driver.FindElements(By.XPath("//button [@type = 'button']"));
            foreach (IWebElement ltrs in letters)
            {
                ltrs.Click();
            }      
        }

        [Test]
        [Obsolete]
        public void ZDropDown()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a [@title = 'Входящие']")));
            IWebElement element = driver.FindElement(By.XPath("//div [@class = 'select__control']"));
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByIndex(3);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}
