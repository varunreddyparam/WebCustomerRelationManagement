using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IAddress
    {
        IQueryable<Address> GetPhoneNumberByContact(Guid contactId, string contactType);
    }
}
