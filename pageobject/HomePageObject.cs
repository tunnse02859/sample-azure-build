using OpenQA.Selenium;
using Selenium_Sample.driver_core;
using Selenium_Sample.interfaces;
using Selenium_Sample.pagefactory;

namespace Selenium_Sample.pageobject
{
    public class HomePageObject : WebDriverBase
    {
        public HomePageObject(IWebDriver driver) : base()
        {
            this.driver = driver;
        }

        public string GetWelcomeMessage()
        {
            return driver.Title;
        }

        public bool IsActive()
        {
            return driver.Title.Equals("Guru99 Bank Manager HomePage");
        }

        internal bool IsWelcomeMessageDisplayed()
        {
            return IsElementDisplayed(HomePageUI.WELCOME_MESSAGE_TEXT);
        }

        internal NewCustomerPageFactory ClickToNewCustomerMenu()
        {
            WaitForElementClickable(HomePageUI.NEW_CUSTOMERS_LINK);
            ClickToElement(HomePageUI.NEW_CUSTOMERS_LINK);
            return PageGeneratorManager.GetNewCustomerPageFactory(driver);
        }
    }
}