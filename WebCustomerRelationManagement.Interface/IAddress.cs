using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IAddress
    {
        IQueryable<tbl_Address> GetAddressByContact(Guid contactId, string contactType);
        void CreateAddress(tbl_Address entity);

        void UpdateAddress(tbl_Address address);

        int DeleteAddress(Guid addressid);
    }
}
