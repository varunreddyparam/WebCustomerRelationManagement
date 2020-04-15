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

        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
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
    }
}