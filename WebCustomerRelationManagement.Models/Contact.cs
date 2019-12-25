using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCustomerRelationManagement.Models
{
    [Table("Contact")]
    public class Contact
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Guid ContactId { get; set; }
        public int ContactType { get; set; }
        public string ContactTypeName { get; set; }
        public List<PhoneNumber> Phone { get; set; }
        public List<EmailAddress> Emails { get; set; }
        public List<WebsiteURL> WebsiteURLs { get; set; }
        public List<Address> Addresses { get; set; }
        public string description { get; set; }
        public bool donotbulkemail { get; set; }
        public bool donotbulkemailname { get; set; }
        public bool donotbulkpostalmail { get; set; }
        public bool donotbulkpostalmailname { get; set; }
        public bool donotemail { get; set; }
        public bool donotemailname { get; set; }
        public bool donotfax { get; set; }
        public bool donotfaxname { get; set; }
        public bool donotphone { get; set; }
        public bool donotphonename { get; set; }
        public bool donotpostalmail { get; set; }
        public bool donotpostalmailname { get; set; }
        public bool donotsendmarketingmaterialname { get; set; }
        public int statecode { get; set; }
        public string statecodename { get; set; }
        public int statuscode { get; set; }
        public string statuscodename { get; set; }
        public int createdby { get; set; }
        public string createdbyname { get; set; }
        public DateTime createdon { get; set; }
        public int createdonbehalfby { get; set; }
        public string createdonbehalfbyname { get; set; }
        public int modifiedby { get; set; }
        public string modifiedbyname { get; set; }
        public DateTime modifiedon { get; set; }
        public int modifiedonbehalfby { get; set; }
        public string modifiedonbehalfbyname { get; set; }
    }
}
