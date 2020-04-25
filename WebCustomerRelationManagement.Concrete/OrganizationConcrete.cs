using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class OrganizationConcrete : IEntity
    {
        public OrganizationConcrete()
        {

        }

        public Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            if (requestBody != null)
            {
                object orgObject = JsonConvert.DeserializeObject(requestBody);
                var getOgId = this.getOrganization(orgObject, azureTableStorage, entityLogicalName);
                if (getOgId.Result.Length > 0)
                    return getOgId.Result;
            }
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<OrganizationEntity>(entityLogicalName, entityLogicalName, Id));
        }

        public Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }
        public async Task<string> getOrganization(object orgObject, AzureTableStorage azureTableStorage, string entityLogicalName)
        {
            TableQuery<OrganizationEntity> table = new TableQuery<OrganizationEntity>();
            table.Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, entityLogicalName),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("Organizationname", QueryComparisons.Equal, ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JProperty)((Newtonsoft.Json.Linq.JContainer)orgObject).First).Value).Value.ToString())));
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(entityLogicalName, table));
        }
    }
}