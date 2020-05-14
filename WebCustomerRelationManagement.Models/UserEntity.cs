using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Models
{
    public partial class UserEntity:TableEntity
    {

        public const string key = "User";
        public UserEntity(Guid id)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.UserId = id;
        }
        public UserEntity()
        {

        }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public bool IsPrimary { get; set; }
        public Guid CustomerAddressId { get; set; }
        public string CustomerFullAddress { get; set; }
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
        public Guid Organization { get; set; }
        public string OrganizationName { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
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
