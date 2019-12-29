using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IWebSiteURL
    {
        IQueryable<WebsiteURL> GetWebSiteByContact(Guid contactId, string contactType);
        void CreateWebSiteUrl(WebsiteURL entity);

        void UpdateWebsiteURL(WebsiteURL websiteURL);

        int DeleteWebsiteURL(Guid webSiteUrlId);
    }
}
