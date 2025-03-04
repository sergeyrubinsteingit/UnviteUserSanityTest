using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test.GlobalClasses
{
    public class LoginToDcs
    {


        public static void LoginFlow()
        {
            Task RunTask;

            // TEMPORARY COMMENTED

            //RunTask = Task.Run(() => {

            //    // Sends SQL query to set user status to zero
            //    TestRelatedClasses.SetUserStatusToZero.UpdateUserStatusToZero();

            //});
            //RunTask.Wait();


            RunTask = Task.Run(() => {

                // gets a bandwidth rate
                GlobalClasses.BandwidthCheck.RunBandwidthCheck();

            });
            RunTask.Wait();


            string[] CredentialsId = {

                GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.USER_MAIL_INPUT],
                GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.USER_PASS_INPUT],
                GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.SIGNIN_BUTTON],

            };

            string[] CredentialsValue = {

                GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.USER_NAME],
                GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.PASS_QA]

            };


            int i;

            for (i = 0; i < CredentialsId.Length; i++)
            {

                RunTask = Task.Run(() =>
                {
                    // find element
                    _ = GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(CredentialsId[i], 120);

                });

                RunTask.Wait();

                if (i < CredentialsId.Length - 1) {

                    // insert into text fields
                    GlobalClasses.WaitTillExpectedCondition.ExpectedElement.SendKeys(CredentialsValue[i]);

                } else {

                    // click sign in button
                    GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();

                }

            }//for

        }
    }
}
