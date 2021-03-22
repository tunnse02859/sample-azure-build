using System;
using System.Net;
using System.Web;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Selenium_Sample.reporter;

namespace Selenium_Sample.api_core
{
    public class Request
    {
        public HttpWebRequest request;
        public string url { get; set; }
        public string requestBody { get; set; }
        public string formData { get; set; }

        public Request SetUrl(string url)
        {
            this.url = url;
            request = (HttpWebRequest)WebRequest.Create(url);
            return this;
        }

        public Request()
        {
            url = "";
            requestBody = "";
            formData = "";
        }

        public Request AddHeader(string key, string value)
        {
            request.Headers.Add(key, value);
            return this;
        }

        public Request SetRequestParameter(string key, string value)
        {
            if (url.Contains("?"))
            {
                url = url + "?" + key + "=" + value;
            }
            else
            {
                url = url + "&" + key + "=" + value;
            }
            return this;
        }

        public Request AddFormData(string key, string value)
        {
            if (formData.Equals("") || formData == null)
            {
                formData += key + "=" + value;
            }
            else if (!formData.Equals(""))
            {
                formData += "&" + key + "=" + value;
            }
            return this;
        }

        public Request SetContentType(string name)
        {
            request.ContentType = name;
            return this;
        }

        public Response Get()
        {
            request.Method = "GET";
            Response response = SendRequest();
            return response;
        }

        public Response Post()
        {
            request.Method = "POST";
            Response response = SendRequest();
            return response;
        }

        public Response Put()
        {
            request.Method = "PUT";
            Response response = SendRequest();
            return response;
        }

        public Response Delete()
        {
            request.Method = "DELETE";
            Response response = SendRequest();
            return response;
        }

        public Response SendRequest()
        {
            if (request.Method == "GET")
            {
                requestBody = null;
            }
            else
            {
                if (requestBody != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }

                if (!formData.Equals(""))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(formData);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
            }

            try
            {
                IAsyncResult asyncResult = request.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                var httpResponse = (HttpWebResponse)request.EndGetResponse(asyncResult);
                HtmlReporter.Info(request, httpResponse);
                return new Response(httpResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}