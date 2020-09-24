using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebCustomerRelationManagement.Concrete;
using System.Net.Http;

namespace WebCustomerRelationManagement.API
{
    public static class UpdateRequest
    {
        private static string EntityLogicalName { get; set; }
        private static string ResultJson { get; set; }
        private static string Id { get; set; }
        [FunctionName("UpdateRequest")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("CreateRequest HTTP trigger function started processing a request.");

                EntityLogicalName = req.Query["entitylogicalname"];
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                AzureTableStorage azureTableStorage = new AzureTableStorage(Environment.GetEnvironmentVariable("DataConnectionString"));
                //Environment.GetEnvironmentVariable("DataConnectionString"));
                //"DefaultEndpointsProtocol=https;AccountName=monkeycrm;AccountKey=FSpn7CPjKKMOEdFggeBpfXZd71ZfeQpKSopP8DLZsIo5np3Y3oUrNN8PC/2bRTwsgFL9Abcy0mtT54ij1305AQ==;EndpointSuffix=core.windows.net");

                if (requestBody == null && string.IsNullOrEmpty(EntityLogicalName) && string.IsNullOrEmpty(Id))
                    return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent)
                    {
                        Content = new StringContent("This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.")
                    };
                var entityType = TableStorageEntityFactory.GetEntityObject(EntityLogicalName);
                ResultJson = entityType.UpdateRequest(EntityLogicalName, Id, requestBody, azureTableStorage).Result;
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
                        Content = new StringContent("Record Not Updated")
                    };
        }
    }
}
