using Common;
using SFSAdacdemyAdminPortalService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SFSAdacdemyAdminPortalService.DataAccess
{
    public class PortalRepository:IPortalRepository
    {
        private IDBHelper _helper;

        public PortalRepository()
        {
            _helper = new SqlDbHelper(ConfigurationManager.ConnectionStrings["SFSAcademy" + "-" + ConfigurationManager.AppSettings["Region"].ToString()].ConnectionString);
        }

        public List<Portal> GetPortalDetails(Portal input)
        {
            List<Portal> result = new List<Portal>();
            //DataSet data = new DataSet();

            //if (!string.IsNullOrEmpty(input.Environment))
            //    _helper = new SqlDbHelper(ConfigurationManager.ConnectionStrings["SFSAcademy" + "-" + input.Environment].ConnectionString);

            //string sql = UtilityHelper.GetSQLQuery("Portal");

            //data = _helper.ExecuteDataSet(null, Enums.CommandTypes.Text, sql);

            //if (data.Tables.Count > 0)
            //{
            //    result = (from d in data.Tables[0].AsEnumerable()
            //              select new Portal
            //              {
            //                  ID = d.Field<int>("ID"),
            //                  Name = d.Field<string>("Name")
            //              }).ToList();
            //}

            result.Add(new Portal
            {
                ID =1,
                Name = "Admin"
            });
            result.Add(new Portal
            {
                ID = 2,
                Name = "News"
            });
            return result;
        }

        public Portal GetPortalDetailByID(string environment, Int32 ID)
        {
            if (!string.IsNullOrEmpty(environment))
                _helper = new SqlDbHelper(ConfigurationManager.ConnectionStrings["SFSAcademy" + "-" + environment].ConnectionString);

            var result = new Portal();

            List<DBParameters> parameters = new List<DBParameters>();
            parameters.Add(new DBParameters("@ID", DbType.Int32, ParameterDirection.Input, true, ID, 10));

            var data = _helper.ExecuteDataSet(parameters, Enums.CommandTypes.Text, UtilityHelper.GetSQLQuery("Portal_DetailByID"));

            foreach (DataRow row in data.Tables[0].Rows)
            {
                result.ID = Convert.ToInt32(row["ID"]);
                result.Name = Convert.ToString(row["Name"]);
            }

            //result.ID = 1;
            //result.Name = "Satyendra";

            return result;
        }

    }
}