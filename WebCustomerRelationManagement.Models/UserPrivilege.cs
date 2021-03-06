﻿using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace WebCustomerRelationManagement.Models
{
    public class UserPrivilegeEntity : TableEntity
    {
        public const string key = "UserPrivilege";
        public UserPrivilegeEntity(Guid id)
        {
            this.PartitionKey = key;
            this.RowKey = id.ToString();
            this.UserPrivilegeId = id;
        }
        public UserPrivilegeEntity()
        {

        }
        public Guid UserPrivilegeId { get; set; }
        public string EntityName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanCreate { get; set; }
        public bool CanDelete { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }
        public Guid Organization { get; set; }
        public string OrganizationName { get; set; }
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
