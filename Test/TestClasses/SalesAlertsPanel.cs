using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.TestClasses
{
    class SalesAlertsPanel
    {

        static Task RunTask;

        // schedules and their elements to search for
        static readonly Dictionary<string, string> schedules = new Dictionary<string, string>
        {
            { "Schedule Sales Summary", "//*[@id=\"grid_DailyReportWeekDays\"]/table/tbody/tr[2]/td[2]/input" },
            { "Schedule Machine Alerts Reports", "//*[@id=\"__BVID__232\"]" },
            { "//*[@id=\"__BVID__232\"]/option[11]", "//*[@id=\"treeReports_0\"]/a/input" }
        };

        [Obsolete]
        public static void SalesAlertsScreen()
        {
            for (int i = 0; i < schedules.Count; i++)
            {
                Console.WriteLine(schedules.Keys.ElementAt(i) + " : " + schedules[schedules.Keys.ElementAt(i)]);

                // searches for the schedule links
                RunTask = Task.Run(() => {

                    if ( i < 2 ) {

                        GlobalClasses.WaitTillExpectedCondition.ElementExistsByPartialLinkText(schedules.Keys.ElementAt(i), 60);

                    } else {

                        GlobalClasses.WaitTillExpectedCondition.ElementExistsByXpath(schedules.Keys.ElementAt(i), 60);

                    } // if

                });
                RunTask.Wait();

                // clicks the schedule links
                GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();


                // searches for the schedule elements
                RunTask = Task.Run(() => {

                    GlobalClasses.WaitTillExpectedCondition.ElementDisplayedByXpath(schedules[schedules.Keys.ElementAt(i)], 60);

                });
                RunTask.Wait();

                // clicks the schedule elements
                GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();

                /////// Validates elements' state ///////
                RunTask = Task.Run(() => {

                    if (i != 1) {

                        AssertState.ElementState
                        (
                            3, /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; 4 = css selector, selected; case: 5 = xpath, compare strings; */
                            schedules[schedules.Keys.ElementAt(i)], /*screen element to search for*/
                            null, /* a string to compare for a matching case */
                            0 /* a number to compare for a matching case */
                        );

                    } else if ( i == schedules.Count ) {

                        AssertState.ElementState
                        (
                            3, /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; 4 = css selector, selected; case: 5 = xpath, compare strings; case: 6 = xpath, compare numbers; */
                            schedules[schedules.Keys.ElementAt(i)], /*screen element to search for*/
                            null, /* a string to compare for a matching case */
                            0 /* a number to compare for a matching case */
                        );

                    } else {

                        // searches for a drop menu hour setting option
                        GlobalClasses.WaitTillExpectedCondition.ElementExistsByXpath(schedules.Keys.ElementAt(i + 1), Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 20));

                        AssertState.ElementState
                        (
                            5, /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; 4 = css selector, selected; case: 5 = xpath, compare strings; case: 6 = xpath, compare numbers; */
                            GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Text, /*screen element to search for*/
                            "09:00", /* a string to compare for a matching case */
                            0 /* a number to compare for a matching case */
                        );

                    } // if

                });
                RunTask.Wait();

            } // for

        } // SalesAlertsScreen
    }
}
