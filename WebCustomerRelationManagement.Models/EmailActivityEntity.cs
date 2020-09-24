using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace WebCustomerRelationManagement.Models
{
    public class EmailActivityEntity : TableEntity
    {
        public const string key = "EmailActivity";
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
        public string ContentUrl { get; set; }
        public string MessageId { get; set; }
        public string ThreadId { get; set; }
        public string HistoryId { get; set; }
        public Guid contactid { get; set; }
        public string contactName { get; set; }
        public Guid Accountid { get; set; }
        public string AccountName { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
        public Guid Organization { get; set; }
        public string OrganizationName { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedOnBehalfBy { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public Guid ModifiedOnBehalfBy { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
    }
}
