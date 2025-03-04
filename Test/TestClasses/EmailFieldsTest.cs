using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace Test.TestClasses
{
class EmailFieldsTest
{
        static readonly string[] emailEmpty = new[] { GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_EMAIL], " ", "//*[@id=\"details\"]/div/div[2]/table/tbody/tr[1]/td[2]/span", "Email is required" /*"Please enter a valid Email"*/ };
        static readonly string[] verifyEmailEmpty = new[] { GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_VERIFY_EMAIL], " ", "//*[@id=\"details\"]/div/div[2]/table/tbody/tr[2]/td[2]/span", "Verify Email is required" /*"Please enter a valid Email"*/ };
        static readonly string[] invalidEmail = new[] { GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_EMAIL], "croco-mail", "//*[@id=\"details\"]/div/div[2]/table/tbody/tr[1]/td[2]/span", "Please enter a valid Email" };
        static readonly string[] invalidVerifyEmail = new[] { GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_VERIFY_EMAIL], "coco-mail", "//*[@id=\"details\"]/div/div[2]/table/tbody/tr[2]/td[2]/span", "Email must be identical" };
        static readonly string[] emailLowercase = new[] { GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_EMAIL], "sergeyr@nayax.com", "//*[@id=\"details\"]/div/div[2]/table/tbody/tr[1]/td[2]/span", "" };
        static readonly string[] verifyEmailLowercase = new[] { GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_VERIFY_EMAIL], "SERGEYR@nayax.com", "//*[@id=\"details\"]/div/div[2]/table/tbody/tr[2]/td[2]/span", "" };

        static readonly string[][] emailValidationData = new[] { emailEmpty, verifyEmailEmpty, invalidEmail, invalidVerifyEmail, emailLowercase, verifyEmailLowercase };

        static Task RunTask;

        [Obsolete]
        public static void UserEmails() {

            for (int i = 0; i < emailValidationData.Length; i++) {

                // searches for the input email field
                GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(emailValidationData[i][0], Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate));

                // clicks it
                GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Click();

                // clearing a field
                GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Clear();

                // sends keys
                GlobalClasses.WaitTillExpectedCondition.ExpectedElement.SendKeys(emailValidationData[i][1]);

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 60));

                // clicks outside the field
                Procedure.webDriver.FindElement(By.XPath("//*[@id=\"details\"]/div/div[2]/div")).Click(); 

                // warning messages test
                if (emailValidationData[i][2] != null) {

                    try {

                        // forced pause
                        System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 60));

                        // searches for a warning message
                        GlobalClasses.WaitTillExpectedCondition.ElementExistsByXpath(emailValidationData[i][2], Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 20));


                        /////// Compare warning messages ///////
                        RunTask = Task.Run(() => {

                            AssertState.ElementState
                            (
                                5, /* case: 1 = xpath, deselected; 2 = css selector, deselected; case: 3 = xpath, selected; case: 4 = css selector, selected; case: 5 = xpath, compare strings; */
                                GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Text, /* string displayed */
                                emailValidationData[i][3] /* a string to compare for a matching case */
                            );

                        });
                        RunTask.Wait();

                        Console.WriteLine("A warning is displayed: " + GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Text);

                    }
                    catch (NoSuchElementException)
                    {

                        // if a warning isn't found
                        Console.WriteLine("\"" + emailValidationData[i][2] + "\" warning isn't displayed.");

                    } 
                    catch (StaleElementReferenceException sex)
                    {

                        RunTask = Task.Run(() => {

                            GlobalClasses.ScreenElementSearch.SearchForElement
                            (
                                1, /*case: 1 = css selector, 2 = xpath*/
                                emailValidationData[i][2], /*screen element to search for*/
                                true, /*is iframe?*/
                                GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.INVITE_USER_IFRAME], /*iframe's xpath*/
                                null, /*menu entry's xpath*/
                                null /*keys to send*/
                            );

                        });
                        RunTask.Wait();

                        // if a warning isn't found
                        Console.WriteLine("Stale Element Exception:\n" + sex);

                    }//try

                }//if
            
            }//for 

        }// UserEmailFields

    }
}
