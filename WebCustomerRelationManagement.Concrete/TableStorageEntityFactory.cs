using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

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
                case "Contact":
                    return new ContactConcrete();
                case "Account":
                    return new AccountConcrete();
                case "User":
                    return new UserConcrete();
                case "Organization":
                    return new OrganizationConcrete();
                case "Notes":
                    return new NotesConcrete();
                case "TimeSheet":
                    return new TimeSheetConcrete();
                case "Task":
                    return new TaskConcrete();
                case "ExpenseSheet":
                    return new ExpenseSheetConcrete();
                case "UserPrivilege":
                    return new UserPrivilegeConcrete();
                case "EmailActivity":
                    return new EmailActrivityConcrete();
                case "EmailConfiguration":
                    return new EmailConfigurationConcrete();
                default:
                    return (IEntity)new Object();
            }
        }
    }
}
