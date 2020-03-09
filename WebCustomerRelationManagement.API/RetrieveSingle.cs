
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Concrete;

namespace WebCustomerRelationManagement.API
{
    public static class RetrieveSingle
    {
        private static string Id { get; set; }
        private static string EntityLogicalName { get; set; }

        private static string ResultJson { get; set; }

        [FunctionName("RetrieveSingle")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req,
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
                ResultJson = entityType.Retrieve(EntityLogicalName, EntityLogicalName, azureTableStorage).Result;
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
