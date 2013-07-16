using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using System.Globalization;

namespace SeleniumFramework.Core.Framework
{
    class Browser
    {
        private const int ELEMENT_TIMEOUT = 30;
        private IWebDriver driver;
        private ITakesScreenshot screenshotDriver;
        private string rootPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
        
        public Browser()
        {
            Directory.CreateDirectory(Properties.Settings.Default.ScreenshotLocation);
            driver = new ChromeDriver(Properties.Settings.Default.DriversLocation);
            screenshotDriver = driver as ITakesScreenshot;
        }
        
        public Browser(string driverPath)
        {
            Directory.CreateDirectory(Properties.Settings.Default.ScreenshotLocation);
            driver = new ChromeDriver(Properties.Settings.Default.DriversLocation);
            screenshotDriver = driver as ITakesScreenshot;
        }
        
        public void OpenUrl(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            
        }

        public void Click(By by)
        {
            WaitForElement(by).Click();
        }

        public void TypeText(By by, string text)
        {
            WaitForElement(by).SendKeys(text);
        }
        
        public void WaitForTitle(string title)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ELEMENT_TIMEOUT));
            wait.Until((d) => { return d.Title.StartsWith(title); });
        }

        public IWebElement WaitForElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ELEMENT_TIMEOUT));
            return wait.Until(drv => drv.FindElement(by));
        }

        public IWebElement WaitForElement(By by, int timeOut)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(drv => drv.FindElement(by));
        }

        public bool IfElementPresent(By by)
        {
            bool result = true;
            try
            {
                WaitForElement(by);
            }
            catch { result = false; }
            return result;
        }

        public bool IfElementPresent(By by, int timeOut)
        {
            bool result = false;
            try
            {
                WaitForElement(by, timeOut);
            }
            catch { result = false; }
            return result;
        }

        public void GetScreenshot()
        {
            Screenshot screen = screenshotDriver.GetScreenshot();
            screen.SaveAsFile(Properties.Settings.Default.ScreenshotLocation + "\\" + 
                DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")) + "_[" + 
                DateTime.Now.Hour +"_"+
                DateTime.Now.Minute + "_" +
                DateTime.Now.Second +
                "].png", ImageFormat.Png);
        }

        public void WaitFor(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
