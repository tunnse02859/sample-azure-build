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
using Selenium_Sample.api_core;
using Selenium_Sample.reporter;
using Json.Net;


namespace Selenium_Sample.reporter
{
    public class HtmlReporter
    {
        private static int testCaseIndex;
        private static string testCaseName;
        private static ExtentReports _report;
        private static Dictionary<string, ExtentTest> extentTests = new Dictionary<string, ExtentTest>();

        public static ExtentReports createReport(string path)
        {
            if (_report == null)
            {
                _report = createInstance(path);
            }
            return _report;
        }

        private static ExtentReports createInstance(string path)
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.DocumentTitle = path;
            htmlReporter.Config.ReportName = path;
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;
        }

        public static void flush()
        {
            if (_report != null)
            {
                _report.Flush();
            }
        }

        public static ExtentTest createTest(string className, string classDescription = "")
        {
            ExtentTest testClass = _report.CreateTest(className, classDescription);
            extentTests.Add("testClass", testClass);
            return testClass;
        }

        public static ExtentTest createNode(string className, string testcase, string description = "")
        {
            ExtentTest testClass = GetParent();
            if (testClass == null)
            {
                testClass = createTest(className);
            }
            testCaseName = "testCase" + (testCaseIndex++).ToString();
            ExtentTest testCase = testClass.CreateNode(testcase, description);
            extentTests.Add(testCaseName, testCase);
            return testCase;
        }

        public static ExtentTest GetParent()
        {
            ExtentTest testClass = extentTests["testClass"];
            return testClass;
        }
        
        public static ExtentTest GetNode()
        {
            ExtentTest testClass = extentTests[testCaseName];
            return testClass;
        }

        public static ExtentTest GetTest()
        {
            if (GetNode() == null)
            {
                return GetParent();
            }
            return GetNode();
        }

        public static void Pass(string des)
        {
            GetTest().Pass(des);
            TestContext.Progress.WriteLine(des);
        }

        public static void Fail(string des)
        {
            GetTest().Fail(des);
            TestContext.Progress.WriteLine(des);
        }

        public static void Fail(string des, string path)
        {
            GetTest().Fail(des).AddScreenCaptureFromPath(path);
            TestContext.Progress.WriteLine(des);
        }
        public static void Fail(string des, string ex, string path)
        {
            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.Progress.WriteLine(des);
        }

        public static void Info(string des)
        {
            GetTest().Info(des);
            TestContext.Progress.WriteLine(des);
        }

        public static void Info(HttpWebRequest request, HttpWebResponse response)
        {
            GetTest().Info(MarkupHelperPlus.CreateRequest(request, response));
            // TestContext.Progress.WriteLine(des);
        }

        public static void Warning(string des)
        {
            GetTest().Warning(des);
            TestContext.Progress.WriteLine(des);
        }

        public static void Skip(string des)
        {
            GetTest().Skip(des);
            TestContext.Progress.WriteLine(des);
        }

        public static void MarkUpHtml()
        {
            var htmlMarkup = HtmlInjector.CreateHtml();
            var m = MarkupHelper.CreateLabel(htmlMarkup, ExtentColor.Transparent);
            GetTest().Info(m);
        }

        public static void MarkupPassJson()
        {
            var json = "{'foo' : 'bar', 'foos' : ['b','a','r'], 'bar' : {'foo':'bar', 'bar':false,'foobar':1234}}";
            GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        }

        public static void MarkupTable()
        {
            string[][] someInts = new string[][] { new string[] { "<label> HAHAHA </label>" }, new string[] {} };
            var m = MarkupHelper.CreateTable(someInts);

            GetTest().Info(m);
        }

        public static void MarkupLabel()
        {
            var text = "extent";
            var m = MarkupHelper.CreateLabel(text, ExtentColor.Blue);
            GetTest().Pass(m);
        }
    }
}