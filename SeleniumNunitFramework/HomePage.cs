using System;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;



namespace SeleniumNunitFramework
{
    [TestFixture]
    class Home
    {
       public  IWebDriver driver = null;
        public IConfiguration config;
        public ExtentReportsHelper extent;
        
        [OneTimeSetUp]
        public void Intialize()
        {
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            driver.Manage().Window.Maximize();
            config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            extent = new ExtentReportsHelper();
        }

        [Test]
        public void HomePage()
        {
            driver.Navigate().GoToUrl(config["ShopUrl"]);
            Console.WriteLine("APplication Launched successfully");

        }
        [Test]
        public void CreateStore()
        {
            driver.Navigate().GoToUrl(config["ShopUrl"]);
            driver.FindElement(By.XPath("//a[contains(text(),'Create my store')]")).Click();
            System.Threading.Thread.Sleep(3000);


        }


        [TearDown]
        public void CloseDriver()
        {
            driver.Quit();

        }

    }
}
