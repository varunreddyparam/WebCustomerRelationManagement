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
        IQueryable<EmailAddress> GetEmailAddressByContact(Guid contactId,string customerType);
    }
}
