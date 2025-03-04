using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading.Tasks;


namespace Test.GlobalClasses
{
    class ScreenShotsTaker
    {
        // path to the screenshot directory
        static string ShotDirectoryPath = @"C:\Users\sergeyr\sergey_workspace\Nayax_TestSet\Nayax_TestSet\Screenshots\";

        static Task RunTask;

        public static string RecordForHtmlReport = "";


        // creates screenshot directory
        public static void CreateShotsDirectory()
        {

            try
            {

                RunTask = Task.Run(() => {

                    // Deletes a directory if it exists
                    if (Directory.Exists(ShotDirectoryPath)) Directory.Delete(ShotDirectoryPath, true);//if

                    // creates the directory
                    DirectoryInfo DirectoryInfo_ = Directory.CreateDirectory(ShotDirectoryPath);

                });//RunTask

            }
            catch (Exception e)
            {

                Console.WriteLine("Directory creation failed: {0}. System is shut down.", e.ToString());
                System.Environment.Exit(0);
                Procedure.webDriver.Quit();
                return;

            }
            finally
            {

                Console.WriteLine("Screenshots directory had been successflly created");

            }//try

        }// CreateShotsDirectory


        // Screenshot taker
        [Obsolete]
        public static void TakeScreenShot(string ShotName, IWebElement elementToScroll_)
        {

            System.Console.WriteLine("<<<<< TakeScreenShot begins >>>>>");

            RunTask = Task.Run(() => {

                // to prevent dividing to zero
                long NumberOfShots;

                if (GlobalClasses.GetElementDimensions.OffsetHeight_ != 0)
                { NumberOfShots = GlobalClasses.GetElementDimensions.ScrollHeight_ / GlobalClasses.GetElementDimensions.OffsetHeight_; }
                else
                { NumberOfShots = 1; }//if

                // to avoid a discrepancy in loop
                if (NumberOfShots == 0) NumberOfShots = 1; //if

                // a scroll step
                double ScrollStep = 0;

                // timestamp for a shot's name
                string Timestamp_ = "";

                for (int i = 0; i < NumberOfShots; i++)
                {

                    // sets a timestamp
                    Timestamp_ = DateTime.Now.ToString("HH-mm-ss-ffff");

                    // add here a scroll on one element's client height. If there is none, it should be Body to scroll
                    ((IJavaScriptExecutor)Procedure.webDriver).ExecuteScript("arguments[0].scrollTo(0," + ScrollStep + ");", elementToScroll_);

                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 10));

                    // takes a screenshot
                    Screenshot ScreenShot = ((ITakesScreenshot)Procedure.webDriver).GetScreenshot();

                    // saves the screenshot
                    ScreenShot.SaveAsFile(string.Format("{0}\\{1}", ShotDirectoryPath, ShotName + Timestamp_ + ".png"));
                    //ScreenShot.SaveAsFile(string.Format("{0}\\{1}", ShotDirectoryPath, ShotName + Timestamp_ + ".png"), format: ScreenshotImageFormat.Png);

                    // a record in html report
                    RecordForHtmlReport += "<img class=\"TestScreenShots\" src=\"" + ShotDirectoryPath + ShotName + Timestamp_ + ".png" + "\" onClick=\"javascript:EnlargeImage(this.src);\" />";

                    // increasing step
                    ScrollStep += GlobalClasses.GetElementDimensions.OffsetHeight_;

                }//for

            });//RunTask
            RunTask.Wait();

        }//TakeScreenShot


        // Draws a border by CSS selector
        public static void DrawBorderAroundElementByCssSelector(string SelectorType, string Selector_, string SingleOrPlural_, string ItemIndex_)
        {

            RunTask = Task.Run(() => {

                System.Console.WriteLine("\n\n<<<<<<< Draw border JS: document.getElement" + SingleOrPlural_ + "By" + SelectorType + "(\"" + Selector_ + "\")" + ItemIndex_ + ".style.border=\"2px solid " + Asserts.TestReportFontColor + "\" >>>>>>\n\n");

                ((IJavaScriptExecutor)Procedure.webDriver).ExecuteScript("document.getElement" + SingleOrPlural_ + "By" + SelectorType + "(\"" + Selector_ + "\")" + ItemIndex_ + ".style.border=\"2px solid " + Asserts.TestReportFontColor + "\"");

            });//RunTask

        }//DrawBorderAroundElementByCssSelector



        // Draws a border by Xpath
        public static void DrawBorderAroundElementByXpath(string Xpath_)
        {
            System.Console.WriteLine("\n\nDrawBorderAroundElementByXpath:\ndocument.evaluate(\"" + Xpath_ + "\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).style.border=\"2px solid " + Asserts.TestReportFontColor + "\"\"" + "\n\n\n");

            RunTask = Task.Run(() => {

                ((IJavaScriptExecutor)Procedure.webDriver).ExecuteScript("document.evaluate(\"" + Xpath_ + "\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).style.border=\"2px solid " + Asserts.TestReportFontColor + "\"\"");

            });//RunTask

        }//DrawBorderAroundElementByCssSelector

    }
}
