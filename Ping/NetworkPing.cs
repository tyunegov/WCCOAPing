using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCOAPing.Ping
{
    public class NetworkPing : IPing
    {
        public bool GetStatus(string ip)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, bool> GetStatus(Dictionary<string, string> ip)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            foreach(var value in ip)
            {
                try
                {
                    result.Add(value.Key, new System.Net.NetworkInformation.Ping().Send(value.Value).Status.ToString().Equals("Success"));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Errors: {e}");
                }
            }
            return result;
        }
    }
}
