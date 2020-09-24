using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCustomerRelationManagement.Models
{
    [Table("tbl_Account")]
    public class Account
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
        public Guid PrimaryContactId { get; set; }
        public string PrimaryContactName { get; set; }
        public List<PhoneNumber> Phone { get; set; }
        public List<EmailAddress> Emails { get; set; }
        public List<WebsiteURL> WebsiteURLs { get; set; }
        public List<Address> Addresses { get; set; }
        public string Description { get; set; }
        public bool DoNotBulkEmail { get; set; }
        public bool DoNotBulkPostalMail { get; set; }
        public bool DoNotEmail { get; set; }
        public bool DoNotFax { get; set; }
        public bool DoNotPhone { get; set; }
        public bool Donotpostalmail { get; set; }
        public int Statecode { get; set; }
        public string Statecodename { get; set; }
        public int Statuscode { get; set; }
        public string Statuscodename { get; set; }
        public Guid Createdby { get; set; }
        public string Createdbyname { get; set; }
        public DateTime Createdon { get; set; }
        public Guid Createdonbehalfby { get; set; }
        public Guid  Createdonbehalfbyname { get; set; }
        public int Modifiedby { get; set; }
        public string Modifiedbyname { get; set; }
        public DateTime Modifiedon { get; set; }
        public Guid  Modifiedonbehalfby { get; set; }
        public string Modifiedonbehalfbyname { get; set; }
    }
}
