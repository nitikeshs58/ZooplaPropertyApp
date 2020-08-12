using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ZooplaApp.Pages
{
    public class PropertySelection
    {
        // Declaration of IWebDriver
        public IWebDriver driver;

        // Constructor PropertySelection 
        public PropertySelection(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//p[@class='ui-agent__link ui-agent__text']//a[@class='ui-link']")]
        public IWebElement searchedAgentsLink;

        [FindsBy(How = How.XPath, Using = "//p[@class='top-half listing-results-marketed']//span")]
        public IWebElement agentsHeader;

        [FindsBy(How = How.XPath, Using = "//div[@id='breadcrumbs']//strong")]
        public IWebElement agentsName;
        
        /// <summary>
        /// To select 5th number property from displayed list
        /// </summary>
        public void PropertySelectionMethod()
        {
            Thread.Sleep(2000);
            IList<IWebElement> propertyNumber = driver.FindElements(By.XPath("//a[@class='photo-hover']"));
            Thread.Sleep(4000);
            propertyNumber[5].Click();
        }

        /// <summary>
        /// Click on particluar agent
        /// And checking all properties belongs to the same Agent
        /// </summary>
        /// <returns></returns>
        public bool AgentSelectionMethod()
        {
            bool titleMatch = false;
            Thread.Sleep(8000);
            searchedAgentsLink.Click();
            Thread.Sleep(4000);
            string actualName = agentsName.Text;
            Dictionary<int, string> dict = new Dictionary<int, string>();
            IList<IWebElement> agentPropertyNames = driver.FindElements(By.XPath("//p[@class='top-half listing-results-marketed']//span"));
            Thread.Sleep(2000);
           
            for (int i = 0; i < agentPropertyNames.Count; i++)
            {
                dict.Add(i, agentPropertyNames[i].Text);
            }

            foreach (KeyValuePair<int, string> kvp in dict)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            
            foreach (KeyValuePair<int, string> kvp in dict)
            {
                if(kvp.Value.Contains(actualName))
                {
                    titleMatch = true;
                }
            }
            return titleMatch;
        }
    }
}
