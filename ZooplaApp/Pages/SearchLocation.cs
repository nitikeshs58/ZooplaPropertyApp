using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ZooplaApp.Pages
{
    public class SearchLocation
    {
        // Declaration of IWebDriver
        public IWebDriver driver;

        // Constructor with driver parameter
        public SearchLocation(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//body/div/div/div/div/div/div/div/form/div/div/div/input[1]")]
        public IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='search-top']//div[@class='search-input-wrapper']")]
        public IWebElement rightInput;

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--primary']")]
        public IWebElement searchButton;
        
        [FindsBy(How =How.XPath,Using = "//body/div/div/div/ul/li")]
        public IWebElement printProperties;

        /// <summary>
        /// To search particular location related property like 'London'
        /// </summary>
        /// <param name="Location"></param>
        public void SearchLocationMethod(string Location)
        {
            Thread.Sleep(5000);
            searchButton.Click();
            Thread.Sleep(2000);
            searchInput.SendKeys(Location);
            Thread.Sleep(3000);
            rightInput.Click();
            Thread.Sleep(2000);
            searchButton.Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Print all properties belonging to that place only as per search
        /// </summary>
        public void PrintSearch()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            IList<IWebElement> printTitles = driver.FindElements(By.XPath("//a[@class='listing-results-price text-price']"));
            Thread.Sleep(2000);

            for (int i = 0; i < printTitles.Count; i++)
            {
                dict.Add( i,printTitles[i].Text);
            }
           
            foreach (KeyValuePair<int, string> kvp in dict.OrderByDescending(Key => Key.Value))
            {
               Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }
    }
}