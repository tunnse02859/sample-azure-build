using Selenium_Sample.driver_core;
using Selenium_Sample.interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Sample.pageobject
{
    class NewAccountPageObject : WebDriverBase
    {
        public NewAccountPageObject(IWebDriver driver) : base()
        {
            this.driver = driver;
        }

        internal void InputCustomerIDTextbox(string customerId)
        {
            WaitForElementVisible(NewAccountPageUI.CUSTOMERSID_TEXTBOX);
            SendKeyToElement(NewAccountPageUI.CUSTOMERSID_TEXTBOX,customerId);
        }

        internal void InputInitialDepositTextbox(string initialDeposit)
        {
            WaitForElementVisible(NewAccountPageUI.DEPOSIT_TEXTBOX);
            SendKeyToElement(NewAccountPageUI.DEPOSIT_TEXTBOX, initialDeposit);
        }

        internal void ClickSubmitButton()
        {
            WaitForElementClickable(NewAccountPageUI.SUBMIT_BUTTON);
            ClickToElement(NewAccountPageUI.SUBMIT_BUTTON);
        }

        internal string GetSuccessMessage()
        {
            WaitForElementVisible(NewAccountPageUI.SUCESS_MESSAGE);
            return GetElementText(NewAccountPageUI.SUCESS_MESSAGE);
        }
    }
    }

