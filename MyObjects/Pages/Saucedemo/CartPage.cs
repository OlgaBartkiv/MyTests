using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Pages.Saucedemo
{
    public class CartPage
    {
        IWebDriver webDriver;

        public readonly By btnRemoveBackpack = By.XPath("//button[contains(@id,'remove-sauce-labs-backpack')]");
        public readonly By btnCheckout = By.XPath("//button[contains(@id,'checkout')]");
        public readonly By btnContinue = By.XPath("//button[contains(@id,'continue-shopping')]");


        public CartPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

        }
        public void WaitForPageToLoad(WebDriverWait wait)
        {
            wait.Until(d => d.FindElement(btnCheckout));
        }
        public void RemoveBackpackFromCart()
        {
            webDriver.FindElement(btnRemoveBackpack).Click();
        }
        public void ClickContinue()
        {
            webDriver.FindElement(btnContinue).Click();
        }
        public void ClickCheckout()
        {
            webDriver.FindElement(btnCheckout).Click();
        }
    }
}
