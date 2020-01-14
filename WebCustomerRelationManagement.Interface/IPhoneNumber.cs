using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IPhoneNumber
    {
        IQueryable<tbl_PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType);

        void CreatePhoneNumber(tbl_PhoneNumber entity);

        void UpdatePhoneNumber(tbl_PhoneNumber phoneNumber);

        int DeletePhoneNumber(Guid phoneNumberId);
    }
}
