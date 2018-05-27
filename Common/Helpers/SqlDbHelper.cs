
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Common
{
    public class SqlDbHelper : IDBHelper
    {

        #region "Constructor"

        public static string ConnectionStr = string.Empty;


        /// <summary>
        /// SqlDbHelpe:Constructor
        /// </summary>
        public SqlDbHelper()
        {
            ConnectionStr = ConfigurationManager.ConnectionStrings["SFSAcademyConnection"].ConnectionString;
        }


        public SqlDbHelper(string ConnectionString)
        {
            ConnectionStr = ConnectionString;
        }

        #endregion

        #region "Properties"

        string connectionString;
        string IDBHelper.ConnectionString
        {
            get
            {
                connectionString = ConnectionStr;
                return connectionString;
            }
        }

        #endregion

        #region "Private Methods"

        /// <summary>
        /// CreateCommand
        /// </summary>
        /// <param name="Enums.CommandTypes commandType, string commandText, SqlConnection Connection"></param>
        /// <returns></returns>
        private SqlCommand CreateCommand(Enums.CommandTypes commandType, string commandText, SqlConnection Connection)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = (CommandType)commandType;
            cmd.Connection = Connection;
            return cmd;
        }

        /// <summary>
        /// FillParameters
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        private void FillParameters(SqlCommand cmd, List<DBParameters> parameters)
        {
            if (parameters != null)
            {
                foreach (var para in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = para.ParameterName,
                        DbType = para.DbType,
                        Direction = para.Direction,
                        IsNullable = para.IsNullable,
                        Value = para.Value

                    });
                }
            }

        }

        #endregion

        #region "Public Methods"

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="List<DBParameters> parameters,Enums.CommandTypes commandType, string commandText"></param>
        /// <returns>int</returns>

        public int ExecuteNonQuery(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText)
        {
            int cnt = 0;
            using (SqlConnection Con = new SqlConnection(ConnectionStr))
            {
                SqlCommand cmd = CreateCommand(commandType, commandText, Con);
                FillParameters(cmd, parameters);
                using (cmd)
                {
                    cmd.Connection.Open();
                    cnt = cmd.ExecuteNonQuery();
                }
            }
            return cnt;
        }


        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText, out List<DBParameters> outputParams"></param>
        /// <returns>int</returns>
        public int ExecuteNonQuery(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText, out List<DBParameters> outputParams)
        {
            int cnt = 0;
            outputParams = new List<DBParameters>();
            using (SqlConnection Con = new SqlConnection(ConnectionStr))
            {
                SqlCommand cmd = CreateCommand(commandType, commandText, Con);
                FillParameters(cmd, parameters);
                using (cmd)
                {
                    cmd.Connection.Open();
                    cnt = cmd.ExecuteNonQuery();

                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            outputParams.Add(
                                new DBParameters(parameter.ParameterName, parameter.DbType, parameter.Direction, parameter.IsNullable, parameter.Value, parameter.Size
                                ));
                        }
                    }
                }
            }
            return cnt;
        }

        /// <summary>
        /// ExecuteDataSet
        /// </summary>
        /// <param name="List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Con = new SqlConnection(ConnectionStr))
            {
                SqlCommand cmd = CreateCommand(commandType, commandText, Con);
                cmd.CommandTimeout = 800;
                FillParameters(cmd, parameters);
                using (cmd)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }
            return ds;
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText"></param>
        /// <returns></returns>
        public Object ExecuteScalar(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText)
        {
            Object returnValue = null;
            using (SqlConnection Con = new SqlConnection(ConnectionStr))
            {
                SqlCommand cmd = CreateCommand(commandType, commandText, Con);
                FillParameters(cmd, parameters);
                using (cmd)
                {
                    cmd.Connection.Open();
                    returnValue = cmd.ExecuteScalar();
                }
            }
            return returnValue;
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(List<DBParameters> parameters, Enums.CommandTypes commandType, string commandText)
        {
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(ConnectionStr);
            SqlCommand cmd = CreateCommand(commandType, commandText, con);
            FillParameters(cmd, parameters);
            cmd.Connection.Open();
            using (cmd)
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            return reader;
        }
        #endregion
    }
}
