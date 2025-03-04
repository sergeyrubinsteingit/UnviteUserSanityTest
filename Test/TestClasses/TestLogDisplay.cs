using System;
using OpenQA.Selenium;
using System.IO;

namespace Test.TestClasses
{
    class TestLogDisplay
    {

        public static void DisplayTestLog() {

            string PathToDirectory = @"C:\Users\sergeyr\sergey_workspace\Nayax_TestSet\Nayax_TestSet\TestReports\";

            // lists all html files in the directory
            string[] AllHtmlFiles = Directory.GetFiles(PathToDirectory, "*.html");

            foreach (var HtmlFile in AllHtmlFiles) {

                System.Console.WriteLine("HtmlFile:  " + HtmlFile);

                // opens a new tab
                Procedure.webDriver.SwitchTo().NewWindow(WindowType.Tab);

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 100));

                // opens HTML
                Procedure.webDriver.Navigate().GoToUrl(HtmlFile);

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 100));

            } //foreach

        }// DisplayTestLog

    }
}
