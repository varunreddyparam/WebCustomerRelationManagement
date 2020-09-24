using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace MailApplication
{
    public class ConnectGmail
    {
        //20384649056-mpk34nr4leo4c3s5nivp69li9jakdg4j.apps.googleusercontent.com
        //4dvi7FGSY_Ovt-E40WZHYidE
        private string[] Scopes = { Google.Apis.Gmail.v1.GmailService.Scope.MailGoogleCom };
        private string ApplicationName = "Gmail API CRM";
        /// <summary>
        /// getUserCredentials for Firstime
        /// </summary>
        /// <returns>UserCredential</returns>
        public UserCredential userCredential(string _clientId, string _clientSecret)
        {
            UserCredential credential;

            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = _clientId,
                    ClientSecret = _clientSecret
                },
                Scopes,
                               "me",
                               CancellationToken.None,
                               new FileDataStore("Analytics.Auth.Store")).Result;

            return credential;
        }

        /// <summary>
        /// Return Gmail Service
        /// </summary>
        /// <returns>GmailService</returns>
        public Google.Apis.Gmail.v1.GmailService CreateGmailAPIservice(string clientId, string clientSecret)
        {
            return new Google.Apis.Gmail.v1.GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = userCredential(clientId, clientSecret),
                ApplicationName = ApplicationName,
            });
        }

    }
}
