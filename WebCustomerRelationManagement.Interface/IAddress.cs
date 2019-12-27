using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IAddress
    {
        IQueryable<Address> GetAddressByContact(Guid contactId, string contactType);
        void CreateAddress(Address entity);

        void UpdateAddress(Guid addressid, string contactaddressName, int stateCode, int statusCode, string line1, string line2, string line3, string city, string country, string county);

        int DeleteAddress(Guid addressid);
    }
}
