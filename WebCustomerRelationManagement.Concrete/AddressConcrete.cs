using System;
using System.Linq;
using System.Linq.Dynamic;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AddressConcrete : IAddress
    {
        public void CreateAddress(tbl_Address entity)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    context.tbl_Address.Add(entity);
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
                var context = new MonkeyCRMEntities();
                var address = (from addressentity in context.tbl_Address
                               where addressentity.addressid == addressid
                               select addressentity).SingleOrDefault();
                if (address != null)
                {
                    context.tbl_Address.Remove(address);
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

        public IQueryable<tbl_Address> GetAddressByContact(Guid contactId, string contactType)
        {
            var _Context = new MonkeyCRMEntities();
            var addressDeatil = (from address in _Context.tbl_Address
                                 where address.customertype == contactId &&
                                 address.customertypename == contactType
                                 select address);
            return addressDeatil;
        }


        public void UpdateAddress(tbl_Address address)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    var contactEntity = context.tbl_Address.Where(key => key.addressid == address.addressid).SingleOrDefault();
                    context.Entry(contactEntity).CurrentValues.SetValues(address);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
