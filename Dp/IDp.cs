using System.Collections.Generic;
using ETM.WCCOA;

namespace WCCOAPing.Dp
{
    interface IDp
    {
        List<string> GetDpNamesByDPTName(string dptName);
        Dictionary<string, dynamic> ReadDpValue(List<string> dpNames, string node);
        OaVariant ReadDpValue(string dpName, string node);
        void WriteDpeValue(Dictionary<string, bool> valuePairs, string node);
        void WriteDpeValue(Dictionary<string, string> valuePairs, string node);
        void WriteDpeValue(string dpName, string node, dynamic value);
    }
}