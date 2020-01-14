using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    interface ISystemUser
    {
        tbl_SystemUser GetSystemUsers();
        tbl_SystemUser GetSystemUser(Guid userId);
        Guid CreateUser();
        void DeleteUser(Guid userId);
        void Update(tbl_SystemUser user);
        bool LoginAuthentication(string password, string UserName = null, string UserEmailAddress = null);

    }
}
