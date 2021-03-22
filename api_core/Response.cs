using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Selenium_Sample.reporter;


namespace Selenium_Sample.api_core
{
    public class Response
    {
        public HttpWebResponse response;
        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }

        public Response(HttpWebResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }

        private string GetResponseBody()
        {
            responseBody = "";
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
            }
            return responseBody;
        }
        private string GetResponseStatusCode()
        {
            responseStatusCode = response.StatusCode.ToString();
            // if (response.StatusCode != HttpStatusCode.Created)
            // {
            //     var message = String.Format("Failed: Received HTTP: {0}", responseStatusCode);
            //     HtmlReporter.Fail(message);
            // }
            // else
            // {
            //     HtmlReporter.Pass("HTTP status ok!");
            // }
            // response.Close();
            return responseStatusCode;
        }
    }
}