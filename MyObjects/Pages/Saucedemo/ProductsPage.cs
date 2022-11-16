using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Pages.Saucedemo
{
    public class ProductsPage
    {
        IWebDriver webDriver;

        public readonly By btnAddBackpack = By.XPath("//button[contains(@id,'add-to-cart-sauce-labs-backpack')]");
        public readonly By btnAddTshirt = By.XPath("//button[contains(@id,'add-to-cart-sauce-labs-bolt-t-shirt')]");
        public readonly By hlShoppingCart = By.CssSelector("div[id='shopping_cart_container'] a[class*='shopping_cart_link']");


        public ProductsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

        }
        public void WaitForPageToLoad(WebDriverWait wait)
        {
            wait.Until(d => d.FindElement(hlShoppingCart));
        }
        public void AddBackpackToCart()
        {
           webDriver.FindElement(btnAddBackpack).Click();
        }
        public void AddTshirtToCart()
        {
            webDriver.FindElement(btnAddTshirt).Click();
        }

        public void GoToCart()
        {
            webDriver.FindElement(hlShoppingCart).Click();
        }
    }
}
