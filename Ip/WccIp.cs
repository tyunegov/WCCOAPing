using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETM.WCCOA;
using WCCOAPing.Dp;
using WCCOAPing.Ip;

namespace WCCOAPing.Factory
{
    class WccIp : IIp
    {
        OaManager manager;
        IDp dp;
        public WccIp(OaManager manager, IDp dp)
        {
            this.manager = manager;
            this.dp = dp;
        }

        public Dictionary<string, string> GetIp()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<string> dpNames = dp.GetDpNamesByDPTName("_ConnectionDevices");
            for (int i = 1; i < dpNames.Count(); i++)
            {
                try
                {
                    result.Add(dpNames[i], dp.ReadDpValue(dpNames[i], "ip").ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Errors (Class WccIp function GetIp) " + e);
                }
            }
            return result;
        }
    }
}
