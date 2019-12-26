using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;


namespace WebCustomerRelationManagement.Concrete
{
    public class EmailAddressConcrete : IEmailAddress
    {
        public IQueryable<EmailAddress> GetEmailAddressByContact(Guid contactId, string contactType)
        {
            var _Context = new DatabaseContext();
            var emailDeatil = (from emailAddress in _Context.EmailAddresses
                               where emailAddress.CustomerType == contactId &&
                               emailAddress.CustomerTypeName == contactType
                               select emailAddress);
            return emailDeatil;
        }
    }
}
