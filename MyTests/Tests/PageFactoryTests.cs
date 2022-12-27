using MyObjects.Helpers;
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

        [Test, Retry(2), Description("This test is using Page Factory class")]
        [Ignore("Ignore this test as we are using POM not Page Factory")]
        public void LoginAndAddItemToCart()
        {
            myWebDriver.GoTo(GlobalVariables.Saucedemo);
            var loginPage = new LoginPagePO(myWebDriver);
            loginPage.UserName.SendKeys("standard_user");
            loginPage.Password.SendKeys("secret_sauce");
            loginPage.Login.Submit();

            var productsPage = new ProductsPagePO(myWebDriver);
            productsPage.BackPack.Submit();
        }
    }
}
