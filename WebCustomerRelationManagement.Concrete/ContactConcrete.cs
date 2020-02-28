using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class ContactConcrete : IContacts
    {
        /// <summary>
        /// Declaration of Context
        /// </summary>
        private MonkeyCRMOrganizationDataContext monkeyCRMOrgEntitiesContext = null;
        public PhoneNumberConcrete phoneNumber = new PhoneNumberConcrete();
        public EmailAddressConcrete emailAddress = new EmailAddressConcrete();
        public WebSiteUrlConcrete webSiteUrl = new WebSiteUrlConcrete();
        public AddressConcrete address = new AddressConcrete();
        public const string contactType = "Contact";

        public int GetTotalContactsCount(string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            return monkeyCRMOrgEntitiesContext.tbl_Contacts.Count();
        }

        public int GetTotalContactbyType(int? contactType, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            //return monkeyCRMOrgEntitiesContext.tbl_Contacts.Where(contact=>contact.contacttype == contactType)
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public ContactDetailView GetContactById(Guid contactId, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            var contactDeatil = (from contact in monkeyCRMOrgEntitiesContext.tbl_Contacts
                                 where contact.contactid == contactId
                                 select new ContactDetailView
                                 {
                                     Name = contact.name,
                                     FirstName = contact.firstname,
                                     LastName = contact.lastname,
                                     MiddleName = contact.middlename,
                                     ContactId = contact.contactid,
                                     ContactType = contact.contacttype,
                                     ContactTypeName = contact.contacttypename,
                                     Phone = phoneNumber.GetPhoneNumberByContact(contactId, contactType, source, initialCatalogue).ToList(),
                                     Emails = emailAddress.GetEmailAddressByContact(contactId, contactType, source, initialCatalogue).ToList(),
                                     WebsiteURLs = webSiteUrl.GetWebSiteByContact(contactId, contactType, source, initialCatalogue).ToList(),
                                     Addresses = address.GetAddressByContact(contactId, contactType, source, initialCatalogue).ToList(),
                                     Description = contact.description,
                                     DoNotBulkEmail = contact.donotbulkemail,
                                     DoNotBulkPostalMail = contact.donotbulkpostalmail,
                                     DoNotEmail = contact.donotemail,
                                     DoNotFax = contact.donotfax,
                                     DoNotPhone = contact.donotphone,
                                     Donotpostalmail = contact.donotpostalmail,
                                     Statecode = contact.statecode,
                                     Statecodename = contact.statecodename,
                                     Statuscode = contact.statuscode,
                                     Statuscodename = contact.statuscodename,
                                     Createdby = contact.createdby,
                                     Createdbyname = contact.createdbyname,
                                     Createdon = contact.createdon,
                                     Createdonbehalfby = contact.createdonbehalfby,
                                     Createdonbehalfbyname = contact.createdonbehalfbyname,
                                     Modifiedby = contact.modifiedby,
                                     Modifiedbyname = contact.modifiedbyname,
                                     Modifiedon = contact.modifiedon,
                                     Modifiedonbehalfby = contact.modifiedonbehalfby,
                                     Modifiedonbehalfbyname = contact.modifiedonbehalfbyname
                                 }).FirstOrDefault();

            return contactDeatil;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortColumn"></param>
        /// <param name="sortColumnDir"></param>
        /// <param name="Search"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public IEnumerable<tbl_Contact> ShowAllContacts(string sortColumn, string sortColumnDir, string Search, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            var contactList = (from contact in monkeyCRMOrgEntitiesContext.tbl_Contacts
                               select contact);
            return contactList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public Guid CreateContact(tbl_Contact contact, string source, string initialCatalogue)
        {
            try
            {
                monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
                monkeyCRMOrgEntitiesContext.tbl_Contacts.InsertOnSubmit(contact);
                monkeyCRMOrgEntitiesContext.SubmitChanges();
                return contact.contactid;

            }
            catch (Exception)
            {

            }
            return Guid.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void UpdateContact(tbl_Contact contact, string source, string initialCatalogue)
        {

            try
            {
                monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
                //var contactEntity = context.tbl_Contacts.Where(key => key.contactid == contact.contactid).SingleOrDefault();
                monkeyCRMOrgEntitiesContext.SubmitChanges();

            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteContact(Guid contactId, string source, string initialCatalogue)
        {
            try
            {
                monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
                var contact = (from addressentity in monkeyCRMOrgEntitiesContext.tbl_Contacts
                               where addressentity.contactid == contactId
                               select addressentity).SingleOrDefault();
                if (contact != null)
                {
                    monkeyCRMOrgEntitiesContext.tbl_Contacts.DeleteOnSubmit(contact);
                    monkeyCRMOrgEntitiesContext.SubmitChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
