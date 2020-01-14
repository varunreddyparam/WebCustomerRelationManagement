using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IEmailAddress
    {
        IQueryable<tbl_EmailAddress> GetEmailAddressByContact(Guid contactId,string customerType);
        void CreateEmailAddress(tbl_EmailAddress entity);

        void UpdateEmailAddress(tbl_EmailAddress emailAddress);

        int DeleteEmailAddress(Guid phoneNumberId);
    }
}
