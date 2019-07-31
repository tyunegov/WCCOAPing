using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCOAPing.Dp
{
    interface IDp
    {
        List<string> ReadDpNames(string dptName);
        dynamic ReadDpValue(string dpNameElement);
        Dictionary<string, dynamic> ReadDpValue(List<string> name);
        void WriteDpeValue(string dpName, bool value);
        void WriteDpStatus(Dictionary<string, bool> statusPairs);
    }
}
