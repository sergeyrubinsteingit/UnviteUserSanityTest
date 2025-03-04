using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Test.TestClasses
{
    class AssertState
    {
        static IWebElement elementToCheck = null;

        public static IWebElement ElementState(int case_, string selector_, string textToCompare_) {

            // check if an element is unchecked
            try
            {
                switch (case_) {

                    case 1:

                        elementToCheck = Procedure.webDriver.FindElement(By.XPath(selector_));

                        Assert.IsFalse(elementToCheck.Selected); // is deselected

                        Console.WriteLine("Element " + elementToCheck + " is deselected.");

                        break;

                    case 2:

                        elementToCheck = Procedure.webDriver.FindElement(By.CssSelector(selector_));

                        Assert.IsFalse(elementToCheck.Selected); // is deselected

                        Console.WriteLine("Element " + elementToCheck + " is deselected.");

                        break;

                    case 3:

                        elementToCheck = Procedure.webDriver.FindElement(By.XPath(selector_));

                        Assert.IsTrue(elementToCheck.Selected); // is selected

                        Console.WriteLine("Element " + elementToCheck + " is selected.");

                        break;

                    case 4:

                        elementToCheck = Procedure.webDriver.FindElement(By.CssSelector(selector_));

                        Assert.IsTrue(elementToCheck.Selected); // is selected

                        Console.WriteLine("Element " + elementToCheck + " is selected.");

                        break;

                    case 5:

                        elementToCheck = Procedure.webDriver.FindElement(By.PartialLinkText(selector_));

                        Assert.Equals(
                            selector_ = Regex.Replace(selector_, @"\s", "").ToLower(),
                            textToCompare_ = Regex.Replace(textToCompare_, @"\s", "").ToLower()
                        ); // is text matches

                        Console.WriteLine("Text matches:" + selector_);

                        break;

                    default:

                        Environment.Exit(-1);

                        throw new Exception("Failed to find an element" + selector_ + ". The test is shut down.");

                };

            }
            catch (Exception e)
            {

                Environment.Exit(-1);

                throw new Exception("Failed to proceed the element " + elementToCheck + ". The test is shut down.\nTrace:\n" + e);

            }//try

            return elementToCheck;

        }//elementState

    }
}
