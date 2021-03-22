using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Selenium_Sample.test_setup;
using Selenium_Sample.api_core;
using Selenium_Sample.model;

namespace Selenium_Sample.services
{
    public class MockAPILoginService
    {
        public string userLoginPath = "/userlogin";

        public Response LoginasdaRequest()
        {
            Response response = new Request()
                .SetUrl(Constant.MOCK_API_API_HOST + userLoginPath)
                .Get();
            return response;
        }

        public Response LoginRequest(string username, string password)
        {
            Response response = new Request()
                .SetUrl(Constant.MOCK_API_API_HOST + userLoginPath)
                .AddHeader("Content-Type","application/x-www-form-urlencoded")
                .AddFormData("Token", "myToken")
                .AddFormData("username", username)
                .AddFormData("password", password)
                .Post();
            return response;

        }
        public UserLogin Login(string username, string password)
        {
            Response response = LoginRequest(username, password);
            UserLogin userLogin = (UserLogin)JsonConvert.DeserializeObject<UserLogin>(response.responseBody);
            return userLogin;
        }
    }
}