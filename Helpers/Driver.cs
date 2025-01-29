using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatomoTestSuite.Helpers
{
    [TestFixture]
    public class Driver
    {
        public static IWebDriver driver { get; set; }

        [OneTimeSetUp]
        public static void Initialize()
        {
            driver = new ChromeDriver();
            TurnOnWait();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Config.webURL);

        }

        //Implicit Wait
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(Config.webURL);
        }

        //Close the browser
        [OneTimeTearDown]
        public static void Close()
        {
            driver.Quit();
            TestHelper.FlushExtentReport();
        }
    }
}
