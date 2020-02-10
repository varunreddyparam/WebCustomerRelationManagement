using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;


namespace WebCustomerRelationManagement.Concrete
{
    public class EmailAddressConcrete : IEmailAddress
    {
        public IQueryable<tbl_EmailAddress> GetEmailAddressByContact(Guid contactId, string contactType)
        {
            var _Context = new MonkeyCRMEntities();
            var emailDeatil = (from emailAddress in _Context.tbl_EmailAddress
                               where emailAddress.customertype == contactId &&
                               emailAddress.customertypename == contactType
                               select emailAddress);
            return emailDeatil;
        }
        public void CreateEmailAddress(tbl_EmailAddress entity)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    context.tbl_EmailAddress.Add(entity);
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
                var context = new MonkeyCRMEntities();
                var emailAddress = (from emailAddressentity in context.tbl_EmailAddress
                                    where emailAddressentity.emailaddressid == emailAddressId
                                    select emailAddressentity).SingleOrDefault();
                if (emailAddress != null)
                {
                    context.tbl_EmailAddress.Remove(emailAddress);
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

        public void UpdateEmailAddress(tbl_EmailAddress emailAddress)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    var emailAddressEntity = context.tbl_EmailAddress.Where(key => key.emailaddressid == emailAddress.emailaddressid).SingleOrDefault();
                    context.Entry(emailAddressEntity).CurrentValues.SetValues(emailAddress);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
