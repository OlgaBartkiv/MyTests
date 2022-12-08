using MyObjects.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Pages.Page_Objects
{
    public class LoginPagePO
    {

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'user-name')]")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'password')]")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'login-button')]")]
        public IWebElement Login { get; set; }

        public LoginPagePO(MyWebDriver myWebDriver)
        {
            PageFactory.InitElements(myWebDriver, this);
        }
    }
}
