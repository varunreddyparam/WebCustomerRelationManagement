﻿using System;
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

        public Guid CreateContact(Contact contact)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Contacts.Add(contact);
                    context.SaveChanges();
                    return contact.ContactId;
                }
            }
            catch (Exception)
            {

            }
            return Guid.Empty;
        }

        public void UpdateContact(Contact contact)
        {

            try
            {
                using (var context = new DatabaseContext())
                {
                    var contactEntity = context.Contacts.Where(key => key.ContactId == contact.ContactId).SingleOrDefault();
                    context.Entry(contactEntity).CurrentValues.SetValues(contact);
                }
            }
            catch(Exception ex)
            {

            }
        }

        public int DeleteContact(Guid contactId)
        {
            try
            {
                var context = new DatabaseContext();
                var contact = (from addressentity in context.Contacts
                               where addressentity.ContactId == contactId
                               select addressentity).SingleOrDefault();
                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    int resultContact = context.SaveChanges();
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
    }
}
