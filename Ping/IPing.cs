using System.Collections.Generic;
using System.Threading.Tasks;

namespace WCCOAPing.Ping
{
    public interface IPing
    {
        Dictionary<string, bool> GetStatus(Dictionary<string, string> ip);
        bool GetStatus(string ip);
    }
}