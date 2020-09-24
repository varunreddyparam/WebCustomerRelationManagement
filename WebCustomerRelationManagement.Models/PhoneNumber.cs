using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCustomerRelationManagement.Models
{
    [Table("tbl_PhoneNumber")]
    public class PhoneNumber
    {
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public Guid PhoneNumberId { get; set; }
        public bool IsPrimary { get; set; }
        public int PhoneNumberType { get; set; }
        public string PhoneNumberTypeName { get; set; }
        public Guid CustomerType { get; set; }
        public string CustomerTypeName { get; set; }
        public int Statecode { get; set; }
        public string Statecodename { get; set; }
        public int Statuscode { get; set; }
        public string Statuscodename { get; set; }
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
