using MyObjects.Helpers;
using MyTests.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    public class UnitTest1 : TestBase
    {

        [Test]
        public void Test1()
        {
            myWebDriver.GoTo(GlobalVariables.Google);
            Assert.Pass();
        }

    }
}