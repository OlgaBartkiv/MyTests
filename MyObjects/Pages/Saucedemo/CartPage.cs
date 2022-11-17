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


        public CartPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;

        }
        public void WaitForPageToLoad(WebDriverWait wait)
        {
            wait.Until(d => d.FindElement(btnCheckout));
        }
        public override void IsPageProperlyLoaded()
        {
            try
            {
                FindElement(lbLogo);
                FindElement(btnCheckout);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        public void RemoveBackpackFromCart()
        {
            ClickOnElement(btnRemoveBackpack);
        }
        public void ClickContinue()
        {
            ClickOnElement(btnContinue);
        }
        public void ClickCheckout()
        {
            ClickOnElement(btnCheckout);
        }
    }
}
