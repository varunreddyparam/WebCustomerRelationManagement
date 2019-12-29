using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class WebSiteUrlConcrete : IWebSiteURL
    {
        public void CreateWebSiteUrl(WebsiteURL entity)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.WebsiteURLs.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public int DeleteWebsiteURL(Guid webSiteUrlId)
        {
            try
            {
                var context = new DatabaseContext();
                var webSiteUrl = (from webSiteUrlentity in context.WebsiteURLs
                                    where webSiteUrlentity.WebsiteUrlId == webSiteUrlId
                                    select webSiteUrlentity).SingleOrDefault();
                if (webSiteUrl != null)
                {
                    context.WebsiteURLs.Remove(webSiteUrl);
                    int resultWebSiteUrl = context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<WebsiteURL> GetWebSiteByContact(Guid contactId, string contactType)
        {
            var _Context = new DatabaseContext();
            var urlDeatil = (from webSiteUrl in _Context.WebsiteURLs
                             where webSiteUrl.CustomerType == contactId &&
                             webSiteUrl.CustomerTypeName == contactType
                             select webSiteUrl);
            return urlDeatil;
        }

        public void UpdateWebsiteURL(WebsiteURL websiteURL)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var contactEntity = context.WebsiteURLs.Where(key => key.WebsiteUrlId == websiteURL.WebsiteUrlId).SingleOrDefault();
                    context.Entry(contactEntity).CurrentValues.SetValues(websiteURL);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
