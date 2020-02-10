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
    
    public partial class tbl_Address
    {
        public int slno { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string addressline3 { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string postalcode { get; set; }
        public string postofficebox { get; set; }
        public string stateorprovince { get; set; }
        public System.Guid addressid { get; set; }
        public Nullable<System.Guid> customertype { get; set; }
        public string customertypename { get; set; }
        public Nullable<bool> isprimary { get; set; }
        public Nullable<int> statecode { get; set; }
        public string statecodename { get; set; }
        public Nullable<int> statuscode { get; set; }
        public string statuscodename { get; set; }
        public System.Guid createdby { get; set; }
        public string createdbyname { get; set; }
        public System.DateTime createdon { get; set; }
        public Nullable<System.Guid> createdonbehalfby { get; set; }
        public string createdonbehalfbyname { get; set; }
        public Nullable<System.Guid> modifiedby { get; set; }
        public string modifiedbyname { get; set; }
        public Nullable<System.DateTime> modifiedon { get; set; }
        public Nullable<System.Guid> modifiedonbehalfby { get; set; }
        public string modifiedonbehalfbyname { get; set; }
        public int ownerid { get; set; }
        public string ownername { get; set; }
        public int departmentid { get; set; }
        public string departmentname { get; set; }
    
        public virtual tbl_Account tbl_Account { get; set; }
        public virtual tbl_Contact tbl_Contact { get; set; }
    }
}