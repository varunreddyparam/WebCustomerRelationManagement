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

        IQueryable<tbl_Contact> ShowAllContacts(string sortColumn, string sortColumnDir, string Search);

        Guid CreateContact(tbl_Contact contact);

        void UpdateContact(tbl_Contact contact);

        int DeleteContact(Guid contactId);
    }
}
