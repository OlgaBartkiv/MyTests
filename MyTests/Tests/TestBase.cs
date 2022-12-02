using MyObjects.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests.Tests
{
    public class TestBase
    {
        public MyWebDriver myWebDriver { get; set; }


        [SetUp]
        public void StartChrome()
        {
            InitializeDriver();
        }


        public void InitializeDriver()
        {
            if (myWebDriver == null)
            {
                try
                {
                    var testDirectory = TestContext.CurrentContext.TestDirectory;
                    myWebDriver = new MyWebDriver(new ChromeDriver(testDirectory + @"\chromedriver.exe"));
                    myWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    myWebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                    Logger.Info("Started chrome browser");
                    myWebDriver.Manage().Window.Maximize();
                }
                catch
                {
                    throw new Exception("Could not start chrome driver");
                }
            }

        }


        [OneTimeTearDown]
        public void CloseTest()
        {
            myWebDriver.Close();
            Logger.Info("Test run was closed");

        }
    }
}
