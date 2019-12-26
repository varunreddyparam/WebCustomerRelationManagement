using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IContacts
    {
        int GetTotalContactsCount();

        int GetTotalContactbyType(int contactType);

        ContactDetailView GetContactById(Guid contactId);

        IQueryable<Contact> ShowAllContacts(string sortColumn, string sortColumnDir, string Search);

        void CreateContact(Contact contact);

        void UpdateContact(Guid contactId);

        void DeleteContact(Guid contactId);
    }
}
