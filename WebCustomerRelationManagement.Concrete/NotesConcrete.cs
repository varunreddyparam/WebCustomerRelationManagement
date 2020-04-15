using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class NotesConcrete : IEntity
    {
        public async Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            NotesEntity entity = new NotesEntity();
            entity = JsonConvert.DeserializeObject<NotesEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.UserId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
        }

        public async Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            NotesEntity entity = new NotesEntity();
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            return JsonConvert.SerializeObject(await azureTableStorage.DeleteAsync(entityLogicalName, entity));
        }

        public async Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage)
        {
            TableQuery<NotesEntity> table = new TableQuery<NotesEntity>();
            table.SelectColumns = queryExpression.Attributes;
            table.Where(queryExpression.FilterCondition);
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(queryExpression.EntityLogicalName, table));
        }

        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<NotesEntity>(entityLogicalName, entityLogicalName, Id));
        }

        public async Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            NotesEntity entity = new NotesEntity();
            entity = JsonConvert.DeserializeObject<NotesEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.UserId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.UpdateAsync(entityLogicalName, entity));
        }

        public async Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            NotesEntity entity = new NotesEntity();
            entity = JsonConvert.DeserializeObject<NotesEntity>(requestBody);
            entity.PartitionKey = entityLogicalName;
            entity.RowKey = Id;
            entity.UserId = Guid.Parse(entity.RowKey);
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(entityLogicalName, entity));
        }
    }
}