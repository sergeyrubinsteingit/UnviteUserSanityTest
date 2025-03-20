using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace Test.TestClasses
{
    class NextPreviousButtons
    {
        static Task RunTask;

        [Obsolete]
        public static void ClickNextPreviousButton(bool isFrame, bool isInvite) {

            // to distinguish between Next and Invite buttons
            string[] buttonSelectors;

            if (isInvite) {

                buttonSelectors = new[] {
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_NEXT_BUTTON],
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_INVITE_BUTTON]
                };

            }
            else {

                buttonSelectors = new[] {
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_NEXT_BUTTON],
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_PREVIUOS_BUTTON],
                    GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_NEXT_BUTTON]
                };

            };//if

            for (int i = 0; i < buttonSelectors.Length; i++) {

                try {

                    RunTask = Task.Run(() => {

                        GlobalClasses.ScreenElementSearch.SearchForElement
                        (
                            1, /*case: 1 = css selector, 2 = xpath*/
                            buttonSelectors[i], /*screen element to search for*/
                            true, /*is iframe?*/
                            GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                            null, /*menu entry's xpath*/
                            null, /*keys to send*/
                            true /*click the element*/
                        );

                    });
                    RunTask.Wait();

                }
                catch (NoSuchElementException) {

                    continue;

                };//try

            }//for

        }// ClickNextPreviousButtons

    }

}
