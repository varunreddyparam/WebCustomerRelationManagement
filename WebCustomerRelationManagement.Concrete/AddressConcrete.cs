using System;
using System.Linq;
using System.Linq.Dynamic;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AddressConcrete : IAddress
    {
        public void CreateAddress(Address entity)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Addresses.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public int DeleteAddress(Guid addressid)
        {
            try
            {
                var context = new DatabaseContext();
                var address = (from addressentity in context.EmailAddresses
                               where addressentity.EmailAddressId == addressid
                               select addressentity).SingleOrDefault();
                if (address != null)
                {
                    context.EmailAddresses.Remove(address);
                    int resultemailAddress = context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<Address> GetAddressByContact(Guid contactId, string contactType)
        {
            var _Context = new DatabaseContext();
            var addressDeatil = (from address in _Context.Addresses
                                 where address.CustomerType == contactId &&
                                 address.CustomerTypeName == contactType
                                 select address);
            return addressDeatil;
        }


        public void UpdateAddress(Address address)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var contactEntity = context.Addresses.Where(key => key.AddressId == address.AddressId).SingleOrDefault();
                    context.Entry(contactEntity).CurrentValues.SetValues(address);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
