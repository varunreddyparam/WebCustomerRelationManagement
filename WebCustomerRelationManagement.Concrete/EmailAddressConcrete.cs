using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;


namespace WebCustomerRelationManagement.Concrete
{
    public class EmailAddressConcrete : IEmailAddress
    {
        /// <summary>
        /// Declaration of Context
        /// </summary>
        private MonkeyCRMOrganizationDataContext monkeyCRMOrgEntitiesContext = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="contactType"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public IEnumerable<tbl_EmailAddress> GetEmailAddressByContact(Guid contactId, string contactType, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            var emailDeatil = (from emailAddress in monkeyCRMOrgEntitiesContext.tbl_EmailAddresses
                               where emailAddress.customertype == contactId &&
                               emailAddress.customertypename == contactType
                               select emailAddress);
            return emailDeatil;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void CreateEmailAddress(tbl_EmailAddress entity, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            try
            {
                {
                    monkeyCRMOrgEntitiesContext.tbl_EmailAddresses.InsertOnSubmit(entity);
                    monkeyCRMOrgEntitiesContext.SubmitChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeleteEmailAddress(Guid emailAddressId, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            try
            {
                var emailAddress = (from emailAddressentity in monkeyCRMOrgEntitiesContext.tbl_EmailAddresses
                                    where emailAddressentity.emailaddressid == emailAddressId
                                    select emailAddressentity).SingleOrDefault();
                if (emailAddress != null)
                {
                    monkeyCRMOrgEntitiesContext.tbl_EmailAddresses.DeleteOnSubmit(emailAddress);
                    monkeyCRMOrgEntitiesContext.SubmitChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEmailAddress(tbl_EmailAddress emailAddress, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            try
            {
                    //var emailAddressEntity = monkeyCRMOrgEntitiesContext.tbl_EmailAddresses.Where(key => key.emailaddressid == emailAddress.emailaddressid).SingleOrDefault();
                monkeyCRMOrgEntitiesContext.SubmitChanges();
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
