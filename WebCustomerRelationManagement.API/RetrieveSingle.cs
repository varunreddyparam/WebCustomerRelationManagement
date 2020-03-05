
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Concrete;

namespace WebCustomerRelationManagement.API
{
    public static class RetrieveSingle
    {
        [FunctionName("RetrieveSingle")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            //AddressConcrete addressConcrete = new AddressConcrete(Environment.GetEnvironmentVariable("AccountConnectionStrings"));
            string id = req.Query["id"];
            string entityLogicalName = req.Query["entitylogicalname"];
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);


            return await AddressConcrete.Get(id, entityLogicalName) != null
                ? new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(await AddressConcrete.Get(id)))
                }
                : new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Please pass a id on the query string")
                };
        }
    }
}
