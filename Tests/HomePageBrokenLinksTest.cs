using MatomoTestSuite.Helpers;
using MatomoTestSuite.Pages;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatomoTestSuite.Tests
{
    [TestFixture]
    public class HomePageBrokenLinksTest: TestHelper
    {
        HomePage homePage;
        static StringBuilder testOutput;
        bool isPasss;

        public HomePageBrokenLinksTest()
        {
            homePage = new HomePage();
            testOutput = new StringBuilder();
            InitExtentReports("Broken Links Test");
        }

        [Test]
        public async Task BrokenLinksTest()
        {
            try
            {
                TestHelper.StartExtentTest("Broken Links Test");
                Assert.That(await homePage.checkBrokenLinks(testOutput),Is.EqualTo(true));
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

        [Test]
        public async Task BrokenLinksTestForImages()
        {
            try
            {
                testOutput = new StringBuilder();
                TestHelper.StartExtentTest("Broken Links Test For Images");
                Assert.That(await homePage.checkBrokenLinks(testOutput,true), Is.EqualTo(true));
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
            TestHelper.LoggingTestStatusExtentReport(testOutput);
        }
    }
}
