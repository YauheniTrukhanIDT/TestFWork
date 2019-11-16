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

            public static IWebDriver Init()
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                }
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
