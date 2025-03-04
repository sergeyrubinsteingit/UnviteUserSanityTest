using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.GlobalClasses
{
    class SwitchToOldDcs
    {

        static Task RunTask;

        public static Actions Actions_ = new Actions(Procedure.webDriver);

        public static object SwitchToOldDcsUi() {

            System.Console.WriteLine("<<<<<<<<< SwitchToOldDcsUi begins >>>>>>>>>");

            RunTask = Task.Run(() => {

                //search for the filter container
                GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.FILTER_CONTAINER],
                    GlobalClasses.BandwidthCheck.DownloadRate * (int)(GlobalClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // gets background color of the container
            string ContainerBackgroundColor = GlobalClasses.WaitTillExpectedCondition.ExpectedElement.GetCssValue("background-color");

            System.Console.WriteLine("Container's color:" + ContainerBackgroundColor);

            // if the color is of the new ui, switches to the old version
            if (ContainerBackgroundColor.Equals("rgba(67, 67, 67, 1)")) {

                RunTask = Task.Run(() => {

                    //search for the theme icon
                    GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.MENU_THEME_ICON],
                        GlobalClasses.BandwidthCheck.DownloadRate * (int)(GlobalClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();

                // clicks the icon
                Actions_.MoveToElement(GlobalClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();


                RunTask = Task.Run(() => {

                    //search for the popup closing icon
                    GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.CLOSE_POPUP],
                        GlobalClasses.BandwidthCheck.DownloadRate * (int)(GlobalClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();

                // clicks the closing icon
                Actions_.MoveToElement(GlobalClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();


                RunTask = Task.Run(() => {

                    //search for the filter container again
                    GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.FILTER_CONTAINER],
                        GlobalClasses.BandwidthCheck.DownloadRate * (int)(GlobalClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();

                // gets background color of the container
                ContainerBackgroundColor = GlobalClasses.WaitTillExpectedCondition.ExpectedElement.GetCssValue("background-color");

                // verifies if the color had been changed
                if (!ContainerBackgroundColor.Equals("rgba(67, 67, 67, 1)"))
                {

                    return true;

                }
                else {

                    System.Console.WriteLine("Failed to switch version. The test is shut down");
                    Procedure.webDriver.Quit();
                    System.Environment.Exit(0);

                } //if


            } //if

            return false;

        } // SwitchToOldDcsUi

    }
}
