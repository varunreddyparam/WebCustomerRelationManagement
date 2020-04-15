using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebTimeSheetManagementModels
{
    public class TaskEntity : TableEntity
    {
        public const string key = "Task";
        public TaskEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.TaskId = id;
        }
        public TaskEntity()
        {
        }

        public Guid TaskId { get; set; }
        public string Taskseries { get; set; }
        public string ClientName { get; set; } // from Client
        public Guid ClientId { get; set; }
        public string VendorCompany { get; set; } //from Contact
        public Guid VendorId { get; set; } //from Contact
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public decimal Hours { get; set; }
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
