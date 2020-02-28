using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IWebSiteURL
    {
        IEnumerable<tbl_WebsiteURL> GetWebSiteByContact(Guid contactId, string contactType, string source, string initialCatalogue);
        void CreateWebSiteUrl(tbl_WebsiteURL entity, string source, string initialCatalogue);

        void UpdateWebsiteURL(tbl_WebsiteURL websiteURL, string source, string initialCatalogue);

        void DeleteWebsiteURL(Guid webSiteUrlId, string source, string initialCatalogue);
    }
}
