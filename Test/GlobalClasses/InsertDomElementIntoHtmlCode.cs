using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.GlobalClasses
{
    class InsertDomElementIntoHtmlCode
    {

        // Creates a new div inside the DOM
        public static void CreateDomElement ( string Message_, IWebElement DomElementToAttachTo_, bool FlagToDeterminateColor_ ) {

            string PopupColor = "";

            if (FlagToDeterminateColor_) {

                PopupColor = "#94f736"; // "green"; // 

            } 
            else 
            {

                PopupColor = "#f77036"; //"red"; //
                    
            } //if

            ((IJavaScriptExecutor)Procedure.webDriver).ExecuteScript
                (

                    "var htmlElements = arguments[0];"
                    + "htmlElements.innerHTML += \" <div id=\'TestResultDisplay\' style=\'position:absolute;top:50%;left:50%;"
                    + "transform:translate(-50%,-50%); width:50%;height:auto;"
                    + "display:inline-block;z-index:10;padding: 5px 5px 5px 5px;"
                    + "box-shadow: 2px 2px 7px #999999;text-align: center;"
                    + "font-weight:bold;background-color:" + PopupColor + "\'>" + Message_ + "</div>\";"
                    , DomElementToAttachTo_
        
                );//JavascriptExecutor

        }//CreateDomElement

    }
}
