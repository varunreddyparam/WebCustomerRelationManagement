using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCustomerRelationManagement.Models
{
    [Table("tbl_WebsiteURL")]
    public class WebsiteURL
    {
        public string Name { get; set; }
        public string WebSiteUrl { get; set; }
        public Guid WebsiteUrlId { get; set; }
        public int WebsiteTypeCode { get; set; }
        public string WebsiteTypeName { get; set; }
        public bool IsPrimary { get; set; }
        public Guid CustomerType { get; set; }
        public string CustomerTypeName { get; set; }
        public int statecode { get; set; }
        public string statecodename { get; set; }
        public int statuscode { get; set; }
        public string statuscodename { get; set; }
        public Guid createdby { get; set; }
        public string createdbyname { get; set; }
        public DateTime createdon { get; set; }
        public Guid createdonbehalfby { get; set; }
        public Guid createdonbehalfbyname { get; set; }
        public int modifiedby { get; set; }
        public string modifiedbyname { get; set; }
        public DateTime modifiedon { get; set; }
        public Guid modifiedonbehalfby { get; set; }
        public string modifiedonbehalfbyname { get; set; }
    }
}
