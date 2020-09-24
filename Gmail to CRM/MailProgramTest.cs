using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MailApplication;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace GmailtoCRM
{
    public class MailProgramTest
    {
        public void MailProgram()
        {
            var listMessage = new GetMailProgram().GetListMessages("20384649056-mpk34nr4leo4c3s5nivp69li9jakdg4j.apps.googleusercontent.com", "4dvi7FGSY_Ovt-E40WZHYidE", "label:jobs after:1600848360 before:1600895160");
            //"label:Jobs");
            SendtoContacts(listMessage);
        }

        public async void SendtoContacts(List<MailMessage> mailMessages)
        {
            var apiURL = "http://localhost:7071/api/BulkCreateRequest?entitylogicalname=EmailActivity";
            //"https://webcustomerrelationmanagementapi.azurewebsites.net/api/BulkCreateRequest?entitylogicalname=EmailActivity";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiURL);
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(apiURL));
            request.Content = new StringContent(JsonConvert.SerializeObject(mailMessages));
            await client.PostAsync(new Uri(apiURL), request.Content).ContinueWith(responseTask =>
             {
                 Console.WriteLine("Response: {0}", responseTask.Result);
             });
        }
    }
}
