
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
    public static class RetrieveSingleRequest
    {
        private static string Id { get; set; }
        private static string UserId { get; set; }
        private static string OrganizationId { get; set; }
        private static string EntityLogicalName { get; set; }
        private static string ResultJson { get; set; }

        [FunctionName("RetrieveSingleRequest")]
        public async static Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("RetrieveSingle HTTP trigger function started processing a request.");

                Id = req.Query["id"];
                EntityLogicalName = req.Query["entitylogicalname"];
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                log.LogInformation(requestBody);
                if (Id == null && EntityLogicalName == null)
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Please Pass id and entitylogicalname on the query string")
                    };
                log.LogInformation(Environment.GetEnvironmentVariable("DataConnectionString"));
                AzureTableStorage azureTableStorage = new AzureTableStorage(Environment.GetEnvironmentVariable("DataConnectionString"));
                //Environment.GetEnvironmentVariable("DataConnectionString"));
                //"DefaultEndpointsProtocol=https;AccountName=monkeycrm;AccountKey=FSpn7CPjKKMOEdFggeBpfXZd71ZfeQpKSopP8DLZsIo5np3Y3oUrNN8PC/2bRTwsgFL9Abcy0mtT54ij1305AQ==;EndpointSuffix=core.windows.net");
                var entityType = TableStorageEntityFactory.GetEntityObject(EntityLogicalName);
                ResultJson = entityType.RetrieveSingleRequest(EntityLogicalName, Id, azureTableStorage, requestBody).Result;
                log.LogInformation(ResultJson);
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
