using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Concrete
{
    public class EmailConfigurationConcrete : IEntity
    {
        public Task<string> CreateRequest(string entityLogicalName, string OrganizationId, string UserId, string requestBody, AzureTableStorage azureTableStorage)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            throw new NotImplementedException();
        }

        public Task<string> EmailRetrieveRequest(string entityLogicalName, string userId, string organizationId, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }

        public Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage)
        {
            throw new NotImplementedException();
        }

        public Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            throw new NotImplementedException();
        }

        public Task<string> ValidateRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }
    }
}
