using ETM.WCCOA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCOAPing.Dp;
using WCCOAPing.Factory;
using WCCOAPing.Ip;
using WCCOAPing.Ping;

namespace WCCOAPing
{
    class Program
    {
        static bool isFirstRun;
        static void Main(string[] args)
        { 
            ManagerWcc wcc = new ManagerWcc(args);
            
            IDp dp = new WccDp(wcc.MyManager, new reduNumber.ReduNumConfig());
            //   IIp ip = new WccIp(wcc.MyManager);
            IIp ip = new ConfigIp(dp);
            IPing ping = new NetworkPing();

            Dictionary<string, string> ipPairs = ip.GetIp();
            Dictionary<string, bool> dictionaryPairs = ping.GetStatus(ipPairs); 
            dp.WriteDpStatus(dictionaryPairs);

            if (isFirstRun)
            {
                isFirstRun = false;
                Console.WriteLine("Manager is running");
            }
            /*
             * Реализовано:
             * GetStatus();
             * WriteDpStatus();
             * new WccDp();
             *
             * Не сделано:
             * GetIp()
             */
        }
    }
}
