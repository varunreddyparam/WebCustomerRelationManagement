﻿using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AddressConcrete : IEntity
    {
        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<AddressEntity>(entityLogicalName, entityLogicalName, Id));
        }

        public async Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            AddressEntity entity = new AddressEntity();
            entity = JsonConvert.DeserializeObject<AddressEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.CustomerAddressId = entity.RowKey;
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
        }

        public async Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            AddressEntity entity = new AddressEntity();
            entity = JsonConvert.DeserializeObject<AddressEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.CustomerAddressId = entity.RowKey;
            return JsonConvert.SerializeObject(await azureTableStorage.UpdateAsync(entityLogicalName, entity));
        }

        public async Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            AddressEntity entity = new AddressEntity();
            entity = JsonConvert.DeserializeObject<AddressEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.CustomerAddressId = entity.RowKey;
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(entityLogicalName, entity));
        }

    }
}
