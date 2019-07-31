using ETM.WCCOA;
using System;
using System.Collections.Generic;
using WCCOAPing.reduNumber;

namespace WCCOAPing.Dp
{
    class WccDp : IDp
    {
        OaManager manager;
        IReduNum reduNum;
        string systemName;

        public WccDp(OaManager manager, IReduNum reduNum)
        {
            this.manager = manager;
            this.reduNum = reduNum;
            systemName = manager.GetCurrentSystemName();
        }

        public List<string> ReadDpNames(string dptName)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, dynamic> ReadDpValue(List<string> name)
        {

            throw new NotImplementedException();
        }

        public dynamic ReadDpValue(string dpNameElement)
        {
            try
            {
                return manager.ProcessValues.GetDpValue(systemName+":"+dpNameElement).DpValue;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errors: " + e);
                return null;
            }
        }

        public void WriteDpeValue(string dpName, bool value)
        {
            throw new NotImplementedException();
        }

        public void WriteDpStatus(Dictionary<string, bool> statusPairs)
        {
            OaProcessValues valueAccess = manager.ProcessValues;
            foreach (var value in statusPairs)
            {
                try
                {                    
                    valueAccess.SetDpValueAsync(CreateDpeStatusName(systemName + ":"+value.Key), value.Value).Wait();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");
                }
            }
        }

        string CreateDpeStatusName(string dpName)
        {
            string dpeName = $"{dpName}.isConnected";
            string tail = ":_original.._value";
            return reduNum.GetReduNum() == 1 ? dpeName + tail : $"{dpeName}_{reduNum.GetReduNum()}{tail}";
        }
    }
}
