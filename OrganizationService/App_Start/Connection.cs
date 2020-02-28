using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganizationService
{ 
    /// <summary>
    /// 
    /// </summary>
    public static class Connection
    {
        /// <summary>
        /// connectionstring
        /// </summary>
        public static string ConnectionString = "Data Source={0);Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=True;";

        /// <summary>
        /// ConstructConnection
        /// </summary>
        /// <param name="initialCatalog"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConstructConnectionString(string initialCatalog, string source)
        {
            return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=True;", source, initialCatalog).ToString();
        }
    }
}