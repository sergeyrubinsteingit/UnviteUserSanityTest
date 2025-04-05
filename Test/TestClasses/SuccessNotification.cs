using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace Test.TestClasses
{
    class SuccessNotification
    {

        public static IWebElement CheckSuccessNotification() {

            // counter
            int count_ = 0;

            try
            {

                // forced pause
                System.Threading.Thread.Sleep(60);

                GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.NOTIF_SUCCESS], GlobalClasses.BandwidthCheck.DownloadRate * 2);

                Console.WriteLine("Success notification is displayed. The test passed.");

            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverException)
            {
                // forced pause
                System.Threading.Thread.Sleep(60);

                GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.NOTIF_SUCCESS], GlobalClasses.BandwidthCheck.DownloadRate * 2);

                Console.WriteLine("Success notification is displayed. The test passed.");

                count_++;

                if (count_ > 1000)
                {

                    Procedure.webDriver.Quit();

                    throw new Exception("Success notification wasn't found. The test failed.");

                };//if

                };//try


            // object to find
            //IWebElement objectToFind;

            //// searches for the notification
            //    do
            //    {

            //        GlobalClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GlobalClasses.TestData.TestKeyValues[GlobalClasses.TestData.KeyWords.NOTIF_SUCCESS], GlobalClasses.BandwidthCheck.DownloadRate * 2);

            //        objectToFind = GlobalClasses.WaitTillExpectedCondition.ExpectedElement;

            //        Console.WriteLine("A search for the Success notification");

            //        // forced pause
            //        System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate));

            //        count_++;

            //        if (count_ > 33) {

            //            Procedure.webDriver.Quit();

            //            throw new Exception("Success notification wasn't found. The test failed.");

            //        } // if

            //    } while (objectToFind == null);

            return GlobalClasses.WaitTillExpectedCondition.ExpectedElement;

        }//CheckSuccessNotification

    }
}
