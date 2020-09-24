using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Models
{
    public class MailMessage
    {
        private string date;
        private string subject;
        private string from;
        private string body;
        private string messageid;
        private string historyid;
        private string threadid;

        public MailMessage(string date, string from, string subject, string body, string messageid, string historyid, string threadid)
        {
            this.date = date;
            this.from = from;
            this.subject = subject;
            this.body = body;
            this.messageid = messageid;
            this.threadid = threadid;
            this.historyid = historyid;
        }

        public string From
        {
            get { return from; }
            set { from = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string MessageId
        {
            get { return messageid; }
            set { messageid = value; }
        }
        public string HistoryId
        {
            get { return historyid; }
            set { historyid = value; }
        }
        public string ThreadId
        {
            get { return threadid; }
            set { threadid = value; }
        }
    }
}
