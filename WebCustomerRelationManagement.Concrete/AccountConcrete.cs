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

        /// <summary>
        /// Create Account from the requestbody and deserialize requestbody based on AccountEntity
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="requestBody"></param>
        /// <param name="azureTableStorage"></param>
        /// <returns></returns>
        public async Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            AccountEntity entity = new AccountEntity();
            entity = JsonConvert.DeserializeObject<AccountEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.AccountId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
        }

        /// <summary>
        /// Delete Account record based on Id Supplied 
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="Id"></param>
        /// <param name="azureTableStorage"></param>
        /// <returns></returns>
        public async Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            AccountEntity entity = new AccountEntity();
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            return JsonConvert.SerializeObject(await azureTableStorage.DeleteAsync(entityLogicalName, entity));
        }

        /// <summary>
        /// Load Emails related to Account in the Emails Section
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="userId"></param>
        /// <param name="Id"></param>
        /// <param name="organizationId"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public Task<string> EmailRetrieveRequest(string entityLogicalName, string userId, string organizationId, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve Multiple request based on the Query expression 
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="azureTableStorage"></param>
        /// <returns></returns>
        public async Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage)
        {
            TableQuery<AccountEntity> table = new TableQuery<AccountEntity>();
            table.SelectColumns = queryExpression.Attributes;
            table.Where(queryExpression.FilterCondition);
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(queryExpression.EntityLogicalName, table));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="Id"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<AccountEntity>(entityLogicalName, entityLogicalName, Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="Id"></param>
        /// <param name="requestBody"></param>
        /// <param name="azureTableStorage"></param>
        /// <returns></returns>
        public async Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            AccountEntity entity = new AccountEntity();
            entity = JsonConvert.DeserializeObject<AccountEntity>(requestBody);
            return JsonConvert.SerializeObject(await azureTableStorage.UpdateAsync(entityLogicalName, entity));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="Id"></param>
        /// <param name="requestBody"></param>
        /// <param name="azureTableStorage"></param>
        /// <returns></returns>
        public async Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            AccountEntity entity = new AccountEntity();
            entity = JsonConvert.DeserializeObject<AccountEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.AccountId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(entityLogicalName, entity));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="Id"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public Task<string> ValidateRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }
    }
}