using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using excel = Microsoft.Office.Interop.Excel;
using System.Configuration;

namespace Jul2018
{
    [TestFixture]
    public class Blogspot2
    {
        IWebDriver driver = new ChromeDriver();

        private string email;
        private string pass;

        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Quit();
        }

        [Test, Order(1)]
        public void UpLoad()
        {
            try
            {
                
                excel.Application x1app = new excel.Application();
                excel.Workbook x1workbook = x1app.Workbooks.Open(@"C:\temp\billy.xlsx");
                excel._Worksheet x1worksheet = x1workbook.Sheets[1];
                excel.Range x1range = x1worksheet.UsedRange;

                int count = x1range.Rows.Count;
                for (int i = 1; i <= count; i++)

                {
                    string email = (x1range.Cells[i, 1] as excel.Range).Value;
                    string pass = (x1range.Cells[i, 2] as excel.Range).Value;

                    driver.FindElement(By.Id("UserName")).SendKeys(email);
                    driver.FindElement(By.Id("Password")).SendKeys(pass);
                    driver.FindElement(By.Id("do-submit")).Click();
                    driver.FindElement(By.CssSelector(".lock")).Click();
                }

                driver.Quit();
                x1app.Quit();
            }
            catch (Exception ex)
            {

            }
        }


    }
}

