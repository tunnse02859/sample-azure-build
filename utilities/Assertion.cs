using System;
using NUnit.Framework;
using Selenium_Sample.reporter;

namespace Selenium_Sample.utilities
{
    public class Assertion
    {
        public static void True(bool condition, string successMessage, string failureMessage)
        {
            try
            {
                Assert.True(condition, failureMessage);
                HtmlReporter.Pass(successMessage);
            }
            catch(Exception ex)
            {
                HtmlReporter.Fail(failureMessage, " - Exception: " + ex.ToString());
                throw ex;
            }
        }

        public static void AreEqual(string text1, string text2, string successMessage, string failureMessage)
        {
            try
            {
                Assert.AreEqual(text1, text2, failureMessage);
                HtmlReporter.Pass(successMessage);
            }
            catch(Exception ex)
            {
                HtmlReporter.Fail(failureMessage, " - Exception: " + ex.ToString());
                throw ex;
            }
        }

        public static void Contains(string text1, System.Collections.ICollection collection, string successMessage, string failureMessage)
        {
            try
            {
                Assert.Contains(text1, collection, failureMessage);
                HtmlReporter.Pass(successMessage);
            }
            catch(Exception ex)
            {
                HtmlReporter.Fail(failureMessage, " - Exception: " + ex.ToString());
                throw ex;
            }
        }
    }
}
