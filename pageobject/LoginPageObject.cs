using OpenQA.Selenium;
using Selenium_Sample.driver_core;
using Selenium_Sample.interfaces;

namespace Selenium_Sample.pageobject
{
    public class LoginPageObject : WebDriverBase
    {
        public LoginPageObject(IWebDriver driver) : base()
        {
            this.driver = driver;
        }
        internal void InputUserIdTextbox(string value)
        {
            WaitForElementVisible(LoginPageUI.USERID_TEXTBOX);
            SendKeyToElement(LoginPageUI.USERID_TEXTBOX, value);
        }

        internal void InputPasswordTextbox(string value)
        {
            WaitForElementVisible(LoginPageUI.PASSWORD_TEXTBOX);
            SendKeyToElement(LoginPageUI.PASSWORD_TEXTBOX, value);
        }

        internal string ClickToLoginButton()
        {
            WaitForElementClickable(LoginPageUI.LOGIN_BUTTON);
            ClickToElement(LoginPageUI.LOGIN_BUTTON);
            SleepInSeconds(3000);
            var alert = driver.SwitchTo().Alert();
            return alert.Text;
        }

        internal HomePageObject ClickLoginButton()
        {
            WaitForElementClickable(LoginPageUI.LOGIN_BUTTON);
            ClickToElement(LoginPageUI.LOGIN_BUTTON);
            return PageGeneratorManager.GetHomePage(driver);
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