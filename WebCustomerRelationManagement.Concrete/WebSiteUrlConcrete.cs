using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class WebSiteUrlConcrete : IWebSiteURL
    {
        public IQueryable<WebsiteURL> GetWebSiteByContact(Guid contactId, string contactType)
        {
            var _Context = new DatabaseContext();
            var urlDeatil = (from webSiteUrl in _Context.WebsiteURLs
                             where webSiteUrl.CustomerType == contactId &&
                             webSiteUrl.CustomerTypeName == contactType
                             select webSiteUrl);
            return urlDeatil;
        }
    }
}
