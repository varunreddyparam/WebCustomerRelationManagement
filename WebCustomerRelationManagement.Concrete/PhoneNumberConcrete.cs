using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class PhoneNumberConcrete : IPhoneNumber
    {
        public void CreatePhoneNumber(tbl_PhoneNumber entity)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    context.tbl_PhoneNumber.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public int DeletePhoneNumber(Guid phoneNumberId)
        {
            try
            {
                var context = new MonkeyCRMEntities();
                var phoneNumber = (from phoneNumberentity in context.tbl_PhoneNumber
                                   where phoneNumberentity.phonenumberd == phoneNumberId
                                   select phoneNumberentity).SingleOrDefault();
                if (phoneNumber != null)
                {
                    context.tbl_PhoneNumber.Remove(phoneNumber);
                    int resultphoneNumber = context.SaveChanges();
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

        public IQueryable<tbl_PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType)
        {

            try
            {
                var _Context = new MonkeyCRMEntities();
                var phoneNumberDeatil = (from phoneNumber in _Context.tbl_PhoneNumber
                                         where phoneNumber.customertype == contactId &&
                                         phoneNumber.customertypename == contactType &&
                                         phoneNumber.statuscode == 0 &&
                                         phoneNumber.statuscodename == "Active"
                                         select phoneNumber);
                return phoneNumberDeatil;

            }
            catch (Exception)
            {

            }
            return null;
        }

        public void UpdatePhoneNumber(tbl_PhoneNumber phoneNumber)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    var phoneNumberEntity = context.tbl_PhoneNumber.Where(key => key.phonenumberd == phoneNumber.phonenumberd).SingleOrDefault();
                    context.Entry(phoneNumberEntity).CurrentValues.SetValues(phoneNumber);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
