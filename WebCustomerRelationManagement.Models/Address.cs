using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Models
{
    [Table("tbl_Address")]
    public class Address
    {
        public string Address1_AddressId { get; set; }
        public string Address1_City { get; set; }
        public string Address1_Country { get; set; }
        public string Address1_County { get; set; }
        public string Address1_FreightTermsCode { get; set; }
        public string Address1_FreightTermsCodeName { get; set; }
        public string Address1_Latitude { get; set; }
        public string Address1_Line1 { get; set; }
        public string Address1_Line2 { get; set; }
        public string Address1_Line3 { get; set; }
        public string Address1_Longitude { get; set; }
        public string Address1_Name { get; set; }
        public string Address1_PostalCode { get; set; }
        public string Address1_PostOfficeBox { get; set; }
        public string Address1_StateOrProvince { get; set; }
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
