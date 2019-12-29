using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;


namespace WebCustomerRelationManagement.Concrete
{
    public class EmailAddressConcrete : IEmailAddress
    {
        public IQueryable<EmailAddress> GetEmailAddressByContact(Guid contactId, string contactType)
        {
            var _Context = new DatabaseContext();
            var emailDeatil = (from emailAddress in _Context.EmailAddresses
                               where emailAddress.CustomerType == contactId &&
                               emailAddress.CustomerTypeName == contactType
                               select emailAddress);
            return emailDeatil;
        }
        public void CreateEmailAddress(EmailAddress entity)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.EmailAddresses.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public int DeleteEmailAddress(Guid emailAddressId)
        {
            try
            {
                var context = new DatabaseContext();
                var emailAddress = (from emailAddressentity in context.EmailAddresses
                                    where emailAddressentity.EmailAddressId == emailAddressId
                                    select emailAddressentity).SingleOrDefault();
                if (emailAddress != null)
                {
                    context.EmailAddresses.Remove(emailAddress);
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

        public void UpdateEmailAddress(EmailAddress emailAddress)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var emailAddressEntity = context.EmailAddresses.Where(key => key.EmailAddressId == emailAddress.EmailAddressId).SingleOrDefault();
                    context.Entry(emailAddressEntity).CurrentValues.SetValues(emailAddress);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
