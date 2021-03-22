using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Selenium_Sample.driver_core;
using Selenium_Sample.pageobject;
using Selenium_Sample.pagefactory;
using Selenium_Sample.utilities;
using Selenium_Sample.api_core;
using Selenium_Sample.reporter;
using Selenium_Sample.services;
using Selenium_Sample.model;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Selenium_Sample
{
    [TestFixture]
    public class MainTest : WebDriverManager_
    {
        public static string dateTimeIndex = GetTime.NowDateTime();
        public Request request;
        public JsonPlaceHolderService myServices;
        public MockAPILoginService myLoginService;
        public UserDataService myUserDataService1;
        public UserDataService myUserDataService2;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            myServices = new JsonPlaceHolderService();
            myLoginService = new MockAPILoginService();

            UserLogin userLogin1 = new UserLogin();
            UserLogin userLogin2 = new UserLogin();

            myUserDataService1 = new UserDataService(userLogin1);
            myUserDataService2 = new UserDataService(userLogin2);

            UserData userData1 = new UserData();
            UserData userData2 = new UserData();

            Common.InitReportDirection(dateTimeIndex);
            HtmlReporter.createReport(Common.HTML_PATH);
            HtmlReporter.createTest(TestContext.CurrentContext.Test.ClassName);
        }

        [SetUp]
        public void Setup()
        {
            HtmlReporter.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
        }

        [TestCase(5, TestName = "TC01. GET request test")]
        public void APIGetTest(int index)
        {
            User user = myServices.GetUserByIndex(index);
            HtmlReporter.Pass("GETed title of user " + (index++).ToString() + ": " + user.title.ToString());
        }
        
        [TestCase("1234", "myTitle", "myBody", TestName = "TC02. POST request test")]
        public void APIPostTest(string postId, string postTitle, string postBody)
        {
            User user = myServices.PostUser(postId, postTitle, postBody);
            Assertion.True(user.title.ToString() == postTitle, "POST request PASSED!", "POST request FAILED...");
        }
        
        [TestCase("user001", "pw001", "user002", "pw002", TestName = "TC03. Login Service with Token test")]
        public void LoginServiceTest(string username1, string pw1, string username2, string pw2)
        {
            UserLogin userLogin1 = myLoginService.Login(username1, pw1);
            UserLogin userLogin2 = myLoginService.Login(username2, pw2);

            if(userLogin1.Token == "myToken")
            {
                UserData userData1 = myUserDataService1.GetUserDataById(userLogin1.id);
                Assertion.True(userData1.username.ToString() == username1, "user01 Login Successful!", "User Login Failed...");
            }

            if(userLogin2.Token == "myToken")
            {
                UserData userData2 = myUserDataService2.GetUserDataById(userLogin2.id);
                Assertion.True(userData2.username.ToString() == username2, "user02 Login Successful!", "User Login Failed...");
            }
        }    

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            HtmlReporter.flush();
        }
    }
}