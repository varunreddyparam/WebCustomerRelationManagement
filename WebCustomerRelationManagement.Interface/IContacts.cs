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

        Guid CreateContact(Contact contact);

        void UpdateContact(Contact contact);

        int DeleteContact(Guid contactId);
    }
}
