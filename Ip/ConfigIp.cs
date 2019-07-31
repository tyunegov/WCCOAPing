using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WCCOAPing.Dp;

namespace WCCOAPing.Ip
{
    class ConfigIp : IIp
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

                foreach(var value in File.ReadAllLines(startupPath))
                {
                    result.Add(value, dp.ReadDpValue($"{value}.ip:_original.._value"));
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errors: " + e);
                return null;
            }
        }
    }
}
