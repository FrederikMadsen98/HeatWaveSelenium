using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace HeatwaveSelenium
{
    [TestClass]
    public class UnitTest1

    {
        private static readonly string _baseUrl = "https://happy-water-0902f6503.5.azurestaticapps.net/";
        private static IWebDriver _driver;
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_baseUrl);

        }
        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("https://happy-water-0902f6503.5.azurestaticapps.net/");
            IWebElement buttonshowlist = _driver.FindElement(By.Id("2"));
            buttonshowlist.Click();
            IWebElement table = _driver.FindElement(By.Id("myTable"));
            Assert.IsTrue(table.Displayed);
        }
        [TestMethod]
        public void TestMethod2()
        {
            IWebElement buttonshow = _driver.FindElement(By.Id("full"));
            buttonshow.Click();

        }
        [TestMethod]
        public void TestMethod3()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement slider = wait.Until(driver => driver.FindElement(By.Id("myRange")));

            slider.Click();

            slider.SendKeys(Keys.ArrowRight);
        }
    }
}