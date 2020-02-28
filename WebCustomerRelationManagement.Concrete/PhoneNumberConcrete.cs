using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class PhoneNumberConcrete : IPhoneNumber
    {
        /// <summary>
        /// Declaration of Context
        /// </summary>
        private MonkeyCRMOrganizationDataContext monkeyCRMOrgEntitiesContext = null;

        /// <summary>
        /// Create PhoneNumber
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public void CreatePhoneNumber(tbl_PhoneNumber entity, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            try
            {
                monkeyCRMOrgEntitiesContext.tbl_PhoneNumbers.InsertOnSubmit(entity);
                monkeyCRMOrgEntitiesContext.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumberId"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void DeletePhoneNumber(Guid phoneNumberId, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            try
            {
                var phoneNumber = (from phoneNumberentity in monkeyCRMOrgEntitiesContext.tbl_PhoneNumbers
                                   where phoneNumberentity.phonenumberid == phoneNumberId
                                   select phoneNumberentity).SingleOrDefault();
                if (phoneNumber != null)
                {
                    monkeyCRMOrgEntitiesContext.tbl_PhoneNumbers.DeleteOnSubmit(phoneNumber);
                    monkeyCRMOrgEntitiesContext.SubmitChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve PhoneNumber By Contact Type
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="contactType"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public IEnumerable<tbl_PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            try
            {
                var phoneNumberDeatil = (from phoneNumber in monkeyCRMOrgEntitiesContext.tbl_PhoneNumbers
                                         where phoneNumber.customertype == contactId &&
                                         phoneNumber.customertypename == contactType &&
                                         phoneNumber.statuscode == 0 &&
                                         phoneNumber.statuscodename == "Activated"
                                         select phoneNumber);
                return phoneNumberDeatil;

            }
            catch (Exception)
            {

            }
            return null;
        }

        public void UpdatePhoneNumber(tbl_PhoneNumber phoneNumber, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            try
            {
                //var phoneNumberEntity = monkeyCRMOrgEntitiesContext.tbl_PhoneNumbers.Where(key => key.phonenumberid == phoneNumber.phonenumberid).FirstOrDefault();
                monkeyCRMOrgEntitiesContext.SubmitChanges();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
