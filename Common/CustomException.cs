using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class CustomException
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string ExceptionMessage { get; set; }

        [DataMember]
        public string InnerException { get; set; }

        [DataMember]
        public string StackTrace { get; set; }
    }
}
