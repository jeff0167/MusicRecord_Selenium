using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using MusicRecords;
using System.Threading;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MusicRecord_Selenium
{
    [TestClass]
    public class MusicRecordWebTest
    {
        const string driverLocation = @"C:\Users\Bruger\Desktop\WebDrivers\ChromeDriverNew";
        const string WebPageFile = @"C:\Users\Bruger\source\repos\Vue_Stuff\jsSayHelloVue3\MusicWebPage\index.htm";
        [TestMethod]
        public void MusicRecordWeb_ShouldReturnEntireList()
        {
            using (IWebDriver driver = new ChromeDriver(driverLocation))
            {
                // Arrange
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl(WebPageFile);

                string title = driver.Title;

                Assert.AreEqual(title, "Music web page");

                IWebElement ButtonElement = driver.FindElement(By.Id("ButtonId"));

                ButtonElement.Click();

                IWebElement MusicList = wait.Until(d => d.FindElement(By.Id("MusicList")));

                Assert.IsTrue(MusicList.Text.Contains("eminem"));

            }
        }
    }
}
