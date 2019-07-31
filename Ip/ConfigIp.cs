using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using WCCOAPing.Dp;
using WCCOAPing.Factory;

namespace WCCOAPing.Ip
{
    class ConfigIp
    {
        IDp dp;
        public ConfigIp(IDp dp)
        {
            this.dp = dp;
        }
        public Dictionary<string, string> GetIp()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();            
                try
                {
                    string startupPath = Assembly.GetExecutingAssembly().Location;
                    startupPath = startupPath.Substring(0, startupPath.Length - 18);
                    startupPath += @"\config\config.ping";

                    foreach (var value in File.ReadAllLines(startupPath))
                    {
                        result.Add(value, dp.ReadDpValue(value, "ip").ToString());
                    }                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Errors (class ConfigIp function GetIp) " + e);
                    result =  null;
                }           
            return result;
        }
    }
}
