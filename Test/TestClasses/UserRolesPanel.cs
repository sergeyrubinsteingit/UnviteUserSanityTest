using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.GlobalClasses;

namespace Test.TestClasses
{
    class UserRolesPanel
    {
        static Task RunTask;

        [Obsolete]
        public static void UserRoles() {

            /////// User role checking the box ///////
            RunTask = Task.Run(() => {

                ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    TestData.TestKeyValues[TestData.KeyWords.INVITE_USER_ADMIN_ROLE], /*screen element to search for*/
                    true, /*is iframe?*/
                    TestData.TestKeyValues[TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    null, /*keys to send*/
                    true /*click the element*/
                );

            });
            RunTask.Wait();

            /////// Checks if the user role in the hierarchy is unchecked ///////
            RunTask = Task.Run(() => {

                AssertState.ElementState
                (
                    1,  /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; case: 4 = css selector, selected; case: 5 = xpath, compare strings; */
                    TestData.TestKeyValues[TestData.KeyWords.INVITE_USER_ADMIN_ROLE], /*screen element to search for*/
                    null, /*a string to compare for a matching case*/
                    0 /* a number to compare for a matching case */
                );

            });
            RunTask.Wait();


        } // UserRoles

    }
}
