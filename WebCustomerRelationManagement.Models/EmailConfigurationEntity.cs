using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace WebCustomerRelationManagement.Models
{
    public class EmailConfigurationEntity : TableEntity
    {
        public const string key = "EmailConfiguration";
        public EmailConfigurationEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.EmailConfigurationId = id;
        }
        public EmailConfigurationEntity()
        {

        }
        public Guid EmailConfigurationId { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string PopServer { get; set; }
        public int PopPort { get; set; }
        public string PopUsername { get; set; }
        public string PopPassword { get; set; }
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
