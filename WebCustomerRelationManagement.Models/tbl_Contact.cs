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
    
    public partial class tbl_Contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Contact()
        {
            this.tbl_Account = new HashSet<tbl_Account>();
            this.tbl_Address = new HashSet<tbl_Address>();
            this.tbl_EmailAddress = new HashSet<tbl_EmailAddress>();
            this.tbl_PhoneNumber = new HashSet<tbl_PhoneNumber>();
            this.tbl_WebsiteURL = new HashSet<tbl_WebsiteURL>();
        }
    
        public int slno { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public System.Guid contactid { get; set; }
        public Nullable<int> contacttype { get; set; }
        public string contacttypename { get; set; }
        public string description { get; set; }
        public Nullable<bool> donotbulkemail { get; set; }
        public Nullable<bool> donotemail { get; set; }
        public Nullable<bool> donotbulkpostalmail { get; set; }
        public Nullable<bool> donotfax { get; set; }
        public Nullable<bool> donotphone { get; set; }
        public Nullable<bool> donotpostalmail { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Account> tbl_Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Address> tbl_Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_EmailAddress> tbl_EmailAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PhoneNumber> tbl_PhoneNumber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WebsiteURL> tbl_WebsiteURL { get; set; }
    }
}
