using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Selenium_Sample.test_setup;
using Selenium_Sample.api_core;
using Selenium_Sample.model;

namespace Selenium_Sample.services
{
    public class UserDataService
    {
        public string userDataPath = "/userlogin";

        public UserLogin userLogin;

        public UserDataService(UserLogin userLogin)
        {
            this.userLogin = userLogin;
        }

        public Response GetUserDataByIdRequest(int index)
        {
            Response response = new Request()
                .SetUrl(Constant.USER_DATA_SERVICE_API_HOST + userDataPath + "/" + index)
                .Get();
            return response;
        }

        public UserData GetUserDataById(int index)
        {
            Response response = GetUserDataByIdRequest(index);
            UserData userLogin = (UserData)JsonConvert.DeserializeObject<UserData>(response.responseBody);
            return userLogin;
        }
    }
}