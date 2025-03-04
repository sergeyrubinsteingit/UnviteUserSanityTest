using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.GlobalClasses
{
    class RunTaskAndWait
    {
        private const IWebElement Arg = null;

        static Task RunTask;

        public static void WaitTillFinished(Func<IWebElement> TaskToRun)
        {

            RunTask = Task.Run(() =>
            {
                // Attempt to find login field of SMS version
                TaskToRun();

            });

            RunTask.Wait();


        }//WaitTillFinished

    }
}
