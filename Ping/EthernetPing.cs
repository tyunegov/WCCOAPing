using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCOAPing.Ping
{
    public class EthernetPing : IPing
    {
        public bool GetStatus(string ip)
        {
            bool isConnect;
            try
             {
                isConnect = new System.Net.NetworkInformation.Ping().Send(ip).Status.ToString().Equals("Success");                
             }
             catch
             {
             isConnect = false;
             }
            return isConnect;
        }

        public Dictionary<string, bool> GetStatus(Dictionary<string, string> ip)
        {
            var start = DateTime.Now;
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            bool isConnect;
            foreach (var value in ip)
            {
               isConnect = GetStatus(value.Value);
            }
            Console.WriteLine(DateTime.Now - start);
            return result;
        }
    }
}
