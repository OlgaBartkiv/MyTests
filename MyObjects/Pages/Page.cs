using NUnit.Framework;
using OpenQA.Selenium;

namespace MyObjects.Pages
{
    public abstract class Page
    {
        IWebDriver webDriver;


        public Page(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

        }

        public abstract void IsPageProperlyLoaded();

        public IWebElement FindElement(By locator)
        {
            return webDriver.FindElement(locator);
        }

        public void ClickOnElement(By locator)
        {
            IWebElement element = FindElement(locator);
            element.Click();
        }

        public void FillInTextBox(By locator, string text)
        {
            IWebElement element = FindElement(locator);
            element.SendKeys(text);
        }
    }
}
