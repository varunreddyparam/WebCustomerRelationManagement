//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebCustomerRelationManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_SystemUser
    {
        public int slno { get; set; }
        public System.Guid userid { get; set; }
        public string username { get; set; }
        public string emailaddress { get; set; }
        public string password { get; set; }
        public string passwordkey { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string addressline3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pin { get; set; }
        public string country { get; set; }
        public System.DateTime cretedon { get; set; }
        public Nullable<System.Guid> createdby { get; set; }
        public Nullable<System.Guid> modifiedby { get; set; }
        public Nullable<System.DateTime> modifiedon { get; set; }
    }
}