using NUnit.Framework;
using System;
using System.Threading;
using ZooplaApp.Credencials;
using ZooplaApp.MailReport;
using ZooplaApp.Pages;
using ZooplaApp.ZooplaBase;

namespace ZooplaApp.ZooplaTest
{
    [TestFixture]
    [Parallelizable]
    public class NegativeTests : Base
    {
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test,Order(1)]
        public void BlankEmailPasswordSigninTestMethod()
        {
            try
            {
                log.Info("BlankEmailPasswordSigninTestMethod test Started.");
                Signin signin = new Signin(driver);
                bool NullCheck=signin.BlankEmailPassword(JsonData.data.NullValue, JsonData.data.NullValue);
                Assert.IsTrue(NullCheck);
                log.Info("BlankEmailPasswordSigninTestMethod test Ended.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [Test, Order(2)]
        public void InvalidEmailSigninTestMethod()
        {
            try
            {
                log.Info("InvalidEmailSigninTestMethod test Started.");
                Signin signin = new Signin(driver);
                bool emailCheck=signin.InvalidEmail(JsonData.data.InvalidEmail, JsonData.data.Password);
                Assert.IsTrue(emailCheck);
                log.Info("InvalidEmailSigninTestMethod test Ended.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [Test, Order(3)]
        public void InvalidPasswordSigninTestMethod()
        {
            try
            {
                log.Info("InvalidPasswordSigninTestMethod test Started.");
                Thread.Sleep(3000);
                Signin signin = new Signin(driver);
                bool passCheck = signin.InvalidPassword(JsonData.data.UserEmail, JsonData.data.InvalidPassword);
                Assert.IsTrue(passCheck);
                log.Info("InvalidPasswordSigninTestMethod test Ended.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [Test, Order(4)]
        public void InvalidEmailPasswordSigninTestMethod()
        {
            try
            {
                log.Info("InvalidEmailPasswordSigninTestMethod test Started.");
                Thread.Sleep(3000);
                Signin signin = new Signin(driver);
                bool emailPassCheck=signin.InvalidEmailPassword(JsonData.data.InvalidEmail, JsonData.data.InvalidPassword);
                Assert.IsTrue(emailPassCheck);
                log.Info("InvalidEmailPasswordSigninTestMethod test Ended.");
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



