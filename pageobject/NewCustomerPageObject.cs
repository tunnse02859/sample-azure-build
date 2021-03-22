using Selenium_Sample.driver_core;
using Selenium_Sample.interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_Sample.pageobject
{
    class NewCustomerPageObject : WebDriverBase
    {
        public NewCustomerPageObject(IWebDriver driver) : base()
        {
            this.driver = driver;
        }

        internal void InputNameTextbox(string name)
        {
            WaitForElementVisible(NewCustomerPageUI.CUSTOMER_NAME_TEXTBOX);
            SendKeyToElement(NewCustomerPageUI.CUSTOMER_NAME_TEXTBOX, name);
        }

        internal void InputDateofBirthTextbox(string dateofBirth)
        {
            WaitForElementVisible(NewCustomerPageUI.DATE_OF_BIRTH_TEXTBOX);
            SendKeyToElement(NewCustomerPageUI.DATE_OF_BIRTH_TEXTBOX, dateofBirth);
        }

        internal void InputCityTextbox(string city)
        {
            WaitForElementVisible(NewCustomerPageUI.CITY_TEXTBOX);
            SendKeyToElement(NewCustomerPageUI.CITY_TEXTBOX,city);
        }

        internal void InputAddressTextarea(string address)
        {
            WaitForElementVisible(NewCustomerPageUI.ADDRESS_TEXTAREA);
            SendKeyToElement(NewCustomerPageUI.ADDRESS_TEXTAREA,address);
        }

        internal void InputPinTextbox(string pin)
        {
            WaitForElementVisible(NewCustomerPageUI.PIN_TEXTBOX);
            SendKeyToElement(NewCustomerPageUI.PIN_TEXTBOX, pin);
        }

        internal void InputEmailTextbox(string email)
        {
            WaitForElementVisible(NewCustomerPageUI.EMAIL_TEXTBOX);
            SendKeyToElement(NewCustomerPageUI.EMAIL_TEXTBOX,email);
        }

        internal void InputStateTextbox(string state)
        {
            WaitForElementVisible(NewCustomerPageUI.STATE_TEXTBOX);
            SendKeyToElement(NewCustomerPageUI.STATE_TEXTBOX, state);
        }

        internal void InputPasswordTextbox(string pass)
        {
            WaitForElementVisible(NewCustomerPageUI.PASSWORD_TEXTBOX);
            SendKeyToElement(NewCustomerPageUI.PASSWORD_TEXTBOX,pass);
        }

        internal void ClickSubmitButton()
        {
            WaitForElementClickable(NewCustomerPageUI.SUBMIT_BUTON);
            ClickToElement(NewCustomerPageUI.SUBMIT_BUTON);
        }

        internal NewAccountPageObject ClickNewAccountMenu()
        {
            WaitForElementClickable(NewCustomerPageUI.NEW_ACCOUNT_MENU);
            ClickToElement(NewCustomerPageUI.NEW_ACCOUNT_MENU);
            return PageGeneratorManager.GetNewAccountPage(driver);
        }

        internal string GetCustomerId()
        {
            WaitForElementVisible(NewCustomerPageUI.CUSTOMER_ID);
            return GetElementText(NewCustomerPageUI.CUSTOMER_ID);
        }

        internal string GetSuccessMessage()
        {
            WaitForElementVisible(NewCustomerPageUI.SUCCESS_MESSAGE);
            return GetElementText(NewCustomerPageUI.SUCCESS_MESSAGE);
        }

        internal void InputMobileNumberTextbox(string phone)
        {
            WaitForElementVisible(NewCustomerPageUI.MOBILE_NUMBER_TEXTBOX);
            SendKeyToElement(NewCustomerPageUI.MOBILE_NUMBER_TEXTBOX,phone);
        }
    }
}
