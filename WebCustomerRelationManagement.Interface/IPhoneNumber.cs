using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IPhoneNumber
    {
        IQueryable<PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType);
    }
}
