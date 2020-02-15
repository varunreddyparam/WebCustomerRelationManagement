using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganizationService
    public static class Connection
    {
        public static string ConnectionString = "Data Source={0);Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=True;";

        public static string ConstructConnectionString(string initialCatalog, string source)
        {
            return string.Format(ConnectionString, source, initialCatalog);
        }
    }
}