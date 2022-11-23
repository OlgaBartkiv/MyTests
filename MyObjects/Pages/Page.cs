using MyObjects.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyObjects.Pages
{
    public abstract class Page
    {
        protected MyWebDriver myWebDriver;
        const int timeoutSeconds = 10;


        public Page(MyWebDriver myWebDriver)
        {
            this.myWebDriver = myWebDriver;

        }

        public abstract void IsPageProperlyLoaded();

        protected void WaitForElementToBeClickable(By locator)
        {
            Logger.Info($"Waiting for element by locator: {locator} to be clickable");
            WebDriverWait wait = new WebDriverWait(myWebDriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        protected void FluentlyWaitForElementToBePresent(By locator)
        {
            Logger.Info($"Waiting for element by locator: {locator} to be present");
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(myWebDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
            fluentWait.Until(x => x.FindElement(locator));
        }

        protected void FluentlyWaitForElementToDisappear(By locator)
        {
            Logger.Info($"Waiting for element by locator: {locator} to disappear");
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(myWebDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.Until(x => x.FindElements(locator).Count == 0);
        }




    }
}
