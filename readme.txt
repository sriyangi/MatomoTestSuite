Overview
--------
This automation framework is designed to test core functionalities on the Matomo website (matomo.org). 
It includes scenarios for:

- Navigating to three sections of the website (Login, Help, Demo).
- Checking for broken links and images on the homepage.
- Generating detailed reports on test execution using AventStack.ExtentReports.


Structure of the Automation Framework
-------------------------------------
Project Folder Structure

/MatomoTestSuite
/bin/               # Contains compiled binaries of the test project (output folder after build)
/Reports/           # Folder to store the generated test reports. This name is configurable
/Tests/             # Contains the test scripts
 - HomePageBrokenLinksTest.cs  # Test cases related to the homepage navigation and validation
 - HomePageLinkNavigationTest.cs  # Test cases to check for broken links and images
/Pages/             # Contains the page objects
 - HomePage.cs	    # Contains web elements and events related to home page
/Helpers/           # Contains helper classes
 - Config.cs	    # Use to store static links, names,etc.
 - Driver.cs	    # Methods and properties related to web driver including one time setup and one time tear down
 - TestHelper.cs    # Methods and properties related to extend reporter function
- MatomoTestSuite.sln # Solution file for Visual Studio

How to Run the Automated Tests
------------------------------
Prerequisites:
Before running the automated tests, ensure the following are installed:

- Visual Studio (or any other C# IDE of your choice).
- .NET Framework: Make sure you are targeting a compatible version (usually .NET Core or .NET Framework).
- NuGet Packages:
Selenium WebDriver, NUnit, AventStack.ExtentReports (For generating the test execution report)

Steps to Run the Tests:
1. Clone the repository or unzip the project:

2. Build the Solution:

Open the solution file MatomoTestSuite.sln in Visual Studio.
Build the solution by selecting Build > Build Solution from the menu.

3. Run the Tests:

Open Test Explorer in Visual Studio (View > Test Explorer).
The tests should appear in the Test Explorer.
Select and run all tests, or choose individual tests to execute.

4. Execution:

The tests will launch the browser (Chrome).
The tests will then perform the steps defined in the test files:
Navigate to sections.
Check for broken links and images on the homepage.
The results will be recorded in the Reports folder.


How to View the Test Execution Report
-------------------------------------
Once the tests have been executed, the test execution report will be generated using AventStack.ExtentReports.

Steps to View the Report:
After test execution, navigate to the Reports directory in the project folder.
You will find an HTML report file (e.g., Broken Links Test_01292025_1007AM.html).
Open the HTML file in a browser to view the detailed test execution report.

Report Details:
The report will include:

The total number of tests run.
The number of tests passed and failed.
Detailed logs for each test, including test steps, any failures.
Summary of the results, including status of all links and images found on the home page.

Assumptions
-----------

The Matomo website is publicly accessible and does not require any authentication to access the demo or core sections.
The tests are designed to run on a Chrome browser only due to the time limitation. 
The framework is intended for basic link and image validation, and does not cover complex dynamic testing beyond basic navigation.
The Config.cs file was used to store the URL path and report directory name instead of using a .config or .json file due to time limitations.
Under the test 'Verify the navigation to any three sections of the website from the homepage,' only basic validations were performed to check the presence of a few random elements.
Under the test 'Check for any broken links or images on the homepage,' HttpClient was used instead of Selenium WebDriver to improve efficiency.


