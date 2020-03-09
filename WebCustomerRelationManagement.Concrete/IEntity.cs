using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Concrete
{
    public interface IEntity
    {
        Task<string> Retrieve(string entityLogicalName, string Id, AzureTableStorage azureTableStorage);
        Task<string> CreateRequest(string entityLogicalName, string requestBody,AzureTableStorage azureTableStorage);
    }
}
