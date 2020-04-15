using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebCustomerRelationManagement.Models
{
    public partial class OrganizationEntity : TableEntity
    {
        public const string key = "Organization";
        public OrganizationEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.OraganizationId = id;
        }
        public OrganizationEntity()
        {

        }
        public Guid OraganizationId { get; set; }
        public string Organizationname { get; set; }
        public string OrganizationURL { get; set; }
        public string OrganizationFullAddress { get; set; }
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
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
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
