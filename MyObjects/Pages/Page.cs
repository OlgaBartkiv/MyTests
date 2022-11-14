using NUnit.Framework;
using OpenQA.Selenium;

namespace MyObjects.Pages
{
    public class Page
    {
        IWebDriver webDriver;

        public readonly By lbLogo = By.XPath("//div[contains(@class,'logo')]");


        public Page(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

        }

        public virtual void IsPageProperlyLoaded()
        {
            try
            {
                FindElement(lbLogo);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

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
