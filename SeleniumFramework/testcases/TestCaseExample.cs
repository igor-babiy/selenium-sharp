using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumFramework.BuisnessLogic.TestCase;
using SeleniumFramework.Core.Exceptions;
using SeleniumFramework.Core.Framework;


namespace SeleniumFramework.Testcases
{
    class TestCaseExample : TestCaseBase
    {
        //Define variables
        Browser browser;

        //Initialize variables
        protected override void init()
        {
            browser = new Browser();
        }

        //Write test steps here
        protected override void test()
        {
            browser.OpenUrl("http://eng1.trimbleconnect.com/connect/login");         // open site url
            browser.WaitFor(1);                          // wait for 1 second
            browser.TypeText(By.Name("j_username"), "rnaber");  // type text "google" in serch field with id "gbqfq"
            browser.TypeText(By.Name("j_password"), "abcdefg");
            browser.WaitFor(1);
            browser.Click(By.Id("submit"));               // click by element with id "gbqfb"
            browser.GetScreenshot();
            browser.WaitFor(5);
        }

        //Test finalization
        // use this to free/delete variables
        protected override void finalize()
        {
            browser.Close();
            
        }

    }
}
