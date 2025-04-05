using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.GlobalClasses;

namespace Test.TestClasses
{
    class GetUserId
    {
        public static int UserId;

        public static int InvitedUserId() {

            // forced pause
            System.Threading.Thread.Sleep(60);

            WaitTillExpectedCondition.ElementExistsByCssSelector(TestData.TestKeyValues[TestData.KeyWords.USER_ID], BandwidthCheck.DownloadRate * 2);

            UserId = Convert.ToInt32(WaitTillExpectedCondition.ExpectedElement.Text);

            Console.WriteLine("User ID is " + UserId.ToString());

            return UserId;
                
        } //InvitedUserId

    }
}
