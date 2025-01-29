using MatomoTestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MatomoTestSuite.Pages
{
    public class HomePage : Driver
    {
        private IWebElement demoLink;
        private IWebElement loginLink;
        private IWebElement helpLink;

        #region Page Events

        public void clickDemoLink()
        {
            demoLink = driver.FindElement(By.Id("a-variant-hero-btn-link"));
            demoLink.Click();

            //Check few random elemnts
            IWebElement titleElement = driver.FindElement(By.XPath("//*[@id=\"cloud\"]/div/div[1]/header/h2"));
            IWebElement emailElement = driver.FindElement(By.Id("email"));
            IWebElement webElement = driver.FindElement(By.Id("website"));
            IWebElement acceptTermsElement = driver.FindElement(By.Id("acceptterms"));
            IWebElement buttonElement = driver.FindElement(By.XPath("//*[@id=\"signup_form\"]/div[6]/button"));

            //Asertions
            Assert.That(titleElement.Text, Is.EqualTo("Start improving your websites and apps"));
            Assert.That(emailElement != null);
            Assert.That(webElement != null);
            Assert.That(acceptTermsElement != null);
            Assert.That(buttonElement != null);
        }

        public void clickLogin()
        {
            loginLink = driver.FindElement(By.Id("login_link"));
            loginLink.Click();

            //Check few random elemnts
            IWebElement titleElement = driver.FindElement(By.XPath("//span[@class='heading' and text()='Log in to your Matomo Analytics']"));
            IWebElement domainElement = driver.FindElement(By.Id("domain"));
            IWebElement domainSuffixElement = driver.FindElement(By.Id("domain_suffix"));
            IWebElement domainLoginElement = driver.FindElement(By.Id("domain_login"));

            //Asertions
            Assert.That(titleElement.Text, Is.EqualTo("Log in to your Matomo Analytics"));
            Assert.That(domainElement != null);
            Assert.That(domainSuffixElement != null);
            Assert.That(domainLoginElement != null);
        }

        public void clickHelpLink()
        {
            helpLink = driver.FindElement(By.Id("help_center_link"));
            helpLink.Click();

            //Check few random elemnts
            IWebElement titleElement = driver.FindElement(By.XPath("//h1[@class='elementor-heading-title elementor-size-default' and text()='Matomo Help Centre']"));
            IWebElement searchElement = driver.FindElement(By.Id("elementor-search-form-a5e7204"));
            IWebElement searchButtonElement = driver.FindElement(By.XPath("//*[@id=\"help-page-search\"]/div/search/form/div/button"));
            
            //Assertions
            Assert.That(titleElement.Text, Is.EqualTo("Matomo Help Centre"));
            Assert.That(searchElement != null);
            Assert.That(searchButtonElement != null);
        }


        //Method to get all links and images on the home page and check whether it works
        public async Task<bool> checkBrokenLinks(StringBuilder testOutput, bool isImage =false)
        {
            string tagName = "a";
            string attributName = "href";
            List<IWebElement> links;
            bool areAllLinksValid = true;

            if (isImage)
            {
                tagName = "img";
                attributName = "src";
            }

            links = new List<IWebElement>(driver.FindElements(By.TagName(tagName)));

            // Check all links and image links
            foreach (IWebElement link in links)
            {
                string url = link.GetAttribute(attributName);
                if (url != null && (new Uri(url).Scheme == "http" || new Uri(url).Scheme == "https"))
                {
                    if (!await CheckLink(url, testOutput)) areAllLinksValid = false;
                }
            }

            return areAllLinksValid;
        }

        #endregion

        #region Supporting Methods

        //Method to send http request and check whether the link is valid
        public static async Task<bool> CheckLink(string url, StringBuilder testOutput)
        {
            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //Write to test explorer
                    Console.WriteLine($"Valid link: {url}");
                    //Use to passs to the test report
                    testOutput.AppendLine($"Valid link: {url} (Status Code: {response.StatusCode})<br>");
                    return true;
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    Console.WriteLine($"Forbidden link: {url} (Status Code: {response.StatusCode})");
                    testOutput.AppendLine($"Forbidden link: {url} (Status Code: {response.StatusCode})<br>");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Broken link: {url} (Status Code: {response.StatusCode})");
                    testOutput.AppendLine($"Broken link: {url} (Status Code: {response.StatusCode})<br>");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error checking {url}: {ex.Message}");
                testOutput.AppendLine($"Error checking {url}: {ex.Message}<br>");
                return false;
            }
        }

        #endregion
    }
}
