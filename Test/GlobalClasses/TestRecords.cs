using System;
using System.IO;

namespace Test.GlobalClasses
{
    class TestRecords
    {
        public static string PathToLogFile = @"C:\Users\sergeyr\sergey_workspace\Nayax_TestSet\Nayax_TestSet\TestReports\TestLog.txt";

        public static StreamWriter StreamWriter_;

        public static object _lockObject = new object();


        // creates a log file
        public static void CreateTestLogFile()
        {
            // creates a file
            StreamWriter_ = File.CreateText(PathToLogFile);

            // forced pause to let a file be created
            System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate));

            // closes the stream
            StreamWriter_.Close();

            // timestamp
            string TimeStamp = DateTime.Now.ToLocalTime().ToString();

            // writes a header
            lock (_lockObject) {

                if (File.Exists(PathToLogFile))
                {

                    File.AppendAllText(
                        PathToLogFile,
                        "\n------------------------------------------------------------------------------\n"
                        + "   TEST REPORT at " + TimeStamp
                        + "\n------------------------------------------------------------------------------\n\n\n"
                    );
                }
                else
                {

                    System.Console.WriteLine("<<<    File " + PathToLogFile + " was not found    >>>");

                }//if

            }//lock

        }//CreateTestLogFile


        // writes a record into the log file
        public static string FinalRecord_;
        public static string WriteTestRecordToLog( string Record_ )
        {
            lock (_lockObject) {

                File.AppendAllText(PathToLogFile, Record_ + "\n");

            }//lock

            FinalRecord_ = Record_;

            return FinalRecord_;

        }//CreateTestLogFile

    }
}
