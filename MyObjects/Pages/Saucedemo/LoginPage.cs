using MyObjects.Helpers;
using NUnit.Framework;
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
        public static readonly string PageUrl = Url.saucedemoUrl;

        private readonly By txtUsername = By.XPath("//input[contains(@id,'user-name')]");
        private readonly By txtPassword = By.XPath("//input[contains(@id,'password')]");
        private readonly By btnLogin = By.XPath("//input[contains(@id,'login-button')]");
        private readonly By lbLogo = By.XPath("//div[contains(@class,'logo')]");

        public LoginPage(MyWebDriver myWebDriver) : base(myWebDriver)
        {
            this.myWebDriver = myWebDriver;
            Logger.Info($"Opening 'Login' page: {PageUrl}");
            myWebDriver.AssertUrl(PageUrl);

        }
        public void WaitForPageToLoad(WebDriverWait wait)
        {
            wait.Until(d => d.FindElement(btnLogin));
        }

        public override void IsPageProperlyLoaded()
        {
            try
            {
                myWebDriver.FindElement(lbLogo);
                myWebDriver.FindElement(btnLogin);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        public void SetUsername(string username)
        {
            myWebDriver.FillInTextBox(txtUsername, username);
        }
        public void SetPassword(string password)
        {
            myWebDriver.FillInTextBox(txtPassword, password);
        }
        public void ClickLogin()
        {
            myWebDriver.ClickOnElement(btnLogin);
        }
        public void Login(string username, string password)
        {
            myWebDriver.FillInTextBox(txtUsername, username);
            myWebDriver.FillInTextBox(txtPassword, password);
            myWebDriver.ClickOnElement(btnLogin);
            myWebDriver.LogScreenshot("After credentials submission...");
        }

    }
}
