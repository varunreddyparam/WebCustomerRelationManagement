using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;
using WebTimeSheetManagementModels;

namespace WebCustomerRelationManagement.Concrete
{
    public class ExpenseSheetConcrete : IEntity
    {
        public ExpenseSheetConcrete()
        {

        }

        public async Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            ExpenseSheetEntity entity = new ExpenseSheetEntity();
            entity = JsonConvert.DeserializeObject<ExpenseSheetEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.ExpenseSheetId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
        }

        public async Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            ExpenseSheetEntity entity = new ExpenseSheetEntity();
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            return JsonConvert.SerializeObject(await azureTableStorage.DeleteAsync(entityLogicalName, entity));
        }

        public async Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage)
        {
            TableQuery<ExpenseSheetEntity> table = new TableQuery<ExpenseSheetEntity>();
            table.SelectColumns = queryExpression.Attributes;
            table.Where(queryExpression.FilterCondition);
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(queryExpression.EntityLogicalName, table));
        }

        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<ExpenseSheetEntity>(entityLogicalName, entityLogicalName, Id));
        }

        public async Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            ExpenseSheetEntity entity = new ExpenseSheetEntity();
            entity = JsonConvert.DeserializeObject<ExpenseSheetEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.ExpenseSheetId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.UpdateAsync(entityLogicalName, entity));
        }

        public async Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            ExpenseSheetEntity entity = new ExpenseSheetEntity();
            entity = JsonConvert.DeserializeObject<ExpenseSheetEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.ExpenseSheetId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(entityLogicalName, entity));
        }
    }
}