using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    public class UnitTest1
    {
        IWebDriver webDriver;


        [OneTimeSetUp]
        public void StartChrome()
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;
            webDriver = new ChromeDriver(testDirectory + @"\chromedriver.exe");
        }

        [Test]
        public void Test1()
        {
            webDriver.Url = "https://www.google.com/";
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            webDriver.Close();
        }
    }
}