using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFWork.Utils
{
    class WebDriverUtil
    {
            private static IWebDriver driver;
                                            
            private WebDriverUtil()
            {
            }

            public static void Init()
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                }
            }

            public static IWebDriver GetWebDriver()
            {
                return driver;
            }

            public static void Close()
            {
                if (driver == null)
                {
                    return;
                }
                driver.Quit();
                driver = null;
            }
        }
    }
