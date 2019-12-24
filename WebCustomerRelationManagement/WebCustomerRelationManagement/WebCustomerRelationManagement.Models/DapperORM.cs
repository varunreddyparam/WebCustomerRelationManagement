﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement
{
    public static class DapperORM
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString();

        public static void ExecuteWithOutReturn(string proceedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                con.Execute(proceedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnScalar<T>(string proceedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return (T)Convert.ChangeType(con.Execute(proceedureName, parameters, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }
    }
}
