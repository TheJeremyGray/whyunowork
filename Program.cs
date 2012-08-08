using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using ConsoleApplication6.EgusReference;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime AfterRightNow = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0, 0));
            DateTime BeforeRightNow = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0, 0));

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


            // Web Reference Request
            WebReference.ItemsChoiceType2[] MyItemNames3 = new WebReference.ItemsChoiceType2[] { WebReference.ItemsChoiceType2.fromDate, WebReference.ItemsChoiceType2.toDate };
            WebReference.EGUSPartyRequest web_reference_request = new WebReference.EGUSPartyRequest() { Items = MyItems, ItemsElementName = MyItemNames3 };

            using (WebReference.EGUSReference web_proxy = new WebReference.EGUSReference { Url = url, Credentials = MyNetworkCredential }) //, PreAuthenticate = true, UnsafeAuthenticatedConnectionSharing = true 
            {
                var r3 = web_proxy.EGUSParty(web_reference_request);
            }
       

            //EgusReference.EGUSReference r = new EgusReference.EGUSReference() { Url = url, Credentials = MyNetworkCredential, PreAuthenticate = true, UnsafeAuthenticatedConnectionSharing = true };

            //
            //var r3 = r.EGUSParty(r2);

            //r.Dispose();

        }
    }
}
