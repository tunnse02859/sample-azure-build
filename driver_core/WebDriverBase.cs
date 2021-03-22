using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Selenium_Sample.utilities;
using Selenium_Sample.reporter;


namespace Selenium_Sample.driver_core
{
    public class WebDriverBase
    {
        public IWebDriver driver;
        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public IWebElement FindElementByXpath(string locator)
        {
            return driver.FindElement(ByXpath(locator));
        }

        public IList<IWebElement> FindElementsByXpath(String locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public void Click(IWebElement e)
        {
            try
            {
                e.Click();
                HtmlReporter.Pass("Clicked to element [" + e.ToString() + "]");
            }
            catch (Exception ex)
            {
                string screenshot = TakeScreenshot(driver);
                HtmlReporter.Fail("Could not click to element [" + e.ToString() + "]", ex.ToString(), screenshot);
                throw ex;
            }
        }

        public void SendKeys_(IWebElement e, string key)
        {
            try
            {
                e.SendKeys(key);
                HtmlReporter.Pass("Sent to element [" + e.ToString() + "] keys: " + key);
            }
            catch (Exception ex)
            {
                string screenshot = TakeScreenshot(driver);
                HtmlReporter.Fail("Could not sendkeys to element [" + e.ToString() + "]", ex.ToString(), screenshot);
                throw ex;
            }
        }

        public void ClickToElement(String locator)
        {
            try
            {
                driver.FindElement(ByXpath(locator)).Click();
                HtmlReporter.Pass("Clicked to element [" + locator.ToString() + "]");
            }
            catch (Exception ex)
            {
                string screenshot = TakeScreenshot(driver);
                HtmlReporter.Fail("Could not click to element [" + locator.ToString() + "]", ex.ToString(), screenshot);
                throw ex;
            }
        }

        public void SendKeyToElement(string locator, string value)
        {
            try
            {
                HtmlReporter.Pass("Sent to element [" + locator.ToString() + "] keys: " + value);
                driver.FindElement(ByXpath(locator)).Clear();
                driver.FindElement(ByXpath(locator)).SendKeys(value);
            }
            catch (Exception ex)
            {
                string screenshot = TakeScreenshot(driver);
                HtmlReporter.Fail("Could not send to element [" + locator.ToString() + "] keys: " + value, ex.ToString(), screenshot);
                throw ex;
            }
        }

        public void WaitForElementVisible(string locator)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longtimeout));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByXpath(locator)));
        }

        public void WaitForElementClickable(string locator)
        {
            try
            {
                explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longtimeout));
                explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByXpath(locator)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SleepInSeconds(int time)
        {
            try
            {
                Thread.Sleep(time);
            }
            catch (ThreadInterruptedException e)
            {
                e.StackTrace.ToString();
            }
        }

        public String GetElementText(String locator)
        {
            return driver.FindElement(ByXpath(locator)).Text;
        }

        public bool IsElementDisplayed(string locator)
        {
            try
            {
                element = FindElementByXpath(locator);
                return element.Displayed;
            }
            catch (NoSuchElementException ex)
            {
                ex.StackTrace.ToString();
                return false;
            }
        }

        public static string TakeScreenshot(IWebDriver driver)
        {
            string path = Common.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
        // private SelectElement select;
        // private IJavaScriptExecutor js;
        private IWebElement element;
        IList<IWebElement> elements;
        private WebDriverWait explicitWait;
        private readonly long longtimeout = 30;
        // private readonly long shorttimeout = 5;
    }
}