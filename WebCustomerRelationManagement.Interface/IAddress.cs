using System.Collections.Generic;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IAddress
    {
        List<AddressEntity> GetAll();
        AddressEntity Get(string id);
        void Delete(string id);
        string CreateOrUpdate(AddressEntity addressEntity);

    }
}
