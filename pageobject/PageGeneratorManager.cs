using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Selenium_Sample.pagefactory;

namespace Selenium_Sample.pageobject
{
    class PageGeneratorManager
    {
        
        public static HomePageObject GetHomePage(IWebDriver driver)
        {
            return new HomePageObject (driver);
        }
        public static LoginPageObject GetLoginPage(IWebDriver driver)
        {
            return new LoginPageObject(driver);
        }
        public static NewAccountPageObject GetNewAccountPage(IWebDriver driver)
        {
            return new NewAccountPageObject(driver);
        }
        public static NewCustomerPageObject GetNewCustomerPage(IWebDriver driver)
        {
            return new NewCustomerPageObject(driver);
        }
        public static Lotte Lotte(IWebDriver driver)
        {
            return new Lotte(driver);
        }
        public static NewCustomerPageFactory GetNewCustomerPageFactory(IWebDriver driver)
        {
            return new NewCustomerPageFactory(driver);
        }
    }
}
