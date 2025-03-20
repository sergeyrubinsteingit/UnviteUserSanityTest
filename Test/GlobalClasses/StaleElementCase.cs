using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace Test.GlobalClasses
{
    class StaleElementCase
    {
        public static IWebElement ExpectedStaleElement;

        static readonly DefaultWait<IWebDriver> FluentWait = new DefaultWait<IWebDriver>(Procedure.webDriver);

        [Obsolete]
        public static IWebElement StaleElementSearch(int case_, string selector_, bool isIframe, string iframeXpath) {

            ExpectedStaleElement = null;

            int count = 0;

            // for recursion while this flag is true
            bool isStale = true;

            FluentWait.Timeout = TimeSpan.FromSeconds(60);

            FluentWait.PollingInterval = TimeSpan.FromSeconds(5);

            FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            FluentWait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            FluentWait.IgnoreExceptionTypes(typeof(WebDriverException));

            // time counter, milliseconds
            var StopWatch = new Stopwatch();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 1.2));

            // switches to a parent frame to allow a further switch to its children
            //Procedure.webDriver.SwitchTo().ParentFrame();
            Procedure.webDriver.SwitchTo().DefaultContent();

            // in case the element lays within an iframe
            if (isIframe) Procedure.webDriver.SwitchTo().Frame(Procedure.webDriver.FindElement(By.XPath(iframeXpath)));

            try
            {
                while (isStale) {

                    Console.WriteLine("\"StaleElementSearch\" begins, case=" +case_);

                    StopWatch.Start();

                    switch (case_) {

                        case 1:

                            ExpectedStaleElement = FluentWait.Until(_ => Procedure.webDriver.FindElement(By.CssSelector(selector_)));

                            break;

                        case 2:

                            ExpectedStaleElement = FluentWait.Until(_ => Procedure.webDriver.FindElement(By.XPath(selector_)));

                            break;

                        default:

                            throw new Exception("Failed to find an element" + selector_ + ". The test is shut down.");

                    } // switch

                    StopWatch.Stop();

                    // breaks the loop if an element's found
                    isStale = false;

                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 10));

                } // while

            } catch (Exception ex) {

                Console.WriteLine("From the Catch block");
                Console.WriteLine(ex);

                if (ex is StaleElementReferenceException || ex is NoSuchElementException || ex is ElementNotInteractableException) {

                    // continues the cycle
                    isStale = true;

                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 1.2));

                    // counter increase
                    count++;

                    Console.WriteLine("Waiting for element by CSS selector: " + selector_ 
                        + ", time elapsed: " + StopWatch.ElapsedMilliseconds + " milliseconds. The counter = " + count);

                    // quits on repeated failures
                    if (count > 3) {

                        Environment.Exit(-1);

                        throw new Exception("Failed to find an element" + selector_ + ". The test is shut down.");
                    
                    };// if

                } else {

                    Environment.Exit(-1);

                    throw new Exception("Failed to find an element" + selector_ + ". The test is shut down.");

                }// if

            }// try

            return ExpectedStaleElement;

        }// StaleElementSearch

    }
}
