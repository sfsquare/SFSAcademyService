using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LogInstance
    {
        static ErrorLogging logging = new ErrorLogging();

        public static void Error(Exception ex)
        {
            string user = string.Empty;
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;
            logging.LogData(ex.ToString(), user, methodName,string.Empty, "ERROR");
        }

        public static void Error(string message, Exception ex)
        {
            string user = string.Empty;
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;
            logging.LogData(ex.ToString(), user, methodName, message, "ERROR");
        }

        public static void Error(Exception ex, string  message)
        {
            string user = string.Empty;
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;
            logging.LogData(ex.ToString(), user, methodName, message, "ERROR");
        }

        public static void Error(string  method, string message)
        {
            string user = string.Empty;
            logging.LogData(message, user, method, method, "ERROR");
        }

        public static void Error(string message)
        {
            string user = string.Empty;
            logging.LogData(message, user, message, message, "ERROR");
        }

        public static void Debug(string message)
        {
            //string user = string.Empty;
            //logging.LogData(message, user, message, message, "DEBUG");
        }

        public static void Info(string message)
        {
            //string user = string.Empty;
            //logging.LogData(message, user, message, message, "INFO");
        }
    }
}
