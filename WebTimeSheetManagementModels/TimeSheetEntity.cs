using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebTimeSheetManagementModels
{
    public class TimeSheetEntity : TableEntity
    {
        public const string key = "TimeSheet";
        public TimeSheetEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.TimesheetId = id;
        }
        public TimeSheetEntity()
        {
        }

        public Guid TimesheetId { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; } // from Client
        public Guid ClientId { get; set; }
        public string VendorCompany { get; set; } //from Contact
        public Guid VendorId { get; set; } //from Contact
        public DateTime Date { get; set; }
        public string Day { get; set; } // Monday,Tueesday
        public string Year { get; set; }//Year (2020)
        public string Month { get; set; }// JAN,FEB
        public int MonthNumber { get; set; }// 01 to 12
        public string StartTime { get; set; } // 24 hrs format
        public string EndTime { get; set; } // 24 hrs format
        public bool IsChargable { get; set; }
        public string Comments { get; set; }
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

