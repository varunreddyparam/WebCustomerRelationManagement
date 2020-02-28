using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebCustomerRelationManagement.Models
{
    public class AddressEntity : TableEntity
    {
        private const string key = "Address";
        public AddressEntity (Guid id)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
        }
        public AddressEntity()
        {

        }

        public int AddressNumber { get; set; }
        public int AddressTypeCode { get; set; }
        public string AddressTypeCodeName { get; set; }
        public string City { get; set; }
        public string Composite { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnBehalfBy { get; set; }
        public string  CreatedOnBehalfByName { get; set; }
        public string CustomerAddressId { get; set; }
        public int ExchangeRate { get; set; }
        public string Fax { get; set; }
        public int FreightTermsCode { get; set; }
        public string FreightTermsCodeName { get; set; }
        public string Latitude { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Longitude { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public int UTCConversionTimeZoneCod { get; set; }
        public int UTCOffset { get; set; }
        public int VersionNumber { get; set; }
    }
}
