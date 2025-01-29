using MatomoTestSuite.Helpers;
using MatomoTestSuite.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatomoTestSuite.Tests
{
    [TestFixture]
    public class HomePageLinkNavigationTest:TestHelper
    {
        HomePage homePage;

        public HomePageLinkNavigationTest()
        {
            homePage = new HomePage();
            InitExtentReports("Link Navigation Test");
        }

        [Test, Order(1)]
        public void demoNavigationTest()
        {
            try
            {
                TestHelper.StartExtentTest("Link Navigation Test ");
                homePage.clickDemoLink();
            }
            catch (NoSuchElementException noSuchElementException)
            {
                Assert.Fail("Element not found " + noSuchElementException.Message);
            }
            catch (Exception exception)
            {
                Assert.Fail("Error occured " + exception.Message);
            }
        }

        [Test, Order(2)]
        public void loginNavigationTest()
        {
            try
            {
                Driver.NavigateUrl();
                TestHelper.StartExtentTest("Login Link Navigation Test ");
                homePage.clickLogin();
            }
            catch (NoSuchElementException noSuchElementException)
            { 
                Assert.Fail("Element not found " + noSuchElementException.Message);
            }
            catch (Exception exception)
            {
                Assert.Fail("Error occured " + exception.Message);
            }
        }

        [Test, Order(3)]
        public void helpNavigationTest()
        {
            try
            {
                Driver.NavigateUrl();
                TestHelper.StartExtentTest("Help Link Navigation Test ");
                homePage.clickHelpLink();
            }
            catch (NoSuchElementException noSuchElementException)
            {
                Assert.Fail("Element not found " + noSuchElementException.Message);
            }
            catch (Exception exception)
            {
                Assert.Fail("Error occured " + exception.Message);
            }
        }

        //Write Report
        [TearDown]
        public static void CloseTest()
        {
            TestHelper.LoggingTestStatusExtentReport();
        }
    }
}

