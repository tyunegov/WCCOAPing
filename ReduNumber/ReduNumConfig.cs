using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WCCOAPing.reduNumber
{
    public class ReduNumConfig : IReduNum
    {
        public int GetReduNum()
        {
            try
            {
                string startupPath = Assembly.GetExecutingAssembly().Location;
                startupPath = startupPath.Substring(0, startupPath.Length - 18);
                startupPath += @"\config\config";
                foreach(var v in File.ReadAllLines(startupPath))
                {
                    if (v.StartsWith("ReduNumId="))
                    {
                        return Convert.ToInt32(v.Replace("ReduNumId=",""));
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errors: " + e);
                return 1;
            }
        }
    }
}
