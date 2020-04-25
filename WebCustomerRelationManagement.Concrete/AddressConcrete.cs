using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AddressConcrete : IEntity
    {
        public AddressConcrete()
        {
        }

        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<AddressEntity>(entityLogicalName, entityLogicalName, Id));
        }

        public async Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            AddressEntity entity = new AddressEntity();
            entity = JsonConvert.DeserializeObject<AddressEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.CustomerAddressId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
        }

        public async Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            AddressEntity entity = new AddressEntity();
            entity = JsonConvert.DeserializeObject<AddressEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.CustomerAddressId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.UpdateAsync(entityLogicalName, entity));
        }

        public async Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            AddressEntity entity = new AddressEntity();
            entity = JsonConvert.DeserializeObject<AddressEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.CustomerAddressId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(entityLogicalName, entity));
        }

        public async Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            AddressEntity entity = new AddressEntity();
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            return JsonConvert.SerializeObject(await azureTableStorage.DeleteAsync(entityLogicalName, entity));
        }

        public async Task<string> RetrieveMultipleRequest(QueryDeSerializer queryDeSerializer, AzureTableStorage azureTableStorage)
        {
            TableQuery<AddressEntity> table = new TableQuery<AddressEntity>();
            table.SelectColumns = queryDeSerializer.Attributes;
            table.Where(queryDeSerializer.FilterCondition);
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(queryDeSerializer.EntityLogicalName, table));
        }
    }
}
