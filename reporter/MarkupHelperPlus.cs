using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.MarkupUtils;
using Selenium_Sample.utilities;
using Json.Net;

namespace Selenium_Sample.reporter
{
    public class MarkupHelperPlus
    {  
        public static IMarkup CreateRequest(HttpWebRequest request, HttpWebResponse response)
        {
            Markup markup = new Markup();
            markup.request = request;
            markup.response = response;
            return markup;
        }
    }
}