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
    public class ProductsPage : Page
    {
        public static readonly string PageUrl = Url.saucedemoUrl + "inventory.html";

        private readonly By btnAddBackpack = By.XPath("//button[contains(@id,'add-to-cart-sauce-labs-backpack')]");
        private readonly By btnAddTshirt = By.XPath("//button[contains(@id,'add-to-cart-sauce-labs-bolt-t-shirt')]");
        private readonly By hlShoppingCart = By.CssSelector("div[id='shopping_cart_container'] a[class*='shopping_cart_link']");
        private readonly By lbLogo = By.XPath("//div[contains(@class,'logo')]");


        public ProductsPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            Logger.Info($"Opening 'Products' page: {PageUrl}");

        }
        public void WaitForPageToLoad(WebDriverWait wait)
        {
            wait.Until(d => d.FindElement(hlShoppingCart));
        }
        public override void IsPageProperlyLoaded()
        {
            try
            {
                FindElement(lbLogo);
                FindElement(hlShoppingCart);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        public void AddBackpackToCart()
        {
            ClickOnElement(btnAddBackpack);
            Logger.Info("Backpack is added to cart");
        }
        public void AddTshirtToCart()
        {
            ClickOnElement(btnAddTshirt);
            Logger.Info("Tshirt is added to cart");
        }

        public void GoToCart()
        {
            ClickOnElement(hlShoppingCart);
        }
    }
}
