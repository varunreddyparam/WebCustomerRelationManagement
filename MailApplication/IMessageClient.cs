using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MailApplication
{
    public interface IMessages
    {
        List<Message> GetGmailMessageList(GmailService service, String userId, String query);
        Message GetMessage(GmailService service, String userId, String messageId);
        String DecodeBase64String(string s);
        String GetNestedBodyParts(IList<MessagePart> part, string curr);
    }
}
