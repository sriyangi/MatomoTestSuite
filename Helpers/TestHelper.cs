using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MatomoTestSuite.Helpers
{
    public class TestHelper : Driver
    {
        public static ExtentReports extentReports;
        public static ExtentTest testlog;

        public static void InitExtentReports(string fileName)
        {
            string projectPath = TestHelper.GetProjectPath();

            string reportPath = projectPath + Config.reportDirectory + "\\";

            if (!(Directory.Exists(reportPath))) Directory.CreateDirectory(reportPath);

            //Create report name with date and time
            string reportPathwithFileName = Path.Combine(reportPath, fileName + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

            //will be used to configure the reports
            ExtentSparkReporter htmlReporter = new ExtentSparkReporter(reportPathwithFileName);
            extentReports = new ExtentReports();
            htmlReporter.Config.Theme = Theme.Standard;
            extentReports.AttachReporter(htmlReporter);
        }

        //Save and finalize the test report
        public static void FlushExtentReport()
        {
            extentReports.Flush();
        }

        public static void StartExtentTest(string testsToStart)
        {
            testlog = extentReports.CreateTest(testsToStart);
        }

        public static void LoggingTestStatusExtentReport(StringBuilder testOutput = null)
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.Empty + TestContext.CurrentContext.Result.StackTrace + string.Empty;
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;

                //Write to the testlog depending on the test status
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        testlog.Log(logstatus, "Test steps NOT Completed for Test case " + TestContext.CurrentContext.Test.Name + " ");
                        testlog.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        testlog.Log(logstatus, "Test ended with" + logstatus + stacktrace);
                        if (testOutput != null) testlog.Log(logstatus, testOutput.ToString());
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        testlog.Log(logstatus, "Test ended with " + logstatus);
                        if (testOutput != null) testlog.Log(logstatus, testOutput.ToString());
                        break;
                    default:
                        logstatus = Status.Pass;
                        testlog.Log(logstatus, "Test steps finished for test case " + TestContext.CurrentContext.Test.Name);
                        testlog.Log(logstatus, "Test ended with " + logstatus);
                        if (testOutput != null) testlog.Log(logstatus, testOutput.ToString());
                        break;
                }
            }
            catch (Exception exception)
            {
                testlog.Log(Status.Fail, "Test steps NOT Completed for Test case " + TestContext.CurrentContext.Test.Name + " ");
                testlog.Log(Status.Fail, "Test ended with " + Status.Fail + " – " + exception.Message);
                if (testOutput != null) testlog.Log(Status.Fail, testOutput.ToString());
            }
        }

        //Method to get project path
        public static string GetProjectPath()
        {
            string path = Assembly.GetCallingAssembly().Location;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            return projectPath;
        }
    }
}
