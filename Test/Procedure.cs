using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.GlobalClasses;
using Test.TestClasses;

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
            BandwidthCheck.RunBandwidthCheck();


            // checks connection state
            RunTask = Task.Run(() => {

                InternetConnectionCheck.AvailablePort();

            });
            RunTask.Wait();


            // navigates to DCS login page
            webDriver.Url = TestData.TestKeyValues[TestData.KeyWords.URL_QA];

            // maximizes a window
            webDriver.Manage().Window.Maximize();

            // deletes cookies
            webDriver.Manage().Cookies.DeleteAllCookies();

            // forsed pause to let cookies be deleted
            System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate));

            // test functions
            List<Action> allFunctions = new List<Action> {

                () => OutlookUserInvitation.DeleteExistingMails(), // deletes mails in the User Invitation folder in the Outlook
                () => LoginToDcs.LoginFlow(), // Log into DCS
                () => SmsOrMomaLogin.SmsInputField(), // fires SMS or Moma method
                () => CookieBarIAvailability.FindCookieBar(), // accepts the cookies
                () => SwitchToOldDcs.SwitchToOldDcsUi(), // switches to DCS in necessary
                () => UserDetailsPanel.UserDetails(), // a panel to fill a user's details in
                () => UserRolesPanel.UserRoles(), // a panel to fill a user's roles in
                () => UserScreensPanel.UserScreens(),   // a panel to choose UI screens available to a user
                () => SalesAlertsPanel.SalesAlertsScreen(),   // a panel to set the rules fo Sales / Machine Alerts report
                () => AlertRulesPanel.AlertRulesScreen(),   // a panel to set the alert rules for a machine
                () => SuccessNotification.CheckSuccessNotification(),   // a check for a success notification to be displayed
                () => OutlookUserInvitation.ProceedInvitationLink(false), // reads the link in the User Invitation mail
                () => GetUserId.InvitedUserId(), // gets an ID of the invited user

            };//list

            bool isInvited = false;

            // test functions' firing loop
            for (int i = 0; i < allFunctions.Count; i++) {

                allFunctions[i]();

                if (i == 9) isInvited = true; // if

                if (i >= 5 && i <= 9) {

                    /////// Clicking the "Next"-"Previous", also the "Invite" buttons ///////
                    RunTask = Task.Run(() => {

                        NextPreviousButtons.ClickNextPreviousButton(true, isInvited);

                    });
                    RunTask.Wait();

                } //if

            } //for

            //// Log into DCS
            //    RunTask = Task.Run(() => {

            //    LoginToDcs.LoginFlow();

            //});
            //RunTask.Wait();


            //// fires SMS or Moma method
            //RunTask = Task.Run(() => {

            //    SmsOrMomaLogin.SmsInputField();

            //});
            //RunTask.Wait();


            //// accepts the cookies
            //RunTask = Task.Run(() => {

            //    TestClasses.CookieBarIAvailability.FindCookieBar();

            //});
            //RunTask.Wait();


            //// switches to DCS in necessary
            //RunTask = Task.Run(() => {

            //    SwitchToOldDcs.SwitchToOldDcsUi();

            //});
            //RunTask.Wait();


            //// a panel to fill a user's details in
            //RunTask = Task.Run(() =>
            //{

            //    TestClasses.UserDetailsPanel.UserDetails();

            //});
            //RunTask.Wait();


            ///////// Clicking the "Next"-"Previous", also the "Invite" buttons ///////
            //RunTask = Task.Run(() => {

            //    TestClasses.NextPreviousButtons.ClickNextPreviousButton(true, false);

            //});
            //RunTask.Wait();

            //// a panel to fill a user's roles in
            ////RunTask = Task.Run(() => {

            ////    TestClasses.UserRolesPanel.UserRoles();

            ////});
            ////RunTask.Wait();


            ///////// Clicking the "Next"-"Previous", also the "Invite" buttons ///////
            //RunTask = Task.Run(() => {

            //    TestClasses.NextPreviousButtons.ClickNextPreviousButton(true, false);

            //});
            //RunTask.Wait();


            //// a panel to choose UI screens available to a user
            ////RunTask = Task.Run(() => {

            ////    TestClasses.UserScreensPanel.UserScreens();

            ////});
            ////RunTask.Wait();


            ///////// Clicking the "Next"-"Previous", also the "Invite" buttons ///////
            //RunTask = Task.Run(() => {

            //    TestClasses.NextPreviousButtons.ClickNextPreviousButton(true, false);

            //});
            //RunTask.Wait();


            //// a panel to set the rules fo Sales / Machine Alerts report
            ////RunTask = Task.Run(() => {

            ////    TestClasses.SalesAlertsPanel.SalesAlertsScreen();

            ////});
            ////RunTask.Wait();


            /////// Clicking the "Next"-"Previous", also the "Invite" buttons ///////
            //RunTask = Task.Run(() =>
            //{

            //    TestClasses.NextPreviousButtons.ClickNextPreviousButton(true, false);

            //});
            //RunTask.Wait();


            //// a panel to set the alert rules for a machine
            ////RunTask = Task.Run(() => {

            ////    TestClasses.AlertRulesPanel.AlertRulesScreen();

            ////});
            ////RunTask.Wait();


            /////// Clicking the "Next"-"Previous", also the "Invite" buttons, here is Invite ///////
            //RunTask = Task.Run(() =>
            //{

            //    TestClasses.NextPreviousButtons.ClickNextPreviousButton(true, true);

            //});
            //RunTask.Wait();


            //// a check for a success notification to be displayed
            //RunTask = Task.Run(() =>
            //{

            //    TestClasses.SuccessNotification.CheckSuccessNotification();

            //});
            //RunTask.Wait();


            //// reads a message in the Outlook mailer
            //RunTask = Task.Run(() => {

            //    TestClasses.OpenOutlook.GetMailInvitationLink(false);

            //});
            //RunTask.Wait();

            ///////////////////////////////////////////////////////////////////////////


            //// creates screenshots directory
            //ScreenShotsTaker.CreateShotsDirectory();

            //// creates a log file
            //TestRecords.CreateTestLogFile();

            //// writes opening tags to HTML report file
            //HtmlGenerator.CreateHtmlOpeningTags();

            //// sets a webdriver for Chrome
            //webDriver = new ChromeDriver();

            ////////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT ENDS__ //////////////////////
            //////////////////////////////////////////////////////////////////////////////
            ///

            //// navigates to DCS login page
            //webDriver.Url = TestData.TestKeyValues[TestData.KeyWords.URL_QA];

            //// maximizes a window
            //webDriver.Manage().Window.Maximize();

            //// deletes cookies
            //webDriver.Manage().Cookies.DeleteAllCookies();

            //// forsed pause to let cookies be deleted
            //System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate));


            //////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT ENDS //////////////////////
            //////////////////////////////////////////////////////////////////////////////


            //// fires LoginFlow method
            //RunTask = Task.Run(() =>
            //{
            //    LoginToDcs.LoginFlow();
            //});
            //RunTask.Wait();

            //// fires SMS or Moma method
            //RunTask = Task.Run(() =>
            //{
            //    SmsOrMomaLogin.SmsInputField();
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

            //    SwitchToOldDcs.SwitchToOldDcsUi();

            //});
            //RunTask.Wait();

            //// forced pause - temporary , just to see the result
            //System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 10));


            //////////////////////////////////////////////////////////////////////////////
            ////////////////////// TEMPORARY COMMENTED SCRIPT ENDS //////////////////////
            ////////////////////////////////////////////////////////////////////////////

            // Closes the HTML report file
            //RunTask = Task.Run(() =>
            //{
            //    HtmlGenerator.CreateHtmlClosingTags();
            //});

            //RunTask.Wait();

            //// forced pause
            //System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate) * (int)BandwidthCheck.Coefficient_);


            //// forced pause - temporary , just to see the result
            //System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 10));

            //// Displays test logs at the end of the tests
            //RunTask = Task.Run(() =>
            //{
            //    TestClasses.TestLogDisplay.DisplayTestLog();
            //});
            //RunTask.Wait();

        }

    }
}
