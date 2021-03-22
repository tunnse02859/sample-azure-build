using System;

namespace Selenium_Sample.utilities
{
    public class Common
    {
        public static string REPORT_PATH {get; set;}
        public static string HTML_PATH {get; set;}
        public static string SCREENSHOT_PATH {get; set;}
        private static string dateTimeIndex;
        private static string dateIndex;

        public static void InitReportDirection(string dateTimeIndex)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string dateIndex = dateTimeIndex.Substring(0,8);

            REPORT_PATH = projectPath + "\\Reports\\Report_" + dateIndex;
            // Only use with Extent HTML Report V3 (ExtentV3HtmlReporter)
            // HTML_PATH = REPORT_PATH + "\\TestReport_" + nowDateTimeString + ".html";
            HTML_PATH = REPORT_PATH + "\\index.html";
            SCREENSHOT_PATH = REPORT_PATH + "\\Screenshot";

            FilePath.CreateFolder(projectPath + "\\Reports");
            FilePath.CreateFolder(REPORT_PATH);
            FilePath.CreateFolder(SCREENSHOT_PATH);
        }
    }
}