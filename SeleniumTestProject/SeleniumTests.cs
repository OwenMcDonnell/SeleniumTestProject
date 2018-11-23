using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    [TestClass]
    public class SeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("inside test method 1");
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.LinkText("Docs")).Click();
            var element = driver.FindElement(By.Id("welcome-to-appveyor"));
            this.driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Assert.IsTrue(element.Displayed, "Verified title of the page");
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://www.appveyor.com/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                //case "Firefox":
                //    driver = new FirefoxDriver();
                //    break;
                //case "IE":
                //    driver = new InternetExplorerDriver();
                //    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
