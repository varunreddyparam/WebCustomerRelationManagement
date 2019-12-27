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


        public void UpdateAddress(Guid addressid, string contactaddressName, int stateCode, int statusCode, string line1, string line2, string line3, string city, string country, string county)
        {
            try
            {
                var _Context = new DatabaseContext();
                var context = new DatabaseContext();
                var address = (from addressentity in context.Addresses
                               where addressentity.AddressId == addressid
                               select addressentity).SingleOrDefault();
                if (address != null)
                {
                    address.Name = contactaddressName;
                    address.AddressLine1 = line1;
                    address.AddressLine2 = line2;
                    address.AddressLine3 = line3;
                    address.City = city;
                    address.Country = country;
                    address.County = county;
                    address.statecode = stateCode;
                    //emailAddress.statecodename = 
                    address.statuscode = statusCode;
                    //emailAddress.statuscodename
                    //emailAddress.modifiedby
                    address.modifiedon = DateTime.Now;
                    //emailAddress.modifiedbyname
                    //emailAddress.modifiedonbehalfby
                    //emailAddress.modifiedonbehalfbyname
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
