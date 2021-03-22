using Selenium_Sample.driver_core;
using Selenium_Sample.interfaces;
using Selenium_Sample.pageobject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Sample.pagefactory
{
    public class NewCustomerPageFactory : WebDriverBase
    {
        
        public NewCustomerPageFactory(IWebDriver driver) : base()
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        private IWebElement CUSTOMER_NAME_TEXTBOX_;

        [FindsBy(How = How.XPath, Using = "//input[@name='dob']")]
        private IWebElement DATE_OF_BIRTH_TEXTBOX_;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='addr']")]
        private IWebElement ADDRESS_TEXTAREA_;

        [FindsBy(How = How.XPath, Using = "//input[@name='city']")]
        private IWebElement CITY_TEXTBOX_;

        [FindsBy(How = How.XPath, Using = "//input[@name='state']")]
        private IWebElement STATE_TEXTBOX_;

        [FindsBy(How = How.XPath, Using = "//input[@name='pinno']")]
        private IWebElement PIN_TEXTBOX_;

        [FindsBy(How = How.XPath, Using = "//input[@name='telephoneno']")]
        private IWebElement MOBILE_NUMBER_TEXTBOX_;

        [FindsBy(How = How.XPath, Using = "//input[@name='emailid']")]
        private IWebElement EMAIL_TEXTBOX_;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement PASSWORD_TEXTBOX_;

        [FindsBy(How = How.XPath, Using = "//input[@name='submit']")]
        private IWebElement SUBMIT_BUTON_;

        [FindsBy(How = How.XPath, Using = "//*[@class='heading3']")]
        private IWebElement SUCCESS_MESSAGE_;

        [FindsBy(How = How.XPath, Using = "//*[text()='Customer ID']/following-sibling::td")]
        private IWebElement CUSTOMER_ID_;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'New Account')]")]
        private IWebElement NEW_ACCOUNT_MENU_;
        
        internal void InputNameTextbox(string name)
        {
            SendKeys_(CUSTOMER_NAME_TEXTBOX_, name);
        }

        internal void InputDateofBirthTextbox(string dateofBirth)
        {
            SendKeys_(DATE_OF_BIRTH_TEXTBOX_, dateofBirth.ToString().Substring(0,4));
            SendKeys_(DATE_OF_BIRTH_TEXTBOX_, Keys.Tab);
            SendKeys_(DATE_OF_BIRTH_TEXTBOX_, dateofBirth.ToString().Substring(4,4));
        }

        internal void InputCityTextbox(string city)
        {
            SendKeys_(CITY_TEXTBOX_, city);
        }

        internal void InputAddressTextarea(string address)
        {
            SendKeys_(ADDRESS_TEXTAREA_, address);
        }

        internal void InputPinTextbox(string pin)
        {
            SendKeys_(PIN_TEXTBOX_, pin);
        }

        internal void InputEmailTextbox(string email)
        {
            SendKeys_(EMAIL_TEXTBOX_, email);
        }

        internal void InputStateTextbox(string state)
        {
            SendKeys_(STATE_TEXTBOX_, state);
        }

        internal void InputPasswordTextbox(string pass)
        {
            SendKeys_(PASSWORD_TEXTBOX_, pass);
        }

        internal void ClickSubmitButton()
        {
            ClickToElement("//input[@type='submit']");
        }

        internal NewAccountPageObject ClickNewAccountMenu()
        {
            // WaitForElementClickable(driver, NEW_ACCOUNT_MENU_);
            NEW_ACCOUNT_MENU_.Click();
            return PageGeneratorManager.GetNewAccountPage(driver);
        }

        internal string GetCustomerId()
        {
            // WaitForElementVisible(driver, CUSTOMER_ID_);
            return CUSTOMER_ID_.Text;
        }

        internal string GetSuccessMessage()
        {
            // WaitForElementVisible(driver, SUCCESS_MESSAGE);
            return SUCCESS_MESSAGE_.Text;
        }

        internal void InputMobileNumberTextbox(string phone)
        {
            // WaitForElementVisible(driver, MOBILE_NUMBER_TEXTBOX);
            MOBILE_NUMBER_TEXTBOX_.SendKeys(phone);
        }

        internal bool IsSuccessMessageDisplayed()
        {
            return IsElementDisplayed(NewCustomerPageUI.SUCCESS_MESSAGE);
        }
    }
}
