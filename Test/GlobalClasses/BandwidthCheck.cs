using System;
using System.Net;
using System.Diagnostics;

namespace Test.GlobalClasses
{
    class BandwidthCheck
    {
        public static int DownloadRate = 0;

        public static double Coefficient_ = 0;

        public static int RunBandwidthCheck()
        {

            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            // Download data
            var webClient = new WebClient();

            int count_ = 0;

            for (int i = 0; i < 10; i++)
            {

                try
                {
                    webClient.DownloadFile("https://media.geeksforgeeks.org/wp-content/uploads/gfg-40.png", "gfg-40.png");
                }
                catch (Exception)
                {

                    System.Console.WriteLine("Image is not found to measure downloading rate: \"gfg - 40.png\"");
                    throw;
                }

                Stopwatch.Stop();

                // download rate
                DownloadRate = Convert.ToInt32(Stopwatch.Elapsed.TotalMilliseconds);

                // forced pause
                System.Threading.Thread.Sleep(50);

            } //for



            // coefficient
            if (DownloadRate >= 1000) { Coefficient_ = 0.1; } else { Coefficient_ = 100; }

            System.Console.WriteLine("<<<<<<<<< DownloadRate: " + DownloadRate.ToString() + " millisec. >>>>>>>>>");

            return DownloadRate;
        }

    }
}
