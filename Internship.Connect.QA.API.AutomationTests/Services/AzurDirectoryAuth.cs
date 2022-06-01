using System;
using System.Threading;
using Internship.Connect.QA.API.AutomationTests.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public class AzureDirectoryAuth
    {
        private readonly IWebDriver _driver = new ChromeDriver();

        public string DirectoryAuth()
        {
            try
            {
                _driver.Navigate().GoToUrl(Endpoints.AzureDirectoryWebUrl);
                Thread.Sleep(3000);

                WebDriverWait driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                IWebElement emailButton = driverWait.Until(d => d.FindElement(By.Id("i0116")));
                emailButton.Click();
                emailButton.SendKeys("");

                var nextButton = driverWait.Until(d => d.FindElement(By.Id("idSIButton9")));
                nextButton.Click();

                Thread.Sleep(10000);
                var passwordButton = _driver.FindElement(By.Name("passwd"));
                passwordButton.Click();
                passwordButton.SendKeys("");

                var submitButton = driverWait.Until(d => d.FindElement(By.Id("idSIButton9")));
                submitButton.Click();

                Thread.Sleep(10000);
                var someButton = driverWait.Until(d => d.FindElement(By.Id("idBtn_Back")));
                someButton.Click();

                var currentUrl = _driver.Url;

                string[] splitUrl = currentUrl.Split('&');
                string firstUrlPart = splitUrl[0];
                var secondUrlPart = firstUrlPart.Split('=');
                string accessWebToken = secondUrlPart[1];
                return accessWebToken;
            }
            finally
            {
                _driver.Quit();
            }
        }
    }
}