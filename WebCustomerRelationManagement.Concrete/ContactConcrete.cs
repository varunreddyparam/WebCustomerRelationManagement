using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class ContactConcrete : IEntity
    {
        public async Task<string> CreateRequest(string entityLogicalName, string OrganizationId, string UserId, string requestBody, AzureTableStorage azureTableStorage)
        {
            ContactEntity entity = new ContactEntity();
            entity = JsonConvert.DeserializeObject<ContactEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.CustomerId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
        }

        public async Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            ContactEntity entity = new ContactEntity();
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            return JsonConvert.SerializeObject(await azureTableStorage.DeleteAsync(entityLogicalName, entity));
        }

        public Task<string> EmailRetrieveRequest(string entityLogicalName, string userId, string organizationId, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage)
        {
            TableQuery<ContactEntity> table = new TableQuery<ContactEntity>();
            table.SelectColumns = queryExpression.Attributes;
            table.Where(queryExpression.FilterCondition);
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(queryExpression.EntityLogicalName, table));
        }

        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<ContactEntity>(entityLogicalName, entityLogicalName, Id));
        }

        public async Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            ContactEntity entity = new ContactEntity();
            entity = JsonConvert.DeserializeObject<ContactEntity>(requestBody);
            return JsonConvert.SerializeObject(await azureTableStorage.UpdateAsync(entityLogicalName, entity));
        }

        public async Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            ContactEntity entity = new ContactEntity();
            entity = JsonConvert.DeserializeObject<ContactEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.CustomerAddressId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(entityLogicalName, entity));
        }

        public Task<string> ValidateRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetContactByName(string entityLogicalName, string contactName, AzureTableStorage azureTableStorage)
        {
            TableQuery<ContactEntity> table = new TableQuery<ContactEntity>();
            table.Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, entityLogicalName),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, contactName)));
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(entityLogicalName, table));
        }

        public async Task<string> InsertOrUpdateContact(string entityLogicalName,string contactName, AzureTableStorage azureTableStorage, AccountEntity account, UserEntity user, OrganizationEntity org)
        {
            ContactEntity contactEntity = new ContactEntity();
            var contact = JsonConvert.DeserializeObject<ContactEntity>(await this.GetContactByName(entityLogicalName, contactName, azureTableStorage));
            if (contact == null)
            {
                contactEntity.PartitionKey = entityLogicalName;
                contactEntity.RowKey = Guid.NewGuid().ToString();
                contactEntity.CustomerId = Guid.Parse(contactEntity.RowKey);
                contactEntity.Name = contactName;
                contactEntity.Organization = org.OraganizationId;
                contactEntity.OrganizationName = org.Organizationname;
                contactEntity.OwnerId = user.OwnerId;
                contactEntity.OwnerName = user.OwnerName;
                contactEntity.PrimaryAccountId = account.AccountId;
                contactEntity.PrimaryAccountName = account.CompanyName;
                contactEntity.CreatedOn = DateTime.Now;
                contactEntity.CreatedBy = user.OwnerId;
                contactEntity.CreatedByName = user.OwnerName;
                contactEntity.ModifiedBy = user.OwnerId;
                contactEntity.ModifiedByName = user.OwnerName;
                contactEntity.ModifiedOn = DateTime.Now;
                await azureTableStorage.AddAsync(entityLogicalName, contactEntity);
            }
            else
                return "Contact already exist";
            return "Contact is Created";
            
        }
    }
}
