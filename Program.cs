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
                Magic();

            }
            catch (Exception e)
            {
                Console.WriteLine("Errors (class Program function Main): " + e);
            }
        }

        static void Magic()
        {
            Dictionary<string, string> ipPairs = new Dictionary<string, string>();
            Dictionary<string, bool> oldStatusPingPairs = new Dictionary<string, bool>();

            while (true)
            {
                if (isFirstRun) ipPairs = ip.GetIp();
                else
                {
                    new Thread(new ThreadStart(() =>
                    {
                        Thread.Sleep(10000);
                        ip.GetIp();
                    })).Start();
                }
                    foreach (var v in ipPairs)
                    {
                        if (isFirstRun) oldStatusPingPairs.Add(v.Key, false);
                        new Thread(new ThreadStart(() =>
                           {
                               bool isPing = ping.GetStatus(v.Value);
                               if (oldStatusPingPairs[v.Key] != isPing)
                               {
                                   oldStatusPingPairs[v.Key] = isPing;
                                   if (isPing) Thread.Sleep(isFirstRun ? 0 : 5000);
                                   dp.WriteDpeValue(v.Key, "isConnected" + (redu.GetReduNum() == 1 ? "" : $"_{redu.GetReduNum()}"), isPing);
                               }
                           })).Start();
                    }

                    if (isFirstRun)
                    {
                        Console.WriteLine("Manager is start");
                        isFirstRun = false;
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }

