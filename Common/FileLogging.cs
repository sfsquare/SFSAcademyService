using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class FileLogging
    {
        public static void LogData(string className, string message)
        {
            Exception ex = new Exception(message);
            LogInstance.Error(className, ex);
        }
    }
}
