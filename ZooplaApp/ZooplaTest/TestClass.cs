// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Threading;
using NUnit.Framework;
using ZooplaApp.Credencials;
using ZooplaApp.MailReport;
using ZooplaApp.Pages;
using ZooplaApp.ZooplaBase;

namespace ZooplaApp
{
    [TestFixture]
    [Parallelizable]
    public class TestClass : Base
    {
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test,Order(1)]
        public void SigninTestMethod()
        {
            try
            {
                log.Info("SignIn test Started.");
                Signin signin = new Signin(driver);
                signin.SigninMethod(JsonData.data.UserEmail, JsonData.data.Password);
                Assert.AreEqual(JsonData.data.WebsiteTitle, driver.Title);
                log.Info("SignIn test Ended.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [Test, Order(2)]
        public void SearchLocationTestMethod()
        {
            try
            {
                log.Info("SearchLocationTestMethod test Started.");
                Thread.Sleep(3000);
                SearchLocation searchLocation = new SearchLocation(driver);
                searchLocation.SearchLocationMethod(JsonData.data.PropertySearchName);
                Assert.AreEqual(JsonData.data.PropertyLocationTitle, driver.Title);
                log.Info("SearchLocationTestMethod test Ended.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [Test, Order(3)]
        public void PrintTitleTestMethod()
        {
            try
            {
                log.Info("PrintTitleTestMethod test Started.");
                Thread.Sleep(3000);
                SearchLocation searchLocation = new SearchLocation(driver);
                searchLocation.PrintSearch();
                log.Info("PrintTitleTestMethod test Ended.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [Test, Order(4)]
        public void PropertySelectionTestMethod()
        {
            try
            {
                log.Info("PropertySelectionTestMethod test Started.");
                Thread.Sleep(3000);
                PropertySelection propertySelection = new PropertySelection(driver);
                propertySelection.PropertySelectionMethod();
                log.Info("PropertySelectionTestMethod test Ended.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [Test, Order(5)]
        public void ParticularAgentPropertyTestMethod()
        {
            try
            {
                log.Info("ParticularAgentPropertyTestMethod test Started.");
                Thread.Sleep(3000);
                PropertySelection popertySelection = new PropertySelection(driver);
                var expectedAgentsPropertyName = popertySelection.AgentSelectionMethod();
                Assert.IsTrue(expectedAgentsPropertyName);
                log.Info("ParticularAgentPropertyTestMethod test Ended.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [OneTimeTearDown]
        public void QuitBrowser()
        {
            Thread.Sleep(3000);
            driver.Quit();
            SendMail.SendEmailMethod();
        }
    }
}
