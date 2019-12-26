using System.Data.Entity;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() :  base("name=MonkeyCRM")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<WebsiteURL> WebsiteURLs { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
