using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebTimeSheetManagementModels
{
    public class ExpenseSheetEntity : TableEntity
    {
        public const string key = "ExpenseSheet";
        public ExpenseSheetEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.ExpenseSheetId = id;
        }
        public ExpenseSheetEntity()
        {
        }

        public Guid ExpenseSheetId { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; } // from Client
        public Guid ClientId { get; set; }
        public string VendorCompany { get; set; } //from Contact
        public Guid VendorId { get; set; } //from Contact
        public DateTime ClaimDate { get; set; }
        public bool ExpenseType { get; set; } //Post or pre
        public bool IsRecipted { get; set; }
        public bool PaymentMethod { get; set; }//cash or Credit
        public string Currency { get; set; }
        public string Description { get; set; }
        public decimal ExpenseAmount { get; set; } 
        public decimal LocalAmount { get; set; }
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