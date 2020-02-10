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
            throw new NotImplementedException();
            //return DapperORM.GetTotalCount<int>("Usp_GetContactsCount");
        }

        public int GetTotalContactbyType(int contactType)
        {
            throw new NotImplementedException();
        }

        public ContactDetailView GetContactById(Guid contactId)
        {
            var _Context = new MonkeyCRMEntities();
            var contactDeatil = (from contact in _Context.tbl_Contact
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
                                     Phone = phoneNumber.GetPhoneNumberByContact(contactId, contactType).ToList(),
                                     Emails = emailAddress.GetEmailAddressByContact(contactId, contactType).ToList(),
                                     WebsiteURLs = webSiteUrl.GetWebSiteByContact(contactId, contactType).ToList(),
                                     Addresses = address.GetAddressByContact(contactId, contactType).ToList(),
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

        public IQueryable<tbl_Contact> ShowAllContacts(string sortColumn, string sortColumnDir, string Search)
        {
            var _Context = new MonkeyCRMEntities();
            var contactList = (from contact in _Context.tbl_Contact
                                 select contact);
            return contactList;
        }

        public Guid CreateContact(tbl_Contact contact)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    context.tbl_Contact.Add(contact);
                    context.SaveChanges();
                    return contact.contactid;
                }
            }
            catch (Exception)
            {

            }
            return Guid.Empty;
        }

        public void UpdateContact(tbl_Contact contact)
        {

            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    var contactEntity = context.tbl_Contact.Where(key => key.contactid == contact.contactid).SingleOrDefault();
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
                var context = new MonkeyCRMEntities();
                var contact = (from addressentity in context.tbl_Contact
                               where addressentity.contactid == contactId
                               select addressentity).SingleOrDefault();
                if (contact != null)
                {
                    context.tbl_Contact.Remove(contact);
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
