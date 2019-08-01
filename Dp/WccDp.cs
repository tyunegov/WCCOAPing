using ETM.WCCOA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WCCOAPing.Dp
{
    class WccDp : IDp
    {
        OaManager manager;
        string systemName;

        public WccDp(OaManager manager)
        {
            this.manager = manager;
            systemName = manager.GetCurrentSystemName();
        }

        public List<string> GetDpNamesByDPTName(string dptName)
        {
            try
            {
                OaProcessModel values = manager.ProcessModel;
                var dptIds = values.GetAllDpIdsForPattern("*", dptName).FirstOrDefault().ToString();

                //todo Желательно переписать
                short typeId = Convert.ToInt16(dptIds.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                OaDataPointType oaData = new OaDataPointType(manager, manager.GetCurrentSystemId(), typeId);
                return oaData.GetAllDataPointNames().ToList();                
            }
            catch (Exception e)
            {
                Console.WriteLine("Errors (class WccDp function GetDpNamesByDPTName)" + e);
                manager.Stop();
                return null;
            }            
        }



        public Dictionary<string, dynamic> ReadDpValue(List<string> dpNames, string node)
        {
            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
            foreach (var v in dpNames)
            {
                result.Add(v, ReadDpValue(v, node));
            }
            return result;
        }

        public OaVariant ReadDpValue(string dpName, string node)
        {
            OaVariant variant;
            try
            {
                variant = manager.ProcessValues.GetDpValue($"{systemName}:{dpName}.{node}:_original.._value").DpValue;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errors: " + e);
                variant = null;
            }
            return variant;
        }

        public async void WriteDpeValue(string dpName, string node, dynamic value)
        {
            OaProcessValues valueAccess = manager.ProcessValues;
            await valueAccess.SetDpValueAsync($"{systemName}:{dpName}.{node}:_original.._value", value);
        }

        public void WriteDpeValue(Dictionary<string, bool> valuePairs, string node)
        {
            foreach (var value in valuePairs)
            {
                try
                {
                    WriteDpeValue(value.Key, node, value.Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");
                }
            }
        }

        public void WriteDpeValue(Dictionary<string, string> valuePairs, string node)
        {
            throw new NotImplementedException();
        }
    }
}
