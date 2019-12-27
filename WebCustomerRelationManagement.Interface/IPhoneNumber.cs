using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IPhoneNumber
    {
        IQueryable<PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType);

        void CreatePhoneNumber(PhoneNumber entity);

        void UpdatePhoneNumber(int phoneNumberType, Guid phoneNumberId, string phoneNumberTypeName, string contactphoneNumber, int stateCode, int statusCode);

        int DeletePhoneNumber(Guid phoneNumberId);
    }
}
