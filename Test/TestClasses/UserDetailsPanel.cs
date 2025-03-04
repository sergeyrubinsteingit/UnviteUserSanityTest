
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace Test.TestClasses
{
    class UserDetailsPanel
    {

        static Task RunTask;

        [Obsolete]
        public static void UserDetails() {

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 1.2));

            RunTask = Task.Run(() => {

                // opens Administration menu
                GlobalClasses.WaitTillExpectedCondition.ElementExistsByXpath(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.MENU_ADMINISTRATION_LINK], 60);

            });
            RunTask.Wait();

            GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();


            RunTask = Task.Run(() => {

                // opens System Users page
                GlobalClasses.WaitTillExpectedCondition.ElementExistsByXpath(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.MENU_SYSTEM_USERS_LINK], 60);

            });
            RunTask.Wait();

            GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();


            RunTask = Task.Run(() => {

                // clicks Invite User Button
                GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.CREATE_USER_BUTTON], 60);

            });
            RunTask.Wait();

            GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();
            
            RunTask = Task.Run(() => {

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 60));

                // checks if user invite window is opened
                GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_WINDOW], 200);

            });
            RunTask.Wait();

            /////// Operator field ///////
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.ACTOR_ID_INPUT], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    "//*[@id=\"actor_id\"]/div[2]/ul/li[2]/b", /*menu entry's xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.ACTOR_QA] /*keys to send*/
                );

            });
            RunTask.Wait();

            /////// Job Title field ///////
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_TITLE], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_JOB_TITLE_DESCR] /*keys to send*/
                );

            });
            RunTask.Wait();

            /////// Job Function field ///////
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    1, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_JOB_FUNCTION], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    "//*[@id=\"job_function\"]/div[2]/ul/li[2]", /*menu entry's xpath*/
                    null /*keys to send*/
                );

            });
            RunTask.Wait();

            /////// New Login field ///////
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    1, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_LOGIN], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_LOGIN_DESCR] /*keys to send*/
                );

            });
            RunTask.Wait();

            /////// Email fields ///////
            RunTask = Task.Run(() => {

                TestClasses.EmailFieldsTest.UserEmails();

            });
            RunTask.Wait();

        }// UserDetails

    }
}
