using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Concrete
{
    public interface IEntity
    {
        Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody);
        Task<string> CreateRequest(string entityLogicalName, string OrganizationId, string UserId, string requestBody, AzureTableStorage azureTableStorage);
        Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage);
        Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage);
        //Task<string> BulkCreateRequest();
        Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage);
        Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage);
        Task<string> ValidateRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody);
        Task<string> EmailRetrieveRequest(string entityLogicalName, string userId, string organizationId, AzureTableStorage azureTableStorage, string requestBody);

    }
}
