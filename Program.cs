using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WCCOAPing.Dp;
using WCCOAPing.Factory;
using WCCOAPing.Ip;
using WCCOAPing.Ping;
using WCCOAPing.reduNumber;

namespace WCCOAPing
{
    class Program
    {
        static bool isFirstRun = true;
        static IDp dp;
        static IIp ip;
        static IPing ping;
        static IReduNum redu;
        static void Main(string[] args)
        {
            var manager = new ManagerWcc(args);
            dp = new WccDp(manager.MyManager);
            ip = new WccIp(manager.MyManager, dp);
            ping = new EthernetPing();
            redu = new ReduNumConfig();

            try
            {
                while (true)
                {
                    Dictionary<string, bool> pingPairs = new Dictionary<string, bool>();
                    pingPairs = ping.GetStatus(ip.GetIp());
                    dp.WriteDpeValue(pingPairs, "isConnected" + (redu.GetReduNum() == 1 ? "" : $"_{redu.GetReduNum()}"));

                    if (isFirstRun)
                    {
                        Console.WriteLine("Manager is start");
                        isFirstRun = false;
                    }
                    Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Errors (class Program function Main): " + e);
            }
        }
    }
}
