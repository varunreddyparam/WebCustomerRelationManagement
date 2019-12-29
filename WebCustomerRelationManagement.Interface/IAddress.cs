using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IAddress
    {
        IQueryable<Address> GetAddressByContact(Guid contactId, string contactType);
        void CreateAddress(Address entity);

        void UpdateAddress(Address address);

        int DeleteAddress(Guid addressid);
    }
}
