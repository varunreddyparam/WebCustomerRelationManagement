using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Interface
{
    public class BatchOperationOptions
    {
        public BatchInsertMethod BatchInsertMethod { get; set; }
    }

    public enum BatchInsertMethod
    {
        Insert,
        InsertOrReplace,
        InsertOrMerge
    }
}
