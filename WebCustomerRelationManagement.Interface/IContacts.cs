using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IContacts
    {
        int GetTotalContactsCount(string source, string initialCatalogue);

        int GetTotalContactbyType(int? contactType, string source, string initialCatalogue);

        ContactDetailView GetContactById(Guid contactId, string source, string initialCatalogue);

        IEnumerable<tbl_Contact> ShowAllContacts(string sortColumn, string sortColumnDir, string Search, string source, string initialCatalogue);

        Guid CreateContact(tbl_Contact contact, string source, string initialCatalogue);

        void UpdateContact(tbl_Contact contact, string source, string initialCatalogue);

        void DeleteContact(Guid contactId, string source, string initialCatalogue);
    }
}
