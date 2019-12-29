using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IPhoneNumber
    {
        IQueryable<PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType);

        void CreatePhoneNumber(PhoneNumber entity);

        void UpdatePhoneNumber(PhoneNumber phoneNumber);

        int DeletePhoneNumber(Guid phoneNumberId);
    }
}
