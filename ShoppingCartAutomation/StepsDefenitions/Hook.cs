using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using ShoppingCartAutomation.Common;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace ShoppingCartAutomation.Steps
{
    [Binding]
    public class Hook
    {
        public static ThreadLocal<IWebDriver> webdriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetWebDriver()
        {
            return webdriver.Value;
        }

        public static void SetWebDriver(IWebDriver driver)
        {
            webdriver.Value = driver;
        }

        [BeforeScenario]
        public static void Setup()
        {
            endDrivers();
            IWebDriver driver;
            if (ConfigurationManager.AppSettings["browser"].ToUpperInvariant() == Constants.IEBrowser)
            {
                var optionsIE = new InternetExplorerOptions { EnsureCleanSession = true };
                optionsIE.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                optionsIE.IgnoreZoomLevel = true;
                optionsIE.EnableNativeEvents = true;
                optionsIE.EnablePersistentHover = true;
                optionsIE.RequireWindowFocus = true;
                driver = new InternetExplorerDriver(optionsIE);
            }
            else
            {
                driver = new ChromeDriver();
            }
            driver.Manage().Cookies.DeleteAllCookies();
            SetWebDriver(driver);
            string appURL = ConfigurationManager.AppSettings["url"];
            driver.Navigate().GoToUrl(appURL);
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.Wait);

        }

        [AfterScenario]
        public static void Cleanup()
        {
            GetWebDriver().Quit();
            endDrivers();
        }

        public static void endDrivers()
        {
            Process KillScriptProcess = new Process();
            string location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + @"\BrowserKillScript.bat";
            KillScriptProcess.StartInfo.FileName = location;
            KillScriptProcess.Start();
            KillScriptProcess.WaitForExit();
            Console.WriteLine("\t\t BrowserKillScript has been Executed!!");
        }
    }
}
