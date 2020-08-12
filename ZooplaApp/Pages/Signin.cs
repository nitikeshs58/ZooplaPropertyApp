using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace ZooplaApp.Pages
{
    public class Signin
    {
        // Declartion of IWebDriver
        public IWebDriver driver;

        // Constructor signin with driver as parameter
        public Signin(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='ui-button-secondary']")]
        public IWebElement cookiePreferances;

        [FindsBy(How = How.XPath, Using = "//fieldset[@class='form__group']//input[1]")]
        public IWebElement userEmail;

        [FindsBy(How = How.XPath, Using = "//input[2]")]
        public IWebElement password;

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--primary button--wide']")]
        public IWebElement signinButton;

        /// <summary>
        /// Sign with valid Email and password
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        public void SigninMethod(string Email, string Password)
        {
            Thread.Sleep(5000);
            cookiePreferances.Click();
            Thread.Sleep(1000);
            userEmail.SendKeys(Email);
            Thread.Sleep(1000);
            password.SendKeys(Password);
            Thread.Sleep(1000);
            signinButton.Click();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Negative test
        /// Providing Email and password with Null values
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool BlankEmailPassword(string Email, string Password)
        {
            Thread.Sleep(3000);
            cookiePreferances.Click();
            Thread.Sleep(2000);
            userEmail.SendKeys(Email);
            Thread.Sleep(1000);
            password.SendKeys(Password);
            Thread.Sleep(1000);
            signinButton.Click();
            Thread.Sleep(1000); 
            bool emailCheck=(driver.FindElement(By.XPath("//span[@title='Please provide a full, valid email address e.g. johnsmith@gmail.com']"))).Displayed;
            bool passcheck = (driver.FindElement(By.XPath("//span[@title='Please provide a valid password (Minimum eight characters)']"))).Displayed;
            Thread.Sleep(4000);
            if(emailCheck==true && passcheck==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Negative test
        /// Providing Invalid Email and Valid Password
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool InvalidEmail(string Email, string Password)
        {
            Thread.Sleep(2000);
            userEmail.Clear();
            Thread.Sleep(1000);
            userEmail.SendKeys(Email);
            Thread.Sleep(1000);
            userEmail.Clear(); 
            Thread.Sleep(1000);
            password.SendKeys(Password);
            Thread.Sleep(1000);
            signinButton.Click();
            Thread.Sleep(1000);
            bool emailCheck = (driver.FindElement(By.XPath("//span[@title='Please provide a full, valid email address e.g. johnsmith@gmail.com']"))).Displayed;
            Thread.Sleep(4000);
            if (emailCheck == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Negative test
        /// Providing Valid Email and Invalid Password
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool InvalidPassword(string Email, string Password)
        {
            Thread.Sleep(2000);
            userEmail.Clear();
            Thread.Sleep(1000);
            userEmail.SendKeys(Email);
            Thread.Sleep(1000);
            userEmail.Clear();
            Thread.Sleep(1000);
            password.SendKeys(Password);
            Thread.Sleep(1000);
            signinButton.Click();
            bool passcheck = (driver.FindElement(By.XPath("//span[@title='Please provide a valid password (Minimum eight characters)']"))).Displayed;
            Thread.Sleep(4000);
            if (passcheck == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Negative test
        /// Providing Invalid Email and Password
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool InvalidEmailPassword(string Email, string Password)
        {
            Thread.Sleep(2000);
            userEmail.Clear();
            Thread.Sleep(1000);
            userEmail.SendKeys(Email);
            Thread.Sleep(1000);
            userEmail.Clear();
            Thread.Sleep(1000);
            password.SendKeys(Password);
            Thread.Sleep(1000);
            signinButton.Click();
            Thread.Sleep(1000);
            bool emailCheck = (driver.FindElement(By.XPath("//span[@title='Please provide a full, valid email address e.g. johnsmith@gmail.com']"))).Displayed;
            bool passcheck = (driver.FindElement(By.XPath("//span[@title='Please provide a valid password (Minimum eight characters)']"))).Displayed;
            Thread.Sleep(4000);
            if (emailCheck == true && passcheck == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
