using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace Test.GlobalClasses
{
    class SmsOrMomaLogin
	{
		static Task RunTask;
		public static void SmsInputField() {


			RunTask = Task.Run(() => {

				// gets a bandwidth rate
				GlobalClasses.BandwidthCheck.RunBandwidthCheck();

			});
			RunTask.Wait();

			try
			{
				RunTask = Task.Run(() =>
                {
					// Attempt to find login field of SMS version
					_ = WaitTillExpectedCondition.ElementExistsByCssSelector(TestData.TestKeyValues[TestData.KeyWords.SMS_LOGIN_FIELD], 150);

                });

                RunTask.Wait();

				System.Console.WriteLine("SMS login input is found");

			}
			catch (Exception) {
                try
                {
					RunTask = Task.Run(() =>
					{
                        // Attempt to find login field of MOMA version
                        _ = WaitTillExpectedCondition.ElementExistsByCssSelector(TestData.TestKeyValues[TestData.KeyWords.MOMA_LOGIN_FIELD], 150);

					});

					RunTask.Wait();

					System.Console.WriteLine("MOMA login input is found");

				}
				catch (Exception)
                {
					Procedure.webDriver.Quit();

					throw new Exception("Failed to find SMS/MOMA login input. The test is shut down.");
                }
            }


			RunTask = Task.Run(() =>
			{
				// Opens a dialog to get OTC from user
				UserInputDialogBox.ShowInputDialogBox("", "Insert your OTC here", 400, 100, "User's OTC");
			});

			RunTask.Wait();

			///////
			System.Console.WriteLine("Control: " + WaitTillExpectedCondition.ExpectedElement.GetDomProperty("id"));

            // click in the OTC input field to get it in focus
            WaitTillExpectedCondition.ExpectedElement.Click();

			// forced pause
			System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate));

			WaitTillExpectedCondition.ExpectedElement.SendKeys(UserInputDialogBox.boxInput);

            RunTask = Task.Run(() =>
			{
				// search for Sign in button
				_ = WaitTillExpectedCondition
				.ElementExistsByCssSelector(TestData.TestKeyValues[TestData.KeyWords.SIGNIN_BUTTON], 150);

			});

			RunTask.Wait();

			// Click Sign in button
			WaitTillExpectedCondition.ExpectedElement.Click();

			// control: user OTC
			System.Console.WriteLine(UserInputDialogBox.boxInput);

			// forced pause
			System.Console.WriteLine("<<<<<<<<< DownloadRate: " + GlobalClasses.BandwidthCheck.DownloadRate.ToString() + " millisec. >>>>>>>>>");
			//System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 100));

			RunTask = Task.Run(() =>
			{
				// search for Not Now link
				_ = WaitTillExpectedCondition
				.ElementExistsByCssSelector(TestData.TestKeyValues[TestData.KeyWords.DONT_TRUST_BUTTON], Convert.ToInt32(BandwidthCheck.DownloadRate * 10000));

			});

			RunTask.Wait();

			// forced pause
			System.Console.WriteLine("<<<<<<<<< DownloadRate: " + GlobalClasses.BandwidthCheck.DownloadRate.ToString() + " millisec. >>>>>>>>>");
            System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * BandwidthCheck.Coefficient_));

			//System.Threading.Thread.Sleep(1000);

			// Click Dont Trust button
			WaitTillExpectedCondition.ExpectedElement.Click();

		}// SmsInputField
    }
}
