
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using WebCustomerRelationManagement.Models;
using WebCustomerRelationManagement.Concrete;

namespace WebCustomerRelationManagement.API
{
    public static class AddressFunction
    {
        [FunctionName("AddressFunction")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string id = req.Query["id"];
            AddressConcrete addressConcrete = new AddressConcrete();
            //string requestBody = new StreamReader(req.Body).ReadToEnd();

            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            id = JsonConvert.SerializeObject(addressConcrete.Get(id);

            return id != null
                ? (ActionResult)new OkObjectResult(id)
                : new BadRequestObjectResult("Please pass a id on the query string");
        }
    }
}
