using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IAddress
    {
        IEnumerable<tbl_Address> GetAddressByContact(Guid contactId, string contactType, string source, string initialCatalogue);
        void CreateAddress(tbl_Address entity, string source, string initialCatalogue);

        void UpdateAddress(tbl_Address address, string source, string initialCatalogue);

        void DeleteAddress(Guid addressid, string source, string initialCatalogue);
    }
}
