using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using WebCustomerRelationManagement.Concrete;

namespace WebCustomerRelationManagement.API
{
    public static class DeleteRequest
    {
        private static string Id { get; set; }
        private static string EntityLogicalName { get; set; }
        private static string ResultJson { get; set; }

        [FunctionName("DeleteRequest")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("RetrieveSingle HTTP trigger function started processing a request.");

                Id = req.Query["id"];
                EntityLogicalName = req.Query["entitylogicalname"];
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                if (Id == null && EntityLogicalName == null)
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Please Pass id and entitylogicalname on the query string")
                    };

                AzureTableStorage azureTableStorage = new AzureTableStorage(Environment.GetEnvironmentVariable("DataConnectionString"));
                //"DefaultEndpointsProtocol=https;AccountName=monkeycrm;AccountKey=FSpn7CPjKKMOEdFggeBpfXZd71ZfeQpKSopP8DLZsIo5np3Y3oUrNN8PC/2bRTwsgFL9Abcy0mtT54ij1305AQ==;EndpointSuffix=core.windows.net");
                //Environment.GetEnvironmentVariable("DataConnectionString"));
                var entityType = TableStorageEntityFactory.GetEntityObject(EntityLogicalName);
                ResultJson = entityType.DeleteRequest(EntityLogicalName, Id, azureTableStorage).Result;
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
