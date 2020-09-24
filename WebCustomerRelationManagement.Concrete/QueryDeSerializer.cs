using System.Collections.Generic;

namespace WebCustomerRelationManagement.Concrete
{
    public class QueryDeSerializer
    {
        public string EntityLogicalName { get; set; }
        public List<string> Attributes { get; set; }
        public string FilterCondition { get; set; }
    }
}
