using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common
{
    public static class UtilityHelper
    {
        public static string ConvertToBase64String(string str)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(byt);
        }

        public static string ConvertFromBase64String(string str)
        {
            try
            {
                byte[] b = Convert.FromBase64String(str);
                return System.Text.Encoding.UTF8.GetString(b);
            }
            catch (Exception)
            {
                //If provided string is not a valid base64 string then it will return provided string as is.
                return str;
            }
        }

        public static string GetSQLQuery(string sqlNode)
        {
            var fileName = System.Web.Hosting.HostingEnvironment.MapPath("/SQL.config");
            XDocument xDoc = XDocument.Load(fileName);
            string result = xDoc.Descendants(sqlNode).Select(e => e.Value).SingleOrDefault();

            return result;
        }

        public static string GetDatabaseNameFromConnectionString(string connection)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder connString = new System.Data.SqlClient.SqlConnectionStringBuilder(connection);
            string database = connString.InitialCatalog;
            return database;
        }
    }
}
