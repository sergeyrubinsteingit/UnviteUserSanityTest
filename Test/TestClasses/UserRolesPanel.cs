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

                GlobalClasses.ScreenElementSearch.SearchForElement
                (
                    2, /*case: 1 = css selector, 2 = xpath*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_ADMIN_ROLE], /*screen element to search for*/
                    true, /*is iframe?*/
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                    null, /*menu entry's xpath*/
                    null /*keys to send*/
                );

            });
            RunTask.Wait();

            /////// Checks if the user role in the hierarchy is unchecked ///////
            RunTask = Task.Run(() => {

                AssertState.elementState
                (
                    1,  /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; 4 = css selector, selected; */
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_ADMIN_ROLE], /*screen element to search for*/
                    null /*a string to compare for a matching case*/
                );

            });
            RunTask.Wait();


        }// CheckElements

    }
}
