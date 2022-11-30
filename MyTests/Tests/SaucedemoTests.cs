using MyObjects.Helpers;
using MyObjects.Pages.Saucedemo;
using MyTests.Tests;
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
    public class SaucedemoTests : TestBase
    {
        [Test]
        public void AddItemToCart()
        {
            myWebDriver.GoTo(Url.saucedemoUrl);
            LoginPage loginPage = new LoginPage(myWebDriver);
            //loginPage.WaitForPageToLoad(wait);
            loginPage.IsPageProperlyLoaded();
            loginPage.Login("standard_user", "secret_sauce");
            ProductsPage productsPage = new ProductsPage(myWebDriver);
            //productsPage.WaitForPageToLoad(wait);
            myWebDriver.AssertTextPresentOnPage("Products", "Page title on Products page");
            productsPage.IsPageProperlyLoaded();
            productsPage.AddBackpackToCart();
            productsPage.GoToCart();
            CartPage cartPage = new CartPage(myWebDriver);
            //cartPage.WaitForPageToLoad(wait);
            myWebDriver.AssertTextPresentOnPage("Your Cart", "Page title on Cart page");
            cartPage.IsPageProperlyLoaded();
            cartPage.RemoveBackpackFromCart();
            cartPage.ClickContinue();
            productsPage = new ProductsPage(myWebDriver);
            //productsPage.WaitForPageToLoad(wait);
            productsPage.IsPageProperlyLoaded();
            productsPage.AddTshirtToCart();
            productsPage.GoToCart();
            cartPage = new CartPage(myWebDriver);
            //cartPage.WaitForPageToLoad(wait);
            cartPage.IsPageProperlyLoaded();
            cartPage.ClickCheckout();
            
        }

        [Test]
        public void FailedLoginInvalidPassword()
        {
            myWebDriver.Url = Url.saucedemoUrl;
            LoginPage loginPage = new LoginPage(myWebDriver);
            loginPage.IsPageProperlyLoaded();
            loginPage.Login("standard_user", "secretsauce");
            ProductsPage productsPage = new ProductsPage(myWebDriver);
        }
    }
}
