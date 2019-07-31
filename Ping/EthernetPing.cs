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
            throw new NotImplementedException();
        }

        public Dictionary<string, bool> GetStatus(Dictionary<string, string> ip)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            bool isConnect;
            foreach(var value in ip)
            {
                try
                {
                    try
                    {
                        isConnect = new System.Net.NetworkInformation.Ping().Send(value.Value).Status.ToString().Equals("Success");
                    }
                    catch
                    {
                        isConnect = false;
                    }
                    result.Add(value.Key, isConnect);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Errors (Class EthernetPing function GetStatus): {e}");
                }
            }
            return result;
        }
    }
}
