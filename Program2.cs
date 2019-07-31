using System;
using System.IO;

namespace WCCOAping
{
    class Program
    {
        static void Main(string[] args)
        {
               WccConnection wcc = new WccConnection();
               wcc.EstablishConection(args);
               DpNames dp = new DpNames(wcc.MyManager);

               foreach(var v in dp.ReadConfigFile())
               {
                   StreamWriter writer = new StreamWriter(@"C:\Users\Desktop\text.txt");
                   writer.Write(dp.GetIpAdress(v));
                   dp.GetIpAdress(v);
               }
            Console.ReadKey();      
         /*   var ping = new Ping();
            var pingReply = ping.Send("192.168.79.51");
            Console.WriteLine(pingReply.Status);
            var pingReply2 = ping.Send("192.168.80.119");
            Console.WriteLine(pingReply2.Status);
            Console.ReadKey();
            */
        }
    }
}
