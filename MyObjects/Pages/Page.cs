using NUnit.Framework;
using OpenQA.Selenium;

namespace MyObjects.Pages
{
    public abstract class Page
    {
        protected IWebDriver webDriver;


        public Page(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

        }

        public abstract void IsPageProperlyLoaded();

        protected IWebElement FindElement(By locator)
        {
            return webDriver.FindElement(locator);
        }

        protected void ClickOnElement(By locator)
        {
            IWebElement element = FindElement(locator);
            element.Click();
        }

        protected void FillInTextBox(By locator, string text)
        {
            IWebElement element = FindElement(locator);
            element.SendKeys(text);
        }
    }
}
