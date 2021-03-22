using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Sample.interfaces
{
    class NewCustomerPageUI
    {
		public static readonly string CUSTOMER_NAME_TEXTBOX = "//input[@name='name']";
		public static readonly string DATE_OF_BIRTH_TEXTBOX = "//input[@name='dob']";
		public static readonly string ADDRESS_TEXTAREA = "//textarea[@name='addr']";
		public static readonly string CITY_TEXTBOX = "//input[@name='city']";
		public static readonly string STATE_TEXTBOX = "//input[@name='state']";
		public static readonly string PIN_TEXTBOX = "//input[@name='pinno']";
		public static readonly string MOBILE_NUMBER_TEXTBOX = "//input[@name='telephoneno']";
		public static readonly string EMAIL_TEXTBOX = "//input[@name='emailid']";
		public static readonly string PASSWORD_TEXTBOX = "//input[@name='password']";
		public static readonly string SUBMIT_BUTON= "//input[@type='submit']";
		public static readonly string SUCCESS_MESSAGE = "//*[@class='heading3']";
		public static readonly string CUSTOMER_ID= "//*[text()='Customer ID']/following-sibling::td";
		public static readonly string NEW_ACCOUNT_MENU = "//a[contains(text(),'New Account')]";


	}
}
