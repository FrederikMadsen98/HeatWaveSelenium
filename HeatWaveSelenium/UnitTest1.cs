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
        //URL for hjemmesiden som skal testes
        private static readonly string _baseUrl = "https://happy-water-0902f6503.5.azurestaticapps.net/";

        //Driveren som skal bruges til at interagere med hjemmesiden
        private static IWebDriver _driver;

        //Initialisering testklassen og opretter en instans af driveren
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_baseUrl);

        }

        //Lukker driveren efter testen er kørt
        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        //Tester om at tabellen vises efter at have trykket på knappen
        [TestMethod]
        public void TestMethod1()
        {
            //Navigerer til hjemmesiden
            _driver.Navigate().GoToUrl("https://happy-water-0902f6503.5.azurestaticapps.net/");

            //Finder knappen med id "2" og trykker på den
            IWebElement buttonshowlist = _driver.FindElement(By.Id("2"));
            buttonshowlist.Click();

            //Finder tabellen med id "myTable" og tjekker om den er vist
            IWebElement table = _driver.FindElement(By.Id("myTable"));
            Assert.IsTrue(table.Displayed);
        }

        //Tester om knappen "Full" kan klikkes på
        [TestMethod]
        public void TestMethod2()
        {
            //Finder og trykker på knappen med id "full"
            IWebElement buttonshow = _driver.FindElement(By.Id("full"));
            buttonshow.Click();

        }

        //Tester om slideren kan bruges
        [TestMethod]
        public void TestMethod3()
        {
            //Finder slideren og bruger Keys.ArrowRight til at flytte den
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement slider = wait.Until(driver => driver.FindElement(By.Id("myRange")));

            slider.Click();

            slider.SendKeys(Keys.ArrowRight);
        }
    }
}