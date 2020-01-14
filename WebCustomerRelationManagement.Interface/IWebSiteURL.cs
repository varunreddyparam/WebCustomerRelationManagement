using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IWebSiteURL
    {
        IQueryable<tbl_WebsiteURL> GetWebSiteByContact(Guid contactId, string contactType);
        void CreateWebSiteUrl(tbl_WebsiteURL entity);

        void UpdateWebsiteURL(tbl_WebsiteURL websiteURL);

        int DeleteWebsiteURL(Guid webSiteUrlId);
    }
}
