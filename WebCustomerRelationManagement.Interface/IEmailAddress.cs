using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IEmailAddress
    {
        IEnumerable<tbl_EmailAddress> GetEmailAddressByContact(Guid contactId,string customerType, string source, string initialCatalogue);
        void CreateEmailAddress(tbl_EmailAddress entity, string source, string initialCatalogue);

        void UpdateEmailAddress(tbl_EmailAddress emailAddress, string source, string initialCatalogue);

        void DeleteEmailAddress(Guid phoneNumberId, string source, string initialCatalogue);
    }
}
