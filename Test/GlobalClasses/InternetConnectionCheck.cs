using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test.GlobalClasses
{
    class InternetConnectionCheck
    {
        static Task RunTask;

        public static int AvailablePort_;

        public static string AvailablePort()
        {
            System.Console.WriteLine("<<<<< Available port check began >>>>>");

            int StartIndex = 1, EndIndex = 10000;

            IPGlobalProperties IpProperties = IPGlobalProperties.GetIPGlobalProperties();

            IPEndPoint[] TcpEndPoints = IpProperties.GetActiveTcpListeners();

            List<int> PortsInUse = TcpEndPoints.Select(port_ => port_.Port).ToList<int>();

            for (int PortIdx = StartIndex; PortIdx < EndIndex; PortIdx++) {

                if (!PortsInUse.Contains(PortIdx)) {

                    AvailablePort_ = PortIdx;
                    System.Console.WriteLine("Available port: " + AvailablePort_.ToString());
                    ConnectionState(AvailablePort_, TestData.TestKeyValues[TestData.KeyWords.HOST_QA]);
                    break;

                };//if

            }//for

            return AvailablePort_.ToString();

        }//AvailablePort


        // checks connection state
        public static bool ConnectionState(int Port_, string HostUrl) {

            System.Console.WriteLine("<<<<< Connection state check began >>>>>");

            bool ConnectionState = false;

            Ping Ping_ = new Ping();

            try {

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 1.2));

                PingReply PingReply_ = Ping_.Send(HostUrl, Port_);

                if (PingReply_.Status == IPStatus.Success)
                {

                    System.Console.WriteLine("Connectinon to " + HostUrl + " is available on port " + InternetConnectionCheck.AvailablePort_.ToString());
                    return ConnectionState = true;

                }
                else {

                    System.Console.WriteLine("Connectinon to " + HostUrl + " could not be established.\nThe system is shut down.");
                    System.Environment.Exit(-1);

                };//if

            } catch (Exception e) {

                System.Console.WriteLine("From Internet connection check. Exception:\n" + e);
            
            }

            return ConnectionState;
        }//ConnectionState
    }
}
