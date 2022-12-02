using MyObjects.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyObjects.Pages
{
    public abstract class Page
    {
        protected MyWebDriver myWebDriver;


        public Page(MyWebDriver myWebDriver)
        {
            this.myWebDriver = myWebDriver;

        }

        public abstract void IsPageProperlyLoaded();

       
    }
}
