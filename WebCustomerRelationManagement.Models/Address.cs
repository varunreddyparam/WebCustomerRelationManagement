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
        public Guid AddressId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Latitude { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Longitude { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string PostOfficeBox { get; set; }
        public string StateOrProvince { get; set; }
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
