using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDBHelper
    {
        string ConnectionString { get; }
        int ExecuteNonQuery(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText);
        int ExecuteNonQuery(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText, out List<DBParameters> outputParams);
        DataSet ExecuteDataSet(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText);
        Object ExecuteScalar(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText);
        SqlDataReader ExecuteReader(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText);
    }
}
