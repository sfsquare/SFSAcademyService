using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ErrorLogging
    {
        private string Region
        {
            get
            {
                String _Region = String.Empty;
                if (ConfigurationManager.AppSettings["Region"] != null)
                {
                    _Region = ConfigurationManager.AppSettings["Region"].ToString();
                }
                return _Region;
            }
        }

        private bool IsFileLogging
        {
            get
            {
                bool _IsFileLogging = false;
                if (ConfigurationManager.AppSettings["FileLogging"] != null)
                {
                    _IsFileLogging = Convert.ToBoolean(ConfigurationManager.AppSettings["FileLogging"].ToString());
                }
                return _IsFileLogging;
            }
        }

        private string LoggerURL(string region)
        {
            String _LoggerURL = String.Empty;
            if (ConfigurationManager.AppSettings["SFSLoggerUrlNew" + "-" + region] != null)
            {
                _LoggerURL = ConfigurationManager.AppSettings["SFSLoggerUrlNew" + "-" + region].ToString();
            }
            return _LoggerURL;
        }

        public void LogData(string message,string consumerId, string className, string requestId, string logLevel)
        {
            if (IsFileLogging)
            {
                FileLogging.LogData(className, message);
            }

            int COMPONENT_ID = Constants.SFS_SERVICE_COMPONENT_ID;
            int APPLICATION_ID = Constants.SFS_APPLICATION_ID;
            string _URL = LoggerURL(Region);

            //EnhancedLogger log = new EnhancedLogger(_URL, className, COMPONENT_ID, 2000);
            //String TransId = log.generateTransId(APPLICATION_ID,consumerId,requestId,className,string.Empty,string.Empty);
            //log.logMsg(logLevel, TransId, message);
        }
    }
}
