using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Common
{
    public class DBParameters
    {
        public string ParameterName { get; set; }
        public DbType DbType { get; set; }
        public ParameterDirection Direction { get; set; }
        public bool IsNullable { get; set; }
        public object Value { get; set; }
        public int? Size { get; set; }


        #region "Public Methods"

        /// <summary>
        /// DBParameters
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="type"></param>
        /// <param name="direction"></param>
        /// <param name="isNullable"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        public DBParameters(string parameterName, DbType type, ParameterDirection direction, bool isNullable, object value, int size)
        {
            ParameterName = parameterName;
            DbType = type;
            IsNullable = isNullable;
            Value = value;
            Size = size;
        }

        #endregion
    }
}
