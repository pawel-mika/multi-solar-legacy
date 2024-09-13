using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Solarium.Utils
{
    public static class Log
    {
        public static ILog GetLogger(string name)
        {
            return log4net.LogManager.GetLogger(name);
        }

        public static void Info(string message) 
        {
            
        }
    }
}
