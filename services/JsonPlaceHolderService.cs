using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Selenium_Sample.test_setup;
using Selenium_Sample.api_core;
using Selenium_Sample.model;

namespace Selenium_Sample.services
{
    public class JsonPlaceHolderService
    {
        public string getUserPath = "/posts";
        public string postUserPath = "/posts";

        public Response GetUserRequest()
        {
            Response response = new Request()
                .SetUrl(Constant.JSON_PLACE_HOLDER_API_HOST + getUserPath)
                .Get();
            return response;
        }

        public List<User> GetUsers()
        {
            Response response = GetUserRequest();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(response.responseBody);
            return users;
        }

        public Response PostUserRequest(string userId, string title, string body)
        {
            Response response = new Request()
                .SetUrl(Constant.JSON_PLACE_HOLDER_API_HOST + getUserPath)
                .AddHeader("Content-Type","application/x-www-form-urlencoded")
                .AddFormData("userId", userId)
                .AddFormData("title", title)
                .AddFormData("body", body)
                .Post();
            return response;
        }

        public User PostUser(string userId, string title, string body)
        {
            Response response = PostUserRequest(userId, title, body);
            User user = (User)JsonConvert.DeserializeObject<User>(response.responseBody);
            return user;
        }
        
        public User GetUserByIndex(int index)
        {
            User user = (User)GetUsers().ToArray().GetValue(index);
            return user;
        }
    }
}