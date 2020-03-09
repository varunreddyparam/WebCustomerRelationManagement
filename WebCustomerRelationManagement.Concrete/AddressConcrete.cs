using Newtonsoft.Json;
using System;
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

        public async Task<string> CreateRequest(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            AddressEntity entity = new AddressEntity(Guid.NewGuid(), entityLogicalName);
            entity = JsonConvert.DeserializeObject<AddressEntity>(requestBody);
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
        }
    }
}
