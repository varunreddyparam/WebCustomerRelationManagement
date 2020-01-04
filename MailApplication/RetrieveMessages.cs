using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailApplication
{
    public class RetrieveMessages : IMessages
    {

        /// <summary>
        /// Get all the list of EmailMessages
        /// </summary>
        /// <param name="service"></param>
        /// <param name="userId"></param>
        /// <param name="query"></param>
        /// <returns>list of Messages</returns>
        public List<Message> GetGmailMessageList(GmailService service, String userId, String query)
        {
            List<Message> result = new List<Message>();
            try
            {
                UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
                request.Q = query;
                do
                {
                    try
                    {
                        ListMessagesResponse response = request.Execute();
                        result.AddRange(response.Messages);
                        request.PageToken = response.NextPageToken;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                    }
                } while (!String.IsNullOrEmpty(request.PageToken));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Get Message Information
        /// </summary>
        /// <param name="service"></param>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <returns>Message</returns>
        public Message GetMessage(GmailService service, String userId, String messageId)
        {
            try
            {
                return service.Users.Messages.Get(userId, messageId).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public String DecodeBase64String(string s)
        {
            var ts = s.Replace("-", "+");
            ts = ts.Replace("_", "/");
            var bc = Convert.FromBase64String(ts);
            var tts = Encoding.UTF8.GetString(bc);

            return tts;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="part"></param>
        /// <param name="curr"></param>
        /// <returns></returns>
        public String GetNestedBodyParts(IList<MessagePart> part, string curr)
        {
            string str = curr;
            if (part == null)
            {
                return str;
            }
            else
            {
                foreach (var parts in part)
                {
                    if (parts.Parts == null)
                    {
                        if (parts.Body != null && parts.Body.Data != null)
                        {
                            var ts = DecodeBase64String(parts.Body.Data);
                            str += ts;
                        }
                    }
                    else
                    {
                        return GetNestedBodyParts(parts.Parts, str);
                    }
                }

                return str;
            }
        }
    }
}
