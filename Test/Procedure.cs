using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Test
{
    class Procedure
    {
        public static IWebDriver webDriver;

        static Task RunTask;

        [Obsolete]
        static void Main(string[] args)
        {
            // sets a webdriver for Chrome
            webDriver = new ChromeDriver();

            // available browsers
            Microsoft.Win32.RegistryKey RegistryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
            foreach (string browserName in RegistryKey.GetSubKeyNames()) { Console.WriteLine(browserName); }//

            // to prevent failure after 60 sec. wait
            //var options = new ChromeOptions();
            //options.AddArgument("no-sandbox");

            // gets a bandwidth rate
            GlobalClasses.BandwidthCheck.RunBandwidthCheck();

            RunTask = Task.Run(() => {

                // checks connection state
                GlobalClasses.InternetConnectionCheck.AvailablePort();

            });
            RunTask.Wait();


            // navigates to DCS login page
            webDriver.Url = GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.URL_QA];

            // maximizes a window
            webDriver.Manage().Window.Maximize();

            // deletes cookies
            webDriver.Manage().Cookies.DeleteAllCookies();

            // forsed pause to let cookies be deleted
            System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate));

            // Log into DCS
            RunTask = Task.Run(() => {
                GlobalClasses.LoginToDcs.LoginFlow();
            });
            RunTask.Wait();


            // fires SMS or Moma method
            RunTask = Task.Run(() => {
                GlobalClasses.SmsOrMomaLogin.SmsInputField();
            });
            RunTask.Wait();


            // accepts the cookies
            RunTask = Task.Run(() => {
                TestClasses.CookieBarIAvailability.FindCookieBar();
            });
            RunTask.Wait();


            // switches to DCS in necessary
            RunTask = Task.Run(() => {
                GlobalClasses.SwitchToOldDcs.SwitchToOldDcsUi();
            });
            RunTask.Wait();


            // a window to fill a user's details in
            RunTask = Task.Run(() => {
                TestClasses.UserDetailsPanel.UserDetails();
            });
            RunTask.Wait();


            /////// Clicking the "Next"-"Previous", also the "Invite" buttons ///////
            RunTask = Task.Run(() => {

                TestClasses.NextPreviousButtons.ClickNextPreviousButton(true);

            });
            RunTask.Wait();

            // a window to fill a user's roles in
            RunTask = Task.Run(() => {
                TestClasses.UserRolesPanel.UserRoles();
            });
            RunTask.Wait();


            /////// Clicking the "Next"-"Previous", also the "Invite" buttons ///////
            RunTask = Task.Run(() => {

                TestClasses.NextPreviousButtons.ClickNextPreviousButton(true);

            });
            RunTask.Wait();


            // a window to choose UI screens available to a user
            RunTask = Task.Run(() => {
                TestClasses.UserScreensPanel.UserScreens();
            });
            RunTask.Wait();


            /////// Clicking the "Next"-"Previous", also the "Invite" buttons ///////
            //RunTask = Task.Run(() => {

            //    TestClasses.NextPreviousButtons.ClickNextPreviousButton(true);

            //});
            //RunTask.Wait();


            // reads a message in the Outlook mailer
            RunTask = Task.Run(() => {
                TestClasses.OpenOutlook.GetMailInvitationLink(false);
            });
            RunTask.Wait();

            ///////////////////////////////////////////////////////////////////////////


            //// creates screenshots directory
            //GlobalClasses.ScreenShotsTaker.CreateShotsDirectory();

            //// creates a log file
            //GlobalClasses.TestRecords.CreateTestLogFile();

            //// writes opening tags to HTML report file
            //GlobalClasses.HtmlGenerator.CreateHtmlOpeningTags();

            //// sets a webdriver for Chrome
            //webDriver = new ChromeDriver();

            ////////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT ENDS__ //////////////////////
            //////////////////////////////////////////////////////////////////////////////
            ///

            //// navigates to DCS login page
            //webDriver.Url = GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.URL_QA];

            //// maximizes a window
            //webDriver.Manage().Window.Maximize();

            //// deletes cookies
            //webDriver.Manage().Cookies.DeleteAllCookies();

            //// forsed pause to let cookies be deleted
            //System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate));


            //////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT ENDS //////////////////////
            //////////////////////////////////////////////////////////////////////////////


            //// fires LoginFlow method
            //RunTask = Task.Run(() =>
            //{
            //    GlobalClasses.LoginToDcs.LoginFlow();
            //});
            //RunTask.Wait();

            //// fires SMS or Moma method
            //RunTask = Task.Run(() =>
            //{
            //    GlobalClasses.SmsOrMomaLogin.SmsInputField();
            //});
            //RunTask.Wait();

            //// Verifies availability of the Cookie bar
            //RunTask = Task.Run(() =>
            //{
            //    TestClasses.CookieBarIAvailability.FindCookieBar();
            //});
            //RunTask.Wait();


            //////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT BEGINS //////////////////////
            //////////////////////////////////////////////////////////////////////////////

            //// Verifies UI version, switches to the old one if necessary
            //RunTask = Task.Run(() =>
            //{

            //    GlobalClasses.SwitchToOldDcs.SwitchToOldDcsUi();

            //});
            //RunTask.Wait();

            //// forced pause - temporary , just to see the result
            //System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 10));


            //////////////////////////////////////////////////////////////////////////////
            ////////////////////// TEMPORARY COMMENTED SCRIPT ENDS //////////////////////
            ////////////////////////////////////////////////////////////////////////////

            // Closes the HTML report file
            //RunTask = Task.Run(() =>
            //{
            //    GlobalClasses.HtmlGenerator.CreateHtmlClosingTags();
            //});

            //RunTask.Wait();

            //// forced pause
            //System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate) * (int)GlobalClasses.BandwidthCheck.Coefficient_);


            //// forced pause - temporary , just to see the result
            //System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 10));

            //// Displays test logs at the end of the tests
            //RunTask = Task.Run(() =>
            //{
            //    TestClasses.TestLogDisplay.DisplayTestLog();
            //});
            //RunTask.Wait();

        }

    }
}
