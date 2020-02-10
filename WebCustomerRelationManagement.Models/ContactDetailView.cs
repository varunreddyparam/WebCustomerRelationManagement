using System;
using System.Collections.Generic;

namespace WebCustomerRelationManagement.Models
{
    public class ContactDetailView
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Guid ContactId { get; set; }
        public int? ContactType { get; set; }
        public string ContactTypeName { get; set; }
        public List<tbl_PhoneNumber> Phone { get; set; }
        public List<tbl_EmailAddress> Emails { get; set; }
        public List<tbl_WebsiteURL> WebsiteURLs { get; set; }
        public List<tbl_Address> Addresses { get; set; }
        public string Description { get; set; }
        public bool? DoNotBulkEmail { get; set; }
        public bool? DoNotBulkPostalMail { get; set; }
        public bool? DoNotEmail { get; set; }
        public bool? DoNotFax { get; set; }
        public bool? DoNotPhone { get; set; }
        public bool? Donotpostalmail { get; set; }
        public int? Statecode { get; set; }
        public string Statecodename { get; set; }
        public int? Statuscode { get; set; }
        public string Statuscodename { get; set; }
        public Guid Createdby { get; set; }
        public string Createdbyname { get; set; }
        public DateTime Createdon { get; set; }
        public Guid? Createdonbehalfby { get; set; }
        public string Createdonbehalfbyname { get; set; }
        public Guid? Modifiedby { get; set; }
        public string Modifiedbyname { get; set; }
        public DateTime? Modifiedon { get; set; }
        public Guid? Modifiedonbehalfby { get; set; }
        public string Modifiedonbehalfbyname { get; set; }
    }
}
