using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public static class AddressConcrete
    {
        private const string key = "Address";
        public async static Task<string> CreateOrUpdate(AddressEntity addressEntity)
        {
            throw new NotImplementedException();
        }

        public async static void Delete(string id, string entityLogicalName)
        {
            if (Get(id,entityLogicalName) == null)
            {
                return;
            }
            await GetTable().ExecuteAsync(TableOperation.Delete(await Get(id,entityLogicalName)));
        }

        public async static Task<AddressEntity> Get(string id, string entitylogicalname)
        {
            //return GetTable().CreateQuery<AddressEntity>().Where(x => x.PartitionKey == key && x.RowKey == id).SingleOrDefault();
            TableOperation tableOperation = TableOperation.Retrieve(key, id);
            TableResult tableResult = await GetTable().ExecuteAsync(tableOperation);
            return tableResult.Result as AddressEntity;
        }

        public async static Task<List<AddressEntity>> GetAll()
        {
            var table = GetTable();
            return table.CreateQuery<AddressEntity>().Where(x => x.PartitionKey == key).ToList();
        }
        private static CloudTable GetTable()
        {
            string accountName = "monkeycrm";
            string accountKey = "FSpn7CPjKKMOEdFggeBpfXZd71ZfeQpKSopP8DLZsIo5np3Y3oUrNN8PC/2bRTwsgFL9Abcy0mtT54ij1305AQ==";
            try
            {
                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                CloudTableClient client = account.CreateCloudTableClient();
                CloudTable table = client.GetTableReference(key);
                return table;
            }
            catch
            {
                return null;
            }
        }
    }
}
