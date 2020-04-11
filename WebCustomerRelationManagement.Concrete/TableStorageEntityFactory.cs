using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;
using WebCustomerRelationManagement.Interface;

namespace WebCustomerRelationManagement.Concrete
{
    public class TableStorageEntityFactory
    {
        public static IEntity GetEntityObject(string entityLogicalName)
        {
            switch (entityLogicalName)
            {
                case "Address":
                    return new AddressConcrete();
                case "Account":
                    return new ContactConcrete();
                default:
                    return (IEntity)new Object();
            }
        }
    }
}
