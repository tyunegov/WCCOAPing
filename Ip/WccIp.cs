using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETM.WCCOA;
using WCCOAPing.Ip;

namespace WCCOAPing.Factory
{
    class WccIp : IIp
    {
        OaManager manager;
        public WccIp(OaManager manager)
        {
            this.manager = manager;
        }

        public Dictionary<string, string> GetIp()
        {
            throw new NotImplementedException();
        }
    }
}
