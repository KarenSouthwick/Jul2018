using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using System.Configuration;

namespace Jul2018
{
    [TestFixture]
    public class BasicScript
    {
        IWebDriver driver = new ChromeDriver();
        

        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
            driver.FindElement(By.Id("UserName")).SendKeys("darioeurocash");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Quit();
        }

        [Test, Order(1)]
        public void LogOut()
        {
            driver.FindElement(By.CssSelector(".lock")).Click();
        }
    }
}
