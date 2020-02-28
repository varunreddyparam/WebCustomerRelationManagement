using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AddressConcrete : IAddress
    {
        private static string ConnectionStringConfig = "StorageConnectionString";
        private const string key = "Address";
        public string CreateOrUpdate(AddressEntity addressEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            if (Get(id) == null)
            {
                return;
            }
            GetTable().Execute(TableOperation.Delete(Get(id)));
        }

        public AddressEntity Get(string id)
        {
            return GetTable().CreateQuery<AddressEntity>().Where(x => x.PartitionKey == key && x.RowKey == id).SingleOrDefault();
        }

        public List<AddressEntity> GetAll()
        {
            var table = GetTable();
            return table.CreateQuery<AddressEntity>().Where(x => x.PartitionKey == key).ToList();
        }
        private static CloudTable GetTable()
        {
            // retrieve the storage account details by passing in our 
            // ConnectionStringConfig constant value
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting(ConnectionStringConfig));

            var client = storageAccount.CreateCloudTableClient();
            // creates a CloudTable instance pointing to the table for the name
            // defined in the PK constant.
            return client.GetTableReference(key);
        }
    }
}
