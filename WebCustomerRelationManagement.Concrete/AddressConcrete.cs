using System;
using System.Linq;
using System.Linq.Dynamic;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AddressConcrete
    {
        public IQueryable<Address> GetAddressByContact(Guid contactId, string contactType)
        {
            var _Context = new DatabaseContext();
            var addressDeatil = (from address in _Context.Addresses
                               where address.CustomerType == contactId &&
                               address.CustomerTypeName == contactType
                               select address);
            return addressDeatil;
        }
    }
}
