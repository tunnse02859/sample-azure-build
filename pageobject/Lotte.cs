using OpenQA.Selenium;
using Selenium_Sample.driver_core;
using Selenium_Sample.interfaces;

namespace Selenium_Sample.pageobject
{
    public class Lotte : WebDriverBase
    {
        public Lotte(IWebDriver driver) : base()
        {
            this.driver = driver;
            //PageFactory.InitElements(driver.getDriver(), this);
        }
        internal void ClickMenuBtn()
        {
            // WaitForElementClickable(driver, LotteUI.MENU_BTN);
            ClickToElement(LotteUI.MENU_BTN);
        }

        internal void ClickBurgerBtn()
        {
            // WaitForElementClickable(driver, LotteUI.BURGER_BTN);
            ClickToElement(LotteUI.BURGER_BTN);
        }
       
        // public void inputUserName(string userName)
        // {
        //     //driver.SendKeys(tf_username,userName);
        //     driver.SendKeys(tf_userName,userName);
        // }

        // public void inputPassword(string password)
        // {
        //     driver.SendKeys(tf_password,password);
        // }

        // public void clickLogin()
        // {
        //     driver.Click(bt_login);
        // }

        // public void doLogin(string userName, string password)
        // {
        //     inputUserName(userName);
        //     inputPassword(password);
        //     clickLogin();
        // }
    }
}