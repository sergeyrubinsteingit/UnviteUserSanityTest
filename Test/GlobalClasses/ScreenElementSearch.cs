using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace Test.GlobalClasses
{
    class ScreenElementSearch
    {
        // screen element to return
        public static IWebElement RequiredElement;

        static Task RunTask;

        [Obsolete]
        public static IWebElement SearchForElement(int case_, string elementSelector, bool isIframe, 
            string iframeXpath, string DropMenuEntry, string KeysToSend, bool clickIt) {

            // initializing
            RequiredElement = null;

            // searches for the element
            RunTask = Task.Run(() => {

                _ = StaleElementCase.StaleElementSearch(case_, elementSelector, isIframe, iframeXpath);

            });
            RunTask.Wait();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 10));

            // clicks the element
            if (clickIt) StaleElementCase.ExpectedStaleElement.Click();

            // fills in the element's field
            if (KeysToSend != null) StaleElementCase.ExpectedStaleElement.SendKeys(KeysToSend);

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 101));

            // clicks the element's name in the drop menu
            if (DropMenuEntry != null) Procedure.webDriver.FindElement(By.XPath(DropMenuEntry)).Click();

            RequiredElement = StaleElementCase.ExpectedStaleElement;

            return RequiredElement;

        }//SearchForElement

    }
}
