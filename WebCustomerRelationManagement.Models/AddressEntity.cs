    using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebCustomerRelationManagement.Models
{
    public partial class AddressEntity : TableEntity
    {
        public const string key = "Address";
        public AddressEntity(Guid id)
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
        public int AddressTypeCode { get; set; }
        public string AddressTypeCodeName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedOnBehalfBy { get; set; }
        public string CreatedOnBehalfByName { get; set; }
        public Guid CustomerAddressId { get; set; }
        public bool IsPrimary { get; set; }
        public string CustomerFullAddress { get; set; }
        public string Fax { get; set; }
        public string Latitude { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Longitude { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public Guid ModifiedOnBehalfBy { get; set; }
        public string ModifiedOnBehalfByName { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
