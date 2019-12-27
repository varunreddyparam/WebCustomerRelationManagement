using System;
using System.Linq;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    public interface IWebSiteURL
    {
        IQueryable<WebsiteURL> GetWebSiteByContact(Guid contactId, string contactType);
        void CreateWebSiteUrl(WebsiteURL entity);

        void UpdateWebsiteURL(int webSiteUrlType, Guid webSiteUrlId, string webSiteUrlTypeName, string contactWebSiteUrlName, int stateCode, int statusCode);

        int DeleteWebsiteURL(Guid webSiteUrlId);
    }
}
