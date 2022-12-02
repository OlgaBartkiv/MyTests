﻿using MyObjects.Helpers;
using MyObjects.Pages.Page_Objects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests.Tests
{
    public class PageFactoryTests : TestBase
    {

        [Test]
        public void LoginAndAddItemToCart()
        {
            myWebDriver.GoTo(Url.saucedemoUrl);
            var loginPage = new LoginPagePO(myWebDriver);
            loginPage.UserName.SendKeys("standard_user");
            loginPage.Password.SendKeys("secret_sauce");
            loginPage.Login.Submit();

            var productsPage = new ProductsPagePO(myWebDriver);
            productsPage.BackPack.Submit();
        }
    }
}
