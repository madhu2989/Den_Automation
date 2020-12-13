using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace Sel5
{
    public class program
    {

        IWebDriver driver = new ChromeDriver();


        public void DenLogin()
        {
            driver.Navigate().GoToUrl("http://120.89.72.222/karnataka/default.aspx");
            driver.Manage().Window.Maximize();
            
            string username = "BL2718_shantha";
            string password = "1441";

            IWebElement usernameTxtBox = driver.FindElement(By.Id("_TxtUsername"));
            usernameTxtBox.SendKeys(username);

            IWebElement passwordTxtBox = driver.FindElement(By.Id("_TxtPassword"));
            passwordTxtBox.SendKeys(password);


            IWebElement loginButton = driver.FindElement(By.Id("_BtnLogin"));
            loginButton.Click();
            Thread.Sleep(5000);
        }

        public void Modify(string VcNo)
        {

            driver.Navigate().GoToUrl("http://120.89.72.222/karnataka/assignservices.aspx");
            IWebElement VcNoTxtBox = driver.FindElement(By.Id("txtVCNO"));
            VcNoTxtBox.SendKeys(VcNo);

            IWebElement GoBtn = driver.FindElement(By.Id("_GoBtn"));
            GoBtn.Click();
            

            Thread.Sleep(5000);
            //driver.Close();

        }

        public void ViewCustomer(string VcNo)
        {
            try
            {
                driver.Navigate().GoToUrl("http://120.89.72.222/karnataka/dashboard.aspx");

                IWebElement dropDown = driver.FindElement(By.Id("FilterDropDownList"));
                var dropdownBox = new SelectElement(dropDown);
                dropdownBox.SelectByValue("VCNumber");

                //dropDown.FindElement(By.Name("VC No")).Click();

                IWebElement VcNoTxtBox = driver.FindElement(By.Id("SearchTextBox"));
                string Num = Convert.ToString(VcNo);
                VcNoTxtBox.SendKeys(Num);

                IWebElement GoBtn = driver.FindElement(By.Id("_GoBtn"));
                GoBtn.Click();

                IWebElement ViewDetailsClick = driver.FindElement(By.ClassName("bt-content"));
                ViewDetailsClick.Click();

                Thread.Sleep(5000);
            }
            catch (Exception)
            {
                
                throw;
            }
            


        }

        public void LogoutDen()
        {

            IWebElement dropDownlogout = driver.FindElement(By.ClassName("clearfix"));
            IWebElement dropDownlogoutbtn = driver.FindElement(By.XPath("//*[@id='form1']/section/section/div[2]/div/div[2]/ul/li/ul/li[2]/a/i"));
            dropDownlogoutbtn.Click();
            //var dropdownBoxlogout = new SelectElement(dropDownlogout);
            //dropdownBoxlogout.SelectByText("Logout");
        }


        public void Execute()
        {
            driver.Navigate().GoToUrl("https://www.makemytrip.com");


            driver.Manage().Window.Maximize();

           // IWebElement element = driver.FindElement(By.Id("hp-widget__sfrom"));
            
            IWebElement element1 = driver.FindElement(By.Id("hp-widget__sTo"));
            element1.SendKeys("Mangalore");
            element1.Click();
            Thread.Sleep(2000);

            var dateInput = driver.FindElement(By.Id("hp-widget__depart"));
            dateInput.Click();

            var NextMonth = driver.FindElement(By.CssSelector("span[class='ui-icon ui-icon-circle-triangle-e']"));
            Thread.Sleep(3000);
            var days = driver.FindElements(By.CssSelector("a[class='ui-state-default']"));

            var select = new Actions(driver);
            select.Click(NextMonth).Build().Perform();
            Thread.Sleep(3000);
            days = driver.FindElements(By.CssSelector("a[class='ui-state-default']"));
            Console.WriteLine(days);
            select.Click(days[3]).Build().Perform();
            //driver.FindElements(By.XPath("//*[@id='dp1536257299860']/div/div[1]/table/tbody/tr[2]/td[6]/a"));
            //element.SendKeys("mang");
            Thread.Sleep(5000);

        }

        public void ExecuteKsrtcApp()
        {
            driver.Navigate().GoToUrl("http://www.ksrtc.in");
            driver.Manage().Window.Maximize();
            var page = driver.PageSource.Except("lll");
            var search = driver.PageSource.Contains("date");
            IWebElement body = driver.FindElement(By.ClassName("base"));
            body.SendKeys(Keys.Control + "f");
            body.SendKeys("karnataka");
            body.SendKeys(Keys.Enter);
            

            //
            //Actions act = new Actions(driver);
            //act.KeyDown(Keys.Space).Perform();
            
           //var from = driver.FindElement(By.Id("fromPlaceName"));
           //from.SendKeys("shivamo");
           //from.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            //IWebElement dstTo = driver.FindElement(By.Id("toPlaceName"));
            //dstTo.SendKeys("Banga");
            //dstTo.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            var txtBoxDate = driver.FindElement(By.Name("txtJourneyDate"));

            //var NextMonth = 

        }
    }
}