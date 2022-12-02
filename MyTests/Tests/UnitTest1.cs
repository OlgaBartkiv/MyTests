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
            myWebDriver.Url = "https://www.google.com/";
            Assert.Pass();
        }

    }
}