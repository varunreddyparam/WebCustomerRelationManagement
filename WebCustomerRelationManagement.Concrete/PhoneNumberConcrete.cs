using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class PhoneNumberConcrete : IPhoneNumber
    {
        public void CreatePhoneNumber(PhoneNumber entity)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.PhoneNumbers.Add(entity);
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
                var context = new DatabaseContext();
                var phoneNumber = (from phoneNumberentity in context.PhoneNumbers
                                   where phoneNumberentity.PhoneNumberId == phoneNumberId
                                   select phoneNumberentity).SingleOrDefault();
                if (phoneNumber != null)
                {
                    context.PhoneNumbers.Remove(phoneNumber);
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

        public IQueryable<PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType)
        {

            try
            {
                var _Context = new DatabaseContext();
                var phoneNumberDeatil = (from phoneNumber in _Context.PhoneNumbers
                                         where phoneNumber.CustomerType == contactId &&
                                         phoneNumber.CustomerTypeName == contactType &&
                                         phoneNumber.Statuscode == 0 &&
                                         phoneNumber.Statuscodename == "Active"
                                         select phoneNumber);
                return phoneNumberDeatil;

            }
            catch (Exception)
            {

            }
            return null;
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var phoneNumberEntity = context.PhoneNumbers.Where(key => key.PhoneNumberId == phoneNumber.PhoneNumberId).SingleOrDefault();
                    context.Entry(phoneNumberEntity).CurrentValues.SetValues(phoneNumber);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
