using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IPhoneNumber
    {
        IEnumerable<tbl_PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType, string source, string initialCatalogue);

        void CreatePhoneNumber(tbl_PhoneNumber entity, string source, string initialCatalogue);

        void UpdatePhoneNumber(tbl_PhoneNumber phoneNumber, string source, string initialCatalogue);

        void DeletePhoneNumber(Guid phoneNumberId, string source, string initialCatalogue);
    }
}
