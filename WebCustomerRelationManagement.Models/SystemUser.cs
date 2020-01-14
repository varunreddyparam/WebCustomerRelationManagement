using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Models
{
    public class SystemUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public string StateOrProvince { get; set; }
        public Guid Createdby { get; set; }
        public string Createdbyname { get; set; }
        public DateTime Createdon { get; set; }
        public Guid Createdonbehalfby { get; set; }
        public Guid Createdonbehalfbyname { get; set; }
        public int Modifiedby { get; set; }
        public string Modifiedbyname { get; set; }
        public DateTime Modifiedon { get; set; }
        public Guid Modifiedonbehalfby { get; set; }
        public string Modifiedonbehalfbyname { get; set; }
    }
}
