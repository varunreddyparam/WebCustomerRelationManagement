using Newtonsoft.Json;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AddressConcrete : IEntity
    {
        public async Task<string> Retrieve(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<AddressEntity>(entityLogicalName, entityLogicalName, Id));
        }
    }
}
