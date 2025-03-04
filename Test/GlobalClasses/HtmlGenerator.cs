using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

namespace Test.GlobalClasses
{
    class HtmlGenerator
    {


        static StringBuilder StringBuilder1_ = new StringBuilder();

        // creates the opening tags of the HTML report file
        public static void CreateHtmlOpeningTags()
        {

            StringBuilder1_.Append("<html><head><meta charset='utf-8'/>");
            StringBuilder1_.Append("<link rel=\"stylesheet\" href=\"C:\\Users\\sergeyr\\sergey_workspace\\Nayax_TestSet\\Nayax_TestSet\\TestReports\\TestReportStyles.css\">");
            // a function to open enlarged image in new popup window
            StringBuilder1_.Append("<script language=\"javascript\">");
            StringBuilder1_.Append("function EnlargeImage(img_src){");
            StringBuilder1_.Append("ScreenshotWindow = window.open('','Test Screenshot','width=900px, height=750px,scrollbars=yes');");
            StringBuilder1_.Append("ScreenshotWindow.document.write('<html><head><link rel=\"stylesheet\" href=\"C:\\Users\\sergeyr\\sergey_workspace\\Nayax_TestSet\\Nayax_TestSet\\TestReports\\TestReportStyles.css\"></head>" 
                                + "<body style=\"background-color:#434343; \">" 
                                + "<input type=\"button\" width=\"150px\" height=\"50px\" onClick=\"javascript:window.close();\" value=\"Close the window\""
                                + "style=\"position:absolute;top:15px;left:15px;background-color:#ffcd00;z-index:5;border: 0px solid #fff;border-radius:25px;cursor:pointer; \">"
                                + "<div style=\"position:absolute;top:0;left:0;width:100%;height:100%;\">"
                                + "<img id=\"EnlargedImage\" src=' + img_src + ' style=\"position:absolute;top:50%;left:50%;transform:translate(-50%,-50%);width:90%;height:auto;"
                                + "display:inline-block;z-index:10;padding: 5px 5px 5px 5px;\"></div></body></html>');");
            StringBuilder1_.Append("} // end of function");
            StringBuilder1_.Append("</script>");
            //
            StringBuilder1_.Append("</head><body style=\"background - color:#434343; \">");
            StringBuilder1_.Append("<br><div id=\"HeaderDiv\"><h2 id=\"reportHeader\">TEST REPORT at " + DateTime.Now.ToLocalTime().ToString() + "</h2></div>");
            StringBuilder1_.Append("<div id=\"container\">");

        }// CreateHtmlOpeningTags


        static string ScreenShotsPath = @"C:\Users\sergeyr\sergey_workspace\Nayax_TestSet\Nayax_TestSet\Screenshots\";
        public static void AppendBlockToHtml(string ScreenShotSource, string TestRecord) {

            StringBuilder1_.Append("<div class=\"TestRecordsCollection\">");

            StringBuilder1_.Append("<div class=\"PictureHolder\">" + ScreenShotSource + "</div>");

            StringBuilder1_.Append("<div class=\"TestRecord\"><span class=\"TestRecordSpan\" style=\"color:" + Asserts.TestReportFontColor + ";\">" + TestRecord + "</span></div>");

            StringBuilder1_.Append("</div>");

        }// AppendBlockToHtml


        // closes HTML report file
        public static void CreateHtmlClosingTags()
        {
            // inserts a path to Streamwriter
            StreamWriter StreamWriter1_ = new StreamWriter(@"C:\Users\sergeyr\sergey_workspace\Nayax_TestSet\Nayax_TestSet\TestReports\TestLogDisplay.html");

            // Last tags
            StringBuilder1_.Append("</div>");
            StringBuilder1_.Append("</body></html>");

            // writes to HTML file
            StreamWriter1_.Write(StringBuilder1_);

            // finishes and closes the stream
            StreamWriter1_.Flush();
            StreamWriter1_.Close();
            StreamWriter1_.Dispose();



        }// CreateHtmlOpeningTags


        public static void CreateApiHtmlReport(string ApiResponse_, string ResponseBody_, string IsSuccess_, string ApiType_)
        {

            string ResponseBackgroundColor = "";
            string ResponseHeaderText = "";
            string ResponseCaptionColor = "";

            // sets background color
            if (IsSuccess_.Equals("OK"))
            {

                ResponseBackgroundColor = "#94f736"; // "green"; // 

                ResponseCaptionColor = "#fff"; // "white"; // 

                ResponseHeaderText = "PASSED";

            }
            else
            {
                ResponseBackgroundColor = "#f77036"; //"red"; //

                ResponseCaptionColor = "#85111d"; // "dark red"; // 
                //
                ResponseHeaderText = "FAILED";

            };//if

            StringBuilder StringBuilder2_ = new StringBuilder();

            // opening tags
            StringBuilder2_.Append("<html><head><meta charset='utf-8'/>");
            StringBuilder2_.Append("<link rel=\"stylesheet\" href=\"C:\\Users\\sergeyr\\sergey_workspace\\Nayax_TestSet\\Nayax_TestSet\\TestReports\\TestReportStyles.css\">");
            StringBuilder2_.Append("</head><body style=\"background-color:#434343; \">");
            StringBuilder2_.Append("<div id=\"container_api\">");

            // content

            StringBuilder2_.Append("<div id=\"ResponseBody\" style=\"background-color:" + ResponseBackgroundColor + "\">");

            StringBuilder2_.Append("<center><h2 style=\"color:" + ResponseCaptionColor + ";\">" + ResponseHeaderText + "</h2></center>");

            StringBuilder2_.Append("<p><h4><bold>Headers</bold></h4>" + ApiResponse_ + "</p>");

            StringBuilder2_.Append("<p><h4><bold>Body</bold></h4>" + ResponseBody_ + "</p>");

            StringBuilder2_.Append("</div>");

            // Last tags
            StringBuilder2_.Append("</div>");
            StringBuilder2_.Append("</body></html>");

            StreamWriter StreamWriter2_ = new StreamWriter(@"C:\Users\sergeyr\sergey_workspace\Nayax_TestSet\Nayax_TestSet\TestReports\" + ApiType_ + ".html");

            // writes to HTML file
            StreamWriter2_.Write(StringBuilder2_);

            // finishes and closes the stream
            StreamWriter2_.Flush();
            StreamWriter2_.Close();
            StreamWriter2_.Dispose();

            // clears Stringbuilder
            StringBuilder2_.Clear();

        } // CreateApiHtmlReport

    }
}
