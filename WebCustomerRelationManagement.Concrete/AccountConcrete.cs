using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AccountConcrete : IEntity
    {
        public AccountConcrete()
        {

        }

        public async Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            AccountEntity entity = new AccountEntity();
            entity = JsonConvert.DeserializeObject<AccountEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.AccountId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
        }

        public async Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            AccountEntity entity = new AccountEntity();
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            return JsonConvert.SerializeObject(await azureTableStorage.DeleteAsync(entityLogicalName, entity));
        }

        public async Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage)
        {
            TableQuery<AccountEntity> table = new TableQuery<AccountEntity>();
            table.SelectColumns = queryExpression.Attributes;
            table.Where(queryExpression.FilterCondition);
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(queryExpression.EntityLogicalName, table));
        }

        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<AccountEntity>(entityLogicalName, entityLogicalName, Id));
        }

        public async Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            AccountEntity entity = new AccountEntity();
            entity = JsonConvert.DeserializeObject<AccountEntity>(requestBody);
            return JsonConvert.SerializeObject(await azureTableStorage.UpdateAsync(entityLogicalName, entity));
        }

        public async Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            AccountEntity entity = new AccountEntity();
            entity = JsonConvert.DeserializeObject<AccountEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.AccountId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(entityLogicalName, entity));
        }

        public Task<string> ValidateRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }
    }
}