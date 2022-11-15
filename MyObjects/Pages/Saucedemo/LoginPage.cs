﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Pages.Saucedemo
{
    public class LoginPage : Page
    {
        IWebDriver webDriver;

        public readonly By txtUsername = By.XPath("//input[contains(@id,'user-name')]");
        public readonly By txtPassword = By.XPath("//input[contains(@id,'password')]");
        public readonly By btnLogin = By.XPath("//input[contains(@id,'login-button')]");
        public readonly By lbLogo = By.XPath("//div[contains(@class,'logo')]");

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
       
        }
        public void WaitForPageToLoad(WebDriverWait wait)
        {
            wait.Until(d => d.FindElement(btnLogin));
        }

        public override void IsPageProperlyLoaded()
        {
            try
            {
                FindElement(lbLogo);
                FindElement(btnLogin);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        public void SetUsername(string username)
        {
            FillInTextBox(txtUsername, username);
        }
        public void SetPassword(string password)
        {
            FillInTextBox(txtPassword, password);
        }
        public void ClickLogin()
        {
            ClickOnElement(btnLogin);
        }
        public void Login(string username, string password)
        {
            FillInTextBox(txtUsername, username);
            FillInTextBox(txtPassword, password);
            ClickOnElement(btnLogin);
        }

    }
}