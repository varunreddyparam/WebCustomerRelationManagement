using System;
using System.Linq;
using System.Linq.Dynamic;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class ContactConcrete : IContacts
    {

        public PhoneNumberConcrete phoneNumber = new PhoneNumberConcrete();
        public EmailAddressConcrete emailAddress = new EmailAddressConcrete();
        public WebSiteUrlConcrete webSiteUrl = new WebSiteUrlConcrete();
        public AddressConcrete address = new AddressConcrete();
        public const string contactType = "Contact";

        public int GetTotalContactsCount()
        {
            return DapperORM.GetTotalCount<int>("Usp_GetContactsCount");
        }

        public int GetTotalContactbyType(int contactType)
        {
            throw new NotImplementedException();
        }

        public ContactDetailView GetContactById(Guid contactId)
        {
            var _Context = new DatabaseContext();
            var contactDeatil = (from contact in _Context.Contacts
                                 where contact.ContactId == contactId
                                 select new ContactDetailView
                                 {
                                     Name = contact.Name,
                                     FirstName = contact.FirstName,
                                     LastName = contact.LastName,
                                     MiddleName = contact.MiddleName,
                                     ContactId = contact.ContactId,
                                     ContactType = contact.ContactType,
                                     ContactTypeName = contact.ContactTypeName,
                                     Phone = phoneNumber.GetPhoneNumberByContact(contactId, contactType).ToList(),
                                     Emails = emailAddress.GetEmailAddressByContact(contactId, contactType).ToList(),
                                     WebsiteURLs = webSiteUrl.GetWebSiteByContact(contactId, contactType).ToList(),
                                     Addresses = address.GetAddressByContact(contactId, contactType).ToList(),
                                     Description = contact.Description,
                                     DoNotBulkEmail = contact.DoNotBulkEmail,
                                     DoNotBulkPostalMail = contact.DoNotBulkPostalMail,
                                     DoNotEmail = contact.DoNotEmail,
                                     DoNotFax = contact.DoNotFax,
                                     DoNotPhone = contact.DoNotPhone,
                                     Donotpostalmail = contact.Donotpostalmail,
                                     Statecode = contact.Statecode,
                                     Statecodename = contact.Statecodename,
                                     Statuscode = contact.Statuscode,
                                     Statuscodename = contact.Statuscodename,
                                     Createdby = contact.Createdby,
                                     Createdbyname = contact.Createdbyname,
                                     Createdon = contact.Createdon,
                                     Createdonbehalfby = contact.Createdonbehalfby,
                                     Createdonbehalfbyname = contact.Createdonbehalfbyname,
                                     Modifiedby = contact.Modifiedby,
                                     Modifiedbyname = contact.Modifiedbyname,
                                     Modifiedon = contact.Modifiedon,
                                     Modifiedonbehalfby = contact.Modifiedonbehalfby,
                                     Modifiedonbehalfbyname = contact.Modifiedonbehalfbyname
                                 }).FirstOrDefault();

            return contactDeatil;
        }

        public IQueryable<Contact> ShowAllContacts(string sortColumn, string sortColumnDir, string Search)
        {
            var _Context = new DatabaseContext();
            var contactList = (from contact in _Context.Contacts
                                 select contact);
            return contactList;
        }

        public void CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Guid contactId)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Guid contactId)
        {
            throw new NotImplementedException();
        }
    }
}
