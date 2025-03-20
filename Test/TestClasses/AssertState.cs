using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Test.TestClasses
{
    class AssertState
    {
        static IWebElement elementToCheck = null;

        public static IWebElement ElementState(int case_, string selector_, string textToCompare_, int expectedNumber) {

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

                        elementToCheck = GlobalClasses.WaitTillExpectedCondition.ExpectedElement;

                        Console.WriteLine("Element text: " + GlobalClasses.WaitTillExpectedCondition.ExpectedElement.Text
                            + "; Text to compare: " + textToCompare_);

                        Assert.AreEqual(
                            selector_ = Regex.Replace(selector_, @"\s", "").ToLower(),
                            textToCompare_ = Regex.Replace(textToCompare_, @"\s", "").ToLower()
                        ); // is text matches

                        Console.WriteLine("Text matches: " + selector_);

                        break;

                    case 6:

                        Console.WriteLine("Elements to count: " + Procedure.webDriver.FindElements(By.XPath(selector_)).Count);

                        elementToCheck = Procedure.webDriver.FindElements(By.XPath(selector_))[0];

                        int countedNumber = Procedure.webDriver.FindElements(By.XPath(selector_)).Count; 

                        Assert.AreEqual( (Int64)expectedNumber, (Int64)countedNumber ); // are numbers match

                        Console.WriteLine("Numbers match.  Expected number: " + expectedNumber + ", Counted number: " + countedNumber);

                        break;

                    default:

                        Procedure.webDriver.Quit();

                        throw new Exception("Failed to find an element" + selector_ + ". The test is shut down.");

                };

            }
            catch (Exception e)
            {

                Procedure.webDriver.Quit();

                throw new Exception("Failed to proceed the element " + elementToCheck + ". The test is shut down.\nTrace:\n" + e);

            }//try

            return elementToCheck;

        }//elementState

    }
}
