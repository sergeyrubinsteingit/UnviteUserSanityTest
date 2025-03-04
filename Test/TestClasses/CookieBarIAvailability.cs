using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace Test.TestClasses
{
    class CookieBarIAvailability
    {
        static Task RunTask;
        static IWebElement CookieBarElement;

        [Obsolete]
        public static IWebElement FindCookieBar() {

        System.Console.WriteLine("<<< Find cookie bar begins >>>");


            RunTask = Task.Run(() => {

                // gets a bandwidth rate
                GlobalClasses.BandwidthCheck.RunBandwidthCheck();

            });
            RunTask.Wait();


            RunTask = Task.Run(() => {

            // search for Cookies bar
            CookieBarElement = GlobalClasses.WaitTillExpectedCondition
            .ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.COOKIE_BAR], GlobalClasses.BandwidthCheck.DownloadRate * (int)(GlobalClasses.BandwidthCheck.DownloadRate * GlobalClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // asserts availability of the web element
            GlobalClasses.Asserts.AssertElementExists(GlobalClasses.WaitTillExpectedCondition.ExpectedElement, "Cookie bar");

            // draws a border around the element
            //GlobalClasses.ScreenShotsTaker.DrawBorderAroundElementByCssSelector("Id", "onetrust-button-group-parent", "","");

            //// takes a screenshot
            //GlobalClasses.ScreenShotsTaker.TakeScreenShot("Cookie_bar_", Procedure.webDriver.FindElement(By.TagName("body")));

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 1.2));

            // appends block to html
            //GlobalClasses.HtmlGenerator.AppendBlockToHtml(GlobalClasses.ScreenShotsTaker.RecordForHtmlReport, GlobalClasses.TestRecords.FinalRecord_);

            //// clears the screenshots string from the previous data
            //GlobalClasses.ScreenShotsTaker.RecordForHtmlReport = "";

            RunTask = Task.Run(() => {

                // search for Cookies Accept button
                CookieBarElement = GlobalClasses.WaitTillExpectedCondition
                .ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.COOKIE_CONFIRM_BUTTON], GlobalClasses.BandwidthCheck.DownloadRate);

            });
            RunTask.Wait();

            // clicks the button "Accept"
            GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();

            return CookieBarElement;

        }//FindCookieBar

    }
}
