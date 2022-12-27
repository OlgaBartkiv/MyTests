using MyObjects.Helpers;
using MyObjects.Pages.Saucedemo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTests.Tests
{
    public  class LoginValidationCases : TestBase
    {

        [Test, Description("This test verifies attempts to log in providing valid/invalid username or password")]
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("standard_user", "secretsauce")]
        [TestCase("standarduser", "secret_sauce")]
        [TestCase("standarduser", "secretsauce")]
        [Parallelizable(ParallelScope.All)]
        public void LoginValidation(string username, string password)
        {
            Thread.Sleep(2000);
            myWebDriver.GoTo(GlobalVariables.Saucedemo);
            LoginPage loginPage = new LoginPage(myWebDriver);
            loginPage.IsPageProperlyLoaded();
            loginPage.SetUsername(username);
            loginPage.SetPassword(password);
            loginPage.ClickLogin();
            Thread.Sleep(2000);
            ProductsPage productsPage = new ProductsPage(myWebDriver);
        }
    }
}
