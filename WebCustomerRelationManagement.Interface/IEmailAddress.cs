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
        void CreateEmailAddress(EmailAddress entity);

        void UpdateEmailAddress(EmailAddress emailAddress);

        int DeleteEmailAddress(Guid phoneNumberId);
    }
}
