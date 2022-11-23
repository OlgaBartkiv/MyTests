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
            myWebDriver.Url = Url.saucedemoUrl;
            LoginPage loginPage = new LoginPage(myWebDriver);
            loginPage.IsPageProperlyLoaded();
            loginPage.Login("standard_user", "secret_sauce");
            ProductsPage productsPage = new ProductsPage(myWebDriver);
            myWebDriver.AssertTextPresentOnPage("Products");
            productsPage.IsPageProperlyLoaded();
            productsPage.AddBackpackToCart();
            productsPage.GoToCart();
            CartPage cartPage = new CartPage(myWebDriver);
            myWebDriver.AssertTextPresentOnPage("Your Cart");
            cartPage.IsPageProperlyLoaded();
            cartPage.RemoveBackpackFromCart();
            cartPage.ClickContinue();
            productsPage = new ProductsPage(myWebDriver);
            productsPage.IsPageProperlyLoaded();
            productsPage.AddTshirtToCart();
            productsPage.GoToCart();
            cartPage = new CartPage(myWebDriver);
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
