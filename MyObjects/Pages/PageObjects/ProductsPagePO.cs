using MyObjects.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Pages.Page_Objects
{
    public class ProductsPagePO
    {

        [FindsBy(How = How.XPath, Using = "//button[contains(@id,'add-to-cart-sauce-labs-backpack')]")]
        public IWebElement BackPack { get; set; }

        public ProductsPagePO(MyWebDriver myWebDriver)
        {
            PageFactory.InitElements(myWebDriver, this);
        }
    }
}
