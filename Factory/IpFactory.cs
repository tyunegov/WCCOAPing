using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCOAPing.Dp;
using WCCOAPing.Ip;
using WCCOAPing.reduNumber;

namespace WCCOAPing.Factory
{
    public class Factory
    {
        IDp dp;
        IIp ip;
        IReduNum reduNum;

        public Factory(IpFactory factory)
        {
            dp = factory.CreateDp();
            ip = factory.CreateIp();
            reduNum = factory.CreateReduNum();
        }

        


    }
}
