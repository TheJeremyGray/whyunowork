using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ConsoleApplication6.EgusReference;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            DateTime AfterRightNow = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0, 0));
            DateTime BeforeRightNow = DateTime.Now.Subtract(new TimeSpan(100, 0, 0, 0, 0));

            string username = "";
            string password = "";
            string url = "";

            NetworkCredential MyNetworkCredential = new NetworkCredential(username, password);
            object[] MyItems = new object[] { new DateTime(BeforeRightNow.Year, BeforeRightNow.Month, BeforeRightNow.Day), new DateTime(AfterRightNow.Year, AfterRightNow.Month, AfterRightNow.Day) };


            // WCF Party Request
            EgusReference.ItemsChoiceType2[] MyItemNames2 = new EgusReference.ItemsChoiceType2[] { EgusReference.ItemsChoiceType2.fromDate, EgusReference.ItemsChoiceType2.toDate };
            EgusReference.EGUSPartyRequest wcf_party_request = new EgusReference.EGUSPartyRequest() { Items = MyItems, ItemsElementName = MyItemNames2 };

            using (EgusReference.EGUSReferenceClient proxy = new EGUSReferenceClient())
            {
                proxy.ClientCredentials.UserName.UserName = username;
                proxy.ClientCredentials.UserName.Password = password;
                var WCFResults = proxy.EGUSParty(wcf_party_request);
            }
           
        }
    }
}
