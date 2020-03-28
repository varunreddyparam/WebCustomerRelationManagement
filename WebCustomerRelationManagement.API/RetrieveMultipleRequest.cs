using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Concrete;
using Newtonsoft.Json;

namespace WebCustomerRelationManagement.API
{
    public static class RetrieveMultipleRequest
    {
        private static string EntityLogicalName { get; set; }
        private static string ResultJson { get; set; }

        [FunctionName("RetrieveMultipleRequest")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("RetrieveMultiple HTTP trigger function started processing a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                if (EntityLogicalName == null)
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Please Pass entitylogicalname on the query")
                    };
                var deSerializedObject = JsonConvert.DeserializeObject<QueryDeSerializer>(requestBody);
                EntityLogicalName = deSerializedObject.EntityLogicalName;
                AzureTableStorage azureTableStorage = new AzureTableStorage(Environment.GetEnvironmentVariable("DataConnectionString"));
                //"DefaultEndpointsProtocol=https;AccountName=monkeycrm;AccountKey=FSpn7CPjKKMOEdFggeBpfXZd71ZfeQpKSopP8DLZsIo5np3Y3oUrNN8PC/2bRTwsgFL9Abcy0mtT54ij1305AQ==;EndpointSuffix=core.windows.net");
                //Environment.GetEnvironmentVariable("DataConnectionString"));
                var entityType = TableStorageEntityFactory.GetEntityObject(EntityLogicalName);
                ResultJson = entityType.RetrieveMultipleRequest(deSerializedObject, azureTableStorage).Result;

            }
            catch (Exception ex)
            {
                log.Log(LogLevel.Error, ex.Message, null);
                log.Log(LogLevel.Information, ex.Source, null);
            }
            return ResultJson != null
                    ? new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Content = new StringContent(ResultJson)
                    }
                    : new HttpResponseMessage(System.Net.HttpStatusCode.NoContent)
                    {
                        Content = new StringContent("No Records found with the search")
                    };
        }

    }
}
