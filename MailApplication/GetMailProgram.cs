using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;

namespace MailApplication
{
    public class GetMailProgram
    {
        public ConnectGmail gmailConnection = new ConnectGmail();
        public RetrieveMessages retrieveGmailMessages = new RetrieveMessages();

        private string date;
        private string subject;
        private string from;
        private string body;
        private string messageid;
        private string userid = "me";
        private string historyid;
        private string threadid;

        public List<MailMessage> GetListMessages(string clientId, string clientSecret, string _query)
        {
            try
            {
                var gmailService = gmailConnection.CreateGmailAPIservice(clientId, clientSecret);
                if (gmailService != null)
                {
                    string query = _query;
                    //"label:jobs after:2019/12/18 before:2019/12/19 is:unread";
                    //
                    var messages = retrieveGmailMessages.GetGmailMessageList(gmailService, this.userid, query);

                    if (messages != null && messages.Count >= 0)
                    {
                        Console.WriteLine("there are {0} emails!", messages.Count);
                        return this.GetEmailMessageData(gmailService, this.userid, messages);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<MailMessage> GetEmailMessageData(Google.Apis.Gmail.v1.GmailService gmailService, string UserId, List<Message> messages)
        {
            List<MailMessage> mailMessagesList = new List<MailMessage>();
            try
            {
                foreach (var message in messages)
                {
                    this.messageid = message.Id;
                    this.historyid = message.HistoryId.ToString();
                    this.threadid = message.ThreadId;
                    var messageInfoResponse = retrieveGmailMessages.GetMessage(gmailService, UserId, message.Id);
                    if (messageInfoResponse != null)
                    {
                        //loop through the headers and get the fields we need...
                        ExtractMessageData(messageInfoResponse);
                    }
                    mailMessagesList.Add(new MailMessage(this.date, this.from, this.subject, this.body, this.messageid, this.historyid, this.threadid));
                    Console.WriteLine("{0}  --  {1} -- {2} -- {3} -- {4}", this.subject, this.date, this.messageid, this.threadid, this.historyid);
                }
                return mailMessagesList;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public void ExtractMessageData(Message messageInfoResponse)
        {
            try
            {

                foreach (var mParts in messageInfoResponse.Payload.Headers)
                {
                    switch (mParts.Name)
                    {
                        case "Date":
                            this.date = mParts.Value;
                            break;
                        case "From":
                            this.from = mParts.Value;
                            break;
                        case "Subject":
                            this.subject = mParts.Value;
                            break;
                        default:
                            break;
                    }

                    if (this.date != "" && this.from != "")
                    {
                        if (messageInfoResponse.Payload.Parts == null && messageInfoResponse.Payload.Body != null)
                            this.body = retrieveGmailMessages.DecodeBase64String(messageInfoResponse.Payload.Body.Data);
                        else
                            this.body = retrieveGmailMessages.GetNestedBodyParts(messageInfoResponse.Payload.Parts, "");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
