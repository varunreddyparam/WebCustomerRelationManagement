using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class ContactConcrete : IEntity
    {
        public async Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
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
    }
}
