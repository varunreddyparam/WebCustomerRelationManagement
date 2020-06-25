using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace WebCustomerRelationManagement.Models
{
    public class EmailActivityEntity : TableEntity
    {
        public const string key = "EmailConfiguration";
        public EmailActivityEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.EmailActivityId = id;
        }
        public EmailActivityEntity()
        {

        }
        public Guid EmailActivityId { get; set; }
        public DateTime EmailDate { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string EmailSubject { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
        public Guid Organization { get; set; }
        public string OrganizationName { get; set; }
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
