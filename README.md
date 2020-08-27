## Zoopla Property App

This is readme file for ZooplaPropertyApp repository.

### ZPG Ltd
#### Description
It focuses on providing users with access to information such as sold house prices, area trends & statistics and current value estimates for domestic and commercial properties in the UK.

#### Prerequisite
1. Microsoft Visual Studio
2. Browser like Chrome, Firefox and IE
3. Good internet connection

#### IDE used
* Microsoft Visual Studio 2019

#### Programming language
* C#

#### Used frameworks
1. .NET framework
2. Selenium framework
3. NUnit framework
4. Data Driven framework

#### Packages
* DotNetSeleniumExtras.PageObjects- For Page Factory
* ExtentReports- To generate Test Reports 
* Newtonsoft.Json- To access data from json file
* NUnit- test result in readable format and to use annotations such as SetUp, OneTimeSetUp, Test, TearDown and OneTimeTearDown
* NUnit3Adapter- Running test cases in Visual Studio
* Selenium.WebDriver- .Net Binding for selenium webdriver API
* Selenium.WebDriver.ChromeDriver- Driver for Google Chrome
* DNSClient- In this project it is uesd to get Host name
* Log4Net-Logging Test steps to log file

#### Test Scenario's
  ##### Positive Test Scenario's
    1. Signin to Zoopla App
    2. Search location of property
    3. Print list of properties shown for that particuar location in sorted order.
    4. Select number 5th property (Which is dynamic)
    5. Click on agents link, it will navigate to agents page and check that the propertise listed their belongs to the same mentioned agent on the page.
    
  ##### Negative Test Scenario's
    1. Providing blank email and password field and hitting signin button and verfiying with error message is displayed or not
    2. Providing only email in field and hitting signin button and verfiying with error message is displayed or not
    3. Providing only password in field and hitting signin button and verfiying with error message is displayed or not
    4. Providing both invalid email and password field and hitting signin button and verfiying with error message is displayed or not
