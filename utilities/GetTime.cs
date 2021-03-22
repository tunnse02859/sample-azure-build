using System;

namespace Selenium_Sample.utilities
{
    public class GetTime
    {        
        private static string dateString = DateTime.Now.ToString("yyyyMMddHHmmss");
        public static string NowDate()
        {
            string nowDate = dateString.Substring(0,8);
            return nowDate;
        }
        public static string NowDateTime()
        {
            string nowDateTime = dateString;
            return nowDateTime;
        }
    }
}