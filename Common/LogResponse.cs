using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LogResponse
    {
        public bool Success { get; set; }
        public StringBuilder InfoMessage { get; set; }
        public StringBuilder ErrorMessage { get; set; }
        public StringBuilder StackTrace { get; set; }
        public StringBuilder ErrorId { get; set; }
        public String TransId { get; set; }
        public String LogData { get; set; }
        public Exception Exception { get; set; }
        public String ConsumerId { get; set; }
        public String RequestId { get; set; }
        public String CustomFieldId1 { get; set; }
        public String CustomFieldId2 { get; set; }
        public String Payload { get; set; }

        public LogResponse()
        {
            Success = true;
            InfoMessage = new StringBuilder();
            ErrorMessage = new StringBuilder();
            StackTrace = new StringBuilder();
            ErrorId = new StringBuilder();
        }

        public void AddInfo(string message)
        {
            InfoMessage.Append(message);
        }

        public void AddErrorLogs(string message, bool success)
        {
            ErrorMessage.Append(message);
            Success = success;
        }

        public void AddStackTrace(string message)
        {
            StackTrace.Append(message);
        }

        public void AddError(bool success, string errorMessage, string stackTrace, string errorId)
        {
            Success = success;
            ErrorMessage.Append(errorMessage);
            StackTrace.Append(stackTrace);
            ErrorId.Append(errorId);

        }

        public void AddError(bool success, Exception exception)
        {
            Success = success;
            Exception = exception;
        }
    }
}
