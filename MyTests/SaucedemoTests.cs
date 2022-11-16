using MyObjects.Pages.Saucedemo;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests
{
    public class SaucedemoTests
    {
        IWebDriver webDriver;
        WebDriverWait wait;

        [OneTimeSetUp]
        public void StartChrome()
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;
            webDriver = new ChromeDriver(testDirectory + @"\chromedriver.exe");
            wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
        }

        [Test]
        public void AddItemToCart()
        {
            webDriver.Url = "https://www.saucedemo.com/";
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.WaitForPageToLoad(wait);
            loginPage.Login("standard_user", "secret_sauce");
            ProductsPage productsPage = new ProductsPage(webDriver);
            productsPage.WaitForPageToLoad(wait);
            productsPage.AddBackpackToCart();
            productsPage.GoToCart();
            CartPage cartPage = new CartPage(webDriver);
            cartPage.WaitForPageToLoad(wait);
            cartPage.RemoveBackpackFromCart();
            cartPage.ClickContinue();
            productsPage = new ProductsPage(webDriver);
            productsPage.WaitForPageToLoad(wait);
            productsPage.AddTshirtToCart();
            productsPage.GoToCart();
            cartPage = new CartPage(webDriver);
            cartPage.WaitForPageToLoad(wait);
            cartPage.ClickCheckout();
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            webDriver.Close();
        }
    }
}
