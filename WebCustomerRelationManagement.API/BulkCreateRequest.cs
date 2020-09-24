using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Concrete;

namespace WebCustomerRelationManagement.API
{
    public static class BulkCreateRequest
    {
        private static string UserId { get; set; }
        private static string OrganizationId { get; set; }
        private static string EntityLogicalName { get; set; }
        private static string ResultJson { get; set; }

        [FunctionName("BulkCreateRequest")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("CreateRequest HTTP trigger function started processing a request.");

                EntityLogicalName = req.Query["entitylogicalname"];
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                AzureTableStorage azureTableStorage = new AzureTableStorage("DefaultEndpointsProtocol=https;AccountName=monkeycrm;AccountKey=FSpn7CPjKKMOEdFggeBpfXZd71ZfeQpKSopP8DLZsIo5np3Y3oUrNN8PC/2bRTwsgFL9Abcy0mtT54ij1305AQ==;EndpointSuffix=core.windows.net");
                //Environment.GetEnvironmentVariable("DataConnectionString"));
                //"DefaultEndpointsProtocol=https;AccountName=monkeycrm;AccountKey=FSpn7CPjKKMOEdFggeBpfXZd71ZfeQpKSopP8DLZsIo5np3Y3oUrNN8PC/2bRTwsgFL9Abcy0mtT54ij1305AQ==;EndpointSuffix=core.windows.net");
                //{"FirstName":"Varun Reddy","LastName":"Param","UserName":"VarunReddyParam@CrmOrg.MonkeyCrm.com","Password":"VarunParam@123","Email":"Varunreddyparam@gmail.com","Phone":"7325248221","AddressLine1":"3322 BlueMont Park","AddressLine2":"","AddressLine3":"","Country":"United States","City":"Hilliard","State":"Ohio","Zip":"43026"}
                if (requestBody == null && string.IsNullOrEmpty(EntityLogicalName))
                    return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent)
                    {
                        Content = new StringContent("This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.")
                    };
                var entityType = TableStorageEntityFactory.GetEntityObject(EntityLogicalName);
                ResultJson = entityType.CreateRequest(EntityLogicalName, requestBody, azureTableStorage).Result;
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
                        Content = new StringContent("Record Not Inserted")
                    };
        }
    }
}
