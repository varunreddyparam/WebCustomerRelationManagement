using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebCustomerRelationManagement.Models
{
    public partial class AddressEntity : TableEntity
    {
        public const string key = "Address";
        public AddressEntity(Guid id, string partitionKey)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.CustomerAddressId = id;
        }
        public AddressEntity()
        {

        }
        public Guid OrganizationId { get; set; }
        public string Organizationname { get; set; }
        public int AddressNumber { get; set; }
        public int AddressTypeCode { get; set; }
        public string AddressTypeCodeName { get; set; }
        public Guid ContactId { get; set; }
        public string contactName { get; set; }
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
        public string City { get; set; }
        public string Composite { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnBehalfBy { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public Guid CustomerAddressId { get; set; }
        public bool IsPrimary { get; set; }
        public string CustomerFullAddress { get; set; }
        public string ExchangeRate { get; set; }
        public string Fax { get; set; }
        public int? FreightTermsCode { get; set; }
        public string FreightTermsCodeName { get; set; }
        public string Latitude { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Longitude { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public string ModifiedOnBehalfBy { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
        public int UTCConversionTimeZoneCode { get; set; }
        public string UTCOffset { get; set; }
        public string VersionNumber { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
