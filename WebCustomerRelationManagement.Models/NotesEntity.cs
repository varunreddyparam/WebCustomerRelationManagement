using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Models
{
    public partial class NotesEntity :TableEntity
    {
        public const string key = "Notes";
        public NotesEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.NotesId = id;
        }
        public NotesEntity()
        {

        }
        public Guid NotesId { get; set; }
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string BlobUrl { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public Guid Organization { get; set; }
        public string OrganizationName { get; set; }
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
