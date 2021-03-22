using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium_Sample.driver_core
{
    public class WebDriverManager_
    {
        private IWebDriver driver;

		public IWebDriver CreateBrowserDriver(String Value, String Url)
		{
			if (Value.SequenceEqual("firefox"))
			{
				new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
				driver = new FirefoxDriver();
			}
			else if (Value.SequenceEqual("chrome"))
			{
				new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
				driver = new ChromeDriver();
			}
			else if (Value.SequenceEqual("safari"))
			{
				new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
				driver = new SafariDriver();
			}
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Navigate().GoToUrl(Url);
			return driver;
		}
    }
}