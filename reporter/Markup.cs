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
using Selenium_Sample.api_core;

namespace Selenium_Sample.reporter
{
    public class Markup : IMarkup
    { 
        public HttpWebRequest request {get; set;}
        public HttpWebResponse response {get; set;}

        public string GetMarkup()
        {
            string requestUrl = request.RequestUri.ToString();
            string requestMethod = request.Method.ToString();
            string requestHeaders = request.Headers.ToString();
            string requestBody = "";

            string responseUrl = response.ResponseUri.ToString();
            string responseMethod = response.Method.ToString();
            string responseHeaders = response.Headers.ToString();
            string responseCode = response.StatusCode.ToString();
            string responseBody = "";
            
            string htmlBody = "";
            htmlBody = 
            "<!DOCTYPE html>"
            + "<html>"
            + "<title>Test</title>"
            + "<meta name='viewport' content='width=device-width, initial-scale=1'>"
            + "<style>"
            +   ".custombadge{"
            +           "padding:6px 6px;font-size:12px;text-transform:uppercase;cursor:pointer;color:black;background:green;border:1px solid black"
            +           "}"
            +   "table, th, td {"
            +       "border: 1px solid black;"
            +       "border-collapse: collapse;"
            +       "}"
            +   "</style>"
            + "<body>"
            +   "<div style='display: flex; gap: 10px'>"
            +       "<span class='custombadge'>" + requestMethod + "</span>"
            +           "<a href='" + requestUrl + "'>" + requestUrl + "</a>"
            +   "</div>"
            + "<h2>Request Info</h2>"
            + "<table style='width:100%'>"
            + "<tr>"
            +       "<td>Method</td>"
            +       "<td>" + requestMethod + "</td>"
            +   "</tr>"
            +   "<tr>"
            +       "<td>Headers</td>"
            +       "<td>" + requestHeaders + "</td>"
            +   "</tr>"
            +   "<tr>"
            +       "<td>Body</td>"
            +       "<td>" + requestBody + "</td>"
            +   "</tr>"
            +   "</table>"
            + "<h2>Response Info</h2>"
            + "<table style='width:100%'>"
            + "<tr>"
            +       "<td>Method</td>"
            +       "<td>" + requestMethod + "</td>"
            +   "</tr>"
            +   "<tr>"
            +       "<td>Status Code</td>"
            +       "<td>" + responseCode + "</td>"
            +   "</tr>"
            +   "<tr>"
            +       "<td>Body</td>"
            +       "<td>" + responseBody + "</td>"
            +   "</tr>"
            +   "</table>"
            +   "</body>"
            +   "</html>"
            ;

            return htmlBody;
        }
    }
}