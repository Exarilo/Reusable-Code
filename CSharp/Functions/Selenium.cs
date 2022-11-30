using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cookie = System.Net.Cookie;

namespace MyNamespace
{
    class Program
    {

        static IWebDriver driver;
        static void Main(string[] args)
        {
            string url = (@"urlToFind);
            ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService(System.AppContext.BaseDirectory + "Driver\\");
            chromeDriverService.HideCommandPromptWindow = true;
            driver = new ChromeDriver(chromeDriverService);
        }

        public static void DoCaptcha()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var capatcha = wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@title='reCAPTCHA']")));
            ClickByClassName("recaptcha-checkbox-border");
        }

        public static void ClickByClassName(string element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement bt = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(element)));
            (driver as IJavaScriptExecutor).ExecuteScript("arguments[0].click();", bt);
        }

        public static void SendByXpath(string textArea,string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement area = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(textArea)));
            (driver as IJavaScriptExecutor).ExecuteScript($"arguments[0].value='{value+" "}';", area);
            area.SendKeys(Keys.Backspace);
        }

    }
}
