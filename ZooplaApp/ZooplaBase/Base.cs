using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net.NetworkInformation;
using ZooplaApp.Credencials;
using ZooplaApp.CustomException;
using ZooplaApp.Screenshots;

namespace ZooplaApp.ZooplaBase
{
    [TestFixture]
    public class Base
    {
        public IWebDriver driver = new ChromeDriver();
        public static ExtentReports extent = new ExtentReports();
        public static ExtentTest test;

        /// <summary>
        /// Once to perform setup before any child tests runs
        /// Launching chrome browser and providing URL to address bar
        /// </summary>
        [OneTimeSetUp]
        public void Initilize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\Admin\source\repos\ZooplaApp\ZooplaApp\ExtentReports\ZooplaIndex.html");
            extent.AttachReporter(htmlReporter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = JsonData.data.WebsiteUrl;
        }

        /// <summary>
        /// Ping : Check the availability of web server or any local computer
        /// host : Hostname or Address
        /// ByteBuffer : transferring bytes from source to destination
        /// timeout : timeout time
        /// PingOptions : Controls how the Ping data packets are transmitted
        /// gets the buffer of data received in an internet contol Message Protocl(ICMP) echo reply message
        /// PingReply : Echo message
        /// </summary>
        [SetUp]
        public void CheckInternet()
        {
            try
            {
                Ping newPing = new Ping();
                string host = "zoopla.co";
                byte[] buffer = new byte[32];
                int timeout = 2000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = newPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    Console.Out.WriteLine("Internet connection is available .");
                }
                else
                {
                    Console.Out.WriteLine("No internet connection available");
                }
            }
            catch (Exception)
            {
                throw new CustomExceptions("Error in internet connection", CustomException.ExceptionType.NO_INTERNET_CONNECTIONS);
            }
        }

        /// <summary>
        /// TearDown method
        /// Executes after every test is runned and check whether test passes or fail
        /// And AddScreenCaptureFromPath
        /// </summary>
        [TearDown]
        public void CloseTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            if(TestContext.CurrentContext.Result.Outcome.Status==TestStatus.Passed)
            {
                test.Log(Status.Pass, "Test Sucessful");
                test.AddScreenCaptureFromPath(TakeScreenshot.TakeScreenshotMethod(driver, "SearchLocationTestMethod"));
                test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                test.Log(Status.Fail, "Test Failed");
                test.AddScreenCaptureFromPath(TakeScreenshot.TakeScreenshotMethod(driver, "SearchLocationTestMethod"));
                test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
            }
            // Closes all the connections to the extend reports
            extent.Flush();
        }
    }
}