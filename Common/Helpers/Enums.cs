using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Common
{
    public class Enums
    {
        public enum CommandTypes
        {
            StoredProcedure = CommandType.StoredProcedure,
            Text = CommandType.Text
        }
    }
}
