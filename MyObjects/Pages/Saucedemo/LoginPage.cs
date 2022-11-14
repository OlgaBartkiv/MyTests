using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Pages.Saucedemo
{
    public class LoginPage
    {
        IWebDriver webDriver;

        public readonly By txtUsername = By.XPath("//input[contains(@id,'user-name')]");
        public readonly By txtPassword = By.XPath("//input[contains(@id,'password')]");
        public readonly By btnLogin = By.XPath("//input[contains(@id,'login-button')]");

        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
       
        }
        public void WaitForPageToLoad(WebDriverWait wait)
        {
            wait.Until(d => d.FindElement(btnLogin));
        }

        public void SetUsername(string username)
        {
            webDriver.FindElement(txtUsername).SendKeys(username);
        }
        public void SetPassword(string password)
        {
            webDriver.FindElement(txtPassword).SendKeys(password);
        }
        public void ClickLogin()
        {
            webDriver.FindElement(btnLogin).Click();
        }
        public void Login(string username, string password)
        {
            webDriver.FindElement(txtUsername).SendKeys(username);
            webDriver.FindElement(txtPassword).SendKeys(password);
            webDriver.FindElement(btnLogin).Click();
        }

    }
}
