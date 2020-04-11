using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebCustomerRelationManagement.Models
{
    public class ContactEntity : TableEntity
    {
        public const string key = "Contact";
        public ContactEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.CustomerId = id;
        }
        public ContactEntity()
        {

        }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public bool IsPrimary { get; set; }
        public Guid PrimaryAccountId { get; set; }
        public string PrimaryAccountName { get; set; }
        public Guid CustomerAddressId { get; set; }
        public string CustomerFullAddress { get; set; }
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
