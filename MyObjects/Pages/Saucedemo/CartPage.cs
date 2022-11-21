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
    public class CartPage : Page
    {
        public static readonly string PageUrl = Url.saucedemoUrl + "cart.html";

        private readonly By btnRemoveBackpack = By.XPath("//button[contains(@id,'remove-sauce-labs-backpack')]");
        private readonly By btnCheckout = By.XPath("//button[contains(@id,'checkout')]");
        private readonly By btnContinue = By.XPath("//button[contains(@id,'continue-shopping')]");
        private readonly By lbLogo = By.XPath("//div[contains(@class,'logo')]");


        public CartPage(MyWebDriver myWebDriver) : base(myWebDriver)
        {
            this.myWebDriver = myWebDriver;
            Logger.Info($"Opening 'Cart' page: {PageUrl}");

        }
        public void WaitForPageToLoad(WebDriverWait wait)
        {
            wait.Until(d => d.FindElement(btnCheckout));
        }
        public override void IsPageProperlyLoaded()
        {
            try
            {
                myWebDriver.FindElement(lbLogo);
                myWebDriver.FindElement(btnCheckout);
                myWebDriver.LogScreenshot("Items in the cart currently...");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        public void RemoveBackpackFromCart()
        {
            myWebDriver.ClickOnElement(btnRemoveBackpack);
            Logger.Info("Backpack is removed from cart");
            myWebDriver.LogScreenshot("Backpack removed from cart");
        }
        public void ClickContinue()
        {
            myWebDriver.ClickOnElement(btnContinue);
        }
        public void ClickCheckout()
        {
            myWebDriver.ClickOnElement(btnCheckout);
        }
    }
}
