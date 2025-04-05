using System;
using OpenQA.Selenium;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TestClasses
{
    class AlertRulesPanel
    {

        static Task RunTask;

        [Obsolete]
        public static void AlertRulesScreen()
        {

            // Event Category filter
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_EVENT_CATEGORY], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    "V2V Alerts", /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();

            // Event Category dropdown entry
            RunTask = Task.Run(() => {

                GlobalClasses.WaitTillExpectedCondition.ElementExistsByXpath("//*[@id=\"event_category_id\"]/div[2]/ul/li[38]", 60);

            });
            RunTask.Wait();

            GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();


            // Group Category filter
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_GROUP_CATEGORY], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    "Stock Level", /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();

            // Group Category dropdown entry
            RunTask = Task.Run(() => {

                GlobalClasses.WaitTillExpectedCondition.ElementExistsByXpath("//*[@id=\"group_category_id\"]/div[2]/ul/li[7]", 60);

            });
            RunTask.Wait();

            GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();


            // Filter the alerts' field fill
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_ALERTS_FILTER], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    "Lower", /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();


            // Clicks the Search button 
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_ALERTS_FILTER_BTN], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    null, /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();
            

            // matches a number of table rows
            AssertState.ElementState
            (
                6, /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; 4 = css selector, selected; case: 5 = xpath, compare strings; case: 6 = xpath, compare numbers; */
                "//*[@id=\"userRule_table\"]/div[3]/table/tbody/tr", /*screen element to search for*/
                null, /* a string to compare for a matching case */
                1 /* a number to compare for a matching case */
            );

            // Checks the SMS box 
            RunTask = Task.Run(() => {

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_ALERTS_SMS_BOX], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    null, /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();

            AssertState.ElementState
            (
                3, /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; 4 = css selector, selected; case: 5 = xpath, compare strings; case: 6 = xpath, compare numbers; */
                GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_ALERTS_SMS_BOX], /*screen element to search for*/
                null, /* a string to compare for a matching case */
                0 /* a number to compare for a matching case */
            );

        } // AlertRulesScreen
    }
}
