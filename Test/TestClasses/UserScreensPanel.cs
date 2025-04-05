using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace Test.TestClasses
{
    class UserScreensPanel
    {
        static Task RunTask;

        [Obsolete]
        public static void UserScreens()
        {

            /////// Opening the WEB hierarchy ///////
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_WEB_SCREEN_BOX], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    null, /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();

            /////// Unchecking the LOGS menu for the user ///////
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_LOG_BOX], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    null, /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();

            /////// Validates if the LOGS menu is unchecked ///////
            RunTask = Task.Run(() => {

                AssertState.ElementState
                (
                    1, /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; 4 = css selector, selected; case: 5 = xpath, compare strings; case: 6 = xpath, compare numbers; */
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_LOG_BOX], /*screen element to search for*/
                    null, /* a string to compare for a matching case */
                    0 /* a number to compare for a matching case */
                );

            });
            RunTask.Wait();

            /////// Checking the Allow Edit/Write box ///////
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_EDITWRITE_BOX], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    null, /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();

            /////// Validates if Allow Edit/Write box is checked ///////
            RunTask = Task.Run(() => {

                AssertState.ElementState
                (
                    3, /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; 4 = css selector, selected; case: 5 = xpath, compare strings; case: 6 = xpath, compare numbers; */
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_EDITWRITE_BOX], /*screen element to search for*/
                    null, /* a string to compare for a matching case */
                    0 /* a number to compare for a matching case */
                );

            });
            RunTask.Wait();

        }// UserScreens

    }
}
