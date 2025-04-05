using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Outlook_ = Microsoft.Office.Interop.Outlook;

namespace Test.TestClasses
{
    class OutlookUserInvitation
    {
        public static string LoginUrl = "";

        public static Outlook_.Application ProceedInvitationLink(bool isDetailed)
        {
            try
            {

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 444));

                // Create the Outlook application, in-line initialization
                Microsoft.Office.Interop.Outlook.Application OutlookApp = new Outlook_.Application();

                // Get the MAPI namespace
                Outlook_.NameSpace OutlookNameSpace = OutlookApp.GetNamespace("mapi");

                // Log on by using the default profile or existing session (no dialog box)
                OutlookNameSpace.Logon(Missing.Value, Missing.Value, false, true);

                // Get the Inbox folder > Nayax_User_Invitations subfolder
                Outlook_.MAPIFolder InboxSubfolder = OutlookNameSpace.GetDefaultFolder(Outlook_.OlDefaultFolders.olFolderInbox).Folders["Nayax_User_Invitations"];

                // Get the Items collection in the Inbox folder.
                Outlook_.Items SubfolderItems = InboxSubfolder.Items;

                // Get the first message by subject
                Outlook_.MailItem FirstMessage;

                // Waiting for the first message // System.NullReferenceException:
                do
                {
                    // Get the first message by subject
                    FirstMessage = (Outlook_.MailItem)SubfolderItems.Find("[Subject] = Nayax User Invitation");

                    Console.WriteLine("First Message is not found. ");

                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GlobalClasses.BandwidthCheck.DownloadRate * 15));

                } while (FirstMessage == null);


                LoginUrl = Regex.Match(FirstMessage.Body.ToString(), @"Log in now <(.+?)>").Groups[1].Value;

                Console.WriteLine(LoginUrl);

                // just in case we want to see some mail details
                if (isDetailed)
                {

                    //Check for attachments
                    int AttachCnt = FirstMessage.Attachments.Count;
                    Console.WriteLine("Attachments: " + AttachCnt.ToString());

                    //some common properties.
                    Console.WriteLine(FirstMessage.Subject);
                    Console.WriteLine(FirstMessage.SenderName);
                    Console.WriteLine(FirstMessage.ReceivedTime);

                    //Attachments' listing
                    if (AttachCnt > 0)
                    {
                        for (int i = 1; i <= AttachCnt; i++) Console.WriteLine(i.ToString() + "-" + FirstMessage.Attachments[i].DisplayName);
                    }//if

                    //Display the Outlook window
                    FirstMessage.Display(true); //modal

                };//if

                //Log off.
                OutlookNameSpace.Logoff();

                //Explicitly release objects.
                FirstMessage = null;
                SubfolderItems = null;
                InboxSubfolder = null;
                OutlookNameSpace = null;
                OutlookApp = null;
            }

            //Error handler.
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught: ", e);
            }

            // Return value.
            return null;

        }



        public static Outlook_.Application DeleteExistingMails()
        {
            try
            {
                // Create the Outlook application, in-line initialization
                Microsoft.Office.Interop.Outlook.Application OutlookApp = new Outlook_.Application();

                // Get the MAPI namespace
                Outlook_.NameSpace OutlookNameSpace = OutlookApp.GetNamespace("mapi");

                // Log on by using the default profile or existing session (no dialog box)
                OutlookNameSpace.Logon(Missing.Value, Missing.Value, false, true);

                // Get the Inbox folder > Nayax_User_Invitations subfolder
                Outlook_.MAPIFolder InboxSubfolder = OutlookNameSpace.GetDefaultFolder(Outlook_.OlDefaultFolders.olFolderInbox).Folders["Nayax_User_Invitations"];

                // Get the Items collection in the Inbox folder.
                Outlook_.Items SubfolderItems = InboxSubfolder.Items;

                // deletes all the messages found in this folder
                foreach (Outlook_.MailItem item in SubfolderItems) { item.Delete(); }//foreach

                //Log off.
                OutlookNameSpace.Logoff();

                //Explicitly release objects.
                //FirstMessage = null;
                SubfolderItems = null;
                InboxSubfolder = null;
                OutlookNameSpace = null;
                OutlookApp = null;

            }
            //Error handler.
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught: ", e);
            }

            // Return value.
            return null;

        }


    }
}