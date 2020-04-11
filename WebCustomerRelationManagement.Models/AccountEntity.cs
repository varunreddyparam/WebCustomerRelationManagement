using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebCustomerRelationManagement.Models
{
    public class AccountEntity :TableEntity
    {
        public const string key = "Contact";
        public AccountEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.AccountId = id;
        }
        public AccountEntity()
        {

        }
        public Guid AccountId { get; set; }
        public string AccouuntType { get; set; }
        public int AccountTypeCode { get; set; }
        public string CompanyName { get; set; }
        public Guid AccountAddressId { get; set; }
        public string AccountFullAddress { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
        public string EmailAddress3 { get; set; }
        public string LinkedINURL { get; set; }
        public string TwitterUrL { get; set; }
        public string facebookURL { get; set; }
        public string BlogURL1 { get; set; }
        public string BlogURL2 { get; set; }
        public string BlogURL3 { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnBehalfBy { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public string ModifiedOnBehalfBy { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
    }
}
