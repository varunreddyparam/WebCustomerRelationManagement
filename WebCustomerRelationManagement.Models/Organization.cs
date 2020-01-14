using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Models
{
    public class Organization
    {
        public string OrganizationUrl { get; set; }
        public string OrganizationName { get; set; }
        public Guid Organizationid { get; set; }
        public Guid Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int Modifiedby { get; set; }
        public DateTime Modifiedon { get; set; }
    }
}
