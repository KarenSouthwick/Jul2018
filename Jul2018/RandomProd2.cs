using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace Jul2018
{
    [TestFixture]
    public class RandomProd2
    {
        IWebDriver driver = new ChromeDriver();

        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
            driver.FindElement(By.Id("UserName")).SendKeys("skipperbalbay");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Manage().Cookies.DeleteCookieNamed("catalogueHistory");
            driver.FindElement(By.CssSelector(".lock")).Click();
            driver.Quit();
        }

        [Test, Order(1)]
        public void RandomProduct()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();
            driver.FindElement(By.LinkText("add product")).Click();
            driver.FindElement(By.Id("ProductLine_Name")).SendKeys("" + GetRandomNumber(100, 1000));
            driver.FindElement(By.Id("ProductLine_ReferenceCode")).SendKeys("" + GetRandomNumber(16, 99));
            driver.FindElement(By.XPath("(//input[@type='text'])[5]")).SendKeys("Ackio" + Keys.Enter);
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
        }
    }
}
