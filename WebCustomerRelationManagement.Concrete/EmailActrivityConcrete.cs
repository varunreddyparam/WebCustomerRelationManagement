using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class EmailActrivityConcrete : IEntity
    {
        public async Task<string> CreateRequest(string entityLogicalName, string OrganizationId, string UserId, string requestBody, AzureTableStorage azureTableStorage)
        {
            EmailActivityEntity entity = new EmailActivityEntity();
            ContactConcrete contactConcrete = new ContactConcrete();
            var mailMessage = JsonConvert.DeserializeObject<List<MailMessage>>(requestBody);
            foreach (var message in mailMessage)
            {
                var getMsg = await this.CheckIfMsgExist(entityLogicalName, entity.MessageId, azureTableStorage);
                if (getMsg.Length == 0)
                {
                    entity.PartitionKey = entityLogicalName;
                    entity.RowKey = Guid.NewGuid().ToString();
                    entity.EmailActivityId = Guid.Parse(entity.RowKey);
                    entity.EmailDate = Convert.ToDateTime(message.Date);
                    entity.EmailFrom = message.From;
                    entity.EmailSubject = message.Subject;
                    entity.HistoryId = message.HistoryId;
                    entity.MessageId = message.MessageId;
                    entity.ThreadId = message.ThreadId;

                    string[] contactName = message.From.Split('@');
                    string[] accountName = contactName[1].Split('.');
                    var Organization = new OrganizationConcrete().RetrieveSingleRequest("Organization", OrganizationId, azureTableStorage, null);
                    var User = new UserConcrete().RetrieveSingleRequest("User", UserId, azureTableStorage, null);
                    var contact = contactConcrete.InsertOrUpdateContact("contact", contactName[0],azureTableStorage,,,Organization)
                    entity.ContentUrl = this.CreateBlobStorage(contactName[0], entity.EmailSubject, message.Body);
                   
                    entity.contactName = contactName[0];
                    entity.contactid = Guid.NewGuid();
                    entity.AccountName = accountName[0];
                    entity.Accountid = Guid.NewGuid();
                    //Impleemnt if account exist
                    entity.CreatedBy = Guid.Parse("");
                    entity.CreatedByName = "";
                    entity.CreatedOn = DateTime.Now;
                    entity.ModifiedBy = Guid.Parse("");
                    entity.ModifiedByName = "";
                    entity.ModifiedOn = DateTime.Now;
                    await azureTableStorage.AddAsync(entityLogicalName, entity);
                }

            }
            return "Moved All to DB";
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

        public async Task<string> CheckIfMsgExist(string entityLogicalName, string MessageId, AzureTableStorage azureTableStorage)
        {
            TableQuery<EmailActivityEntity> table = new TableQuery<EmailActivityEntity>();
            table.Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, entityLogicalName),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("MessageId", QueryComparisons.Equal, MessageId)));
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(entityLogicalName, table));
        }

        public string CreateBlobStorage(string contactName, string subject, string body)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=monkeycrm;AccountKey=FSpn7CPjKKMOEdFggeBpfXZd71ZfeQpKSopP8DLZsIo5np3Y3oUrNN8PC/2bRTwsgFL9Abcy0mtT54ij1305AQ==;EndpointSuffix=core.windows.net";
            var blob = new BlobStorage("monkeycrm", connectionString, true);
            var drReference = blob.GetDirectoryReference(contactName + "\\" + subject);
            return blob.CreateBlockBlob(drReference, subject + ".html", "text/html", body);
        }
    }
}
