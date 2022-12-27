using MyObjects.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests.Tests
{
    public class AlertTests : TestBase
    {
        [Test]
        public void HandleSimpleAlert()
        {
            myWebDriver.GoTo(GlobalVariables.GuruAlert);
            myWebDriver.Manage().Window.Maximize();
            myWebDriver.FindElement(By.Name("cusid")).SendKeys("53920");
            myWebDriver.FindElement(By.Name("submit")).Submit();
            var alert = myWebDriver.SwitchTo().Alert();
            alert.Accept(); 
        }

        [Test]
        public void HandlePopupWindow()
        {
            myWebDriver.GoTo(GlobalVariables.GuruPopup);
            myWebDriver.Manage().Window.Maximize();
            myWebDriver.FindElement(By.XPath("//*[contains(@href,'popup.php')]")).Click();
            string mainWindow = myWebDriver.CurrentWindowHandle;
            IList<string> allWindows = new List<string>(myWebDriver.WindowHandles);
            IEnumerator<string> enumerator = allWindows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string childWindow = enumerator.Current;
                if (!mainWindow.Equals(childWindow))
                {
                    myWebDriver.SwitchTo().Window(childWindow);
                    myWebDriver.FindElement(By.Name("emailid")).SendKeys("gaurav.3n@gmail.com");
                    myWebDriver.FindElement(By.Name("btnLogin")).Click();
                    myWebDriver.Close();
                }
            }
            myWebDriver.SwitchTo().Window(mainWindow);
        }
    }
}
