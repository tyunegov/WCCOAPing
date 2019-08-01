using System.Collections.Generic;
using System.Threading.Tasks;

namespace WCCOAPing.Factory
{
    interface IIp
    {
        Dictionary<string, string> GetIp();
    }
}