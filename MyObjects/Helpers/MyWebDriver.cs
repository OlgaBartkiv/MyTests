using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Helpers
{
    public class MyWebDriver : IWebDriver
    {
        public IWebDriver webDriver;

        public MyWebDriver(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement FindElement(By locator)
        {
            Logger.Info($"Searching for element by locator: {locator}");
            return webDriver.FindElement(locator);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            Logger.Info($"Searching for element by locator: {locator}");
            return webDriver.FindElements(locator);
        }

        public void ClickOnElement(By locator)
        {
            IWebElement element = FindElement(locator);
            Logger.Info($"Clicking on element by locator: {locator}");
            element.Click();
        }

        public void FillInTextBox(By locator, string text)
        {
            Logger.Info($"Filling in the text box with the following text: {text}");
            IWebElement element = FindElement(locator);
            element.SendKeys(text);
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }
        public void Close()
        {
            Logger.Info($"Closing current window");
            webDriver.Close();
        }

        public void Quit()
        {
            Logger.Info($"Closing all windows and ending the session");
            webDriver.Quit();
        }

        public IOptions Manage()
        {
            return webDriver.Manage();
        }

        public INavigation Navigate()
        {
            return webDriver.Navigate();
        }
        public ITargetLocator SwitchTo()
        {
            Logger.Info($"Switching to another frame or window");
            return webDriver.SwitchTo();
        }

        public string Url
        {
            get { return webDriver.Url; }
            set { webDriver.Url = value; }
        }

        public string Title => webDriver.Title;

        public string PageSource => webDriver.PageSource;

        public string CurrentWindowHandle => webDriver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => webDriver.WindowHandles;

        /// <summary>
        /// Make full page screenshot and log description into log file
        /// </summary>
        /// <param name="description"></param>
        /// <param name="status"></param>
        public void LogScreenshot(string description = "", TestStatus status = TestStatus.Passed)
        {
            string fileName = "snapshot" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";


            ITakesScreenshot screenshotHandler = webDriver as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\obartkiv\source\MyTests\MyObjects\bin\Debug\Logs" + fileName, ScreenshotImageFormat.Png);

            if (status == TestStatus.Passed)
            {
                Logger.Info($"Screenshot: {description}");
            }
            else
            {
                Logger.Error($"Screenshot: {description}");
            }
        }

        /// <summary>
        /// Hard Assert: actual Url against expected
        /// </summary>
        /// <param name="urlExpected"></param>
        public void AssertUrl(string urlExpected)
        {
            string urlActual = webDriver.Url;
            bool isMatch = urlActual.Equals(urlExpected);
            if (isMatch)
            {
                Logger.Info($"PASS: Actual URL: '{urlActual}' is equal to the Expected URL: '{urlExpected}'");
            }
            else
            {
                Logger.Error($"FAIL: Actual URL: '{urlActual}' is not equal to the Expected URL: '{urlExpected}'");
                Assert.Fail();
            }

        }

        /// <summary>
        /// Hard Assert: verify element is present on page
        /// </summary>
        /// <param name="locator"></param>
        public void AssertElementPresentOnPage(By locator)
        {
            IWebElement element = FindElement(locator);
            if (element != null)
            {
                Logger.Info($"PASS: Expected object with locator: {locator} is present on page");

            }
            else
            {
                Logger.Error($"FAIL: Expected object with locator: {locator} is absent on page");
                Assert.Fail();
            }
        }

        /// <summary>
        /// Soft Assert: verify text is present on page
        /// </summary>
        /// <param name="text"></param>
        public void AssertTextPresentOnPage(string text)
        {
            if (webDriver.PageSource.Contains(text))
            {
                Logger.Info($"PASS: Expected text: {text} is present on page");
            }
            else
            {
                Logger.Error($"FAIL: Expected text: {text} is absent on page");

            }
        }

        /// <summary>
        /// Soft Assert: verify number of items on page against expected
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="expectedCount"></param>
        public void AssertCountOfItemsOnPage(By locator, int expectedCount)
        {
            ReadOnlyCollection<IWebElement> list = FindElements(locator);
            int itemsCount = list.Count;
            if(itemsCount == expectedCount)
            {
                Logger.Info($"PASS: Actual count of items on page is {expectedCount}");
            }
            else
            {
                Logger.Info($"FAIL: Actual count of items on page is not equal to {expectedCount}");
            }
        }
    }
}
