using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Concrete
{
    public interface IEntity
    {
        Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage);
        Task<string> CreateRequest(string entityLogicalName, string requestBody,AzureTableStorage azureTableStorage);
        Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody,AzureTableStorage azureTableStorage);
        Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage);
    }
}
