using OpenQA.Selenium;
using System.IO;


namespace Test.GlobalClasses
{
    class Asserts
    {
        public static string TestReportFontColor = "";

        public static string FailedOrPassed;

        public static void AssertElementExists(IWebElement ElementToValidate, string ElementDescription)
        {

            if (ElementToValidate.Displayed)
            {

                System.Console.WriteLine(ElementDescription + " test passed.");

                TestRecords.WriteTestRecordToLog(ElementDescription + " test passed.");

                TestReportFontColor = "#94f736"; // "green"; // 

            }
            else
            {

                System.Console.WriteLine(ElementDescription + " test failed.");

                TestRecords.WriteTestRecordToLog(ElementDescription + " test failed.");

                TestReportFontColor = "#f77036"; //"red"; //

            };//if

        }//AssertElementExists

        public static void AssertElementDoesNotExist(IWebElement ElementToValidate, string ElementDescription)
        {

            if (!ElementToValidate.Displayed)
            {

                System.Console.WriteLine(ElementDescription + " test passed.");

            }
            else
            {

                System.Console.WriteLine(ElementDescription + " test failed");

            };//if

        }//AssertElementDoesNotExists


        // Validity of the element
        public static void AssertElementValidity(bool AssertEvaluationFlag_, string ElementDescription)
        {
            System.Console.WriteLine("<<<<< Assert Element Validity begins >>>>>");

            if (AssertEvaluationFlag_ == false)
            {

                FailedOrPassed = " test failed.";

                TestReportFontColor = "#f77036"; //"red"; //  

            }
            else
            {

                FailedOrPassed = " test passed.";

                TestReportFontColor = "#94f736"; // "green"; // 

            };//if

            System.Console.WriteLine(ElementDescription + FailedOrPassed);

            TestRecords.WriteTestRecordToLog(ElementDescription + FailedOrPassed);

        }//AssertElementValidity

    }
}
