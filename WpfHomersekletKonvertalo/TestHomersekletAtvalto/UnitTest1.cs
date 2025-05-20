using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;

namespace TestHomersekletAtvalto
{
    public class Tests
    {
        protected const string WinAppDriverUrl = "http://127.0.0.1:4723/";
        private const string WPFProgramId = @"D:\rud-2\kodtarak_2024\13d_asztali_24-25\WpfHomersekletKonvertalo\WpfHomersekletKonvertalo\bin\Debug\net8.0-windows\WpfHomersekletKonvertalo.exe";
        private const string WPFProgramPath = @"D:\rud-2\kodtarak_2024\13d_asztali_24-25\WpfHomersekletKonvertalo\WpfHomersekletKonvertalo\bin\Debug\net8.0-windows\";

        protected static WindowsDriver<WindowsElement> driver;

        protected static ExtentReports extReport;
        protected static ExtentTest exTest;

        [OneTimeSetUp]
        public static void ReportSetup()
        {
            extReport= new ExtentReports();
            extReport.AddSystemInfo("H�m�rs�klet �tv�lt�s teszt","Automatiz�lt teszt");
            extReport.AddSystemInfo("Tesztel�", "XYQ");
            ExtentSparkReporter reporter = new ExtentSparkReporter(WPFProgramPath+"result.html");
            extReport.AttachReporter(reporter);
            reporter.Config.DocumentTitle = "H�m�rs�klet konvert�l�s teszt riport";
            reporter.Config.ReportName = "H�m�rs�klet konvert�l�s";
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            if (driver == null)
            {
                var appiumOptions= new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WPFProgramId);
                appiumOptions.AddAdditionalCapability("devicename", "WindowsPC");
                driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl),appiumOptions);
            }   
        }

        [Test]
        [TestCase(27.77777777,82)]
        [TestCase(31,87.8)]
        [TestCase(39, 87.8)]
        [TestCase(46, 87.8)]
        public void CelsiusToFahrenheitTest(double celsius,double elvart)
        {
            exTest = extReport.CreateTest("Celsius �tv�lt�sa Fahrenheitre");

            var homerseklet = driver.FindElementByAccessibilityId("textboxHomersekletErtek");
            homerseklet.Clear();
            driver.FindElementByAccessibilityId("radioFahrenheitKivalaszt").Click();
            homerseklet.SendKeys(celsius.ToString());
            driver.FindElementByAccessibilityId("buttonKonvertalas").Click();
            var eredmeny=driver.FindElementByAccessibilityId("textblockEredmeny");

            Assert.AreEqual(elvart, Convert.ToDouble(eredmeny.Text),0.0005);
            exTest.Log(Status.Pass,"Celsius �tv�lt�sa Fahrenheitre Ok.");
        }

        //Tesztmet�dusok ide

        //Minden tesztmet�dus ut�n le fog futni a TearDown-al megjel�lt met�dus
        [TearDown]
        public static void CloseReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            var errormsg = TestContext.CurrentContext.Result.Message;

            if (status==TestStatus.Failed)
            {
                ITakesScreenshot shot = (ITakesScreenshot)driver;
                var be=TestContext.CurrentContext.Test.Arguments[0];
                var elvart=TestContext.CurrentContext.Test.Arguments[1];
                var filename = $"result_{be}_{elvart}.png";

                Screenshot screenshot = shot.GetScreenshot();
                screenshot.SaveAsFile(WPFProgramPath+ filename,ScreenshotImageFormat.Png);

                exTest.Log(Status.Fail,stacktrace+","+errormsg);
                exTest.Log(Status.Fail, "K�perny�");
                exTest.AddScreenCaptureFromPath(filename);
            }


            extReport.Flush();
        }

        //A legutols� tesztmet�dus ut�n fut le
        [OneTimeTearDown]
        public void Endtest()
        {
            driver.Close();
            driver.Quit();
        }
    }
}